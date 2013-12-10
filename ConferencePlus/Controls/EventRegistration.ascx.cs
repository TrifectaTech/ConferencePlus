using System;
using System.Collections.Generic;
using System.Linq;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Entities;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;
using Telerik.Web.UI;

namespace ConferencePlus.Controls
{
	public partial class EventRegistration : BaseControl
	{
		public int ConferenceId
		{
			get { return (int)( ViewState["CurrentConferenceId"] ?? -1 ); }
			set { ViewState["CurrentConferenceId"] = value; }
		}

		public int? EventId
		{
			get { return (int?)ViewState["CurrentEventId"]; }
			set { ViewState["CurrentEventId"] = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public void ReloadControl()
		{
			LoadPapers();
			LoadFoodPreferences();

			if (UserControlMode == EnumUserControlMode.Edit)
			{
				LoadFormFromEventId();
			}
		}

		public bool Save(out string errorMessage)
		{
			if (ValidateForm(out errorMessage))
			{

			}

			return errorMessage.IsNullOrWhiteSpace();
		}

		#region Events
		protected void btnContinue_Click(object sender, EventArgs e)
		{
			pnlEventForm.Visible = false;
			pnlTransactionForm.Visible = true;
		}

		protected void btnGoBack_Click(object sender, EventArgs e)
		{
			pnlEventForm.Visible = true;
			pnlTransactionForm.Visible = false;
		}

		protected void rblFeeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			CalculateFee();
		}

		protected void rblFeeAdjustment_SelectedIndexChanged(object sender, EventArgs e)
		{
			CalculateFee();
		}
		#endregion

		#region Helper Methods
		private void LoadFormFromEventId()
		{
			if (EventId.HasValue)
			{
				Event eventEntity = EventManager.Load(EventId.Value);
				if (eventEntity != null)
				{
					rdtpStartDate.SelectedDate = eventEntity.StartDate;
					rdtpEndDate.SelectedDate = eventEntity.EndDate;
					rcbPaper.SelectedValue = eventEntity.PaperId.ToString();
					rcbFoodPreference.SelectedValue = ( (int)eventEntity.FoodPreference ).ToString();
					txtComments.Text = eventEntity.Comments;
				}
			}
		}

		private void LoadPapers()
		{
			List<Paper> papers = PaperManager.LoadByUserId(UserId).OrderBy(p => p.DisplayName).ToList();

			bool noPapers = !papers.SafeAny();

			pnlNoPaper.Visible = noPapers;
			pnlEventForm.Visible = !noPapers;
			pnlTransactionForm.Visible = false;

			rcbPaper.DataSource = papers;
			rcbPaper.DataTextField = Paper.DataTextField;
			rcbPaper.DataValueField = Paper.DataValueField;
			rcbPaper.DataBind();
			rcbPaper.Items.Insert(0, new RadComboBoxItem("--SELECT PAPER--", string.Empty));
			rcbPaper.SelectedIndex = 0;
		}

		private void LoadFoodPreferences()
		{
			rcbFoodPreference.Items.Clear();

			foreach (EnumFoodPreference foodPreference in EnumerationsHelper.GetEnumerationValues<EnumFoodPreference>(true, true))
			{
				rcbFoodPreference.Items.Add(new RadComboBoxItem(foodPreference.ToString(), ( (int)foodPreference ).ToString()));
			}

			rcbFoodPreference.DataBind();

			rcbFoodPreference.Items.Insert(0, new RadComboBoxItem("--SELECT FOOD PREF--", string.Empty));
			rcbFoodPreference.SelectedIndex = 0;
		}

		private bool ValidateForm(out string errorMessage)
		{
			errorMessage = "test";
			return false;
		}

		private void CalculateFee()
		{
			double fee = 0;

			Conference conference = ConferenceManager.Load(ConferenceId);
			if (conference != null)
			{
				fee = (double)conference.BaseFee;

				List<ConferenceFee> conferenceFees = ConferenceFeeManager.LoadOnConferenceId(ConferenceId).ToList();

				if (rblFeeAdjustment.SelectedValue.HasValue())
				{
					EnumFeeAdjustment adjustment = EnumerationsHelper.ConvertFromString<EnumFeeAdjustment>(rblFeeAdjustment.SelectedValue);
					ConferenceFee conferenceFeeAdjustment = conferenceFees.FirstOrDefault(c => c.FeeAdjustment == adjustment);
					if (conferenceFeeAdjustment != null)
					{
						fee *= (double)conferenceFeeAdjustment.Multiplier;
					}
				}

				if (rblFeeType.SelectedValue.HasValue())
				{
					EnumFeeType type = EnumerationsHelper.ConvertFromString<EnumFeeType>(rblFeeType.SelectedValue);
					ConferenceFee conferenceFeeType = conferenceFees.FirstOrDefault(c => c.FeeType == type);
					if (conferenceFeeType != null)
					{
						fee *= (double)conferenceFeeType.Multiplier;
					}
				}
			}

			txtFee.Value = fee;
		}
		#endregion
	}
}