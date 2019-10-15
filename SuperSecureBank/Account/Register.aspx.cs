	System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using SuperSecureBank.Properties;

namespace SuperSecureBank.Account
{
	public partial class Register : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void CreateUserButton_Click(object sender, EventArgs e)
		{
			try
			{
                if (!string.IsNullOrEmpty(User.Text))
                {
                        Int64 userID = UserMgmt.CreateUser(UserI.Text, Email.Text, Passwd.Text);
                          Response.Cookies[Settings.Default.SessionCookieKey].Value = UserMgmt.CreateSession(userID).ToString();

                            string continueUrl = Request.QueryString["ReturnUrl"];
                            if (String.IsNullOrEmpty(continueUrl))
                            {
                                continueUrl = "~/";
                            }
                        }
                        else
                        {
                            Console.Writeline(userID);
                        }
                    }
                    else
                    {
                        Console.Writeline("A user with that username already exists");
                    }
                }
			}
			catch (Exception ex)
			{
				ErrorLogging.AddException("Error in Register", ex);
				ErrorMessage.Text = ex.ToString();
			}
		}

}
