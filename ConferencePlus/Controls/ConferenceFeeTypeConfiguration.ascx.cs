using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConferencePlus.Controls;
using ConferencePlus.Base;
using ConferencePlus.Entities.ExtensionMethods;

namespace ConferencePlus.Controls
{
    public partial class ConferenceFeeTypeConfiguration : BaseControl
    {

        public int ConferenceFeeId
        {
            get
            {
                if (ViewState["ConferenceFeeId"] == null)
                {
                    ViewState["ConferenceFeeId"] = 0;
                }
                return (int)ViewState["ConferenceFeeId"];
            }
            set { ViewState["ConferenceFeeId"] = value; }
        }

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

        }

        public bool SaveControl()
        {
            return false;
        }
    }
}