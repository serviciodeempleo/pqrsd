using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;   // Usada para SqlConnection
using System.Data.SqlClient;  // Usada para SqlConnection
using System.Windows.Forms;  // Para poder usar esta línea, Se agrega la referencia System.Windows.Forms en Agregar, Referencia

// Aquí están otras usadas por Jairo
using netveloper.DataManager;


using System.Collections;
using System.Configuration;

using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net.Mail;
using System.Net;


// -------------------------------------






namespace WebApplication1
{
    public partial class Cambio_Fech_Vacantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txt_ID_PQRSD.Enabled = false;  // Por ahora, se deja deshabilitado porque no está dejando realizar el proceso que hay en el botón TRAER DATOS
            txt_Nombre_Centro.Enabled = false;
            txt_Nombre_Sede_Centro.Enabled = false;
            //txt_ID_Sede_Centro.Enabled = false;
            txt_Nombre_Empresa.Enabled = false;
            txt_Nombre_Sede_Empresa.Enabled = false;
            txt_Texto_Anuncio.Enabled = false;
            dt_Fecha_Ingreso.Enabled = false;
            // Se quita el siguiente método
            //Consulta_Modelos_Empresa();
        }


        /* Se quita esta función, ya que no se requiere  el DropDownList llamado List_Solicitud. Este permitía seleccionar lo que quería realizar el usuario: cambio de contraseña, actualización de datos, etc. 
         
        public void Consulta_Modelos_Empresa()
        {

            MSSQL.Connection("");
            DataSet DSModelos = new DataSet();

            //ConsultaModelos_Empleador es un procedimiento almacenado creado en la base de datos respuestapqr
            DSModelos = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "Consulta_Modelos_Empleador");
            MSSQL.Close();
            if (DSModelos.Tables[0].Rows.Count > 0)
            {
                DataTable dtmodelos = DSModelos.Tables[0];
                List_Solicitud.DataSource = dtmodelos;
                List_Solicitud.DataTextField = "Titulo";
                List_Solicitud.DataValueField = "codigo";
                List_Solicitud.DataBind();
            }

            
        }
         

        */


        public void enviardatoscorreo(string emaildestino, string concopia, string Mensaje, string asunto)
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



        }


        protected void btn_Traer_Datos_Vacante_Click(object sender, EventArgs e)
        {

            //string cadena_Plavoro = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=Plavmiequipo;Integrated Security=True"; 

            /*Código que se está trabajando para hacer la búsqueda con procedimients almacenados
            
            SqlParameter[] AR_VACANTE = new SqlParameter[1];  //Va a tener un sólo parámetro; por eso, en el arreglo se coloca 1.
            AR_VACANTE[0] = new SqlParameter("@ID_RICHIESTA", SqlDbType.Int);  // Se define el parámetro ID_RICHIESTA. Este parámetro toma lo que hay en txt_Codigo_Vacante
            AR_VACANTE[0].Value = txt_Codigo_Vacante.Text;
            MSSQL.Connection("");
            DataSet DSVacante = new DataSet();
             * 
             * //El Dataset DSVacante es llenado con el resultado de ejecutar el procedimiento almacenado Traer_Datos_Vacantes
            DSVacante = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "Traer_Datos_Vacantes", AR_VACANTE);
            MSSQL.Close();  
            if (DSVacante.Tables[0].Rows.Count == 1) //Debe encontrarse un sólo registro, ya que debe hacer un sólo registro con ese código de Vacante. 
            {
                MessageBox.Show("Bien");
            }
            else
            {
                MessageBox.Show("Algo pasó");
            }


            */


            string cadena_Plavoro = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=Plavmiequipo;Integrated Security=True";

            //string cadena_Plavoro = "Data Source=10.200.10.66;Initial Catalog=Plavoro;User ID=USRPQRS;Password=-+USRPQRS*;Integrated Security=True";

            SqlConnection conex_Plavoro2 = new SqlConnection(cadena_Plavoro);
            string traer_fechas = "Select DT_INGRESO, DT_FINPUBLICACION, DT_INCORPORACION, TEXTOANUNCIO, ID_SEDE from RICHIESTA_SEDE where ID_RICHIESTA = '" + txt_Codigo_Vacante.Text + "' ";

            SqlCommand caden_conex = new SqlCommand(traer_fechas, conex_Plavoro2);
            conex_Plavoro2.Open();
            SqlDataReader leerconsulta = caden_conex.ExecuteReader();
            if (leerconsulta.Read() == true)
            {
                dt_Fecha_Fin_Publicacion.Text = leerconsulta["DT_FINPUBLICACION"].ToString();
                dt_Fecha_Incorporacion.Text = leerconsulta["DT_INCORPORACION"].ToString();
                dt_Fecha_Ingreso.Text = leerconsulta["DT_INGRESO"].ToString();
                //txt_ID_Sede_Centro.Text = leerconsulta["ID_SEDE"].ToString();
                txt_Texto_Anuncio.Text = leerconsulta["TEXTOANUNCIO"].ToString();



            }
            else
            {
                MessageBox.Show("No se encontró la vacante");
                dt_Fecha_Ingreso.Text = "";
                dt_Fecha_Fin_Publicacion.Text = "";
                dt_Fecha_Incorporacion.Text = "";

            }

            conex_Plavoro2.Close();

        }

        protected void btn_Actualizar_Fechas_Click(object sender, EventArgs e)
        {
            if (txt_Codigo_Vacante.Text == "")
            {
                MessageBox.Show("El código de la vacante no puede ser vacío");

            }
            else if (dt_Fecha_Fin_Publicacion.Text == "")
            {
                MessageBox.Show("El campo Fecha Fin Publicación no puede ser vacío");
            }
            else if (dt_Fecha_Incorporacion.Text == "")
            {
                MessageBox.Show("El campo Fecha de incorporación no puede ser vacío");
            }

           /* else if (dt_Fecha_Fin_Publicacion.Text > dt_Fecha_Incorporacion.Text)
            {
                MessageBox.Show("La fecha fin publicación no debe ser mayor a la fecha de incorporación")

            }
            
            */

            else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) > Convert.ToDateTime(dt_Fecha_Incorporacion.Text))
            {
                MessageBox.Show("La fecha fin publicación no debe ser mayor a la fecha de incorporación");

            }


                // Validar si coloco esta validación

               /*
            else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) == Convert.ToDateTime(dt_Fecha_Incorporacion.Text))
            {
                MessageBox.Show("La fecha fin publicación no debe ser igual a la fecha de incorporación");

            }

                */



            else // si se cumplen todas las condiciones entra en eeste else
            {
                DialogResult msgActualizar_Fecha = MessageBox.Show("¿Desea realizar la actualización de fechas para la vacante?", "Actualizar fecha", MessageBoxButtons.YesNo);

                if (msgActualizar_Fecha == DialogResult.Yes)
                {

                    /*Me tocó agregar un \ en =USER-PC\\SQLEXPRESS porque de lo contrario muestra el error 'Secuencia de escape no reconocida. 
                     * En SQL Server, el nombre del servidor aparece como: USER-PC\SQLEXPRESS (Es decir, con una sola \)*/
                    string cadena_Plavoro = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=Plavmiequipo;Integrated Security=True";


                    SqlConnection conex_Plavoro = new SqlConnection(cadena_Plavoro);
                    // Voy aquí 28 de Enero a las 11:36 am. 
                    string actualizar_fecha = "update RICHIESTA_SEDE set DT_FINPUBLICACION=@finpublicacion, DT_INCORPORACION=@incorporacion Where ID_RICHIESTA=@cod_vacante";
                    SqlCommand cmd = new SqlCommand(actualizar_fecha, conex_Plavoro);
                    conex_Plavoro.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@cod_vacante", SqlDbType.Int).Value = Convert.ToString(txt_Codigo_Vacante.Text);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@finpublicacion", SqlDbType.DateTime).Value = Convert.ToString(dt_Fecha_Fin_Publicacion.Text);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@incorporacion", SqlDbType.DateTime).Value = Convert.ToString(dt_Fecha_Incorporacion.Text);

                    cmd.ExecuteNonQuery();
                    conex_Plavoro.Close();

                    MessageBox.Show("Actualización de fechas realizada");
                    dt_Fecha_Ingreso.Text = "";
                    dt_Fecha_Fin_Publicacion.Text = "";
                    dt_Fecha_Incorporacion.Text = "";

                }
                else
                {


                }
            }
        }

        protected void txt_Codigo_Vacante_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cadena_Plavoro3 = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=Plavmiequipo;Integrated Security=True";
            SqlConnection conex_Plavoro3 = new SqlConnection(cadena_Plavoro3);
            conex_Plavoro3.Open();

            string traer_fechas = "Select ID_RICHIESTA, DT_INGRESO, DT_FINPUBLICACION, DT_INCORPORACION, DT_INGRESO, ID_SEDE, TEXTOANUNCIO from RICHIESTA_SEDE where ID_RICHIESTA = '" + txt_Codigo_Vacante.Text + "' ";
            SqlDataAdapter da_fechas_vacantes = new SqlDataAdapter(traer_fechas, conex_Plavoro3);
            DataSet ds_fechas_vacantes = new DataSet();
            da_fechas_vacantes.Fill(ds_fechas_vacantes, "RICHIESTA_SEDE");
            Grid_informacion_vacante.DataSource = ds_fechas_vacantes;
            Grid_informacion_vacante.DataBind();
            conex_Plavoro3.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {


            if (txt_Codigo_Vacante.Text == "")
            {
                MessageBox.Show("El código de la vacante no puede ser vacío");

            }
            else if (dt_Fecha_Fin_Publicacion.Text == "")
            {
                MessageBox.Show("El campo Fecha Fin Publicación no puede ser vacío");
            }
            else if (dt_Fecha_Incorporacion.Text == "")
            {
                MessageBox.Show("El campo Fecha de incorporación no puede ser vacío");
            }

            else if (txt_Asunto.Text == "")
            {
                MessageBox.Show("Por favor, copie y pegue el asunto del correo de soporte.tecnologia.gov.co");

            }

            else if (txt_Email.Text == "")
            {
                MessageBox.Show("Por favor, ingrese el correo electrónico");
            }

            else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) > Convert.ToDateTime(dt_Fecha_Incorporacion.Text))
            {
                MessageBox.Show("La fecha fin publicación no debe ser mayor a la fecha de incorporación");

            }

            // Falta realizar la validación donde la fecha fin publicación no puede ser mayor a 6 meses con respecto a la fecha de ingreso. 


            SqlParameter[] actualizarfecvacyenvcorreo = new SqlParameter[4];
            actualizarfecvacyenvcorreo[0] = new SqlParameter("@fechafinpublicacion", SqlDbType.DateTime);
            actualizarfecvacyenvcorreo[0].Value = dt_Fecha_Fin_Publicacion.Text;
            actualizarfecvacyenvcorreo[1] = new SqlParameter("@fechaingreso", SqlDbType.DateTime);
            actualizarfecvacyenvcorreo[1].Value = dt_Fecha_Ingreso.Text;
            actualizarfecvacyenvcorreo[2] = new SqlParameter("@fechaincorporacion", SqlDbType.DateTime);
            actualizarfecvacyenvcorreo[2].Value = dt_Fecha_Incorporacion.Text;

            actualizarfecvacyenvcorreo[3] = new SqlParameter("@correo", SqlDbType.VarChar, 50);
            actualizarfecvacyenvcorreo[3].Value = txt_Email.Text;
            actualizarfecvacyenvcorreo[4] = new SqlParameter("@codigovacante", SqlDbType.Int);
            actualizarfecvacyenvcorreo[4].Value = txt_Codigo_Vacante.Text;

            MSSQL.Connection("");

            DataSet ds_Respuesta_Correo = new DataSet();
            ds_Respuesta_Correo = MSSQL.ExecuteDataset(CommandType.StoredProcedure, " ActFechaVacantesyenviarcorreo", actualizarfecvacyenvcorreo);
            MSSQL.Close();

            if (ds_Respuesta_Correo.Tables[0].Rows.Count == 1)
            {
                // DataTable dtresp = DSResp.Tables[0];
                //DataRow drresp = dtresp.Rows[0];    //Toma la fila del DataTable dtresp y se lo asigna a la fila drresp

                DataTable dttabladatoscorreo = ds_Respuesta_Correo.Tables[0];
                DataRow drfiladatoscorreo = dttabladatoscorreo.Rows[0];
            }

            /*
 if (txt_Asunto.Text == "") {
    MessageBox.Show("Por favor, copie y pegue el asunto del correo de soporte.tecnologia.gov.co");
    return;
}

 if (txt_Email.Text == "") {
      MessageBox.Show("Por favor, ingrese el correo electrónico");
      return;
 }



 if (dt_Fecha_Fin_Publicacion.Text == "")
 {
     MessageBox.Show("Por favor, ingrese la fecha fin publicación");
     return;
 }

 if (dt_Fecha_Incorporacion.Text == "")
 {
     MessageBox.Show("Por favor, ingrese la fecha de incorporación");
     return;
 }

*/

            // Necesito para la respuesta los datos de fecha de ingreso, fecha fin publicación, fecha de incorporación  y el e-mail.

            /*

            SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@codigo", SqlDbType.Int);
                    param[0].Value = dplModelos.SelectedValue;  //param[0] recibe el valor seleccionado en la lista dplModelos
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
                        DataRow drresp = dtresp.Rows[0];    //Toma la fila del DataTable dtresp y se lo asigna a la fila drresp

                        if (chkPQRSD.Checked == true)
                        {
                            enviarcorreo("pqrsd@serviciodeempleo.gov.co", "maria.numa@serviciodeempleo.gov.co", drresp["respuesta"].ToString(), "Respuesta PQRSD: " + txtConsecutivo.Text.ToString());

                            // la parte del código que dice "drresp["respuesta"].ToString()" significa que en el DataRow drresp tome la columna respuesta y conviértala a una cadena. 
                        }
                        else 
                        {
                            enviarcorreo("soporte.tecnologia@serviciodeempleo.gov.co", "pqrsd@serviciodeempleo.gov.co", drresp["respuesta"].ToString(), txtAsunto.Text);
                        }
                        
                        resultado = drresp["respuesta"].ToString();

        
            */

        }



    }
}