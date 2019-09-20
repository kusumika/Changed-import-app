<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="WebApplication1.Programs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2011.2.712.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" EnableAJAX="true" Width="100%">
                            <telerik:RadGrid ShowGroupPanel="false" ID="RadGridPrograms" runat="server" AutoGenerateColumns="False" 
                                GridLines="None" ShowStatusBar="True" Width="500" 
                                ondeletecommand="RadGridProgramsDeleteCommand" 
                                onitemcommand="RadGridProgramsItemCommand" 
                                onneeddatasource="RadGridProgramsNeedDataSource" 
                                onitemcreated="RadGridProgramsItemCreated">
                                <MasterTableView CommandItemDisplay="Top" DataKeyNames="ProgramID" Width="100%">
                                    <Columns>
                                        <telerik:GridEditCommandColumn UniqueName="EditCommandColumn" />
                                        <telerik:GridBoundColumn Visible="False" UniqueName="ProgramID" DataField="ProgramID" />
                                        <telerik:GridBoundColumn UniqueName="ProgramName" HeaderText="Program Name" DataField="Name" />
                                        <telerik:GridBoundColumn UniqueName="ProgramDate" HeaderText="Date" DataField="Date" />
                                        <telerik:GridBoundColumn UniqueName="ProgramStartTime" HeaderText="Start Time" DataField="StartTime" />
                                        <telerik:GridBoundColumn UniqueName="ProgramLeadText" HeaderText="Lead Text" DataField="LeadText" />
                                        <telerik:GridBoundColumn UniqueName="ProgramBLine" HeaderText="B-Line" DataField="BLine" />
                                        <telerik:GridBoundColumn UniqueName="ProgramSynopsis" HeaderText="Synopsis" DataField="Synopsis" />
                                        <telerik:GridBoundColumn UniqueName="ProgramUrl" HeaderText="URL" DataField="URL" />
                                        <telerik:GridButtonColumn CommandName="Delete" UniqueName="DeleteColumn" ConfirmText="&Auml;r du s&auml;ker p&aring; att du vill ta bort rapport namn?" >
                                            </telerik:GridButtonColumn>
                                    </Columns>
                                    <EditFormSettings EditFormType="Template">
                                            <FormTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="3" style="font-weight: bold; text-align: center;">
                                                            <asp:Label ID="lblPrograms" runat="server" Text="Program Detail" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblProgramName" runat="server" Text="Program Name:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtProgramName" runat="server" Text='<%# Bind( "Name") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProgramName" runat="server" ErrorMessage="*" Display="Dynamic" ValidationGroup="Save" ControlToValidate="txtProgramName" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblProgramDate" runat="server" Text="Program Date:" />
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="rdpProgramDate" runat="server" DbSelectedDate='<%# Bind( "Date") %>'/>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProgramDate" runat="server" ErrorMessage="*" ControlToValidate="rdpProgramDate" Display="Dynamic" ValidationGroup="Save" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblProgramStartTime" runat="server" Text="Program Start Time:" />
                                                        </td>
                                                        <td>
                                                            <telerik:RadTimePicker ID="rtpProgramStartTime" runat="server"  DbSelectedDate='<%# Bind( "StartTime") %>'/>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProgramStartTime" runat="server" ErrorMessage="*" ControlToValidate="rtpProgramStartTime" Display="Dynamic" ValidationGroup="Save" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Lead Text:
                                                            <asp:Label ID="lblProgramLeadText" runat="server" Text="Lead Text:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtProgramLeadText" runat="server" Text='<%# Bind( "LeadText") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProgramLeadText" runat="server" ErrorMessage="*" ControlToValidate="txtProgramLeadText" Display="Dynamic" ValidationGroup="Save" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblProgramBLine" runat="server" Text="B-Line:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtProgramBLine" runat="server" Text='<%# Bind( "BLine") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProgramBLine" runat="server" ErrorMessage="*" ControlToValidate="txtProgramBLine" Display="Dynamic" ValidationGroup="Save" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblProgramSynopsis" runat="server" Text="Synopsis:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtProgramSynopsis" runat="server" Text='<%# Bind( "Synopsis") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProgramSynopsis" runat="server" ErrorMessage="*" ControlToValidate="txtProgramSynopsis" Display="Dynamic" ValidationGroup="Save" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblProgramUrl" runat="server" Text="URL:" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtProgramUrl" runat="server" Text='<%# Bind( "URL") %>' />
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvProgramUrl" runat="server" ErrorMessage="*" ControlToValidate="txtProgramUrl" Display="Dynamic" ValidationGroup="Save" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2">
                                                                <asp:Button ID="btnUpdate" ValidationGroup="Save" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'
                                                                runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>'>
                                                            </asp:Button>
                                                            <asp:Button ID="btnCancel" Text="Close" runat="server" CausesValidation="False" CommandName="Cancel" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FormTemplate> 
                                    </EditFormSettings> 
                                </MasterTableView>
                            </telerik:RadGrid>
                        </telerik:RadAjaxPanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
