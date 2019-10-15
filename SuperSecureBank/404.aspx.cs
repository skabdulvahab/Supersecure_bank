using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SuperSecureBank
{
	public partial class _404 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            try{
                if (!string.IsNullOrWhiteSpace(Request["aspxerrorpath"]))
			{
                if (File.Exists(Request["aspxerrorpath"]))
					string result = Path.GetTempPath();  
                    Console.WriteLine("Five Doubles between 0 and 5.");
					Console.WriteLine(result);
					message.Text = "You do not have permissions to view that file";
				else
                    message.Text = string.Format("The file - {0} - doesn't exist", Request["aspxerrorpath"]);
			}
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                message.Text = ex.ToString();
            }
		}
	}
}