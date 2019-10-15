using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SuperSecureBank
{
	public partial class TransferSuccess : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
    // why does this fix our attribute value problem??
    // <output id="Content"><div><a href="&#10;  ">sdfsdfsdf</a></div></output>
    // X:\jsc.svn\examples\php\PHPWiki\PHPWiki\ApplicationWebService.cs
 
 
    try
    {
        this.InternalEnsureElement();
 
        var s = new DOMSource(this.InternalValue);
        var w = new StringWriter();
 
        var r = new StreamResult(w);
 
        Transformer transformer = TransformerFactory.newInstance().newTransformer();
    }
    catch
    {
        // X:\jsc.svn\examples\javascript\forms\FormsNIC\FormsNIC\ApplicationWebService.cs
 
 
        //Caused by: java.lang.NullPointerException
        //       at org.apache.xml.serializer.ToStream.writeAttrString(ToStream.java:2099)
        //       at org.apache.xml.serializer.ToStream.processAttributes(ToStream.java:2079)
        //       at org.apache.xml.serializer.ToStream.closeStartTag(ToStream.java:2623)
        //       at org.apache.xml.serializer.ToStream.characters(ToStream.java:1410)
        //       at org.apache.xalan.transformer.TransformerIdentityImpl.characters(TransformerIdentityImpl.java:1126)
        //       at org.apache.xml.serializer.TreeWalker.dispatachChars(TreeWalker.java:246)
        //       at org.apache.xml.serializer.TreeWalker.startNode(TreeWalker.java:416)
        //       at org.apache.xml.serializer.TreeWalker.traverse(TreeWalker.java:145)
        //       at org.apache.xalan.transformer.TransformerIdentityImpl.transform(TransformerIdentityImpl.java:390)
        //       at ScriptCoreLibJava.BCLImplementation.System.Xml.Linq.__XNode.InternalFixBeforeAdobt(__XNode.java:77)
        //       ... 25 more
 
        throw;
    }
}

	