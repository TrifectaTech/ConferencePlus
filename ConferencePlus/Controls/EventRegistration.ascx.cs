using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Entities;
using ConferencePlus.Entities.Common;
using ConferencePlus.Entities.ExtensionMethods;
using Telerik.Web.UI;
using Transaction = ConferencePlus.Entities.Transaction;
using TransactionManager = ConferencePlus.Business.TransactionManager;

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
			LoadFeeTypes();
			LoadPaymentInfo();
			LoadCreditCardTypes();
			LoadStates();

			if (UserControlMode == EnumUserControlMode.Edit)
			{
				LoadFormFromEventId();
			}

			Conference conference = ConferenceManager.Load(ConferenceId);
			if (conference != null)
			{
				rdtpStartDate.MinDate = rdtpEndDate.MinDate = conference.StartDate;
				rdtpStartDate.MaxDate = rdtpEndDate.MaxDate = conference.EndDate;
			}
		}

		public bool Save(out string errorMessage)
		{
			Event eventEntity = LoadEventFromForm();
			Transaction transaction = LoadTransactionFromForm();

			string eventError,  transactionError = string.Empty;

			if (EventManager.Validate(eventEntity, out eventError) &&
			    TransactionManager.Validate(transaction, out transactionError))
			{
				EventManager.Save(eventEntity, out errorMessage);

				if (eventEntity.EventId.HasValue)
				{
					transaction.EventId = eventEntity.EventId.Value;

					TransactionManager.Save(transaction, out errorMessage);
				}
			}
			else
			{
				errorMessage = string.Format("{0}{1}{2}", eventError, StringMethods.BreakTag, transactionError);
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
			lblFeeAdjustment.Text = string.Empty;
			EnumFeeType type = EnumerationsHelper.ConvertFromString<EnumFeeType>(rblFeeType.SelectedValue);

			ConferenceFee conferenceFee;
			txtFee.Value = ConferenceFeeManager.CalculateFee(ConferenceId, type, out conferenceFee).ToDouble();

			if (conferenceFee != null)
			{
				lblFeeAdjustment.Text = conferenceFee.FeeAdjustment.ToFormattedString();
			}
		}

		protected void rcbPaymentInfo_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
		{
			int paymentInfoId;
			if (e.Value.HasValue() && int.TryParse(e.Value, out paymentInfoId))
			{
				PaymentInfo paymentInfo = PaymentInfoManager.Load(paymentInfoId);
				if (paymentInfo != null)
				{
					rcbCreditCardType.SelectedValue = paymentInfo.CreditCardType.ToString();
					txtCreditCardNumber.Text = paymentInfo.CreditCardNumber;
					rdpExpirationDate.SelectedDate = paymentInfo.ExpirationDate;
					txtCCV.Text = paymentInfo.CCV.ToString();
					txtBillingAddress.Text = paymentInfo.BillingAddress;
					txtCity.Text = paymentInfo.BillingCity;
					rcbStates.SelectedValue = paymentInfo.BillingState;
					txtZip.Text = paymentInfo.BillingZip;
				}
			}
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
					rcbFoodPreference.SelectedValue = eventEntity.FoodPreference.ToString();
					txtComments.Text = eventEntity.Comments;

					Transaction transaction = TransactionManager.LoadByEvent(EventId.Value);
					if (transaction != null)
					{
						rblFeeType.SelectedValue = transaction.FeeType.ToString();
						txtFee.Value = transaction.Fee.ToDouble();
						lblFeeAdjustment.Text = transaction.FeeAdjustment.ToFormattedString();

						rcbCreditCardType.SelectedValue = transaction.CreditCardType.ToString();
						txtCreditCardNumber.Text = transaction.CreditCardNumber;
						rdpExpirationDate.SelectedDate = transaction.ExpirationDate;
						txtCCV.Text = transaction.CCV.ToString();
						txtBillingAddress.Text = transaction.BillingAddress;
						txtCity.Text = transaction.BillingCity;
						rcbStates.SelectedValue = transaction.BillingState;
						txtZip.Text = transaction.BillingZip;
					}
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
				rcbFoodPreference.Items.Add(new RadComboBoxItem(foodPreference.ToString(), foodPreference.ToString()));
			}

			rcbFoodPreference.DataBind();

			rcbFoodPreference.Items.Insert(0, new RadComboBoxItem("--SELECT FOOD PREF--", string.Empty));
			rcbFoodPreference.SelectedIndex = 0;
		}

		private void LoadFeeTypes()
		{
			rblFeeType.Items.Clear();

			foreach (EnumFeeType feeType in EnumerationsHelper.GetEnumerationValues<EnumFeeType>(true, true))
			{
				rblFeeType.Items.Add(new ListItem(feeType.ToFormattedString(), feeType.ToString()));
			}

			rblFeeType.DataBind();
			rblFeeType.ClearSelection();
		}

		private void LoadPaymentInfo()
		{
			List<PaymentInfo> paymentInfo = PaymentInfoManager.LoadByUserId(UserId).ToList();

			if (paymentInfo.SafeAny())
			{
				rcbPaymentInfo.DataSource = paymentInfo;
				rcbPaymentInfo.DataTextField = PaymentInfo.DataTextField;
				rcbPaymentInfo.DataValueField = PaymentInfo.DataValueField;
				rcbPaymentInfo.DataBind();
				rcbPaymentInfo.Items.Insert(0, new RadComboBoxItem("--SELECT PAYMENT INFO--", string.Empty));
				rcbPaymentInfo.SelectedIndex = 0;
			}
			else
			{
				pnlPaymentInfo.Visible = false;
			}
		}

		private void LoadCreditCardTypes()
		{
			rcbCreditCardType.Items.Clear();

			foreach (EnumCreditCardType cardType in EnumerationsHelper.GetEnumerationValues<EnumCreditCardType>(true, true))
			{
				rcbCreditCardType.Items.Add(new RadComboBoxItem(cardType.ToFormattedString(), cardType.ToString()));
			}

			rcbCreditCardType.ClearSelection();
		}

		private void LoadStates()
		{
			rcbStates.Items.Add(new RadComboBoxItem("AL"));
			rcbStates.Items.Add(new RadComboBoxItem("AK"));
			rcbStates.Items.Add(new RadComboBoxItem("AZ"));
			rcbStates.Items.Add(new RadComboBoxItem("AR"));
			rcbStates.Items.Add(new RadComboBoxItem("CA"));
			rcbStates.Items.Add(new RadComboBoxItem("CO"));
			rcbStates.Items.Add(new RadComboBoxItem("CT"));
			rcbStates.Items.Add(new RadComboBoxItem("DC"));
			rcbStates.Items.Add(new RadComboBoxItem("DE"));
			rcbStates.Items.Add(new RadComboBoxItem("FL"));
			rcbStates.Items.Add(new RadComboBoxItem("GA"));
			rcbStates.Items.Add(new RadComboBoxItem("HI"));
			rcbStates.Items.Add(new RadComboBoxItem("ID"));
			rcbStates.Items.Add(new RadComboBoxItem("IL"));
			rcbStates.Items.Add(new RadComboBoxItem("IN"));
			rcbStates.Items.Add(new RadComboBoxItem("IA"));
			rcbStates.Items.Add(new RadComboBoxItem("KS"));
			rcbStates.Items.Add(new RadComboBoxItem("KY"));
			rcbStates.Items.Add(new RadComboBoxItem("LA"));
			rcbStates.Items.Add(new RadComboBoxItem("ME"));
			rcbStates.Items.Add(new RadComboBoxItem("MD"));
			rcbStates.Items.Add(new RadComboBoxItem("MA"));
			rcbStates.Items.Add(new RadComboBoxItem("MI"));
			rcbStates.Items.Add(new RadComboBoxItem("MN"));
			rcbStates.Items.Add(new RadComboBoxItem("MS"));
			rcbStates.Items.Add(new RadComboBoxItem("MO"));
			rcbStates.Items.Add(new RadComboBoxItem("MT"));
			rcbStates.Items.Add(new RadComboBoxItem("NE"));
			rcbStates.Items.Add(new RadComboBoxItem("NV"));
			rcbStates.Items.Add(new RadComboBoxItem("NH"));
			rcbStates.Items.Add(new RadComboBoxItem("NJ"));
			rcbStates.Items.Add(new RadComboBoxItem("NH"));
			rcbStates.Items.Add(new RadComboBoxItem("NY"));
			rcbStates.Items.Add(new RadComboBoxItem("NC"));
			rcbStates.Items.Add(new RadComboBoxItem("ND"));
			rcbStates.Items.Add(new RadComboBoxItem("OH"));
			rcbStates.Items.Add(new RadComboBoxItem("OK"));
			rcbStates.Items.Add(new RadComboBoxItem("OR"));
			rcbStates.Items.Add(new RadComboBoxItem("PA"));
			rcbStates.Items.Add(new RadComboBoxItem("RI"));
			rcbStates.Items.Add(new RadComboBoxItem("SC"));
			rcbStates.Items.Add(new RadComboBoxItem("SD"));
			rcbStates.Items.Add(new RadComboBoxItem("TN"));
			rcbStates.Items.Add(new RadComboBoxItem("TX"));
			rcbStates.Items.Add(new RadComboBoxItem("UT"));
			rcbStates.Items.Add(new RadComboBoxItem("VT"));
			rcbStates.Items.Add(new RadComboBoxItem("VA"));
			rcbStates.Items.Add(new RadComboBoxItem("WA"));
			rcbStates.Items.Add(new RadComboBoxItem("WV"));
			rcbStates.Items.Add(new RadComboBoxItem("WI"));
			rcbStates.Items.Add(new RadComboBoxItem("WY"));

			foreach (RadComboBoxItem item in rcbStates.Items)
			{
				item.Value = item.Text;
			}
		}

		private Event LoadEventFromForm()
		{
			return new Event
			{
				Comments = txtComments.Text.TrimSafely(),
				ConferenceId = ConferenceId,
				EndDate = rdtpEndDate.SelectedDate.GetValueOrDefault(),
				FoodPreference = EnumerationsHelper.ConvertFromString<EnumFoodPreference>(rcbFoodPreference.SelectedValue),
				PaperId = int.Parse(rcbPaper.SelectedValue),
				StartDate = rdtpStartDate.SelectedDate.GetValueOrDefault()
			};
		}

		private Transaction LoadTransactionFromForm()
		{
			return new Transaction
			{
				BillingAddress = txtBillingAddress.Text.TrimSafely(),
				BillingCity = txtCity.Text.TrimSafely(),
				BillingState = rcbStates.SelectedValue,
				BillingZip = txtZip.Text.TrimSafely(),
				CCV = txtCCV.Value.GetValueOrDefault().ToInt(),
				CreditCardNumber = txtCreditCardNumber.Text.TrimSafely(),
				CreditCardType = EnumerationsHelper.ConvertFromString<EnumCreditCardType>(rcbCreditCardType.SelectedValue),
				ExpirationDate = rdpExpirationDate.SelectedDate.GetValueOrDefault(),
				Fee = txtFee.Value.GetValueOrDefault().ToDecimal(),
				FeeAdjustment = lblFeeAdjustment.Text.HasValue()
					? EnumerationsHelper.ConvertFromString<EnumFeeAdjustment>(lblFeeAdjustment.Text)
					: (EnumFeeAdjustment?)null,
				FeeType = EnumerationsHelper.ConvertFromString<EnumFeeType>(rblFeeType.SelectedValue),
				TransactionDate = DateTime.Now,
				UserId = UserId
			};
		}
		#endregion
	}
}