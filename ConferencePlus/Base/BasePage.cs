using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ConferencePlus.Base
{
    public class BasePage : System.Web.UI.Page
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

        public bool ConsumeGlobalErrorMessage
        {
            get
            {
                if (Session["ConsumeGlobalErrorMessage"] == null)
                {
                    Session["ConsumeGlobalErrorMessage"] = false;
                }
                return (bool) Session["ConsumeGlobalErrorMessage"];
            }
            set
            {
                Session["ConsumeGlobalErrorMessage"] = value;
            }
        }

        public string GlobalErrorMessage
        {
            get
            {
                return Session["GlobalErrorMessage"] as string;
            }
            set
            {
                Session["GlobalErrorMessage"] = value;
            }
        }

    }
}