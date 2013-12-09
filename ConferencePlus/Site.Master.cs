using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConferencePlus
{
	public partial class SiteMaster : MasterPage
	{
		private const string AntiXsrfTokenKey = "__AntiXsrfToken";
		private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
		private string antiXsrfTokenValue;

		protected void Page_Init(object sender, EventArgs e)
		{
			// The code below helps to protect against XSRF attacks
			HttpCookie requestCookie = Request.Cookies[AntiXsrfTokenKey];
			Guid requestCookieGuidValue;
			if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
			{
				// Use the Anti-XSRF token from the cookie
				antiXsrfTokenValue = requestCookie.Value;
				Page.ViewStateUserKey = antiXsrfTokenValue;
			}
			else
			{
				// Generate a new Anti-XSRF token and save to the cookie
				antiXsrfTokenValue = Guid.NewGuid().ToString("N");
				Page.ViewStateUserKey = antiXsrfTokenValue;

				HttpCookie responseCookie
					= new HttpCookie(AntiXsrfTokenKey)
					{
						HttpOnly = true,
						Value = antiXsrfTokenValue
					};
				
				if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
				{
					responseCookie.Secure = true;
				}

				Response.Cookies.Set(responseCookie);
			}

			Page.PreLoad += master_Page_PreLoad;
		}

		protected void master_Page_PreLoad(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Set Anti-XSRF token
				ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
				ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? string.Empty;
			}
			else
			{
				// Validate the Anti-XSRF token
				if (ViewState[AntiXsrfTokenKey].ToString() != antiXsrfTokenValue ||
					ViewState[AntiXsrfUserNameKey].ToString() != ( Context.User.Identity.Name ?? string.Empty ))
				{
					throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
				}
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Roles.RoleExists("Admin"))
			{
				Roles.CreateRole("Admin");
			}

			if (!Roles.RoleExists("Member"))
			{
				Roles.CreateRole("Member");
			}

			if (!Roles.IsUserInRole("jortega", "Admin"))
			{
				Roles.AddUserToRole("jortega", "Admin");
			}

			if (!Roles.IsUserInRole("kescobar", "Admin"))
			{
				Roles.AddUserToRole("kescobar", "Admin");
			}

			if (!Roles.IsUserInRole("jduverge", "Admin"))
			{
				Roles.AddUserToRole("jduverge", "Admin");
			}

			if (!Roles.IsUserInRole("jortega", "Member"))
			{
				Roles.AddUserToRole("jortega", "Member");
			}

			if (!Roles.IsUserInRole("kescobar", "Member"))
			{
				Roles.AddUserToRole("kescobar", "Member");
			}

			if (!Roles.IsUserInRole("jduverge", "Member"))
			{
				Roles.AddUserToRole("jduverge", "Member");
			}
		}

		protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
		{
			Context.GetOwinContext().Authentication.SignOut();
		}
	}
}