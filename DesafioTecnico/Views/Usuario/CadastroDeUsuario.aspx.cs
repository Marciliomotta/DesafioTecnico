using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Usuario.Controller;
using Usuario.Models;
using Utils;

namespace DesafioTecnico.Views.Usuario
{
    public partial class CadastroDeUsuario : System.Web.UI.Page
    {
        public List<string> Telefones
        {
            get
            {
                return ViewState["Telefones"] as List<string>;
            }
            set { ViewState["Telefones"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Telefones = new List<string>();
                ddlPerfilLoad();
            }

        }

        private void ddlPerfilLoad()
        {
            ddlPerfil.DataSource = SqlDataSource_Perfil;
            ddlPerfil.DataTextField = "DESCRICAO";
            ddlPerfil.DataValueField = "ID";
            ddlPerfil.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtTelefone.Text.IsNullOrWhiteSpace())
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                       @"javascript:Swal.fire({icon: 'error',title: 'O telefone precisa ser informado', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 1000});", true);
                return;
            }

            Telefones.Add(txtTelefone.Text);
            txtTelefone.Text = String.Empty;
            ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                  @"javascript:Swal.fire({icon: 'success',title: 'Telefone adicionado com sucesso', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 1000});", true);
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                Telefones.Clear();
                txtTelefone.Text = String.Empty;

                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                      @"javascript:Swal.fire({icon: 'success',title: 'Lista de contatos limpada com sucesso', allowEscapeKey: false, allowOutsideClick: false, showConfirmButton: false, timer: 1000});", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            String erro = validarDados();

            if (erro != "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                       @"javascript:Swal.fire({icon: 'error',title: 'ERRO NO CADASTRO', allowEscapeKey: false, allowOutsideClick: false,
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

                M_Contato contato = new M_Contato();
                foreach (var telefone in Telefones)
                {
                    contato.telefone = telefone;
                    model.contatos.Add(contato);
                }

                model.endereco.cep = txtCep.Text;
                model.endereco.logradouro = txtlogradouro.Text;
                model.endereco.complemento = txtComplemento.Text;
                model.endereco.numero = txtNumero.Text;
                model.endereco.cidade = txtCidade.Text;
                model.endereco.estado = txtEstado.Text;
                model.endereco.pais = txtPais.Text;

                controller.Cadastrar(model);

                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
               @"javascript:Swal.fire({icon: 'success',title: 'Usuário Cadastrado com sucesso', allowEscapeKey: false, allowOutsideClick: false, " +
               "}).then((result) => {if (result.value){window.location = '" + ResolveClientUrl("Listagem.aspx") + "';}});", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
                                          string.Format(@"javascript:Swal.fire({icon: 'error',title: 'ERRO NO CADASTRO', allowEscapeKey: false, allowOutsideClick: false,
                                                html: '<b>Detalhes: </b> {0}'});", ex.Message), true);
            }
        }

        private string validarDados()
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
            if (Telefones.Count == 0)
            {
                erro += "<li>Necessário informar, ao menos, um financiador!</li>";
            }
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
    }
}