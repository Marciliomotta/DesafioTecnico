using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Usuario.Controller;
using Usuario.Models;
using Utils;

namespace DesafioTecnico.Views.Usuario
{
    public partial class Detalhar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarDados();
        }

        private void CarregarDados()
        {
            try
            {
                if (Request.QueryString["uid"] != null)
                {
                    var usuarioID = Criptografia.MostrarParametros(Request.QueryString["uid"]);
                    CarregarUsuario(Convert.ToInt32(usuarioID));
                }
                throw new Exception("Os parâmetros não foram passados corretamente. Favor acessar a consulta de Prestação de Contas novamente!");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                 @"javascript:Swal.fire({icon: 'error',title: 'Erro carregar dados', allowEscapeKey: false, allowOutsideClick: false, " +
                 "html: '<b>Detalhes:</b> " + ex.Message + "'}).then((result) => {if (result.value){window.location = '../../Default';}});", true);
            }
        }

        private void CarregarUsuario(int usuarioID)
        {
            try
            {
                C_Usuario controller = new C_Usuario();
                M_Usuario model = controller.BuscarPorID(usuarioID);

                if (model != null)
                {

                }
                throw new Exception("Usuário não encontrado");
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}