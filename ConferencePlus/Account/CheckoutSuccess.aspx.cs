using System;
using System.Globalization;
using ConferencePlus.Base;
using ConferencePlus.Business;
using ConferencePlus.Entities;

namespace ConferencePlus.Account
{
    public partial class CheckoutSuccess : BasePage
    {
        public int TransactionId
        {
            get
            {
                int trans = 0;

				if (Session["TransactionId"] != null)
				{
					trans = (int) Session["TransactionId"];
                }

                return trans;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPageFromTransaction(TransactionId);
            }
        }

        private void LoadPageFromTransaction(int transactionId)
        {
            Transaction transaction = TransactionManager.Load(transactionId);

            if (transaction != null)
            {
                Event eventForTransaction = EventManager.Load(transaction.EventId);

                if (eventForTransaction != null)
                {
                    lblEventDate.Text = eventForTransaction.StartDate.ToShortDateString();

                    lblTransactionId.Text = transaction.TransactionId.GetValueOrDefault().ToString(CultureInfo.InvariantCulture);

                    Conference conference = ConferenceManager.Load(eventForTransaction.ConferenceId);

                    if (conference != null)
                    {
                        lblConferenceName.Text = conference.Name;

                        Paper paper = PaperManager.Load(eventForTransaction.PaperId);

                        if (paper != null)
                        {
                            lblPaperName.Text = paper.Name;

                            lblPaperTopic.Text = paper.FormattedPaperCategory;
                        }
                    }
                }
            }
        }
    }
}