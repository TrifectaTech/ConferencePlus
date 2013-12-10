using System;
using System.Web.Security;
using ConferencePlus.Entities.Common;

namespace ConferencePlus.Base
{
    public class BaseControl : System.Web.UI.UserControl
    {
        public string Username
        {
            get
            {
                return Page.User.Identity.Name;
            }
        }

        public Guid UserId
        {
            get
            {
                var membershipUser = Membership.GetUser(Username);
                if (membershipUser != null && membershipUser.ProviderUserKey != null)
                {
                    Guid userId = Guid.Parse(membershipUser.ProviderUserKey.ToString());

                    return userId;
                }

                return Guid.Empty;
            }
        }

        public EnumUserControlMode UserControlMode
        {
            get
            {
                if (ViewState["UserControl_Mode"] == null)
                {
                    ViewState["UserControl_Mode"] = EnumUserControlMode.None;
                }
                return (EnumUserControlMode)ViewState["UserControl_Mode"];
            }
            set { ViewState["UserControl_Mode"] = value; }
        } 

    }
}