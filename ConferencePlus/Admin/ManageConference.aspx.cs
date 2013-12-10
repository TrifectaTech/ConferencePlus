using System;
using System.Linq;
using ConferencePlus.Base;
using ConferencePlus.Controls;
using Telerik.Web.UI;
using ConferencePlus.Business;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Admin
{
    public partial class ManageConference : BasePage
    {
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

        protected void grdConference_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("Conferences"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                ConferenceConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as ConferenceConfiguration;
                if (userControl != null)
                {
                    e.Canceled = !userControl.SaveControl();
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("ConferenceFeeTypes"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                ConferenceFeeTypeConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as ConferenceFeeTypeConfiguration;
                if (userControl != null)
                {
                    e.Canceled = !userControl.SaveControl();
                }
            }
        }

        protected void grdConference_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("Conferences"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                ConferenceConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as ConferenceConfiguration;
                if (userControl != null)
                {
                    userControl.UserControlMode = EnumUserControlMode.Add;
                    if (!(item is GridEditFormInsertItem))
                    {
                        int conferenceId = (int)item.GetDataKeyValue("ConferenceId");
                        userControl.ConferenceId = conferenceId;
                        userControl.UserControlMode = EnumUserControlMode.Edit;
                    }

                    userControl.ReloadControl();
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode && e.Item.OwnerTableView.Name.SafeEquals("ConferenceFeeTypes"))
            {
                GridEditableItem item = e.Item as GridEditableItem;
                ConferenceFeeTypeConfiguration userControl = item.FindControl(GridEditFormItem.EditFormUserControlID) as ConferenceFeeTypeConfiguration;
                if (userControl != null)
                {
                    int conferenceId = (int)e.Item.OwnerTableView.ParentItem.GetDataKeyValue("ConferenceId");
                    userControl.ConferenceId = conferenceId;

                    userControl.UserControlMode = EnumUserControlMode.Add;

                    if (!(item is GridEditFormInsertItem))
                    {
                        int conferenceFeeId = (int)item.GetDataKeyValue("ConferenceFeeId");
                        userControl.ConferenceFeeId = conferenceFeeId;
                        userControl.UserControlMode = EnumUserControlMode.Edit;
                    }

                    userControl.ReloadControl();
                }
            }
        }

        protected void grdConference_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            if (e.DetailTableView.Name.SafeEquals("ConferenceFeeTypes"))
            {
                int conferenceId = (int)e.DetailTableView.ParentItem.GetDataKeyValue("ConferenceId");
                e.DetailTableView.DataSource = ConferenceFeeManager.LoadOnConferenceId(conferenceId).ToList();
            }
        }

        protected void grdConference_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            lblmessage.Text = string.Empty;
            GridDataItem item = e.Item as GridDataItem;
            if (item != null && item.OwnerTableView.Name.SafeEquals("Conferences"))
            {
                int conferenceId = (int)item.GetDataKeyValue("ConferenceId");

                if (ConferenceManager.IsValidToRemove(conferenceId))
                {
                    ConferenceManager.Delete(conferenceId);
                }
                else
                {
                    lblmessage.Text = "There is an active Event. Please remove Events before removing Conference.";
                }
            }

            if (item != null && item.OwnerTableView.Name.SafeEquals("ConferenceFeeTypes"))
            {
                int conferenceFeeId = (int)item.GetDataKeyValue("ConferenceFeeId");
                ConferenceFeeManager.Delete(conferenceFeeId);
            }
        }
    }
}