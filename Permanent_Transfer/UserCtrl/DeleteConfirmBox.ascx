<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DeleteConfirmBox.ascx.vb" Inherits="Usercontrol_DeleteConfirmBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                                                DisplayModalPopupID="ModalPopupExtender1" >
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"  
                                                BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel" 
                                                OkControlID="ButtonOk" PopupControlID="PNL"  >
                                            </ajaxToolkit:ModalPopupExtender>
                                            <asp:Panel ID="PNL" runat="server" CssClass = "panel" Style="display: none">
                                                Are you sure to delete this record ?
                                                <br />
                                                <br />
                                                <div style="text-align: center;">
                                                    <asp:Button ID="ButtonOk" runat="server"  
                                                        Text="YES" />
                                                    <asp:Button ID="ButtonCancel" runat="server"  
                                                        Text="NO" />
                                                </div>
                                            </asp:Panel>