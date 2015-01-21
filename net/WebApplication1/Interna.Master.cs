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

namespace WebApplication1
{
    public partial class Interna : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string entra;
            try
            {
                entra = Session["PER_Codigo"].ToString();
                if (entra != "2")
                {
                    Response.Redirect("index.aspx");
                }
            }
            catch
            {
                Response.Redirect("index.aspx");

            }
        }

        protected void btnexit_Click(object sender, EventArgs e)
        {
            Session["PER_Codigo"] = 0;
            Response.Redirect("index.aspx");

        }

        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuOPE.aspx");
        }
    }
}
