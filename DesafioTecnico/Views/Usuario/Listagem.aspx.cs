using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Usuario.Controller;
using Utils;

namespace DesafioTecnico.Views.Usuario
{
    public partial class Listagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gvUsuariosLoad();
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

        protected void GvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(GvUsuarios.SelectedDataKey.Value);

            Response.Redirect(string.Concat("Detalhar?uid=", Criptografia.EsconderParametros(id.ToString())));
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent);
                var id = Convert.ToInt32(GvUsuarios.DataKeys[Row.RowIndex].Values[0].ToString());

                C_Usuario controller = new C_Usuario();

                controller.DeletarUsuario(id);

                gvUsuariosLoad();
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                  @"javascript:Swal.fire({icon: 'success',title: 'Usuario excluido com sucesso', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 1000});", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                          string.Format(@"javascript:Swal.fire({icon: 'error',title: 'ERRO NO EXCLUIIR', allowEscapeKey: false, allowOutsideClick: false,
                                                html: '<b>Detalhes: </b> {0}'});", ex.Message), true);
            }
        }
    }
}