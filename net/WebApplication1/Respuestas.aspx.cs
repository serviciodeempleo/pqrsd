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
    public partial class Respuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConsultaModelos();
                chkPQRSD.Checked = true;
                rfvPQRSD.Enabled = true;
            }

            if (chkPQRSD.Checked == true)
            {
                rfvPQRSD.Enabled = true;
                txtAsunto.Visible = false;
                Label7.Visible = false;
                txtConsecutivo.Visible = true;
                txtAsunto.Text = "";
            }
            else
            {
                rfvPQRSD.Enabled = false;
                txtAsunto.Visible = true;
                Label7.Visible = true;
                txtConsecutivo.Visible = false;
                txtAsunto.Text = "RTA:" + txtCedula.Text + " / " + txtemail.Text;
            }
        }



        public void ConsultaModelos()
        {
            MSSQL.Connection("");
            DataSet DSModelos = new DataSet();
            DSModelos = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ConsultaModelos");
            MSSQL.Close();
            if (DSModelos.Tables[0].Rows.Count > 0)
            {
                DataTable dtmodelos = DSModelos.Tables[0];
                dplModelos.DataSource = dtmodelos;
                dplModelos.DataTextField = "titulo";
                dplModelos.DataValueField = "codigo";
                dplModelos.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Entro = "NO";
            lblerror.Text = "";
            lblerror.Text = "";
            lblAsunto.Text = "";
            string resultado = "negativo";

            if (chkPQRSD.Checked == false)
            {
                if (txtAsunto.Text == "")
                {
                    lblAsunto.Text = "Por favor copie y pegue el Asunto del correo de soporte.tecnologia";
                    return;
                }
            }

            try
            {

                if (txtCedula.Text != "")
                {
                    Entro = "SI";
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@codigo", SqlDbType.Int);
                    param[0].Value = dplModelos.SelectedValue;
                    param[1] = new SqlParameter("@numero", SqlDbType.VarChar, 50);
                    param[1].Value = txtCedula.Text;
                    param[2] = new SqlParameter("@email", SqlDbType.VarChar, 100);
                    param[2].Value = txtemail.Text;
                    MSSQL.Connection("");
                    DataSet DSResp = new DataSet();
                    DSResp = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ArmarRespuestaNumero", param);
                    MSSQL.Close();
                    if (DSResp.Tables[0].Rows.Count == 1)
                    {
                        DataTable dtresp = DSResp.Tables[0];
                        DataRow drresp = dtresp.Rows[0];
                        if (chkPQRSD.Checked == true)
                        {
                            enviarcorreo("pqrsd@serviciodeempleo.gov.co", "maria.numa@serviciodeempleo.gov.co", drresp["respuesta"].ToString(), "Respuesta PQRSD: " + txtConsecutivo.Text.ToString());
                        }
                        else 
                        {
                            enviarcorreo("soporte.tecnologia@serviciodeempleo.gov.co", "pqrsd@serviciodeempleo.gov.co", drresp["respuesta"].ToString(), txtAsunto.Text);
                        }
                        
                        resultado = drresp["respuesta"].ToString();
                    }
                }

                /*if (txtemail.Text != "")
                {
                    Entro = "SI";
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@codigo", SqlDbType.Int);
                    param[0].Value = dplModelos.SelectedValue;
                    param[1] = new SqlParameter("@email", SqlDbType.VarChar, 50);
                    param[1].Value = txtemail.Text;
                    MSSQL.Connection("");
                    DataSet DSResp = new DataSet();
                    DSResp = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ArmarRespuesta", param);
                    MSSQL.Close();
                    if (DSResp.Tables[0].Rows.Count == 1)
                    {
                        DataTable dtresp = DSResp.Tables[0];
                        DataRow drresp = dtresp.Rows[0];
                        lblrespuesta.Text = drresp["respuesta"].ToString();
                        resultado = lblrespuesta.Text;
                    }
                }*/
                if (Entro == "NO")
                {
                    lblerror.Text = "Se requiere la Cédula para encontrar al Ciudadano.";
                }
                else
                {
                    SqlParameter[] paramRegistro = new SqlParameter[6];
                    paramRegistro[0] = new SqlParameter("@Tema", SqlDbType.Int);
                    paramRegistro[0].Value = dplModelos.SelectedValue;
                    paramRegistro[1] = new SqlParameter("@PQRSD", SqlDbType.VarChar,10);
                    paramRegistro[1].Value = txtConsecutivo.Text;
                    paramRegistro[2] = new SqlParameter("@usuaro", SqlDbType.Int);
                    paramRegistro[2].Value = Session["USR_Codigo"];
                    paramRegistro[3] = new SqlParameter("@email", SqlDbType.VarChar, 100);
                    paramRegistro[3].Value = txtemail.Text;
                    paramRegistro[4] = new SqlParameter("@identificacion", SqlDbType.VarChar, 50);
                    paramRegistro[4].Value = txtCedula.Text;
                    paramRegistro[5] = new SqlParameter("@resultado", SqlDbType.VarChar, 2000);
                    paramRegistro[5].Value = resultado;
                    
                    MSSQL.Connection("");
                    DataSet DSRespReg = new DataSet();
                    DSRespReg = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "RegistroRespuesta", paramRegistro);
                    lblMensajeFinal.Text = "se realizó el proceso de manera satisfactoria";
                    /*Clipboard.SetDataObject(txtrespuesta.Text);*/
                    if (dplModelos.SelectedValue == "1")
                    {
                        SqlParameter[] param = new SqlParameter[3];
                        param[0] = new SqlParameter("@codigo", SqlDbType.Int);
                        param[0].Value = dplModelos.SelectedValue;
                        param[1] = new SqlParameter("@email", SqlDbType.VarChar, 50);
                        param[1].Value = txtemail.Text;
                        param[2] = new SqlParameter("@numerodocumento", SqlDbType.VarChar, 20);
                        param[2].Value = txtCedula.Text;
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
                                enviarcorreo(txtemail.Text, "" ,drresp["respuesta"].ToString(), "RedEmpleo: Información Importante - Cambio de Contraseña");

                            }
                        }
                        else
                        {
                            lblMensajeFinal.Text = "El correo electrónico no esta registrado en la plataforma";
                        }
                    }

                    if (dplModelos.SelectedValue == "2" || dplModelos.SelectedValue == "3")
                    {
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@codigo", SqlDbType.Int);
                        param[0].Value = dplModelos.SelectedValue;
                        param[1] = new SqlParameter("@email", SqlDbType.VarChar, 50);
                        param[1].Value = txtemail.Text;
                        MSSQL.Connection("");
                        DataSet DSResp = new DataSet();
                        DSResp = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "Respuestasecotr", param);
                        MSSQL.Close();
                        if (DSResp.Tables.Count > 0)
                        {
                            if (DSResp.Tables[0].Rows.Count == 1)
                            {
                                DataTable dtresp = DSResp.Tables[0];
                                DataRow drresp = dtresp.Rows[0];
                                enviarcorreo(txtemail.Text, "soporte.tecnologia.gov.co" ,drresp["respuesta"].ToString(), "RedEmpleo: Información Importante");
                            }
                        }
                        else
                        {
                            lblMensajeFinal.Text = "El correo electrónico no esta registrado en la plataforma";
                        }
                    }
                }
                chkPQRSD.Checked = true;
                rfvPQRSD.Enabled = true;
                txtConsecutivo.Text = "";
                txtAsunto.Text = "";
                if (chkPQRSD.Checked == true)
                {
                    rfvPQRSD.Enabled = true;
                    txtAsunto.Visible = false;
                    Label7.Visible = false;
                }
                else
                {
                    rfvPQRSD.Enabled = false;
                    txtAsunto.Visible = true;
                    Label7.Visible = true;
                }
                
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
            }
        }

        public void enviarcorreo(string emaildestino, string concopia, string Mensaje, string asunto)
        {

            String FROM = emaildestino;
            FROM = "soporte.tecnologia@serviciodeempleo.gov.co";
            String TO = emaildestino;
            String COPIA = concopia;

            String SUBJECT = asunto;
            String BODY = Mensaje;

            String SMTP_USERNAME = "soporte.tecnologia@serviciodeempleo.gov.co";  // Replace with your SMTP username. 
            String SMTP_PASSWORD = "redempleo.2014#25septiembre";  // Replace with your SMTP password.

            String HOST = "smtp.gmail.com";

            int PORT = 25;//already tried with all recommended ports

            SmtpClient client = new SmtpClient(HOST, PORT);
            System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = mailAuthentication;

            MailMessage mess = new MailMessage();
            mess.IsBodyHtml = true;
            mess.Body = BODY;
            mess.From = new MailAddress(FROM);
            mess.To.Add(new MailAddress(TO));
            if (COPIA != "")
            {
                mess.CC.Add(new MailAddress(COPIA));
            }
            
            mess.Subject = SUBJECT;



            try
            {
                client.Send(mess);
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
            }
            /*String FROM = emaildestino;
            FROM = "soporte.tecnologia@serviciodeempleo.gov.co";
            String TO = emaildestino;

            String SUBJECT = "RedEmpleo: Información Importante";
            String BODY = Mensaje;

            String SMTP_USERNAME = "AKIAJCDPCCSTORUHZYKQ";  // Replace with your SMTP username. 
            String SMTP_PASSWORD = "AiXVqZgemrdGII7uVsP/96e5/O39TCxdOPXbjizuDrUG";  // Replace with your SMTP password.

            String HOST = "email-smtp.us-west-2.amazonaws.com";

            int PORT = 25;//already tried with all recommended ports

            SmtpClient client = new SmtpClient(HOST, PORT);
            client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
            
            client.EnableSsl = true;

            MailMessage mess = new MailMessage();
            mess.IsBodyHtml = true;
            mess.Body = BODY;
            mess.From = new MailAddress(FROM);
            mess.To.Add(new MailAddress(TO));
            
            

            try
            {
                client.Send(mess);    
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
            }*/
            

        }

        protected void btnEjecutarConsulta0_Click(object sender, EventArgs e)
        {
                                  

            if (txtCedula.Text == "")
            {
                tblResultado.DataSource = "";
                tblResultado.DataBind();
                tblResultado.Dispose();
                lblrespuesta.Text = "Se requiere de la cedula para realizar la consulta";
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
                    if (DSResp.Tables[0].Rows.Count == 1)
                    {
                        DataTable dtResp = new DataTable();
                        dtResp = DSResp.Tables[0];
                        tblResultado.DataSource = dtResp;
                        tblResultado.DataBind();
                        txtemail.Text = DSResp.Tables[0].Rows[0].ItemArray[8].ToString();

                        lblrespuesta.Text = "";
                    }
                    else
                    {
                        tblResultado.DataSource = "";
                        tblResultado.DataBind();
                        tblResultado.Dispose();
                        lblrespuesta.Text = "Se encontró más de un registro con esta información, por favor verifique o envie un correo a soporte.tecnologia@serviciodeempleo.gov.co, indicando esta situación";
                    }
                }
                else
                {
                    tblResultado.DataSource = "";
                    tblResultado.DataBind();
                    tblResultado.Dispose();
                    lblrespuesta.Text = "No se encontró información con el número de identificación ingresado";
                }
            }
            /*else if (txtemail.Text != "")
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
                    lblrespuesta.Text = "No se encontró información con el Email ingresado";
                }
            }*/

        }

        protected void chkPQRSD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPQRSD.Checked == true)
            {
                rfvPQRSD.Enabled = true;
                txtAsunto.Visible = false;
                Label7.Visible = false;
                txtConsecutivo.Visible = true;
                txtAsunto.Text = "";
            }
            else
            {
                rfvPQRSD.Enabled = false;
                txtAsunto.Visible = true;
                Label7.Visible = true;
                txtConsecutivo.Visible = false;
                txtAsunto.Text = "RTA:" + txtCedula.Text + " / " + txtemail.Text;
            }
        }
    }
}
