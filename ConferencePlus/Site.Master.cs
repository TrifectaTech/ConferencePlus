using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConferencePlus
{
	public partial class SiteMaster : MasterPage
	{
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
			Session.Abandon();
		}
	}
}