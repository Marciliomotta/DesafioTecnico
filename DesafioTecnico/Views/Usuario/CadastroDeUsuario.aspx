<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDeUsuario.aspx.cs" Inherits="DesafioTecnico.Views.Usuario.CadastroDeUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCss" runat="server">
    <link href="<%= ResolveClientUrl("~/Content/vendors/select2/select2.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpnGeral" runat="server">
        <ContentTemplate>
            <div class="page-heading">
                <div class="page-title">
                    <div class="row">
                        <div class="col-12 col-md-6 order-md-1 order-last">
                            <h3>Criar Usuário</h3>
                            <p class="text-subtitle text-muted">Adicionar novo usuário para acesso ao portal</p>
                        </div>
                    </div>
                </div>
                <section class="section">

                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Dados Pessoais e Acesso</h4>
                        </div>
                        <div class="card-content">
                            <div class="card-body">
                                <div class="form form-vertical">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="first-name-icon">Nome</label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-person"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Email </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-envelope"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Senha </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            
                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">cpf </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtcpf" runat="server" class="form-control m_cpf"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Data Nascimento </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtDataNascimento" runat="server" TextMode="Date" class="form-control m_data"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Perfil </label>
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="ddlPerfil" runat="server" class="form-select select2"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12 d-flex justify-content-end">
                                                <asp:Button ID="btnCadastrar" runat="server"
                                                    class="btn btn-primary me-1 mb-1" Text="Cadastrar" />
                                                <asp:LinkButton ID="lkbtnVoltarListagem" runat="server" PostBackUrl="~/Acesso/ListarUsuarios" ToolTip="Voltar"
                                                    CssClass="btn btn-success me-1 mb-1">Voltar</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="display-none">
                            <asp:SqlDataSource ID="SqlDataSource_Perfil" runat="server"
                                ConnectionString="<%$ ConnectionStrings:CadastroUsuarioConnectionString %>"
                                SelectCommand="SELECT ID, DESCRICAO FROM PERFIL"></asp:SqlDataSource>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Endereço</h4>
                        </div>
                        <div class="card-content">
                            <div class="card-body">
                                <div class="form form-vertical">
                                    <div class="form-body">
                                        <div class="row">

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">CEP </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtCep" runat="server" class="form-control m_cep"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-envelope"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Logradouro </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtlogradouro" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-envelope"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Complemento </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Número</label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="TextBox3" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                    <label for="email-id-icon">Cidade </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtCidade" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                            </div>

                                            <div class="col-12">
                                                    <label for="email-id-icon">Estado </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtEstado" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                            </div> 
                                            
                                            <div class="col-12">
                                                    <label for="email-id-icon">País </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtPais" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-senha"></i>
                                                        </div>
                                                    </div>
                                            </div>
                                            <div class="d-none">
                                                <%--<asp:SqlDataSource ID="SqlDataSource_Financiadores" runat="server"
                                                            ConnectionString="<%$ ConnectionStrings:SaproConnectionString %>"
                                                            SelectCommand="SELECT
	                                                                        F.ID
                                                                           ,F.CPF_CNPJ + ' - ' + F.NOMEFANTASIA AS FINANCIADOR
                                                                        FROM PCP.PCP_USUARIO_PORTAL_FINANCIADOR(NOLOCK) U
                                                                        INNER JOIN PCP.PCP_REL_USUARIO_FINANCIADOR(NOLOCK) UF
	                                                                        ON U.ID = UF.USUARIOID
                                                                        INNER JOIN PROJETO.FINANCIADOR(NOLOCK) F
	                                                                        ON F.ID = UF.FINANCIADORID"></asp:SqlDataSource>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </section>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
    <script src="<%= ResolveClientUrl("~/Content/vendors/select2/select2.js") %>"></script>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $('.m_cep').mask("99999-999");
            $('.m_data').mask("99/99/9999");
            $('.m_cpf').mask("999.999.999-99");

            $(".select2").select2();
        }
    </script>
</asp:Content>
