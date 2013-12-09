using System;
using System.Linq;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Entities;
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

			if (UserControlMode == EnumUserControlMode.Edit)
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
				txtBaseFee.Value = (double)conference.BaseFee;
			}
		}

		private void LoadDdlActivites()
		{
			ddlActivties.DataSource = EnumerationsHelper.GetEnumerationValues<EnumActivityType>(true).ToList();
			ddlActivties.DataBind();
			ddlActivties.Items.Insert(0, new RadComboBoxItem("Select One"));
			ddlActivties.SelectedIndex = 0;

		}

		public bool SaveControl()
		{
			lblError.Text = string.Empty;

			Conference confToSave = new Conference();

			if (UserControlMode == EnumUserControlMode.Edit)
			{
				confToSave = ConferenceManager.Load(ConferenceId);
			}

			confToSave.Name = txtName.Text;
			confToSave.Description = txtDescription.Text;
			confToSave.StartDate = dtStartPicker.SelectedDate.GetValueOrDefault(DateTime.Now);
			confToSave.EndDate = dtEndPicker.SelectedDate.GetValueOrDefault(DateTime.Now);
			confToSave.ActivityType = EnumerationsHelper.ConvertFromString<EnumActivityType>(ddlActivties.SelectedValue);
			if (txtBaseFee.Value.HasValue)
			{
				confToSave.BaseFee = (decimal)txtBaseFee.Value.Value;
			}

			string error;
			bool isValid = ConferenceManager.Save(confToSave, out error);
			lblError.Text = error;

			return isValid;
		}
	}
}