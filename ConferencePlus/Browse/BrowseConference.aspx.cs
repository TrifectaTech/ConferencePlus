using System;
using System.Linq;
using System.Web.Security;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Business.NonPersistent;
using ConferencePlus.Controls;
using ConferencePlus.Entities;
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

					Conference conference = ConferenceManager.Load(conferenceId);
					if (conference != null)
					{
						e.DetailTableView.CommandItemDisplay
							= Roles.IsUserInRole("Member") && !conference.IsConferenceEnrollmentExpired
								? GridCommandItemDisplay.Top
								: GridCommandItemDisplay.None;
					}
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
					int conferenceId = (int)item.OwnerTableView.ParentItem.GetDataKeyValue("ConferenceId");
					Conference conference = ConferenceManager.Load(conferenceId);

					Guid userId = (Guid)item.GetDataKeyValue("UserId");

					if (userId != CurrentUserId || (conference != null && conference.IsConferenceEnrollmentExpired))
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

		protected void grdConference_UpdateCommand(object sender, GridCommandEventArgs e)
		{
			GridEditFormItem gridEditFormItem = e.Item as GridEditFormItem;
			if (gridEditFormItem != null)
			{
				EventRegistration control = gridEditFormItem.FindControl(GridEditFormItem.EditFormUserControlID) as EventRegistration;
				if (control != null)
				{
					string errorMessage;
					e.Canceled = !control.Save(out errorMessage);

					if (errorMessage.HasValue())
					{
						AjaxMessageBox(string.Format("Errors while saving:\n{0}", errorMessage));
					}
				}
			}
		}

		protected void grdConference_DeleteCommand(object sender, GridCommandEventArgs e)
		{
			GridDataItem selectedItem = e.Item as GridDataItem;
			if (selectedItem != null && selectedItem.OwnerTableView.Name.SafeEquals("Event"))
			{
				int eventId = (int)selectedItem.GetDataKeyValue("EventId");
				EventManager.Delete(eventId);
			}
		}

		protected void grdConference_ItemCommand(object sender, GridCommandEventArgs e)
		{
			if (e.Item != null)
			{
				string[] commandsToCloseOtherItemsFor = { RadGrid.InitInsertCommandName, RadGrid.EditCommandName };
				if (commandsToCloseOtherItemsFor.Contains(e.CommandName))
				{
					e.Item.OwnerTableView.IsItemInserted = false;
					e.Item.OwnerTableView.ClearChildEditItems();
				}

				if (e.CommandName.Equals(RadGrid.ExpandCollapseCommandName))
				{
					e.Item.OwnerTableView.IsItemInserted = false;
					e.Item.OwnerTableView.ClearChildEditItems();

					if (e.Item is GridDataItem)
					{
						foreach (GridDataItem item in e.Item.OwnerTableView.Items.OfType<GridDataItem>().Where(it => it != e.Item))
						{
							item.Expanded = false;
						}
					}
				}

				if (e.CommandName.Equals(RadGrid.RebindGridCommandName))
				{
					GridTableView table = e.Item.OwnerTableView;
					table.SortExpressions.Clear();
					table.Rebind();
					e.Canceled = true;
				}
			}
		}

		private void AjaxMessageBox(string message)
		{
			RadAjaxPanel1.Alert(message.Replace("<br />", "\n").Replace("<br/>", "\n"));
		}
	}
}