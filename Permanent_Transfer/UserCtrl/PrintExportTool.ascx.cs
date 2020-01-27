using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml.Linq;
using System.Web.UI.HtmlControls;



public partial class usercontrols_PrintExportTool : System.Web.UI.UserControl
{
    public string pnl = "";
   
    public  Panel Mpnl = new Panel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Mpnl.ID = Convert.ToString(ViewState["PanelId"]);
          //  Mpnl.ID = pnl;
        }
    }


    public void Print(string pnl)
    {
        Mpnl.ID = pnl;
        //Session["ctrl"] = Mpnl; 
        //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','_blank');</script>");
        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "PrintPanel();", true);
    }

    public void MyPanel(string PanelId)
    {
        ViewState["PanelId"] = PanelId;
        Mpnl.ID = Convert.ToString(ViewState["PanelId"]);
    }

    public void Pdf(string pnl)
    {
        
        //Mpnl.ID = pnl;
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Work-Progress-Report.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //Mpnl.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();
    }

    public void Excel(string pnl)
    {
        
        Mpnl.ID = pnl;
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Work-Progress-Report.xls");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
        Mpnl.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.End(); 
    }

    protected void export_excel_Click(object sender, ImageClickEventArgs e)
    {
        Excel(Convert.ToString(ViewState["PanelId"]));
    }
    protected void export_pdf_Click(object sender, ImageClickEventArgs e)
    {
        Pdf(Convert.ToString(ViewState["PanelId"]));
    }
  
    protected void print_button_Click2(object sender, ImageClickEventArgs e)
    {
        //Mpnl.ID = pnl;
        //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "PrintPanel();", true);

       // string fileName = "test.aspx";
       // Mpnl.ID = pnl;
        pnl = Convert.ToString(ViewState["PanelId"]);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "PrintPanel('" + pnl + "');", true);
    }
}