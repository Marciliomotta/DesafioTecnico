
using System;
using System.Web.UI;

namespace PortalWeb
{
    public partial class Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GvProjetosRecentesDataBind();
                //GvFaturasRecentesDataBind();
                //GvPcRecentesDataBind();
                //TotalizadorDataBind();
            }
        }

        //private void GvProjetosRecentesDataBind()
        //{
        //    try
        //    {
        //        SqlDataSource_ProjetosRecentes.SelectCommand += string.Format(@" AND F.ID IN (SELECT FINANCIADORID FROM PCP.PCP_REL_USUARIO_FINANCIADOR WHERE USUARIOID = {0}) ORDER BY DATAINICIO DESC", UsuarioLogado.ID.ToString());
        //        GvProjetosRecentes.DataSource = SqlDataSource_ProjetosRecentes;
        //        GvProjetosRecentes.DataBind();

        //        if (GvProjetosRecentes.Rows.Count > 0)
        //        {
        //            pnDataProjetosRecentes.Visible = true;
        //            pnNoDataProjetosRecentes.Visible = false;
        //        }
        //        else
        //        {
        //            pnDataProjetosRecentes.Visible = false;
        //            pnNoDataProjetosRecentes.Visible = true;

        //            lblNoDataProjetosRecentes.Text = "<i class='bi bi-exclamation-triangle'></i> Não há projetos recentes...";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        pnDataProjetosRecentes.Visible = false;
        //        pnNoDataProjetosRecentes.Visible = true;

        //        lblNoDataProjetosRecentes.Text = string.Format("<i class='bi bi-exclamation-triangle'></i> Ocorreu um erro ao carregar os projetos. Detalhes: {0}", ex.Message);
        //    }
        //}

        //private void GvFaturasRecentesDataBind()
        //{
        //    try
        //    {
        //        SqlDataSource_FaturasRecentes.SelectCommand += string.Format(@" AND F.ID IN (SELECT FINANCIADORID FROM PCP.PCP_REL_USUARIO_FINANCIADOR WHERE USUARIOID = {0}) ORDER BY LANC.DATAEMISSAO DESC, CODPRJ DESC", UsuarioLogado.ID.ToString());
        //        GvFaturasRecentes.DataSource = SqlDataSource_FaturasRecentes;
        //        GvFaturasRecentes.DataBind();

        //        if (GvFaturasRecentes.Rows.Count > 0)
        //        {
        //            pnDataFaturasRecentes.Visible = true;
        //            pnNoDataFaturasRecentes.Visible = false;
        //        }
        //        else
        //        {
        //            pnDataFaturasRecentes.Visible = false;
        //            pnNoDataFaturasRecentes.Visible = true;

        //            lblNoDataFaturasRecentes.Text = "<i class='bi bi-exclamation-triangle'></i> Não há faturas emitidas recente...";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        pnDataFaturasRecentes.Visible = false;
        //        pnNoDataFaturasRecentes.Visible = true;

        //        lblNoDataFaturasRecentes.Text = string.Format("<i class='bi bi-exclamation-triangle'></i> Ocorreu um erro ao carregar as faturas. Detalhes: {0}", ex.Message);
        //    }
        //}

        //private void GvPcRecentesDataBind()
        //{
        //    try
        //    {
        //        SqlDataSource_PcRecentes.SelectCommand += string.Format(@" AND F.ID IN (SELECT FINANCIADORID FROM PCP.PCP_REL_USUARIO_FINANCIADOR WHERE USUARIOID = {0}) ORDER BY PC.DATACRIACAO DESC", UsuarioLogado.ID.ToString());
        //        GvPcRecentes.DataSource = SqlDataSource_PcRecentes;
        //        GvPcRecentes.DataBind();

        //        if (GvPcRecentes.Rows.Count > 0)
        //        {
        //            pnDataPcRecentes.Visible = true;
        //            pnNoDataPcRecentes.Visible = false;
        //        }
        //        else
        //        {
        //            pnDataPcRecentes.Visible = false;
        //            pnNoDataPcRecentes.Visible = true;

        //            lblNoDataPcRecentes.Text = "<i class='bi bi-exclamation-triangle'></i> Não há Prestações de Contas emitidas recente...";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        pnDataPcRecentes.Visible = false;
        //        pnNoDataPcRecentes.Visible = true;

        //        lblNoDataPcRecentes.Text = string.Format("<i class='bi bi-exclamation-triangle'></i> Ocorreu um erro ao carregar as Prestações de Contas. Detalhes: {0}", ex.Message);
        //    }
        //}

        //private void TotalizadorDataBind()
        //{
        //    try
        //    {
        //        var ctr = new DA_Projeto();
        //        var model = ctr.Totalizador(UsuarioLogado.ID);

        //        if (model != null)
        //        {
        //            lblValorFinanciado.Text = model.ValorFinanciado.ToString("N2");
        //            lblQtdProjetos.Text = model.QtdProjetos.ToString();
        //            lblQtdProjetosAtivos.Text = model.QtdProjetosAtivos.ToString();
        //            lblQtdPcsFinalizadas.Text = model.QtdPcsFinalizadas.ToString();
        //        }
        //        else
        //        {
        //            throw new Exception("Ocorreu um erro interno ao carregar os dados do financiador. Favor tentar novamente mais tarde!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, GetType(), Guid.NewGuid().ToString(),
        //         @"javascript:Swal.fire({icon: 'error',title: 'Erro carregar dados', allowEscapeKey: false, allowOutsideClick: false, " +
        //         "html: '<b>Detalhes:</b> " + ex.Message + "'});", true);
        //    }
        //}
    
    
    }
}