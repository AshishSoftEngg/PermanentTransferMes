<%@ Page Title="Permanent Transfer" Language="C#" MasterPageFile="~/BSEBMainMasterPage.master" AutoEventWireup="true" CodeFile="Permanent_Transfer.aspx.cs" Inherits="Payroll_Master_Permanent_Transfer" %>

<%@ Register Src="~/usercontrols/Messagebox.ascx" TagName="Messagebox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pan_rpt.ClientID%>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Monthly  Report</title>');
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
    <style type="text/css">
        
        .auto-style3 {
            width: 117px;
        }

        .auto-style8 {
            width: 156px;
        }

        .auto-style9 {
            width: 81px;
        }

        .auto-style10 {
            width: 94px;
        }

        .auto-style13 {
            width: 117px;
            height: 28px;
        }
                 
        .auto-style19 {
            width: 70%;
        }
        .auto-style20 {
            width: 121px;
        }
        .auto-style21 {
            width: 121px;
            height: 28px;
        }
        .auto-style33 {
            width: 247px;
        }
        .auto-style34 {
            width: 248px;
        }
         
        .auto-style35 {
            width: 250px;
        }
        .auto-style36 {
            width: 245px;
        }
         
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <fieldset>
            <table cellpadding="0" cellspacing="0" style="width: 100%; border-style: solid; border-width: 1px 1px 1px 1px;">
                <tr class="PageHeaddingBox">
                    <td colspan="4" style="text-align: center; border-bottom: solid 1px #666633">
                        <b>Permanent Transfer Claim </b>
                    </td>
                    <uc1:Messagebox runat="server" ID="Messagebox" />
                </tr>
                <tr style="height: 10px" >
                    <td class="auto-style35">
                    <asp:Label ID="lblflage" runat="server" Visible="false"></asp:Label>

                    </td>
                     <td class="auto-style35">
                        &nbsp;</td>
                     <td class="auto-style35">
                        &nbsp;</td>
                     <td class="auto-style35">
                        &nbsp;</td>
                </tr>
                <tr>

                    <td>Financial Year:<asp:Label ID="FinYear" runat="server" ForeColor="Red" Text="*"></asp:Label>&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="lblRecordID" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFinancial" runat="server" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                    </td>
                    <td>GPF/NPS: <span style="color: Red;">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlGpsMps" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGpsMps_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">GPF</asp:ListItem>
                            <asp:ListItem Value="2">NPS</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                   
                </tr>
                 <tr style="height: 10px">
                    <td></td>
                </tr>
                
                <tr>
                      
                    <td>Designation Type: <span style="color: Red;">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlEmpType" runat="server" OnSelectedIndexChanged="ddlEmpType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                    </td>
                    <td>Employee Name: <span style="color: Red;">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddl_emp"  AutoPostBack="true" OnSelectedIndexChanged="ddl_emp_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </td>
                
                    
                </tr>
                 <tr style="height: 10px">
                    <td></td>
                </tr>
                <tr>
                  
                    <td runat="server" id="reimburse" >
                        <label>
                            Advance Ref no.
                        </label>
                    </td>
                    <td>
                    <asp:DropDownList ID="Ddl_advancerefNo"  AutoPostBack="true" runat="server"  OnSelectedIndexChanged="Ddl_advancerefNo_SelectedIndexChanged" ></asp:DropDownList>
                   <asp:Label ID="lblrefno" runat="server" Visible="false"></asp:Label>

                        </td>
                    <td>Advance Amount:<span style="color:red">*</span>&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Label ID="lblamonut" runat="server" Visible="true"></asp:Label>
                    </td>
                </tr>
                 <tr style="height: 10px">
                    <td></td>
                </tr>
            </table>
        </fieldset>
    </div>

    <div>
        <fieldset>
            <table cellpadding="0" cellspacing="0" style="width: 100%; border-style: solid; border-width: 1px 1px 1px 1px;">

                <tr style="height: 10px">
                    <td class="auto-style35">
                        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>

                    </td>
                    <td class="auto-style35">
                        &nbsp;</td>
                    <td class="auto-style36">
                        &nbsp;</td>
                    <td class="auto-style35">
                        &nbsp;</td>

                </tr>
                <tr>
                    <td>Name :  &nbsp;&nbsp;&nbsp;
                          
                    </td>

                    <td>
                        <asp:Label ID="lblShowName" runat="server" Visible="true"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        
                    </td>
                    <td>Corp/Office:</td>
                    <td>
                        <asp:Label ID="lblCorpOffice" runat="server" Visible="true"></asp:Label>
                         <asp:dropdownlist ID="ddlHdtrOffice" runat="server"  Width="150px" Visible="false"></asp:dropdownlist>
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td></td>
                </tr>

                <tr>
                    <td>Personal No :  &nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Label ID="lblPersonalNo" runat="server" Visible="true"></asp:Label>
                    </td>
                    <td>Pay Account :  &nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Label ID="lblPayAccount" runat="server" Visible="true"></asp:Label>
                    </td>


                </tr>
                <tr style="height: 10px">
                    <td></td>
                </tr>
                <tr>                 
                    <td>Pay :  &nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Label ID="lblBasicPay" runat="server" Visible="true"></asp:Label>
                    </td>
                    <td runat="server" id="Td1" visible="false">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="height: 10px">
                    <td></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
    <div>
        <fieldset>
            <table cellpadding="0" cellspacing="0" style="width: 100%; border-style: solid; border-width: 1px 1px 1px 1px;">

                <tr style="height: 10px">
                    <td class="auto-style35">
                        &nbsp;</td>
                    <td class="auto-style35">
                        &nbsp;</td>
                    <td class="auto-style36">
                        &nbsp;</td>
                    <td class="auto-style35">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style35">Transfered From :<span style="color: red">*</span>          
                    </td>
                    <td >
                        <asp:TextBox ID="txtTransferedFrom" runat="server" MaxLength="100" Width="150px" ></asp:TextBox>
                    </td>
                    <td class="auto-style36">Rule in TR/SR :<span style="color: red">*</span></td>
                    <td >
                        <asp:TextBox ID="txtRuleTrSr" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style35"></td>
                </tr>
                <tr>
                    <td class="auto-style35">Reference No :<span style="color: red">*</span>  
                          
                    </td>

                    <td >
                        <asp:TextBox ID="txtReferenceNo" runat="server" MaxLength="30" Width="150px"></asp:TextBox>

                    </td>
                    <td class="auto-style36">Place:<span style="color: red">*</span></td>
                    <td >
                        <asp:TextBox ID="txtPlace" runat="server" MaxLength="150" Width="150px"></asp:TextBox>

                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style35"></td>
                </tr>

                <tr>
                    <td class="auto-style35">Date :<span style="color: red">*</span> </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" onkeypress="return false;" onkeydown="return false;" MaxLength="20" Width="150px"></asp:TextBox>
                       <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>                      
                    </td>
                    <td class="auto-style36">Departure :<span style="color: red">*</span>  </td>
                    <td >
                        <asp:TextBox ID="txtDeparture" runat="server" MaxLength="20" Width="150px"></asp:TextBox>
                    </td>                    
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style35"></td>
                </tr>
                <tr>
                    <td class="auto-style35">Arrival :<span style="color: red">*</span>  </td>
                    <td>
                        <asp:TextBox ID="txtArrival" MaxLength="20" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td runat="server" id="Td2" visible="false" class="auto-style36">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style35"></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <br />
    <div>        
        <fieldset>
            <legend><b><u>Allowance For Adult</u></b></legend>
            <table cellpadding="0" cellspacing="0" style="width: 100%; border-style: solid; border-width: 1px 1px 1px 1px;">

                <tr style="height: 10px">
                    <td class="auto-style34">
                        &nbsp;</td>
                     <td class="auto-style34">
                        &nbsp;</td>
                     <td class="auto-style36">
                         &nbsp;</td>
                     <td class="auto-style34">
                         &nbsp;</td>
                </tr>
                <tr style="text-align:left">
                    <td class="auto-style34">Daily Allowance For Adults :<span style="color: red">*</span>                           
                    </td>
                    <td>
                        <asp:TextBox ID="txtDailyAllAdult" runat="server"  MaxLength="10" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" 
                            TargetControlID="txtDailyAllAdult" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>                                                               
                    </td>
                    <td class="auto-style36">No Of Adult :<span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtNoAdult" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" 
                            TargetControlID="txtNoAdult" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style34"></td>
                </tr>

                <tr>
                    <td class="auto-style34">Days :<span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtAdultdays" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True" 
                            TargetControlID="txtAdultdays" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>    
                     
                    <td class="auto-style36">Amount :<span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtAdultAmount" MaxLength="20" runat="server" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True" 
                            TargetControlID="txtAdultAmount" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>                                                   
                </tr>
                
                <tr style="height: 10px">
                    <td class="auto-style34"></td>
                </tr>
            </table>
       </fieldset>
        <fieldset>
             <legend><b><u>Allowance For Minor</u></b></legend>
            <table cellpadding="0" cellspacing="0" style="width: 100%; border-style: solid; border-width: 1px 1px 1px 1px;">

                <tr style="height: 10px">
                    <td class="auto-style33">
                        &nbsp;</td>
                    <td class="auto-style33">
                        &nbsp;</td>
                    <td class="auto-style36">
                        &nbsp;</td>
                    <td class="auto-style33">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style33">Daily Allowance For Minors :<span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtDailyallownMinors" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" Enabled="True" 
                            TargetControlID="txtDailyallownMinors" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>
                    <td class="auto-style36">No Of Minors :<span style="color: red">*</span>  </td>
                    <td>
                        <asp:TextBox ID="txtNoOfMinors" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" Enabled="True" 
                            TargetControlID="txtNoOfMinors" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td> 
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style33"></td>
                </tr>
                <tr>                  
                    <td class="auto-style33">Days :<span style="color: red">*</span>  </td>
                    <td>
                        <asp:TextBox ID="txtMinorsDays" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" Enabled="True" 
                            TargetControlID="txtMinorsDays" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>

                    </td>                                   
                    <td class="auto-style36">Amount :<span style="color: red">*</span>  </td>
                    <td>
                        <asp:TextBox ID="txtMinorAmount" MaxLength="20" runat="server" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" Enabled="True" 
                            TargetControlID="txtMinorAmount" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>                    
                </tr>                
                <tr style="height: 10px">
                    <td class="auto-style33"></td>
                </tr>
            </table>
        </fieldset>
        
    </div>

    <br />
    <div>
        <fieldset>
             <legend><b><u>Personel Effect</u></b></legend>
            <table cellpadding="0" cellspacing="0" style="width: 100%; border-style: solid; border-width: 1px 1px 1px 1px;">

                <tr style="height: 10px">
                    <td class="auto-style33">
                        &nbsp;</td>
                    <td class="auto-style33">
                        &nbsp;</td>
                    <td class="auto-style33">
                        &nbsp;</td>
                    <td class="auto-style33">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style34">Luggage :<span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtluggage" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" Enabled="True" 
                            TargetControlID="txtluggage" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>
                    <td class="auto-style36">Weight :<span style="color: red">*</span> </td>
                    <td>
                        <asp:TextBox ID="txtWeight" runat="server" MaxLength="10" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" Enabled="True" 
                            TargetControlID="txtWeight" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td> 
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style34"></td>
                </tr>
                <tr>                  
                    <td class="auto-style34">Luggage Conveyance :<span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtLuggageConveyance" MaxLength="10" runat="server" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" Enabled="True" 
                            TargetControlID="txtLuggageConveyance" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>                                   
                    <td class="auto-style36">Cartage-Residence to Booking Office :<span style="color: red">*</span></td>
                    <td>
                        <asp:TextBox ID="txtCartageResBOffice" runat="server" MaxLength="20" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" Enabled="True" 
                            TargetControlID="txtCartageResBOffice" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>                    
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style34"></td>
                </tr>
                <tr>
                    <td class="auto-style34">Cartage-Booking Office to Residence :<span style="color: red">*</span>  &nbsp;&nbsp;&nbsp;</td>
                    <td valign="top">
                        <asp:TextBox ID="txtCartageBookingOfficetoRes" MaxLength="20" runat="server" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" Enabled="True" 
                            TargetControlID="txtCartageBookingOfficetoRes" ValidChars="1234567890." FilterMode="ValidChars"></cc1:FilteredTextBoxExtender>
                    </td>
                    <td runat="server" id="Td5" visible="false" class="auto-style36">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="height: 10px">
                    <td class="auto-style34"></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <div>
                        <fieldset>
                            <legend><b><u>Details of Family Members</u></b></legend>
                            <table style="border-collapse: collapse;" class="auto-style19">

                                <tr style="color: #2D2D2D; text-align:justify; background-color: #08a595; font-size: 12px; font-weight: bold; height: 30px; text-align: center; vertical-align: Bottom">
                                    <th style="text-align: left" class="auto-style10">Name:<span style="color: red">*</span>
                                    </th>
                                    <th style="text-align: left" class="auto-style9">Age:<span style="color: red">*</span>
                                    </th>
                                    <th style="text-align: left" class="auto-style3">Relation:<span style="color: red">*</span>
                                    </th>                                    
                                    <th class="auto-style20"></th>
                                </tr>
                                <tr style="background: #3f96e3;">
                                    <td class="auto-style13">
                                        <asp:TextBox ID="txtfamMemName" MaxLength="100" runat="server" Height="16px" Width="191px" />
                                        
                                    </td>
                                    <td class="auto-style13">                                       
                                        <asp:DropDownList ID="ddlAge"  runat="server"  >
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                             <asp:ListItem Value="1">12 year and above</asp:ListItem>
                                             <asp:ListItem Value="2">Over 3 year and under 12 year</asp:ListItem>
                                             <asp:ListItem Value="3">3 year and below</asp:ListItem>
                                        </asp:DropDownList>                                
                                    </td>
                                    <td class="auto-style13">
                                       <%-- <asp:TextBox ID="txtRelation" MaxLength="50" runat="server" Height="16px" Width="204px" />--%>
                                          <asp:DropDownList ID="ddlRelation"  runat="server"  >
                                              <asp:ListItem Value="0">Select</asp:ListItem>
                                             <asp:ListItem Value="1">Wife</asp:ListItem>
                                             <asp:ListItem Value="2">husband</asp:ListItem>
                                             <asp:ListItem Value="3">Father</asp:ListItem>
                                              <asp:ListItem Value="4">Mother</asp:ListItem>
                                             <asp:ListItem Value="5">Children</asp:ListItem>
                                             <asp:ListItem Value="6">Sister</asp:ListItem>
                                              <asp:ListItem Value="7">Minor Brother</asp:ListItem>                                             
                                          </asp:DropDownList> 
                                    </td>                                    
                                    <td class="auto-style21">
                                        <asp:Button Text="Add" runat="server" ID="AddChild1" OnClick="AddChild1_Click" Width="123px"  />
                                    </td>
                                </tr>
                            </table>
                            <div class="col-sm-12">
                                <asp:GridView ID="Grd1" runat="server" Width="70%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Age" HeaderText="Age" />
                                        <asp:BoundField DataField="Relation" HeaderText="Relation" />                                                                          
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkdelete" runat="server" OnClick="lnkdelete1_Click">
                                                    <asp:Image ID="imgDelete" runat="server" ImageUrl="~/App_Themes/BasicTheme/Images/delete.png" Height="20px"
                                                        Width="20px" OnClientClick="return confirm('Are You Sure To Delete?');" ToolTip="Delete" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </fieldset>
                    </div>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>            
        </table>
    </div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <div>
                        <fieldset>
                            <legend><b><u>Details of Journey</u></b></legend>
                            <table width="100%" style="border-collapse: collapse;">

                                <tr style="color: #2D2D2D; text-align:justify; background-color: #08a595; font-size: 12px;  height: 30px; text-align: center; vertical-align: Bottom">
                                    <th >Journey From:<span style="color: red">*</span>
                                    </th>
                                    <th >Journey To:<span style="color: red">*</span>
                                    </th>
                                    <th >Mode of Conveyance:<span style="color: red">*</span>
                                    </th>
                                    <th >Class:<span style="color: red">*</span>
                                    </th>
                                    <th >Distance:<span style="color: red">*</span>
                                    </th>
                                    <th >Rate:<span style="color: red">*</span>
                                    </th>
                                    <th >Amount.<span style="color: red">*</span>
                                    </th>

                                    <th class="auto-style8"></th>
                                </tr>
                                <tr style="background: #3f96e3;">
                                    <td >
                                        <asp:TextBox ID="txtJourneyFrom" MaxLength="100" runat="server" Height="16px" Width="138px" />
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtJourneyTo"  MaxLength="100" runat="server" Height="16px" Width="92px"  />                                       
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtModeofConveyance" MaxLength="60" runat="server" Height="16px" Width="173px" />
                                    </td>

                                    <td >
                                        <asp:TextBox ID="txtClass" MaxLength="20" runat="server" Height="16px" Width="121px"  />

                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtDistance" MaxLength="10" runat="server" Width="126px" Height="16px"  />
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True"
                                            TargetControlID="txtDistance" ValidChars="1234567890." FilterMode="ValidChars">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtRate" MaxLength="10" runat="server" Width="91px" Height="16px" />
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                            TargetControlID="txtRate" ValidChars="1234567890." FilterMode="ValidChars">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtDoJAmount" MaxLength="10" runat="server" />
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                            TargetControlID="txtDoJAmount" ValidChars="1234567890." FilterMode="ValidChars">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td >
                                        <asp:Button Text="Add" runat="server" ID="Add" OnClick="Add_Click"  />
                                    </td>
                                </tr>
                            </table>
                            <div class="col-sm-12">
                                <asp:GridView ID="Grd" runat="server" Width="100%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="JourneyFrom" HeaderText="JourneyFrom" />
                                        <asp:BoundField DataField="JourneyTo" HeaderText="JourneyTo" />
                                        <asp:BoundField DataField="Mode_of_Conveyance" HeaderText="Mode of Conveyance" />
                                        <asp:BoundField DataField="Class" HeaderText="Class" />
                                        <asp:BoundField DataField="Distance" HeaderText="Distance" />
                                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkdelete" runat="server" OnClick="lnkdelete_Click">
                                                    <asp:Image ID="imgDelete" runat="server" ImageUrl="~/App_Themes/BasicTheme/Images/delete.png" Height="20px"
                                                        Width="20px" OnClientClick="return confirm('Are You Sure To Delete?');" ToolTip="Delete" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </fieldset>
                    </div>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" TabIndex="6"
                        ValidationGroup="btnProcess" />
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" TabIndex="7" /></td>
            </tr>
        </table>


    </div>
    <br />
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:GridView ID="grd_data" runat="server" AutoGenerateColumns="False"
                        Width="100%" TabIndex="9" AllowPaging="true" OnPageIndexChanging="grd_data_PageIndexChanging" OnRowDataBound="grd_data_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>

                                    <asp:LinkButton ID="lnkbtn" runat="server" OnClick="lnk_Click">
                                        <asp:Image ID="imgedit" runat="server" ToolTip="Edit" ImageUrl="~/App_Themes/BasicTheme/Images/edit.png"
                                            Height="20px" Width="20px" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmployeeName" runat="server" Text='<%# Bind("Emp_Name") %>'></asp:Label>
                                    <asp:Label ID="lbltabid" runat="server" Visible="false" Text='<%# Bind("TABID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation Type">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmployeeTypeid" Visible="false" runat="server" Text='<%# Bind("EmpType") %>'></asp:Label>
                                    <asp:Label ID="lbl_designame" Visible="true" runat="server" Text='<%# Bind("des_type_name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="GPS/NPS Type">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_EmployeeType" runat="server" Text='<%# Bind("EmpType") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>--%>

                             <asp:TemplateField HeaderText="Corp/Office" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CorpOffice" runat="server" Text='<%# Bind("CorpOffice") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pay Account" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_PayAccount" runat="server" Text='<%# Bind("PayAccount") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Adv. Refrence No." >
                                <ItemTemplate>
                                    <asp:Label ID="lblrefrenceno" runat="server" Text='<%# Bind("refrence_no") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Advance Amt." >
                                <ItemTemplate>
                                    <asp:Label ID="lbladvanceamt" runat="server" Text='<%# Bind("advance_amt") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Financial Year" >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_fin_year" runat="server" Text='<%# Bind("fin_year") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>
                             
                                                      
                            <asp:TemplateField HeaderText="Delete" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="masterdelete" runat="server" OnClick="masterdelete_Click" ImageUrl="~/App_Themes/BasicTheme/Images/delete.png" Height="20px"
                                        Width="20px" OnClientClick="return confirm('Are You Sure To Delete?');" ToolTip="Delete">                                       
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Freeze">

                                <ItemTemplate>
                                    <asp:Label ID="lblfreeze" runat="server" Visible="false"></asp:Label>
                                    <asp:LinkButton ID="btn_freeze" runat="server" OnClick="btn_freeze_Click"
                                        OnClientClick="return confirm('Are You Sure To Freeze this record.?');" Visible="true" ToolTip="Freeze">
                                        <asp:Label ID="lblflag" runat="server" Text='<%#Bind("freeze_flage") %>'></asp:Label>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pan_rpt" runat="server" Style="display: none">
        </asp:Panel>
    </div>
                            </table>
</asp:Content>
