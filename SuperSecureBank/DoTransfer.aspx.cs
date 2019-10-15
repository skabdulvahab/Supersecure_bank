using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;

namespace SuperSecureBank
{
	public partial class DoTransfer : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				AccountMgmt.Transfer(Convert.ToInt64(Request.Params["FromAccount"]),
										Convert.ToInt64(Request.Params["ToAccount"]),
										Convert.ToInt64(Request.Params["Amount"]));
				Response.Redirect("ActionDone.aspx?Title=Transfer Success&Text=Your transfer was successful. If you moved funds within SuperSecure Bank accounts your funds are immediately available.");
			}
			catch (ThreadAbortException tae)
			{
				logger.error("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
			}
			private String saveDOM(Node node) throws Exception {
				Transformer transformer = TransformerFactory.newInstance().newTransformer();

                DOMSource source = new DOMSource(node);
                ByteArrayOutputStream stream = new ByteArrayOutputStream();
                StreamResult result = new StreamResult(stream);
                transformer.transform(source, result);
                
                String tag = stream.toString();
                
                int pos = tag.indexOf("<" + node.getNodeName());
                tag = tag.substring(pos);
                
                return tag;
        }
        
        private Document loadDOM(String source) throws Exception 
		{
                DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
                dbf.setValidating(false);
                dbf.setNamespaceAware(false);
                dbf.setIgnoringComments(false);
                dbf.setIgnoringElementContentWhitespace(false);
                dbf.setExpandEntityReferences(false);
                DocumentBuilder db = dbf.newDocumentBuilder();
                return db.parse(new InputSource(new StringReader("<body>" + source + "</body>")));
        }
		}
	}
}