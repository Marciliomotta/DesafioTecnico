using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Usuario.Controller;

namespace DesafioTecnico.Views.Usuario
{
    public partial class Listagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvUsuariosLoad();
            var controller = new C_Usuario();
            controller.listagem();
        }

        private void gvUsuariosLoad()
        {
            GvUsuarios.DataSource = SqlDataSource_Usuarios;
            GvUsuarios.DataBind();

            if (GvUsuarios.Rows.Count > 0)
            {
                pnData.Visible = true;
                pnNoData.Visible = false;
            }
            else
            {
                pnData.Visible = false;
                pnNoData.Visible = true;

                lblNoData.Text = "<i class='bi bi-exclamation-triangle'></i> Não há usuários cadastrados...";
            }
        }
    }
}