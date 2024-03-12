<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="DesafioTecnico.Views.Usuario.Listagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCss" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpnGeral" runat="server">
        <ContentTemplate>
            <div class="page-heading">
                <div class="page-title">
                    <div class="row">
                        <div class="col-12 col-md-6 order-md-1 order-last">
                            <h3>Listagem de Usuário</h3>
                            <p class="text-subtitle text-muted">Usuários Cadastrados</p>
                        </div>
                    </div>
                </div>

                <section class="section">

                    <div class="card">

                        <asp:Panel ID="pnData" runat="server">
                            <div class="card-header">
                            </div>
                            <div class="card-body">

                                    <asp:GridView ID="GvUsuarios" class="display table-responsive table"
                                        runat="server" GridLines="None" FooterStyle-Font-Bold="true" 
                                        AutoGenerateColumns="False" ShowFooter="false" DataKeyNames="ID">
                                        <Columns>
                                            <asp:BoundField DataField="NOME" HeaderText="Nome" />
                                            <asp:BoundField DataField="CPF" HeaderText="CPF" />
                                            <asp:BoundField DataField="EMAIL" HeaderText="Email" />
                                            <asp:BoundField DataField="Perfil" HeaderText="Perfil" />
                                            <asp:BoundField DataField="dataCriacao" HeaderText="Criado em:" DataFormatString="{0:dd/MM/yyyy}" />
                                        </Columns>
                                    </asp:GridView>

                                <div class="display-none">
                                    <asp:SqlDataSource ID="SqlDataSource_Usuarios" runat="server"
                                        ConnectionString="<%$ ConnectionStrings:CadastroUsuarioConnectionString %>"
                                        SelectCommand="SELECT 
	                                                        USUARIO.id
	                                                        ,NOME
	                                                        ,cpf
	                                                        ,email
	                                                        ,perfil.descricao perfil
	                                                        ,dataCriacao
                                                        FROM Usuario
                                                        INNER JOIN Perfil
	                                                        ON Usuario.perfil = PERFIL.id"></asp:SqlDataSource>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnNoData" runat="server" Visible="false" CssClass="alert alert-warning">
                            <asp:Literal ID="lblNoData" runat="server"></asp:Literal>
                        </asp:Panel>
                    </div>
                </section>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
