using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Principal;
using System.Runtime.InteropServices;

namespace Security
{

    public class SecurityContext
    {
        #region "Unmanaged Code"

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(string pszUsername, string pszDomain, string pszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,
            int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_LOGON_INTERACTIVE = 2;
        const int SECURITY_IMPERSONATION = 2;

        #endregion

        public enum SECURITY_IMPERSONATION_LEVEL : int
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3
        }

        private WindowsImpersonationContext _ImpersonationContext;
        public WindowsImpersonationContext ImpersonationContext
        {
            get { return _ImpersonationContext; }
            set { _ImpersonationContext = value; }
        }

        public bool LogonUser(string sUsername, string sDomain, string sPassword)
        {
            string sResult = null;
            const int LOGON32_PROVIDER_DEFAULT = 0;
            const int LOGON32_LOGON_INTERACTIVE = 2;

            IntPtr pExistingTokenHandle = new IntPtr(0);
            IntPtr pDuplicateTokenHandle = new IntPtr(0);
            pExistingTokenHandle = IntPtr.Zero;
            pDuplicateTokenHandle = IntPtr.Zero;

            bool bImpersonated = LogonUser(sUsername, sDomain, sPassword,
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);

            if (false == bImpersonated)
            {
                int nErrorCode = Marshal.GetLastWin32Error();
                sResult = "LogonUser() failed with error code: " + nErrorCode + "\r\n";
                throw new Exception(sResult);
            }
            return bImpersonated;
        }

        public WindowsImpersonationContext ImpersonateUser(
            string sUsername, string sDomain, string sPassword)
        {
            IntPtr pExistingTokenHandle = new IntPtr(0);
            IntPtr pDuplicateTokenHandle = new IntPtr(0);
            pExistingTokenHandle = IntPtr.Zero;
            pDuplicateTokenHandle = IntPtr.Zero;

            if (sDomain == "") sDomain = System.Environment.MachineName;
            try
            {
                string sResult = null;
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_INTERACTIVE = 2;
                bool bImpersonated = LogonUser(sUsername, sDomain, sPassword,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref pExistingTokenHandle);

                if (false == bImpersonated)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    sResult = "LogonUser() failed with error code: " + nErrorCode + "\r\n";
                    throw new Exception(sResult);
                }

                sResult += "Before impersonation: " + WindowsIdentity.GetCurrent().Name + "\r\n";
                bool bRetVal = DuplicateToken(pExistingTokenHandle,
                    (int)SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, ref pDuplicateTokenHandle);

                if (false == bRetVal)
                {
                    int nErrorCode = Marshal.GetLastWin32Error();
                    CloseHandle(pExistingTokenHandle);
                    sResult += "DuplicateToken() failed with error code: " + nErrorCode + "\r\n";
                    throw new Exception(sResult);
                    //return null;
                }
                else
                {
                    WindowsIdentity newId = new WindowsIdentity(pDuplicateTokenHandle);
                    WindowsImpersonationContext impersonatedUser = newId.Impersonate();
                    sResult += "After impersonation: " + WindowsIdentity.GetCurrent().Name + "\r\n";
                    this.ImpersonationContext = impersonatedUser;
                    return impersonatedUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (pExistingTokenHandle != IntPtr.Zero)
                    CloseHandle(pExistingTokenHandle);
                if (pDuplicateTokenHandle != IntPtr.Zero)
                    CloseHandle(pDuplicateTokenHandle);
            }
        }
    }
}
