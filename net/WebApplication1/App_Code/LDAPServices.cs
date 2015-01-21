using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Principal;
using System.DirectoryServices;
using System.Net.NetworkInformation;

namespace LDAPServices
{
    public class LDAPServices
    {
        public enum LDAPFilterType
        {
            UsersAndGroups,
            OnlyUsers,
            OnlyGroups
        }

        public static string
            getLDAPFilterString(LDAPFilterType Type, string Filter)
        {
            string FilterByName = "(samAccountName=*{0}*)";
            string f = string.Empty;
            switch (Type)
            {
                case LDAPFilterType.OnlyUsers:
                    f = "(&(objectCategory=person)(objectClass=user){0})";
                    break;
                case LDAPFilterType.OnlyGroups:
                    f = "(&(objectCategory=Group){0})";
                    break;
                case LDAPFilterType.UsersAndGroups:
                    f = "(|(&(objectCategory=person)(objectClass=user){0})(&(objectCategory=Group){0}))";
                    break;
            }
            if (Filter == string.Empty)
            {
                return string.Format(f, string.Empty);
            }
            else
            {
                return string.Format(f, string.Format(FilterByName, Filter));
            }
        }

        public static string
            getDomainName()
        {
            return IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }

        public static string
            getLDAPDomainName(string domainName)
        {
            StringBuilder sb = new StringBuilder();
            string[] dcItems = domainName.Split(".".ToCharArray());
            sb.Append("LDAP://");
            foreach (string item in dcItems)
            {
                sb.AppendFormat("DC={0},", item);
            }
            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }

        public static List<string>
            getUserLDAPProperties(string LDAPURL)
        {
            List<string> properties = new List<string>();
            DirectoryEntry entries = new DirectoryEntry(LDAPURL);
            DirectorySearcher searcher = new DirectorySearcher(
                entries, "(&(objectCategory=person)(objectClass=user))");
            try
            {
                foreach (SearchResult result in searcher.FindAll())
                {
                    foreach (string property in
                        result.GetDirectoryEntry().Properties.PropertyNames)
                    {
                        properties.Add(property);
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return properties;
        }

        public static string
            getNTAccountName(string wksid)
        {
            SecurityIdentifier sid = new SecurityIdentifier(wksid);
            NTAccount account = (NTAccount)sid.Translate(typeof(NTAccount));
            return account.Value;
        }

        public static string
            sIDtoString(byte[] sidBinary)
        {
            SecurityIdentifier sid = new SecurityIdentifier(sidBinary, 0);
            return sid.ToString();
        }

        public static Dictionary<string, IdentityReference>
            getADUserMemberOf(IntPtr logonToken)
        {
            Dictionary<string, IdentityReference> groups =
                new Dictionary<string, IdentityReference>();
            WindowsIdentity user = new WindowsIdentity(logonToken);
            IdentityReferenceCollection irc = user.Groups;
            foreach (IdentityReference ir in irc)
            {
                groups.Add(getNTAccountName(ir.Value), ir);
            }
            return groups;
        }

        public static string
            getUserProperties(IntPtr logonToken)
        {
            WindowsIdentity user = new WindowsIdentity(logonToken);
            string propertyDescription = string.Format("The Windows identity named {0}: ", user.Name);

            if (!user.IsAnonymous)
                propertyDescription += ", is not an Anonymous account";
            if (user.IsAuthenticated)
                propertyDescription += ", is authenticated";
            if (user.IsSystem)
                propertyDescription += ", is a System account";
            if (user.IsGuest)
                propertyDescription += ", is a Guest account";

            string authenticationType = user.AuthenticationType;

            if ((authenticationType != null))
            {
                propertyDescription += ", and uses " + authenticationType;
                propertyDescription += " authentication type.";
            }

            propertyDescription += Environment.NewLine;
            propertyDescription += "The SID for the owner is : " + user.Owner.ToString();
            propertyDescription += Environment.NewLine;
            propertyDescription += "Display the SIDs and names for the groups the current user belongs to:";
            propertyDescription += Environment.NewLine;
            IdentityReferenceCollection irc;
            irc = user.Groups;
            foreach (IdentityReference ir in irc)
            {
                propertyDescription += string.Format("Group {0}, SID: {1}{2}",
                    getNTAccountName(ir.Value), ir.Value, Environment.NewLine);
            }
            TokenImpersonationLevel token;
            token = user.ImpersonationLevel;
            propertyDescription += "The impersonation level for the current user is : " + token.ToString();
            return propertyDescription;
        }

        public static List<string>
            getItemsInLDAP(string LDAPURL, LDAPFilterType type, string criteria)
        {
            List<string> items = new List<string>();
            DirectoryEntry entries = new DirectoryEntry(LDAPURL);
            string filter = getLDAPFilterString(type, criteria);
            DirectorySearcher searcher = new DirectorySearcher(
                entries, filter);
            try
            {
                foreach (SearchResult result in searcher.FindAll())
                {
                    items.Add((string)result.Properties["samAccountName"][0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return items;
        }

    }
}
