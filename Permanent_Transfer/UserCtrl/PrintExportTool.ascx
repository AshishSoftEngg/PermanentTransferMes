<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PrintExportTool.ascx.cs"
    Inherits="usercontrols_PrintExportTool" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <script type="text/javascript">
     function PrintPanel(pnl) {


         alert(pnl)

         var panel = pnl;
         var printWindow = window.open('', '', 'height=400,width=800');
         printWindow.document.write('<html><head><title>DIV Contents</title>');
         printWindow.document.write('</head><body >');
         printWindow.document.write(panel.innerHTML);
         printWindow.document.write('</body></html>');
         printWindow.document.close();
         setTimeout(function () {
             printWindow.print();
         }, 500);
         return false;
     }
    </script>
<table width="100%">
<tr>
<td align="right">
<input id="inpHide" type="hidden" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:ImageButton ID="print_button"  runat="server"
                Height="19px" ToolTip="Print" ImageUrl="~/Images/Print.gif" 
                Width="28px" 
                onclick="print_button_Click2"  />
            <asp:ImageButton ID="export_excel" runat="server" Height="19px" ToolTip="Export In Excel"
                ImageUrl="~/images/xls.gif" Width="28px" OnClick="export_excel_Click" />
            <asp:ImageButton ID="export_pdf" runat="server" Height="19px" ToolTip="Export In Pdf"
                ImageUrl="~/Images/Pdf.png" Width="28px" OnClick="export_pdf_Click" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="print_button" />
            <asp:PostBackTrigger ControlID="export_excel" />
            <asp:PostBackTrigger ControlID="export_pdf" />
        </Triggers>
    </asp:UpdatePanel>
    </td>
</tr>
</table>
