using System;
using ConferencePlus.Base;

namespace ConferencePlus.Controls
{
	public partial class EventRegistration : BaseControl
	{
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
		}
	}
}