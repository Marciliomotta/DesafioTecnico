<%@ Page Title="Painel de Informações" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PortalWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCss" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-heading">
        <h3>Painel  de Informações</h3>
    </div>
    <div class="page-content">
        <section class="row">
            <div class="col-12">
                <div class="row">
                    <div class="col-6 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body px-3 py-4-5">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="stats-icon purple">
                                            <i class="iconly-boldWork"></i>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <h6 class="text-muted font-semibold">Projetos Financiados</h6>
                                        <h6 class="font-extrabold mb-0"><asp:Literal ID="lblQtdProjetos" runat="server"></asp:Literal></h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body px-3 py-4-5">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="stats-icon blue">
                                            <i class="iconly-boldDiscount"></i>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <h6 class="text-muted font-semibold">Total Financiado (R$)</h6>
                                        <h6 class="font-extrabold mb-0"><asp:Literal ID="lblValorFinanciado" runat="server"></asp:Literal></h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body px-3 py-4-5">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="stats-icon green">
                                            <i class="iconly-boldWork"></i>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <h6 class="text-muted font-semibold">Projetos Ativos</h6>
                                        <h6 class="font-extrabold mb-0"><asp:Literal ID="lblQtdProjetosAtivos" runat="server"></asp:Literal></h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-6 col-lg-3 col-md-6">
                        <div class="card">
                            <div class="card-body px-3 py-4-5">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="stats-icon red">
                                            <i class="iconly-boldNotification"></i>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <h6 class="text-muted font-semibold">P. Contas sem Aprovação</h6>
                                        <h6 class="font-extrabold mb-0"><asp:Literal ID="lblQtdPcsFinalizadas" runat="server"></asp:Literal></h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <div class="row">
                                    <div class="col-10 float-lg-left">
                                        <h4>Projetos Recentes</h4>
                                    </div>
                                    <div class="col-2 d-flex justify-content-end">
                                        <div class="btn-group mb-1">
                                            <div class="dropdown">
                                                <button type="button" class="btn btn-primary btn-sm dropdown-toggle"
                                                    data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    Ver mais</button>
                                                <div class="dropdown-menu" style="margin: 0px;">
                                                    <a class="dropdown-item" href="~/Projetos/EmAndamento" runat="server">Em andamento</a>
                                                    <a class="dropdown-item" href="~/Projetos/Finalizados" runat="server">Finalizados</a>
                                                    <a class="dropdown-item" href="~/Projetos/ParaExecutar" runat="server">À Executar</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $("#li-painel").addClass('active');
        }
    </script>
</asp:Content>
