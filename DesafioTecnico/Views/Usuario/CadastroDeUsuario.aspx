<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDeUsuario.aspx.cs" Inherits="DesafioTecnico.Views.Usuario.CadastroDeUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCss" runat="server">
    <script src="<%= ResolveUrl("~/Content/vendors/sweetalert2/sweetalert2.all.min.js")%>"></script>
    <script src="<%= ResolveUrl("~/Content/vendors/jquery/jquery.min.js")%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpnGeral" runat="server">
        <ContentTemplate>
            <div class="page-heading">
                <div class="page-title">
                    <div class="row">
                        <div class="col-12 col-md-6 order-md-1 order-last">
                            <h3>Criar Usuário</h3>
                            <p class="text-subtitle text-muted">Adicionar novo usuário</p>
                        </div>
                    </div>
                </div>
                <section class="section">

                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Dados Pessoais </h4>
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
                                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                                                        <div class="form-control-icon">
                                                            <i class="bi bi-envelope"></i>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label>Senha </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label>Cpf </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtcpf" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label>Data Nascimento </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtDataNascimento" runat="server" TextMode="Date" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label>Perfil </label>
                                                    <div class="form-group">
                                                        <asp:DropDownList ID="ddlPerfil" runat="server" class="form-select select2"></asp:DropDownList>
                                                    </div>
                                                </div>
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
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Contato</h4>
                                </div>
                                <div class="card-content">
                                    <div class="card-body">
                                        <div class="form form-vertical">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-group ">
                                                            <label>Telefone </label>
                                                            <div class="position-relative">
                                                                <asp:TextBox ID="txtTelefone" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3 col-12">
                                                        <asp:Button ID="btnAdicionar" runat="server" OnClick="btnAdicionar_Click"
                                                            class="btn btn-success me-1 mb-1" Text="Adicionar" />
                                                        <% if (Telefones.Count != 0)
                                                            { %>
                                                        <asp:Button ID="btnLimpar" runat="server" OnClick="btnLimpar_Click"
                                                            class="btn btn-danger me-1 mb-1" Text="Remover Cadastrados" />
                                                        <%}%>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="control-group margin-left-25">
                                                        <% if (Telefones.Count != 0)
                                                            {%>
                                                        <strong>Telefones:</strong>

                                                        <ul>
                                                            <% foreach (var aux in Telefones)
                                                                {  %>
                                                            <li>
                                                                <strong><%=aux%></strong>

                                                            </li>
                                                            <%} %>
                                                        </ul>
                                                        <%}%>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                                                <div class="form-group ">
                                                    <label>CEP </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtCep" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group ">
                                                    <label>Logradouro </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtlogradouro" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group ">
                                                    <label>Complemento </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtComplemento" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group ">
                                                    <label>Número</label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtNumero" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group ">
                                                    <label>Cidade</label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtCidade" runat="server" class="form-control"></asp:TextBox>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group ">
                                                    <label>Estado </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtEstado" runat="server" class="form-control"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group ">
                                                    <label>País </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtPais" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            <div class="col-md-3 col-12">
                                                <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click"
                                                    class="btn btn-primary me-1 mb-1" Text="Cadastrar" />
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
</asp:Content>
