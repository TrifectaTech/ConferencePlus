using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConferencePlus.Base;
using ConferencePlus.Business.NonPersistent;
using Telerik.Web.UI;

namespace ConferencePlus.Account
{
    public partial class SearchRegisteredEvents : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitle.Text = Page.Title;
            }
        }

        protected void grdRegisteredEvents_OnItemDataBound(object sender, GridItemEventArgs e)
        {

        }

        protected void grdRegisteredEvents_OnNeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                grdRegisteredEvents.DataSource = ConferenceEventsViewManager.LoadByUserId(UserId).ToList();
            }
        }

        protected void btnExportToCsv_OnClick(object sender, EventArgs e)
        {
            grdRegisteredEvents.MasterTableView.ExportToCSV();
        }
    }
}