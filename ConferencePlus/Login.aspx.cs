using System;
using System.Web.Security;
using System.Web.UI;

namespace KarzPlus
{
	public partial class Login : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lgnKarzPlus.Focus();
			if (User.Identity.IsAuthenticated)
			{
				Response.Redirect("~/Default.aspx");
			}
		}

		protected void lgnKarzPlus_LoginError(object sender, EventArgs e)
		{
			MembershipUser membershipUser = Membership.GetUser(lgnKarzPlus.UserName);
			lgnKarzPlus.FailureText
				= membershipUser != null && membershipUser.IsLockedOut
					? @"You are locked out. Please contact the administrator."
					: @"Your login attempt was not successful. Please try again.";
		}

	}
}