using Microsoft.Ajax.Utilities;
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
                    return;
                }
                throw new Exception("Os parâmetros não foram passados corretamente. Favor acessar a Listagem novamente!");
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

                if (model == null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                ddlPerfilLoad();


                UserID.Value = usuarioID.ToString();
                gvUsuariosLoad();

                txtNome.Text = model.nome ;
                txtEmail.Text = model.email;
                txtSenha.Text = model.senha;
                txtcpf.Text = model.cpf;
                txtDataNascimento.Text = model.dataNascimento.Date.ToString("yyyy-MM-dd");
                ddlPerfil.SelectedValue = model.perfil.ID.ToString();


                txtCep.Text = model.endereco.cep;
                txtlogradouro.Text = model.endereco.logradouro;
                txtComplemento.Text = model.endereco.complemento;
                txtNumero.Text = model.endereco.numero;
                txtCidade.Text = model.endereco.cidade;
                txtEstado.Text = model.endereco.estado;
                txtPais.Text = model.endereco.pais;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ddlPerfilLoad()
        {
            ddlPerfil.DataSource = SqlDataSource_Perfil;
            ddlPerfil.DataTextField = "DESCRICAO";
            ddlPerfil.DataValueField = "ID";
            ddlPerfil.DataBind();
        }
        private void gvUsuariosLoad()
        {
            gvContatos.DataSource = SqlDataSource_Contatos;
            gvContatos.DataBind();

            if (gvContatos.Rows.Count > 0)
            {
                pnData.Visible = true;
                pnNoData.Visible = false;
            }
            else
            {
                pnData.Visible = false;
                pnNoData.Visible = true;

                lblNoData.Text = "<i class='bi bi-exclamation-triangle'></i> Não há Telefones cadastrados...";
            }
        }
        protected void gvContatos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAlterarDadosPessoais_Click(object sender, EventArgs e)
        {
            String erro = validarDadosPessoais();

            if (erro != "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                       @"javascript:Swal.fire({icon: 'error',title: 'ERRO NO EDITAR', allowEscapeKey: false, allowOutsideClick: false,
                                                html: '<b>Possui incoerência em:</b> " + erro + "'}); ", true);
                return;
            }

            try
            {
                C_Usuario controller = new C_Usuario();
                M_Usuario model = new M_Usuario();

                model.nome = txtNome.Text;
                model.email = txtEmail.Text;
                model.senha = txtSenha.Text;
                model.cpf = txtcpf.Text;
                model.dataNascimento = DateTime.Parse(txtDataNascimento.Text);
                model.perfil.ID = Convert.ToInt32(ddlPerfil.SelectedValue);
                model.id = Convert.ToInt32(UserID.Value);

                controller.EditarUsuario(model);

                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
               @"javascript:Swal.fire({icon: 'success',title: 'Dados editados com sucesso', allowEscapeKey: false, allowOutsideClick: false, " +
               "}).then((result) => {if (result.value){window.location = '" + ResolveClientUrl("Listagem.aspx") + "';}});", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                          string.Format(@"javascript:Swal.fire({icon: 'error',title: 'ERRO NO CADASTRO', allowEscapeKey: false, allowOutsideClick: false,
                                                html: '<b>Detalhes: </b> {0}'});", ex.Message), true);
            }
        }

        protected void btnAlterarDadosEndereco_Click(object sender, EventArgs e)
        {
            String erro = validarDadosEndereco();

            if (erro != "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                       @"javascript:Swal.fire({icon: 'error',title: 'ERRO NO EDITAR', allowEscapeKey: false, allowOutsideClick: false,
                                                html: '<b>Possui incoerência em:</b> " + erro + "'}); ", true);
                return;
            }

            try
            {
                C_Usuario controller = new C_Usuario();
                M_Endereco model = new M_Endereco();


                model.cep = txtCep.Text;
                model.logradouro = txtlogradouro.Text;
                model.complemento = txtComplemento.Text;
                model.numero = txtNumero.Text;
                model.cidade = txtCidade.Text;
                model.estado = txtEstado.Text;
                model.pais = txtPais.Text;
                model.usuarioID = Convert.ToInt32(UserID.Value);

                controller.EditarEndereco(model);

                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
               @"javascript:Swal.fire({icon: 'success',title: 'Dados editados com sucesso', allowEscapeKey: false, allowOutsideClick: false, " +
               "}).then((result) => {if (result.value){window.location = '" + ResolveClientUrl("Listagem.aspx") + "';}});", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                          string.Format(@"javascript:Swal.fire({icon: 'error',title: 'ERRO NO EDITAR', allowEscapeKey: false, allowOutsideClick: false,
                                                html: '<b>Detalhes: </b> {0}'});", ex.Message), true);
            }
        }


        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow Row = ((GridViewRow)((Control)sender).Parent.Parent);
                var id = Convert.ToInt32(gvContatos.DataKeys[Row.RowIndex].Values[0].ToString());

                if (gvContatos.Rows.Count < 2)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                            @"javascript:Swal.fire({icon: 'error',title: 'É necessário possuir no mínimo um telefone cadastrado', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 2000});", true);

                    return;
                }

                C_Usuario controller = new C_Usuario();


                controller.DeletarContato(id);

                CarregarUsuario(Convert.ToInt32(UserID.Value));

                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                  @"javascript:Swal.fire({icon: 'success',title: 'Telefone desvinculado com sucesso', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 1000});", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                          string.Format(@"javascript:Swal.fire({icon: 'error',title: 'ERRO NO EDITAR', allowEscapeKey: false, allowOutsideClick: false,
                                                html: '<b>Detalhes: </b> {0}'});", ex.Message), true);
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtTelefone.Text.IsNullOrWhiteSpace())
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                       @"javascript:Swal.fire({icon: 'error',title: 'O telefone precisa ser informado', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 1000});", true);
                return;
            }

            C_Usuario controller = new C_Usuario();
            M_Contato model = new M_Contato();

            model.usuarioID = Convert.ToInt32(UserID.Value);
            model.telefone = txtTelefone.Text;

            controller.CadastrarContato(model);

            txtTelefone.Text = String.Empty;
            CarregarUsuario(Convert.ToInt32(UserID.Value));
            ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                  @"javascript:Swal.fire({icon: 'success',title: 'Telefone adicionado com sucesso', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 1000});", true);
        }

        #region Validação
        private string validarDadosPessoais()
        {
            String erro = "";

            if (!Validador.ValidarNome(txtNome.Text))
            {
                erro += "<li>Nome</li>";
            }
            if (!Validador.ValidarEmail(txtEmail.Text))
            {
                erro += "<li>Email</li>";
            }
            if (txtSenha.Text == "")
            {
                erro += "<li>Senha</li>";
            }
            if (!Validador.ValidarCpf(txtcpf.Text))
            {
                erro += "<li>CPF</li>";
            }
            if (!Validador.ValidarData(txtDataNascimento.Text))
            {
                erro += "<li>Data Nascimento</li>";
            }

            return erro;
        }
        private string validarDadosEndereco()
        {
            String erro = "";

            if (txtCep.Text == "")
            {
                erro += "<li>CEP</li>";
            }
            if (txtlogradouro.Text == "")
            {
                erro += "<li>Logradouro</li>";
            }
            if (txtComplemento.Text == "")
            {
                erro += "<li>Complemento</li>";
            }
            if (txtNumero.Text == "")
            {
                erro += "<li>Número</li>";
            }
            if (txtCidade.Text == "")
            {
                erro += "<li>Cidade</li>";
            }
            if (txtEstado.Text == "")
            {
                erro += "<li>Estado</li>";
            }
            if (txtPais.Text == "")
            {
                erro += "<li>País</li>";
            }


            return erro;
        }
        #endregion

        
    }
}