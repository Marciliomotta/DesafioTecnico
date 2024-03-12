using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioTecnico.Views.Usuario
{
    public partial class CadastroDeUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlPerfilLoad();
        }

        private void ddlPerfilLoad()
        {
            ddlPerfil.DataSource = SqlDataSource_Perfil;
            ddlPerfil.DataTextField = "DESCRICAO";
            ddlPerfil.DataValueField = "ID"; 
            ddlPerfil.DataBind();
        }
    }
}