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

namespace WebApplication1
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPlaceHolder mpContentPlaceHolder;
            Button mbotonmenu;
            mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("CPHbotones");
            if (mpContentPlaceHolder != null)
            {
                mbotonmenu = (Button)mpContentPlaceHolder.FindControl("btnMenu");
                if (mbotonmenu != null)
                {
                    mbotonmenu.Visible = false;
                }
            }

        }

        protected void btnRespuestasPQRs_Click(object sender, EventArgs e)
        {
            Response.Redirect("Respuestas.aspx");
        }



        protected void btnEmpleador_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Prueb3.aspx");
            Response.Redirect("Form_FechaVacantes.aspx");
        }

    }
}
