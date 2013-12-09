using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConferencePlus.Base;

namespace ConferencePlus.Controls
{
    public partial class ConferenceConfiguration : BaseControl
    {

        public bool EditOption
        {
            get
            {
                if (ViewState["EditOption"] == null)
                {
                    ViewState["EditOption"] = false;
                }
                return (bool)ViewState["EditOption"];
            }
            set { ViewState["EditOption"] = value; }
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