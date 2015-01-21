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

using netveloper.DataManager;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConsultaModelos();
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

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
                try
                {
                    if (txtCedula.Text != "")
                    {
                        Entro = "SI";
                        SqlParameter[] param = new SqlParameter[2];
                        param[0] = new SqlParameter("@codigo", SqlDbType.Int);
                        param[0].Value = dplModelos.SelectedValue;
                        param[1] = new SqlParameter("@numero", SqlDbType.VarChar, 50);
                        param[1].Value = txtCedula.Text;
                        MSSQL.Connection("");
                        DataSet DSResp = new DataSet();
                        DSResp = MSSQL.ExecuteDataset(CommandType.StoredProcedure, "ArmarRespuestaNumero", param);
                        MSSQL.Close();
                        if (DSResp.Tables[0].Rows.Count == 1)
                        {
                            DataTable dtresp = DSResp.Tables[0];
                            DataRow drresp = dtresp.Rows[0];
                            lblrespuesta.Text = drresp["respuesta"].ToString();

                        }
                    }

                    if (txtemail.Text != "")
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

                        }
                    }
                    if (Entro == "NO")
                    {
                        lblerror.Text = "Se requiere alguno de los dos campos.";
                    }
                }
                catch (Exception ex)
                {
                    lblerror.Text = ex.Message;
                }
        }
    }
}
