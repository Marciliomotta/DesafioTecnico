<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhar.aspx.cs" Inherits="DesafioTecnico.Views.Usuario.Detalhar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCss" runat="server">
    <link href="<%= ResolveClientUrl("~/Content/vendors/select2/select2.css") %>" rel="stylesheet" />
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
                            <h3>Detalhar Usuário</h3>
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
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Senha </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtSenha" runat="server" class="form-control"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtcpf" runat="server" class="form-control"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtDataNascimento" runat="server" TextMode="Date" class="form-control "></asp:TextBox>
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
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3 col-12">
                                                <asp:Button ID="btnAlterarDadosPessoais" runat="server" OnClick="btnAlterarDadosPessoais_Click"
                                                    class="btn btn-primary me-1 mb-1" Text="Alterar Dados Pessoais" />
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
                                <asp:Panel ID="pnData" runat="server">
                                    <div class="card-body">

                                        <asp:GridView ID="gvContatos" class="display table-responsive table"
                                            runat="server" GridLines="None" FooterStyle-Font-Bold="true"
                                            AutoGenerateColumns="False" ShowFooter="false" DataKeyNames="ID">
                                            <Columns>
                                                <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnExcluir" runat="server" Text="Deletar" OnClick="btnExcluir_Click" OnClientClick="javascript: if (confirm('DESEJA APAGAR O TELEFONE ??')) { LoadingButton(this.id) } else { return false }; void('')"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>

                                        <div class="clear"></div>
                                        <div class="row">
                                            <div class="col-12">
                                                <label for="email-id-icon">Adicionar Telefone: </label>
                                                <div class="position-relative">
                                                    <asp:TextBox ID="txtTelefone" runat="server" class="form-control"></asp:TextBox>
                                                    <div class="form-control-icon">
                                                        <i class="bi bi-senha"></i>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3 col-12">
                                                <asp:Button ID="btnAdicionar" runat="server" OnClick="btnAdicionar_Click"
                                                    class="btn btn-success me-1 mb-1" Text="Adicionar" />
                                            </div>
                                        </div>
                                        <div class="display-none">
                                            <asp:SqlDataSource ID="SqlDataSource_Contatos" runat="server"
                                                ConnectionString="<%$ ConnectionStrings:CadastroUsuarioConnectionString %>"
                                                SelectCommand="SELECT ID, TELEFONE 
                                                               FROM CONTATO
                                                               WHERE USUARIOID = @UserID">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="UserID" PropertyName="Value" Name="UserID"></asp:ControlParameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                        </div>
                                        <asp:HiddenField ID="UserID" runat="server" />
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="pnNoData" runat="server" Visible="false" CssClass="alert alert-warning">
                                    <asp:Literal ID="lblNoData" runat="server"></asp:Literal>
                                </asp:Panel>
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
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">CEP </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtCep" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Logradouro </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtlogradouro" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Complemento </label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtComplemento" runat="server" class="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="form-group has-icon-left">
                                                    <label for="email-id-icon">Número</label>
                                                    <div class="position-relative">
                                                        <asp:TextBox ID="txtNumero" runat="server" class="form-control"></asp:TextBox>
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

                                        </div>

                                        <div class="row">
                                            <div class="col-md-3 col-12">
                                                <asp:Button ID="btnAlterarDadosEndereco" runat="server" OnClick="btnAlterarDadosEndereco_Click"
                                                    class="btn btn-primary me-1 mb-1" Text="Alterar Dados Endereço" />
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
</asp:Content>
