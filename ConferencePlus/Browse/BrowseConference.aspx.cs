using System;
using ConferencePlus.Base;
using Microsoft.AspNet.Identity;
using Telerik.Web.UI;

namespace ConferencePlus
{
	public partial class BrowseConference : BasePage
	{
		private Guid CurrentUserId
		{
			get
			{
				if (ViewState["CurrentUserId"] == null)
				{
					ViewState["CurrentUserId"] = UserId;
				}
				return (Guid)ViewState["CurrentUserId"];
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void grdConference_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void grdConference_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void grdConference_ItemDataBound(object sender, GridItemEventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void grdConference_InsertCommand(object sender, GridCommandEventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void grdConference_UpdateCommand(object sender, GridCommandEventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void grdConference_DeleteCommand(object sender, GridCommandEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}