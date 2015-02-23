using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class OpcionesUsuariEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Opc_Usuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Frm_Usuario.aspx");
        }

        protected void btn_Opc_Empresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Frm_Empresa.aspx");
        }
    }
}