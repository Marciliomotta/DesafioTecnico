<%@ Page Title="Painel de Informações" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PortalWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCss" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-heading">
        <h3>Desafio Técnico - CRUD .NET</h3>
    </div>
    <div class="page-content">

        <div class="card">
            <div class="card-header">
                <h4 class="card-title">Avaliação Técnica - Criação de Aplicação Web + Integração com Banco de Dados com .NET.</h4>
            </div>
            <div class="card-body px-3 py-4-5">
                <div class="row">
                    <div class="col-md-4">
                        <h3>Repositório</h3>
                        <p>
                            O projeto foi versionado com o uso do GitHub e encontra-se disponível para consulta e sugestões de melhorias.
                        </p>
                        <p>
                            <a class="btn btn-default" href="https://github.com/Marciliomotta/DesafioTecnico">Acessar&raquo;</a>
                        </p>
                    </div>
                    <div class="col-md-4">
                        <h3>Tecnologias utilizadas</h3>
                        <p>
                            Para a construção do projeto foi utilizado: WebForms, ADO, SQL Server Database entre outras.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
