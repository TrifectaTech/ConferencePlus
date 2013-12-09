using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConferencePlus.Base;
using ConferencePlus.Controls;
using Telerik.Web.UI;
using ConferencePlus.Business;
using ConferencePlus.Entities.ExtensionMethods;

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
                    if (!(item is GridEditFormInsertItem))
                    {
                        int conferenceId = (int)item.GetDataKeyValue("ConferenceId");
                        userControl.ConferenceId = conferenceId;
                        userControl.EditOption = true;
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

                    if (!(item is GridEditFormInsertItem))
                    {
                        int conferenceFeeId = (int)item.GetDataKeyValue("ConferenceFeeId");
                        userControl.ConferenceFeeId = conferenceFeeId;
                        userControl.EditOption = true;
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
    }
}