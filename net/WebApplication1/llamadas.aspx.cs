using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;


using System.Text;
using System.Net.Mail;
using System.Net;

using netveloper.DataManager;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class llamadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == "" && txtemail.Text == "")
            {
                lblerror.Text = "Se requiere del Email o de la cedula para realizar la consulta";
            }

            if (txtCedula.Text != "")
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Cedula", SqlDbType.VarChar, 50);
                param[0].Value = txtCedula.Text;
                MSSQL.Connection("");
                DataSet DSResp = new DataSet();
                DSResp = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ConsultaporDocumento", param);
                MSSQL.Close();
                if (DSResp.Tables[0].Rows.Count >= 1)
                {
                    DataTable dtResp = new DataTable();
                    dtResp = DSResp.Tables[0];
                    tblResultado.DataSource = dtResp;
                    tblResultado.DataBind();
                }
                else
                {
                    lblMensajeFinal.Text = "No se encontró información con el número de identificación ingresado";
                }
            }

            if (txtemail.Text != "")
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                param[0].Value = txtemail.Text;
                MSSQL.Connection("");
                DataSet DSResp = new DataSet();
                DSResp = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ConsultaporEmail", param);
                MSSQL.Close();
                if (DSResp.Tables[0].Rows.Count >= 1)
                {
                    DataTable dtResp = new DataTable();
                    dtResp = DSResp.Tables[0];
                    tblResultado.DataSource = dtResp;
                    tblResultado.DataBind();
                }
                else
                {
                    lblMensajeFinal.Text = "No se encontró información con el Email ingresado";
                }
            }

        }

        protected void btnReiniciarContrasegna_Click(object sender, EventArgs e)
        {
            if (txtemail.Text != "")
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@codigo", SqlDbType.Int);
                param[0].Value = 1;
                param[1] = new SqlParameter("@email", SqlDbType.VarChar, 50);
                param[1].Value = txtemail.Text;
                MSSQL.Connection("");
                DataSet DSResp = new DataSet();
                DSResp = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "Respuestasec", param);
                MSSQL.Close();
                if (DSResp.Tables.Count > 0)
                {
                    if (DSResp.Tables[0].Rows.Count == 1)
                    {
                        DataTable dtresp = DSResp.Tables[0];
                        DataRow drresp = dtresp.Rows[0];
                        enviarcorreo(txtemail.Text, drresp["respuesta"].ToString());

                    }
                }
                else
                {
                    lblMensajeFinal.Text = "El número de identificación no esta registrado";
                }
            }
            else 
            {
                lblMensajeFinal.Text = "Por favor diligencie el correo a donde será enviado el correo.";
            }
        }


        public void enviarcorreo(string emaildestino, string Mensaje)
        {

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(emaildestino);
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = "RedEmpleo: Información Importante";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = Mensaje;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML
            //Adjuntar un archivo
            Attachment archivo = new Attachment(@"D:\PQRs\recomendaciones.pdf");

            mmsg.Attachments.Add(archivo);
            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress("soporteredempleo@mintrabajo.gov.co");

            /*-------------------------CLIENTE DE CORREO----------------------*/
            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new System.Net.NetworkCredential("soporteredempleo", "C45o7r+E");
            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            cliente.Port = 25;
            /*cliente.EnableSsl = true;
            */
            cliente.Host = "10.158.86.166"; //Para Gmail "smtp.gmail.com";
            /*-------------------------ENVIO DE CORREO----------------------*/
            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                lblerror.Text = ex.Message;
            }
        }
    }
}
