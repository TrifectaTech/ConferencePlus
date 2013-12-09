using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Entities;
using ConferencePlus.Entities.ExtensionMethods;
using ConferencePlus.Entities.Common;
using Telerik.Web.UI;

namespace ConferencePlus.Controls
{
    public partial class ConferenceConfiguration : BaseControl
    {

        public int ConferenceId
        {
            get
            {
                if (ViewState["ConferenceId"] == null)
                {
                    ViewState["ConferenceId"] = 0;
                }
                return (int)ViewState["ConferenceId"];
            }
            set { ViewState["ConferenceId"] = value; }
        }   


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ReloadControl()
        {
            LoadDdlActivites();

            if (UserControl_Mode == EnumUserControlMode.Edit)
            {
                LoadConferenceOnConfId(ConferenceId);
            }
        }

        private void LoadConferenceOnConfId(int confId)
        {
            Conference conference = ConferenceManager.Load(confId);

            if (conference != null)
            {
                txtName.Text = conference.Name;
                txtDescription.Text = conference.Description;
                dtStartPicker.SelectedDate = conference.StartDate;
                dtEndPicker.SelectedDate = conference.EndDate;
                ddlActivties.SelectedValue = conference.ActivityType.ToString();
            }
        }

        private void LoadDdlActivites()
        {
            ddlActivties.DataSource = EnumerationsHelper.GetEnumerationValues<EnumActivityType>().ToList();
            ddlActivties.DataBind();
            ddlActivties.Items.Insert(0, new RadComboBoxItem("Select One"));
            ddlActivties.SelectedIndex = 0;

        }

        public bool SaveControl()
        {
            bool isValid;

            lblError.Text = string.Empty;

            Conference confToSave = new Conference();

            if (UserControl_Mode == EnumUserControlMode.Edit)
            {
                confToSave = ConferenceManager.Load(ConferenceId);
            }

            //TODO: Finish save

            return false;
        }
    }
}