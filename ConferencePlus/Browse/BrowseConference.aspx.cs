using System;
using System.Linq;
using System.Web.Security;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Business.NonPersistent;
using ConferencePlus.Controls;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;
using Telerik.Web.UI;

namespace ConferencePlus.Browse
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
			if (!e.IsFromDetailTable)
			{
				grdConference.DataSource = ConferenceManager.LoadAll().ToList();
			}
		}

		protected void grdConference_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
		{
			switch (e.DetailTableView.Name)
			{
				case "Event":
					int conferenceId = (int)e.DetailTableView.ParentItem.GetDataKeyValue("ConferenceId");
					e.DetailTableView.DataSource = ConferenceEventsViewManager.LoadByConferenceId(conferenceId).ToList();
					break;
			}
		}

		protected void grdConference_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridDataItem)
			{
				GridDataItem item = e.Item as GridDataItem;
				if (item.OwnerTableView.Name.SafeEquals("Event"))
				{
					item.OwnerTableView.CommandItemDisplay
						= Roles.IsUserInRole("Member")
							? GridCommandItemDisplay.Top
							: GridCommandItemDisplay.None;

					Guid userId = (Guid)item.GetDataKeyValue("UserId");
					if (userId != CurrentUserId)
					{
						item.OwnerTableView.Columns.FindByUniqueNameSafe("Edit").Visible = false;
						item.OwnerTableView.Columns.FindByUniqueNameSafe("Delete").Visible = false;
					}
				}
			}
			else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
			{
				if (e.Item.OwnerTableView.Name.SafeEquals("Event"))
				{
					GridEditableItem item = e.Item as GridEditableItem;

					int conferenceId = (int)item.OwnerTableView.ParentItem.GetDataKeyValue("ConferenceId");

					EventRegistration control = item.FindControl(GridEditFormItem.EditFormUserControlID) as EventRegistration;
					if (control != null)
					{
						if (item is GridEditFormInsertItem)
						{
							control.UserControlMode = EnumUserControlMode.Add;
							control.EventId = null;
						}
						else
						{
							control.UserControlMode = EnumUserControlMode.Edit;
							control.EventId = (int)item.GetDataKeyValue("EventId");
						}

						control.ConferenceId = conferenceId;
						control.ReloadControl();
					}
				}
			}
		}

		protected void grdConference_InsertCommand(object sender, GridCommandEventArgs e)
		{
		}

		protected void grdConference_UpdateCommand(object sender, GridCommandEventArgs e)
		{
		}

		protected void grdConference_DeleteCommand(object sender, GridCommandEventArgs e)
		{
		}
	}
}