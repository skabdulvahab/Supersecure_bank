using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using SuperSecureBank.Properties;

namespace SuperSecureBank.Account
{
	public partial class Login : System.Web.UI.Page
	{
protected void Page_Load(object sender, EventArgs e)
{
	if (null != Request.Cookies[Settings.Default.SessionCookieKey])
	{
		if (0 != UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value))
			Response.Redirect("~/Default.aspx");
	}
}


		protected void LoginButton_Click(object sender, EventArgs e)
		{
            try
            {
                if (UserMgmt.UserExists(UserName.Text))
                {
                    Int64 userID = UserMgmt.CheckUser(UserName.Text, Password.Text);
                    if (0 != userID)
                    {
                        Response.Cookies[Settings.Default.SessionCookieKey].Value = UserMgmt.CreateSession(userID).ToString();

                        this.Response.Redirect(Request.QueryString["ReturnUrl"].ToString());

                        if (String.IsNullOrEmpty(continueUrl))
                        {
                            continueUrl = "~/";
                        }
                        Response.Redirect(continueUrl);
                    }
                    else
                    {
                        FailureText.Text = string.Format("Sorry {0}, that's not the password we have stored in the system. Please try again.", CleanUsername(UserName.Text));
                    }
                }
                else
                {
                    FailureText.Text = string.Format("Sorry, the username {0} doesn't exist in the system", CleanUsername(UserName.Text));
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in Register", ex);
                FailureText.Text = ex.ToString();
            }
		}
		public static string CreateMD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
Private static string ExecuteCommand(string fileName, string arguments)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();

                process.StartInfo = new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = fileName,
                    Arg1 = arguments,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true
                };

                process.Start("FileName", Arg1);

                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                return error;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
		private string CleanUsername(string p)
		{
            p = p.Replace("<script>", "");
			
			return p;
		}
	}
}
