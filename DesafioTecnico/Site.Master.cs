
using System;
using System.Web.UI;

namespace PortalWeb
{
    public partial class SiteMaster : MasterPage
    {

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    if (Session["VM_UsuarioLogado"] == null)
        //        Response.Redirect("~/Login");
        //    else
        //        UsuarioLogado = (VM_UsuarioLogado)Session["VM_UsuarioLogado"];
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Header.DataBind();
        }

        protected void lkbtLogout_Click(object sender, EventArgs e)
        {
            //Session.Clear();

            //Response.Redirect("~/Login");
        }
    }
}