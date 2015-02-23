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
    public partial class Form_FechaVacantes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

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
                txt_diasentrefeingreyfefinpub.Enabled = false;

                // Se deshabilitan estos dos labels ya que la generación de los mensajes de validación para los botones "Consultar" y "Actualizar Fechas y Enviar Respuesta" se realiza a través de cajas de mensajes de JavaScript
                Lbl_validac_alconsultar.Visible = false;
                Lbl_Valid_al_actualizar.Visible = false;

                // Agregado 22 de febrero del 2015
                txt_Codigo_Vacante.MaxLength = 20;

                // Nota: falta definir cuántos caracteres admite el asunto y el e-mail

            }


            //Calendar_Fecha_Fecha_Ingreso.Visible = false;
            //Calend_fec_finpublic.Visible = false;
            //Calendar_fecha_fin_publicacion.Visible = false;
            //Calendar_fecha_incorporacion.Visible = false;


            if (chk_con_numero_PQRSD.Checked == true)
            {

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



        protected void btn_Traer_Datos_Vacante_Click(object sender, EventArgs e)
        {
            Lbl_validac_alconsultar.Text = "";   //Limpia el campo para cuando vuelva a dar en el botón Consultar.

            //string cadena_Plavoro = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=Plavmiequipo;Integrated Security=True"; 

            /*Código que se está trabajando para hacer la búsqueda con procedimients almacenados            */

            if (txt_Codigo_Vacante.Text == "")

                //Lbl_validac_alconsultar.Text = "El código de la vacante no puede ser vacío";
                CuadroMensConsultAct.Value = "El código de la vacante no puede ser vacío";

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
                    dt_Fecha_Ingreso.Text = drtraerdatosvacantes["DT_INGRESO"].ToString();
                    txt_Texto_Anuncio.Text = drtraerdatosvacantes["TEXTOANUNCIO"].ToString();

                    //Deshabilitada 19 de febrero del 2015 - 12:38 p.m.
                    //txt_Nombre_Centro.Text = drtraerdatosvacantes["AGENCIA"].ToString();
                    txt_Nombre_Centro.Text = drtraerdatosvacantes["NOMBRE_CENTRO_EMPLEO"].ToString();
                    txt_Nombre_Sede_Centro.Text = drtraerdatosvacantes["SEDE_CENTRO_EMPLEO"].ToString();
                    txt_Nombre_Empresa.Text = drtraerdatosvacantes["NOMBRE_EMPRESA"].ToString();
                    txt_Nombre_Sede_Empresa.Text = drtraerdatosvacantes["SEDE_IMPRESA"].ToString();
                    txt_Oferta.Text = drtraerdatosvacantes["OFFER_TITLE"].ToString();

                    // Validación cuando la empresa no tiene centro asociado - Revisar validación

                    if (txt_Nombre_Centro.Text == "") {

                    CuadroMensConsultAct.Value = "La empresa no tiene centro asociado";
                    }

                    // Validación para contar el número de días entre la fecha de ingreso y la fecha fin publicación - Agregada aquí en el botón consultar el 22 de febrero del 2015 - Revisar validación

                    DateTime FecIngreso = Convert.ToDateTime(dt_Fecha_Ingreso.Text);
                    DateTime FecFinPublic = Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text);

                    TimeSpan diasentrFecIngresoyFecFinPublic = FecFinPublic.Subtract(FecIngreso);
                    txt_diasentrefeingreyfefinpub.Text = diasentrFecIngresoyFecFinPublic.Days.ToString();

                    int diastranscurridos;
                    diastranscurridos = Convert.ToInt32(txt_diasentrefeingreyfefinpub.Text);

                    if (diastranscurridos > 180)   
                        //Lbl_Valid_al_actualizar.Text = "La fecha fin publicación no debe pasar los 180 días a partir de la fecha de ingreso";
                        CuadroMensConsultAct.Value = "El número de días de la fecha fin publicación no debe ser mayor a 180 partir de la fecha de ingreso";


                    //  ---------------------------------------------------------------------------



                }
                else if (DStraerdatosvacantes.Tables[0].Rows.Count == 0)
                {
                    CuadroMensConsultAct.Value = "No se encontraron registros de la vacante";
                    //Lbl_validac_alconsultar.Text = "No se encontraron registros de la vacante, o la empresa no tiene centro asociado";
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

                else
                {
                    CuadroMensConsultAct.Value = "Algo pasó";
                    //Lbl_validac_alconsultar.Text = "Algo pasó";
                }


            }


        }

        protected void Btn_Fecha_Fin_Publicacion_Click(object sender, EventArgs e)
        {
            Calend_fec_finpublic.Visible = true;
        }

        protected void Btn_FechaIncorporacion_Click(object sender, EventArgs e)
        {
            Calendar_fecha_incorporacion.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            dt_Fecha_Incorporacion.Text = Calendar_fecha_incorporacion.SelectedDate.ToShortDateString();
            Calendar_fecha_incorporacion.Visible = false;

        }

        protected void Calend_fec_finpublic_SelectionChanged(object sender, EventArgs e)
        {
            dt_Fecha_Fin_Publicacion.Text = Calend_fec_finpublic.SelectedDate.ToShortDateString();
            //La propiedad SelectionMode la dejé en DayWeekMonth para que permitiera seleccionar Día, Semana y Mes. 
            Calend_fec_finpublic.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

  
            //else

            // Llave deshabilitada 23 de febrero del 2015 - 12:16 p.m.

            //{

                /*

                if (chk_con_numero_PQRSD.Checked == false)
                {

                    // Agregado 18 de febrero del 2015 - 10:56 a.m.

                    if (txt_Asunto.Text == "")
                    {
                        Lbl_Valid_al_actualizar.Text = "Por favor, copie y pegue el asunto del correo de soporte.tecnologia.gov.co ";
                        return;
                    }

                }

                 * 
                 * */


                
                /*
                if (chk_con_numero_PQRSD.Checked == true)
                {

                    if (txt_ID_PQRSD.Text == "")
                    {
                        Lbl_Valid_al_actualizar.Text = "Se debe ingresar el identificador del PQRSD";
                        return;
                    }

                }

                 * 
                 * */


                String resultado;
                DialogResult msgActualizar_Fecha = MessageBox.Show("¿Desea realizar la actualización de fechas para la vacante?", "Actualizar fecha", MessageBoxButtons.YesNo);

                if (msgActualizar_Fecha == DialogResult.Yes)
                {


                    //  -----------  Agregado  22 de febrero del 2015 - Revisar

                    int contardias_de_txt_diasentrefeingreyfefinpub;
                    contardias_de_txt_diasentrefeingreyfefinpub = Convert.ToInt32(txt_diasentrefeingreyfefinpub.Text);

                    // ----------------------------------------------------------------

                    // Deshabilitado 22 de febrero del 2015
                    /*
                    DateTime FecIngreso = Convert.ToDateTime(dt_Fecha_Ingreso.Text);
                    DateTime FecFinPublic = Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text);

                    TimeSpan diasentrFecIngresoyFecFinPublic = FecFinPublic.Subtract(FecIngreso);
                    txt_diasentrefeingreyfefinpub.Text = diasentrFecIngresoyFecFinPublic.Days.ToString();

                    int diastranscurridos;
                    diastranscurridos = Convert.ToInt32(txt_diasentrefeingreyfefinpub.Text);
                     * 
                     */

                    Lbl_Valid_al_actualizar.Text = "";

                    if (txt_Codigo_Vacante.Text == "")

                        //Lbl_Valid_al_actualizar.Text = "El código de la vacante no puede ser vacío";
                        CuadroMensConsultAct.Value = "El código de la vacante no puede ser vacío";

                    else if (dt_Fecha_Fin_Publicacion.Text == "")
                        //Lbl_Valid_al_actualizar.Text = "El campo Fecha Fin Publicación no puede ser vacío";
                        CuadroMensConsultAct.Value = "El campo Fecha Fin Publicación no puede ser vacío";

                    else if (dt_Fecha_Ingreso.Text == "")
                        CuadroMensConsultAct.Value = "El campo Fecha de Ingreso no puede ser vacío";

                        /*   Deshabilitado 22 de febrero del 2015

                    else if (diastranscurridos > 180)
                        //Lbl_Valid_al_actualizar.Text = "La fecha fin publicación no debe pasar los 180 días a partir de la fecha de ingreso";
                        CuadroMensConsultAct.Value = "El número de días de la fecha fin publicación no debe ser mayor a 180 partir de la fecha de ingreso";
                         * 
                         */


        //  Agregado 22 de febrero del 2015 - Revisar ---------------------------------------

                    else if (contardias_de_txt_diasentrefeingreyfefinpub > 180)
                        CuadroMensConsultAct.Value = "El número de días de la fecha fin publicación no debe ser mayor a 180 partir de la fecha de ingreso";

                    // -------------------------------------------------------

                    else if (dt_Fecha_Incorporacion.Text == "")

                        //Lbl_Valid_al_actualizar.Text = "El campo Fecha de incorporación no puede ser vacío";
                        CuadroMensConsultAct.Value = "El campo Fecha de incorporación no puede ser vacío";

                    else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) < Convert.ToDateTime(dt_Fecha_Ingreso.Text))

                        // Lbl_Valid_al_actualizar.Text = "La fecha fin publicación debe ser mayor a la fecha de ingreso";
                        CuadroMensConsultAct.Value = "La fecha fin publicación debe ser mayor a la fecha de ingreso";

                    else if (txt_Email_destino.Text == "")
                        //Lbl_Valid_al_actualizar.Text = "Por favor, ingrese el correo electrónico";
                        CuadroMensConsultAct.Value = "Por favor, ingrese el correo electrónico";

                    else if (Convert.ToDateTime(dt_Fecha_Fin_Publicacion.Text) > Convert.ToDateTime(dt_Fecha_Incorporacion.Text))

                        //Lbl_Valid_al_actualizar.Text = "La fecha fin publicación no debe ser mayor a la fecha de incorporación";
                        CuadroMensConsultAct.Value = "La fecha fin publicación no debe ser mayor a la fecha de incorporación";

                    else if (chk_con_numero_PQRSD.Checked == false)
                    {

                        if (txt_Asunto.Text == "")
                        {
                            //Lbl_Valid_al_actualizar.Text = "Por favor, copie y pegue el asunto del correo de soporte.tecnologia.gov.co ";
                            //return;

                            CuadroMensConsultAct.Value = "Por favor, copie y pegue el asunto del correo de soporte.tecnologia@serviciodeempleo.gov.co";

                        }


                    }

                    else if (chk_con_numero_PQRSD.Checked == true)
                    {

                        if (txt_ID_PQRSD.Text == "")
                        {
                            Lbl_Valid_al_actualizar.Text = "Se debe ingresar el identificador del PQRSD";
                            return;
                        }

                    }



                    else
                    {




                        try
                        {

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
                            //msg.Value = "Actualización de fechas realizada satisfactoriamente";
                            //Lbl_Valid_al_actualizar.Text = "Actualización de fechas realizada satisfactoriamente";
                            CuadroMensConsultAct.Value = "Actualización de fechas realizada satisfactoriamente";

                            if (ds_Respuesta_Correo.Tables[0].Rows.Count == 1)
                            {
                                // DataTable dtresp = DSResp.Tables[0];
                                //DataRow drresp = dtresp.Rows[0];    //Toma la fila del DataTable dtresp y se lo asigna a la fila drresp

                                DataTable dttabladatoscorreo = ds_Respuesta_Correo.Tables[0];
                                DataRow drfiladatoscorreo = dttabladatoscorreo.Rows[0];

                                if (chk_con_numero_PQRSD.Checked == true)
                                {

                                    // Estoy realizando esta función
                                    /*enviardatoscorreoactfechasvac(txt_Email_destino.Text, "lucero.vivas@serviciodeempleo.gov.co", drfiladatoscorreo["respuesta"].ToString(), txt_Asunto.Text);
                                     * 
                                     */

                                    enviardatoscorreoactfechasvac(txt_Email_destino.Text, "ivanmauricio77@gmail.com", drfiladatoscorreo["respuesta"].ToString(), "Respuesta PQRSD N°" + txt_ID_PQRSD.Text);

                                }

                                if (chk_con_numero_PQRSD.Checked == false)
                                {

                                    // Esta está funcionando correctamente, pero se va a realizar para que tome un arreglo para que se le puedan enviar a varias personas el correo. 


                                    enviardatoscorreoactfechasvac(txt_Email_destino.Text, "ivanmauricio77@gmail.com", drfiladatoscorreo["respuesta"].ToString(), txt_Asunto.Text);

                                }

                                resultado = drfiladatoscorreo["respuesta"].ToString();

                            }

                            else
                            {

                                if (ds_Respuesta_Correo.Tables[0].Rows.Count == 0)
                                {

                                    //MessageBox.Show("No se encontraron registros");

                                    //Lbl_Valid_al_actualizar.Text = "No se encontraron registros";
                                    CuadroMensConsultAct.Value = "No se encontraron registros";
                                    return;
                                }

                                else
                                {

                                    //MessageBox.Show("No pueden haber 2 vacantes con el mismo código");
                                    //Lbl_Valid_al_actualizar.Text = "No pueden haber 2 vacantes con el mismo código";
                                    CuadroMensConsultAct.Value = "No pueden haber 2 vacantes con el mismo código";
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
                            registroactfechvac[0].Value = Session["USR_Codigo"];
                            registroactfechvac[1] = new SqlParameter("@Tema", SqlDbType.VarChar, 21);
                            registroactfechvac[1].Value = "Cambio Fecha Vacantes";
                            registroactfechvac[2] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                            registroactfechvac[2].Value = txt_Email_destino.Text;
                            registroactfechvac[3] = new SqlParameter("@CodigoVacante", SqlDbType.VarChar, 15);
                            registroactfechvac[3].Value = txt_Codigo_Vacante.Text;
                            registroactfechvac[4] = new SqlParameter("@IdPQRSD", SqlDbType.VarChar, 10);
                            registroactfechvac[4].Value = txt_ID_PQRSD.Text;
                            registroactfechvac[5] = new SqlParameter("Respuesta", SqlDbType.VarChar, 2000);
                            registroactfechvac[5].Value = resultado;

                            // VOY AQUÍ. 

                            MSSQL.Connection("");
                            DataSet DSRegistroActualizacVacantes = new DataSet();
                            DSRegistroActualizacVacantes = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "RegActFecVacantes", registroactfechvac);
                            MSSQL.Close();

                            //Lbl_Valid_al_actualizar.Text = "Registro realizado satisfactoriamente";
                            CuadroMensConsultAct.Value = "Registro realizado satisfactoriamente";
                            // Código agregado 19 de febrero del 2015

                            dt_Fecha_Ingreso.Text = "";
                            dt_Fecha_Fin_Publicacion.Text = "";
                            dt_Fecha_Incorporacion.Text = "";
                            txt_Nombre_Centro.Text = "";
                            txt_Nombre_Sede_Centro.Text = "";
                            txt_Nombre_Empresa.Text = "";
                            txt_Nombre_Sede_Empresa.Text = "";
                            txt_Oferta.Text = "";
                            txt_Texto_Anuncio.Text = "";
                            txt_ID_PQRSD.Text = "";
                            txt_Codigo_Vacante.Text = "";
                            txt_Codigo_Vacante.Focus();
                            txt_Email_destino.Text = "";

                            // Agregada 23 de febrero del 2015 --------------------------------


                            txt_Asunto.Text = "";

                            // -----------------------------------


                            // Hasta aquí agregado 19 de febrero del 2015


                            /* Deshabilitado 19 de febrero del 2015

                              if (DSRegistroActualizacVacantes.Tables.Count > 0)
                              {
                                  if (DSRegistroActualizacVacantes.Tables[0].Rows.Count == 1)
                                  {
                                      DataTable dttabla_registroActVacantes = DSRegistroActualizacVacantes.Tables[0];
                                      DataRow drfilaactvacantes = dttabla_registroActVacantes.Rows[0];

                                      // Voy aquí - 15 de febrero 8:26 p.m.
                                      //enviarcorreo(txtemail.Text, "" ,drresp["respuesta"].ToString(), "RedEmpleo: Información Importante - Cambio de Contraseña");
                                  }
                              }

                              // VOY AQUÍ. 13 DE FEBRERO 6:20 P.M.
                             * 
                             * */

                        }

                        catch (Exception ex)
                        {
                            LblError4.Text = ex.Message;
                        }






                    }    // Hasta aquí va: if (msgActualizar_Fecha == DialogResult.Yes)



                }


                else
                {
                    //msg.Value = "No se actualizarán las fechas de la vacante";
                    //Lbl_Valid_al_actualizar.Text = "No se actualizarán las fechas de la vacante";
                    CuadroMensConsultAct.Value = "No se actualizarán las fechas de la vacante";
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

            // Llave deshabilitada 23 de febrero del 2015 - 12:15 p.m.
            //}

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

        }

        protected void txt_Codigo_Vacante_TextChanged(object sender, EventArgs e)
        {

        }

        protected void msg_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}