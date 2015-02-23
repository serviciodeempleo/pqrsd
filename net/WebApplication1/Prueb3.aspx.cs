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


namespace WebApplication1
{
    public partial class Prueb3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txt_ID_PQRSD.Enabled = false;  // Por ahora, se deja deshabilitado porque no está dejando realizar el proceso que hay en el botón TRAER DATOS


            if (!IsPostBack)
            {
                chk_con_numero_PQRSD.Checked = true;
                txt_Nombre_Centro.Enabled = false;
                txt_Nombre_Sede_Centro.Enabled = false;

                txt_Nombre_Empresa.Enabled = false;
                txt_Nombre_Sede_Empresa.Enabled = false;
                txt_Texto_Anuncio.Enabled = false;
                dt_Fecha_Ingreso.Enabled = false;
                //btn_Actualizar_Fechas.Enabled = false;

                // Deshabilité estos 2 para no permitir ingreso de datos, sino seleccionar desde el calendario
                dt_Fecha_Fin_Publicacion.Enabled = false;
                dt_Fecha_Incorporacion.Enabled = false;
                txt_Oferta.Enabled = false; 

            }


            //Calendar_Fecha_Fecha_Ingreso.Visible = false;
            //Calend_fec_finpublic.Visible = false;
            //Calendar_fecha_fin_publicacion.Visible = false;
            //Calendar_fecha_incorporacion.Visible = false;


            if (chk_con_numero_PQRSD.Checked == true) {

                txt_Asunto.Visible = false;
                lbl_Asunto.Visible = false;
                txt_ID_PQRSD.Visible = true;
                txt_Asunto.Text = "";

            }

            else
            {

                txt_Asunto.Visible = true;
                lbl_Asunto.Visible = true;
                txt_ID_PQRSD.Visible = false;
                txt_Asunto.Text = "Referencia: Vacante # " + txt_Codigo_Vacante.Text;
                //txtAsunto.Text = "RTA:" + txtCedula.Text + " / " + txtemail.Text;
            }



            /*
            
            txt_Nombre_Centro.Enabled = false;
            txt_Nombre_Sede_Centro.Enabled = false;
            txt_ID_Sede_Centro.Enabled = false;
            txt_Nombre_Empresa.Enabled = false;
            txt_Nombre_Sede_Empresa.Enabled = false;
            txt_Texto_Anuncio.Enabled = false;
            dt_Fecha_Ingreso.Enabled = false;
            btn_Actualizar_Fechas.Enabled = false;

            // Se dejó este campo invisible
            txt_ID_PQRSD.Visible = false; 
          
             * */
            

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

        

        public void enviardatoscorreoactfechasvac(string emaildestino, string concopia, string Mensaje, string asunto)
        {

            

            //String FROM = emaildestino;
            String FROM = "ivan.benavides@serviciodeempleo.gov.co";
            String TO = emaildestino;
            String COPIA = concopia;

            String SUBJECT = asunto;
            String BODY = Mensaje;

            String SMTP_USERNAME = "ivan.benavides@serviciodeempleo.gov.co";  // Replace with your SMTP username. 
            String SMTP_PASSWORD = "DSV64AEcPDEB";  // Replace with your SMTP password.

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
                LblError4.Text = ex.Message;
            }

            

        }

    
        



//   HACIENDO LA PRUEBA PARA EL ENVÍO A 2 CORREOS O MÁS

        /*
        
        public void enviardatoscorreoactfechasvac(Array emaildestino, string concopia, string Mensaje, string asunto)
        {


            //String FROM = emaildestino;
            String FROM = "ivan.benavides@serviciodeempleo.gov.co";
            Array TO = emaildestino;
            String COPIA = concopia;

            String SUBJECT = asunto;
            String BODY = Mensaje;

            String SMTP_USERNAME = "ivan.benavides@serviciodeempleo.gov.co";  // Replace with your SMTP username. 
            String SMTP_PASSWORD = "DSV64AEcPDEB";  // Replace with your SMTP password.

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
                LblError4.Text = ex.Message;
            }



        }

         * 
         * */

        protected void btn_Traer_Datos_Vacante_Click(object sender, EventArgs e)
        {

            //string cadena_Plavoro = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=Plavmiequipo;Integrated Security=True"; 

            /*Código que se está trabajando para hacer la búsqueda con procedimients almacenados            */

            if (txt_Codigo_Vacante.Text == "")

                //MessageBox.Show("El código de la vacante no puede ser vacío");
                msg.Value = "El código de la vacante no puede ser vacío";

            else
            {


                SqlParameter[] AR_VACANTE = new SqlParameter[1];  //Va a tener un sólo parámetro; por eso, en el arreglo se coloca 1.
                AR_VACANTE[0] = new SqlParameter("@ID_RICHIESTA", SqlDbType.Int);  // Se define el parámetro ID_RICHIESTA. Este parámetro toma lo que hay en txt_Codigo_Vacante
                AR_VACANTE[0].Value = txt_Codigo_Vacante.Text;
                MSSQL.Connection("");
                DataSet DStraerdatosvacantes = new DataSet();
                //El Dataset DSVacante es llenado con el resultado de ejecutar el procedimiento almacenado Traer_Datos_Vacantes

                //Línea deshabilitada 19 de febrero del 2015
                //DStraerdatosvacantes = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "Traer_Datos_Vacantes", AR_VACANTE);
                DStraerdatosvacantes = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ConsultarInfoVacantes", AR_VACANTE);


                MSSQL.Close();
                if (DStraerdatosvacantes.Tables[0].Rows.Count == 1) //Debe encontrarse un sólo registro, ya que debe hacer un sólo registro con ese código de Vacante. 
                {
                    DataTable dttraerdatosvacantes = DStraerdatosvacantes.Tables[0]; // Al DataTable se le asigna el DataSet
                    DataRow drtraerdatosvacantes = dttraerdatosvacantes.Rows[0];// La fila toma la única fila que tiene el DataTable. Tiene una sola porque debe haber traído un sólo registro relacionado con esa vacante.

                    dt_Fecha_Fin_Publicacion.Text = drtraerdatosvacantes["DT_FINPUBLICACION"].ToString();

                    dt_Fecha_Incorporacion.Text = drtraerdatosvacantes["DT_INCORPORACION"].ToString();
                    //Calendar_fecha_incorporacion.SelectedDate = System.Convert.ToDateTime(drtraerdatosvacantes["DT_INCORPORACION"].ToString());
                    //Calendar_fecha_incorporacion.VisibleDate = System.Convert.ToDateTime(drtraerdatosvacantes["DT_INCORPORACION"].ToString());
                    dt_Fecha_Ingreso.Text = drtraerdatosvacantes["DT_INGRESO"].ToString();
                    //Calendar_Fecha_Fecha_Ingreso.SelectedDate = System.Convert.ToDateTime(drtraerdatosvacantes["DT_INGRESO"].ToString());
                    //Calendar_Fecha_Fecha_Ingreso.VisibleDate = System.Convert.ToDateTime(drtraerdatosvacantes["DT_INGRESO"].ToString());
                    //Calendar_Fecha_Fecha_Ingreso.Enabled = false;

                    //txt_ID_Sede_Centro.Text = drtraerdatosvacantes["ID_SEDE"].ToString();
                    txt_Texto_Anuncio.Text = drtraerdatosvacantes["TEXTOANUNCIO"].ToString();

                    //Deshabilitada 19 de febrero del 2015 - 12:38 p.m.
                    //txt_Nombre_Centro.Text = drtraerdatosvacantes["AGENCIA"].ToString();
                    txt_Nombre_Centro.Text = drtraerdatosvacantes["NOMBRE_CENTRO_EMPLEO"].ToString();

                    txt_Nombre_Sede_Centro.Text = drtraerdatosvacantes["SEDE_CENTRO_EMPLEO"].ToString();
                    txt_Nombre_Empresa.Text = drtraerdatosvacantes["NOMBRE_EMPRESA"].ToString();
                    txt_Nombre_Sede_Empresa.Text = drtraerdatosvacantes["SEDE_IMPRESA"].ToString();
                    txt_Oferta.Text = drtraerdatosvacantes["OFFER_TITLE"].ToString();



                }
                else if (DStraerdatosvacantes.Tables[0].Rows.Count == 0)
                {
                    msg.Value = "No se encontraron registros de la vacante o la empresa no tiene centro asociado";
                    txt_Codigo_Vacante.Focus();
                    dt_Fecha_Ingreso.Text = "";
                    dt_Fecha_Fin_Publicacion.Text = "";
                    dt_Fecha_Incorporacion.Text = "";
                    txt_Nombre_Centro.Text = "";
                    txt_Nombre_Sede_Centro.Text = "";
                    txt_Nombre_Empresa.Text = "";
                    txt_Nombre_Sede_Empresa.Text = "";
                    txt_Texto_Anuncio.Text = "";
                    txt_Asunto.Text = "";
                    txt_Email_destino.Text = "";
                    txt_ID_PQRSD.Text = "";





                }

                else { msg.Value = "Algo pasó"; }


            }

            //string cadena_Plavoro = "Data Source=10.200.10.66;Initial Catalog=Plavoro;User ID=USRPQRS;Password=-+USRPQRS*;Integrated Security=True";

            //SqlConnection conex_Plavoro2 = new SqlConnection();
            //string traer_fechas = "Select DT_INGRESO, DT_FINPUBLICACION, DT_INCORPORACION, TEXTOANUNCIO, ID_SEDE from RICHIESTA_SEDE where ID_RICHIESTA = '" + txt_Codigo_Vacante.Text + "' ";

            //SqlCommand caden_conex = new SqlCommand(traer_fechas, conex_Plavoro2);
            //conex_Plavoro2.Open();
            //SqlDataReader leerconsulta = caden_conex.ExecuteReader();
            //if (leerconsulta.Read() == true)
            //{
            //    dt_Fecha_Fin_Publicacion.Text = leerconsulta["DT_FINPUBLICACION"].ToString();
            //    dt_Fecha_Incorporacion.Text = leerconsulta["DT_INCORPORACION"].ToString();
            //    dt_Fecha_Ingreso.Text = leerconsulta["DT_INGRESO"].ToString();
            //    txt_ID_Sede_Centro.Text = leerconsulta["ID_SEDE"].ToString();
            //    txt_Texto_Anuncio.Text = leerconsulta["TEXTOANUNCIO"].ToString();



            //}
            //else
            //{
            //    MessageBox.Show("No se encontró la vacante");
            //    dt_Fecha_Ingreso.Text = "";
            //    dt_Fecha_Fin_Publicacion.Text = "";
            //    dt_Fecha_Incorporacion.Text = "";

            //}

            //conex_Plavoro2.Close();

        }

        protected void btn_Actualizar_Fechas_Click(object sender, EventArgs e)
        {
            if (txt_Codigo_Vacante.Text == "")
            {
               msg.Value = "El código de la vacante no puede ser vacío";

            }
            else if (dt_Fecha_Fin_Publicacion.Text == "")
            {
                msg.Value = "El campo Fecha Fin Publicación no puede ser vacío";
            }
            else if (dt_Fecha_Incorporacion.Text == "")
            {
               msg.Value =  "El campo Fecha de incorporación no puede ser vacío";
            }

           /* else if (dt_Fecha_Fin_Publicacion.Text > dt_Fecha_Incorporacion.Text)
            {
                msg.Value =  "La fecha fin publicación no debe ser mayor a la fecha de incorporación"

            }
            
            */

            else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) > Convert.ToDateTime(dt_Fecha_Incorporacion.Text))
            {
                msg.Value = "La fecha fin publicación no debe ser mayor a la fecha de incorporación";

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

                    msg.Value =  "Actualización de fechas realizada";
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

            /*
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
            */
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (txt_Codigo_Vacante.Text == "")
                MessageBox.Show("El código de la vacante no puede ser vacío");

            else if (dt_Fecha_Fin_Publicacion.Text == "")
                MessageBox.Show("El campo Fecha Fin Publicación no puede ser vacío");

            else if (dt_Fecha_Incorporacion.Text == "")

                MessageBox.Show("El campo Fecha de incorporación no puede ser vacío");


            else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) < Convert.ToDateTime(dt_Fecha_Ingreso.Text))

                MessageBox.Show("La fecha fin publicación debe ser mayor a la fecha de ingreso");

                /*   Comenté esto hoy 18 de febrero del 2015 para que solamente valide que el asunto está vacío si se ha chequeado
                 * en chk_con_numero_pqrsd

            else if (txt_Asunto.Text == "")

                MessageBox.Show("Por favor, copie y pegue el asunto del correo de soporte.tecnologia.gov.co");
                 * 
                 * */

            else if (txt_Email_destino.Text == "")
                MessageBox.Show("Por favor, ingrese el correo electrónico");

            else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) > Convert.ToDateTime(dt_Fecha_Incorporacion.Text))

                MessageBox.Show("La fecha fin publicación no debe ser mayor a la fecha de incorporación");

            //else if (chk_con_numero_PQRSD.Checked == 0) { 
                //MessageBox.Show("Se debe ingresar el ID de PQRSD"); }


                /*          Deshabilitado porque esto no permite seguir con la actualización de fechas

            else if (chk_con_numero_PQRSD.Checked == true) {

                if (txt_ID_PQRSD.Text == "")
                {
                    MessageBox.Show("Se debe ingresar el ID de PQRSD");
                }

            }
                 * 
                 * */

            // Falta realizar la validación donde la fecha fin publicación no puede ser mayor a 6 meses con respecto a la fecha de ingreso. 
            else
            {

               
                if (chk_con_numero_PQRSD.Checked == false)
                {

                    // Agregado 18 de febrero del 2015 - 10:56 a.m.


                    if (txt_Asunto.Text == "")
                    {
                        MessageBox.Show("Por favor, copie y pegue el asunto del correo de soporte.tecnologia.gov.co ");
                        return;
                    }

                }

                

                if (chk_con_numero_PQRSD.Checked == true)
                {
                    
                        if (txt_ID_PQRSD.Text == "") {
                            MessageBox.Show("Se debe ingresar el identificador del PQRSD");
                        return;
                    }

                }


                String resultado;
                 DialogResult msgActualizar_Fecha = MessageBox.Show("¿Desea realizar la actualización de fechas para la vacante?", "Actualizar fecha", MessageBoxButtons.YesNo);

                if (msgActualizar_Fecha == DialogResult.Yes) {
                

                try {

                SqlParameter[] actualizarfecvacyenvcorreo = new SqlParameter[6];// Se define una arreglo de 6 elementos porque se le están pasando 6 elementos. 

                actualizarfecvacyenvcorreo[0] = new SqlParameter("@fechafinpublicacion", SqlDbType.DateTime);
                actualizarfecvacyenvcorreo[0].Value = dt_Fecha_Fin_Publicacion.Text;
                actualizarfecvacyenvcorreo[1] = new SqlParameter("@fechaingreso", SqlDbType.DateTime);
                actualizarfecvacyenvcorreo[1].Value = dt_Fecha_Ingreso.Text;

                actualizarfecvacyenvcorreo[2] = new SqlParameter("@fechaincorporacion", SqlDbType.DateTime);
                actualizarfecvacyenvcorreo[2].Value = dt_Fecha_Incorporacion.Text;

                actualizarfecvacyenvcorreo[3] = new SqlParameter("@correo", SqlDbType.VarChar, 50);
                actualizarfecvacyenvcorreo[3].Value = txt_Email_destino.Text;
                actualizarfecvacyenvcorreo[4] = new SqlParameter("@codigovacante", SqlDbType.Int);
                actualizarfecvacyenvcorreo[4].Value = txt_Codigo_Vacante.Text;
                actualizarfecvacyenvcorreo[5] = new SqlParameter("@tipodecambioempleador", SqlDbType.VarChar, 1);
                actualizarfecvacyenvcorreo[5].Value = 1;

                MSSQL.Connection("");

                DataSet ds_Respuesta_Correo = new DataSet();
                ds_Respuesta_Correo = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ActFechaVacantesyenviarcorreo", actualizarfecvacyenvcorreo);
                
                
                MSSQL.Close();
                //MessageBox.Show("Actualización de fechas realizada satisfactoriamente");
                    msg.Value ="Actualización de fechas realizada satisfactoriamente";

                if (ds_Respuesta_Correo.Tables[0].Rows.Count == 1)
                {
                    // DataTable dtresp = DSResp.Tables[0];
                    //DataRow drresp = dtresp.Rows[0];    //Toma la fila del DataTable dtresp y se lo asigna a la fila drresp

                    DataTable dttabladatoscorreo = ds_Respuesta_Correo.Tables[0];
                    DataRow drfiladatoscorreo = dttabladatoscorreo.Rows[0];

                    if (chk_con_numero_PQRSD.Checked == true) {

                        // Estoy realizando esta función
                        /*enviardatoscorreoactfechasvac(txt_Email_destino.Text, "lucero.vivas@serviciodeempleo.gov.co", drfiladatoscorreo["respuesta"].ToString(), txt_Asunto.Text);
                         * 
                         */

                        enviardatoscorreoactfechasvac(txt_Email_destino.Text, "ivanmauricio77@gmail.com", drfiladatoscorreo["respuesta"].ToString(), "Respuesta PQRSD N°" + txt_ID_PQRSD.Text);

                                                                 }

                    if (chk_con_numero_PQRSD.Checked == false) {

                        // Esta está funcionando correctamente, pero se va a realizar para que tome un arreglo para que se le puedan enviar a varias personas el correo. 

                        
                        enviardatoscorreoactfechasvac(txt_Email_destino.Text, "ivanmauricio77@gmail.com", drfiladatoscorreo["respuesta"].ToString(), txt_Asunto.Text);
                        
                    }

                    resultado = drfiladatoscorreo["respuesta"].ToString();

                    }

                else
                {

                    if (ds_Respuesta_Correo.Tables[0].Rows.Count == 0) {

                        //MessageBox.Show("No se encontraron registros");
                        msg.Value = "No se encontraron registros";
                        return;

                    
                    }

                    else {

                        //MessageBox.Show("No pueden haber 2 vacantes con el mismo código");
                        msg.Value = "No pueden haber 2 vacantes con el mismo código";
                        return;
                    }


                }

                SqlParameter[] registroactfechvac = new SqlParameter[6];
                //SqlParameter[] registroactfechvac = new SqlParameter[5];


                /*
                 *  Estas son las líneas que estaban para el código de Jairo:
                 *  
                 *  paramRegistro[2] = new SqlParameter("@usuaro", SqlDbType.Int);
                                    paramRegistro[2].Value = Session["USR_Codigo"];
                 * 
                 * */

                registroactfechvac[0] = new SqlParameter("@CodigoUsuario", SqlDbType.Int);
                registroactfechvac[0].Value = Session["URSR_Codigo"];
                registroactfechvac[1] = new SqlParameter("@Tema", SqlDbType.VarChar, 21);
                registroactfechvac[1].Value = "Cambio Fecha Vacantes";
                registroactfechvac[2] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                registroactfechvac[2].Value = txt_Email_destino.Text;
                registroactfechvac[3] = new SqlParameter("@CodigoVacante", SqlDbType.VarChar,15);
                registroactfechvac[3].Value = txt_Codigo_Vacante.Text;
                registroactfechvac[4] = new SqlParameter("@IdPQRSD", SqlDbType.VarChar,10);
                registroactfechvac[4].Value = txt_ID_PQRSD.Text;
                registroactfechvac[5] = new SqlParameter("Respuesta", SqlDbType.VarChar, 2000);
                registroactfechvac[5].Value = resultado;

               // VOY AQUÍ. 

                MSSQL.Connection("");
                DataSet DSRegistroActualizacVacantes = new DataSet();
                DSRegistroActualizacVacantes = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "RegActFecVacantes", registroactfechvac);
                MSSQL.Close();

                msg.Value = "Registro realizado satisfactoriamente";

                if (DSRegistroActualizacVacantes.Tables.Count > 0)
                        {
                            if (DSRegistroActualizacVacantes.Tables[0].Rows.Count == 1)
                            {
                                DataTable dttabla_registroActVacantes = DSRegistroActualizacVacantes.Tables[0];
                                DataRow drfilaactvacantes = dttabla_registroActVacantes.Rows[0];

                                // Voy aquí - 15 de febrero 8:26 p.m.
                               /*enviarcorreo(txtemail.Text, "" ,drresp["respuesta"].ToString(), "RedEmpleo: Información Importante - Cambio de Contraseña");  */
                            }
                        }
                        
                // VOY AQUÍ. 13 DE FEBRERO 6:20 P.M.

            }

                catch (Exception ex) {
                    LblError4.Text = ex.Message; 
                                    }

                }


                else { //MessageBox.Show("No se actualizarán las fechas de la vacante");
                msg.Value = "No se actualizarán las fechas de la vacante";
                return;

                }

                //Mirar si este return aparecía aquí en la anterior versión
                //return;

                // Comenzar aquí el proceso de registro

                /*
                SqlParameter[] registroactfechvac = new SqlParameter[5];
                //SqlParameter[] registroactfechvac = new SqlParameter[5];

                registroactfechvac[0] = new SqlParameter("@codigousuario", SqlDbType.Int);
                registroactfechvac[0].Value = Session["URSR_Codigo"];
                registroactfechvac[1] = new SqlParameter("@Tema", SqlDbType.VarChar, 21);
                registroactfechvac[1].Value = "Cambio Fecha Vacantes";
                registroactfechvac[2] = new SqlParameter("@email", SqlDbType.VarChar, 100);
                registroactfechvac[2].Value = txt_Email_destino.Text;
                registroactfechvac[3] = new SqlParameter("@Codigo Vacante", SqlDbType.Int);
                registroactfechvac[3].Value = txt_Codigo_Vacante.Text;
                registroactfechvac[4] = new SqlParameter("@ Id PQRSD", SqlDbType.Int);
                registroactfechvac[4].Value = txt_ID_PQRSD.Text;
                 * 
                 * */

                // Me falta registrar la respuesta 
                // La fecha de registro me parece que  la está tomando automáticamente el sistema. 


                

                //actualizarfecvacyenvcorreo[1] = new SqlParameter("@fechaingreso", SqlDbType.DateTime);
                //actualizarfecvacyenvcorreo[1].Value = dt_Fecha_Ingreso.Text;

            }

        

        }

       

        protected void chk_con_numero_PQRSD_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_con_numero_PQRSD.Checked == true)
            {
               
                lbl_Asunto.Visible = false;  
                txt_Asunto.Visible = false;  //Si se chequea para digitar el PQRSD, el campon donde se ingresa el asunto debe ser invisible, ya que se envía por defecto: "Respuesta PQRSD" más el número del PQRSD. 
                txt_Asunto.Text = "";
                txt_ID_PQRSD.Visible = true;

            }

            else
            {
                lbl_Asunto.Visible = true;
                txt_Asunto.Visible = true;
                txt_ID_PQRSD.Visible = false;
                txt_ID_PQRSD.Text = "";

            }


            //txt_ID_PQRSD.Visible = true;

            
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            //Calendar1.au
            dt_Fecha_Incorporacion.Text = Calendar_fecha_incorporacion.SelectedDate.ToShortDateString();
            Calendar_fecha_incorporacion.Visible = false;

        }

        protected void Btn_Fecha_Fin_Publicacion_Click(object sender, EventArgs e)
        {
            //Calendar_fecha_fin_publicacion.Visible = true;
            Calend_fec_finpublic.Visible = true;
        }

        protected void Calendar_fecha_fin_publicacion_SelectionChanged(object sender, EventArgs e)
        {
            //dt_Fecha_Fin_Publicacion.Text = Calendar_fecha_fin_publicacion.SelectedDate.ToShortDateString();

            //Calendar_fecha_fin_publicacion.Visible = false;
            // El control Calendar_fecha_fin_publicacion me tocó dejarlo con el valor false en la propiedad Visible 
            // para que me dejara seleccionar el día, mes y año, en lugar de dejarlo invisible desde el load. 

            dt_Fecha_Fin_Publicacion.Text = Calend_fec_finpublic.SelectedDate.ToShortDateString();
            Calend_fec_finpublic.Visible = false; 

        }

        protected void Calendar_fecha_fin_publicacion_SelectionChanged1(object sender, EventArgs e)
        {
            //dt_Fecha_Fin_Publicacion.Text = Calendar_fecha_fin_publicacion.SelectedDate.ToShortDateString();

        }

        protected void Calend_fec_finpublic_SelectionChanged(object sender, EventArgs e)
        {
            dt_Fecha_Fin_Publicacion.Text = Calend_fec_finpublic.SelectedDate.ToShortDateString();
            //La propiedad SelectionMode la dejé en DayWeekMonth para que permitiera seleccionar Día, Semana y Mes. 
            Calend_fec_finpublic.Visible = false; 

        }

        protected void Btn_FechaIncorporacion_Click(object sender, EventArgs e)
        {

            Calendar_fecha_incorporacion.Visible = true;
        }

        protected void msg_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}