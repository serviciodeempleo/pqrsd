using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Net.Mail;


using Security;
using LDAPServices;

using netveloper.DataManager;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class Base : System.Web.UI.MasterPage
    {
        SecurityContext sec = new SecurityContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnAcceder_Click(object sender, EventArgs e)
        {
            lblErrorLogin.Text = "";
            string perfil;
            Session["PER_Codigo"] = 0;
            if (false == false)
            {
                SqlParameter[] paramUsuarioClave = new SqlParameter[2];
                paramUsuarioClave[0] = new SqlParameter("@USR_usuario", SqlDbType.VarChar, 20);
                paramUsuarioClave[0].Value = txtUsuario.Text;
                paramUsuarioClave[1] = new SqlParameter("@USR_Clave", SqlDbType.VarChar, 10);
                paramUsuarioClave[1].Value = txtContrasegna.Text;
                MSSQL.Connection("");
                DataSet DSVerificaClave = new DataSet();
                DSVerificaClave = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "VerificaClave", paramUsuarioClave);
                MSSQL.Close();
                if (DSVerificaClave.Tables[0].Rows.Count > 0)
                {
                    //Asigna el codigo del usuario
                    if (DSVerificaClave.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtVerificaClave = DSVerificaClave.Tables[0];
                        DataRow drVerificaClave = dtVerificaClave.Rows[0];
                        if (drVerificaClave["valor"].ToString() != "0")
                        {
                            Session["PER_Codigo"] = System.Convert.ToInt32(drVerificaClave["valor"].ToString());
                            Session["USR_Codigo"] = System.Convert.ToInt32(drVerificaClave["USR_Codigo"].ToString());
                        }
                        else
                        {
                            lblErrorLogin.Text = "Usuario o contraseña no valida";
                        }
                    }
                }
            }
            else
            {
                SqlParameter[] paramUsuario = new SqlParameter[1];
                paramUsuario[0] = new SqlParameter("@USR_usuario", SqlDbType.VarChar, 20);
                paramUsuario[0].Value = txtUsuario.Text;
                if (validaUsuarioDominio() == true)
                {
                    MSSQL.Connection("");
                    DataSet DSVerificaUsuario = new DataSet();
                    DSVerificaUsuario = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "VerificaUsuario", paramUsuario);
                    MSSQL.Close();
                    if (DSVerificaUsuario.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtVerificaUsuario = DSVerificaUsuario.Tables[0];
                        DataRow drVerificaUsuario = dtVerificaUsuario.Rows[0];
                        if (drVerificaUsuario["valor"].ToString() != "0")
                        {
                            Session["PER_Codigo"] = System.Convert.ToInt32(drVerificaUsuario["valor"].ToString());
                            Session["USR_Codigo"] = System.Convert.ToInt32(drVerificaUsuario["USR_Codigo"].ToString());
                        }
                        else
                        {
                            lblErrorLogin.Text = "Usuario o contraseña no valida";
                        }
                    }
                    else
                    {
                        lblErrorLogin.Text = "Usuario o contraseña no valida";
                    }
                }
                else
                {
                    lblErrorLogin.Text = "Usuario o contraseña no valida";
                }
            }
            if (Session["PER_Codigo"].ToString()=="2")
            {
                Response.Redirect("MenuOPE.aspx");
            }
        }

        private bool validaUsuarioDominio()
        {
            try
            {
                String sDomain = LDAPServices.LDAPServices.getDomainName();
                sec.LogonUser(txtUsuario.Text, sDomain, txtContrasegna.Text);
                return (true);
            }
            catch
            {
                return (false);
            }
        }
    }
}
