using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConferencePlus.Business.NonPersistent;
using Telerik.Web.UI;
using ConferencePlus.Base;

namespace ConferencePlus.Admin
{
    public partial class PaperStatistics : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdStatistics_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                grdStatistics.DataSource = PaperStatisticsViewManager.LoadAll();
            }
        }

        protected void btnExportCSV_OnClick(object sender, EventArgs e)
        {
            grdStatistics.MasterTableView.ExportToCSV();
        }
    }
}