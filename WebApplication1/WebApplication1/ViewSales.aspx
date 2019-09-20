<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSales.aspx.cs" Inherits="WebApplication1.ViewSales" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 116px;
        }
        .style3
        {
            width: 116px;
            height: 23px;
        }
        .style4
        {
            height: 23px;
        }
        .style5
        {
            width: 153px;
        }
        .style6
        {
            width: 153px;
            height: 23px;
        }
        </style>
        <meta name="keywords" content="" />
<meta name="description" content="" />
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title>SpeedUp Utility</title>
<link href="http://fonts.googleapis.com/css?family=Oswald" rel="stylesheet" type="text/css" />
<link href="Styles/Site.css" rel="stylesheet" type="text/css" />

<style type="text/css">
@import "gallery.css";
</style>
</head>
<telerik:RadCodeBlock id="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function showAlert(dueDate, currentDate) {

            if (dueDate < currentDate) {
                if (alert('Förfallodagen har passerats')) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        function confirmation(sender, args) {
            var button = args.get_item();
            if (button.get_commandName() == "delete") {
                var message = "Är du säker på att du vill ta bort alla medlemmar i denna leverantör";
                args.set_cancel(!confirm(message));
            }
        }
    </script>
</telerik:RadCodeBlock>
<body>
 
   
    <form id="form1" runat="server">
     <div id="wrapper">
	<div id="header">
		<div id="logo">
			<h1><a href="#"></a></h1>			
		</div>
	</div>	
	<div id="menu">
		<ul>
			<li><a href="#"><asp:LinkButton ID="btnHome" 
                    runat="server" onclick="btnHome_Click" 
                    >Hem</asp:LinkButton></a></li>
			<li><a href="#"> <asp:LinkButton ID="btnImport" runat="server" 
                    onclick="btnImport_Click">Importera Filer</asp:LinkButton></a></li>
            <li><a href="#"><asp:LinkButton ID="btnView" runat="server" onclick="btnView_Click">Visa Filer</asp:LinkButton></a></li>			
            <li><a href="#"> <asp:LinkButton ID="btnExport" runat="server" Visible="false">Export</asp:LinkButton></a></li>
			
		</ul>
	</div>
    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" Skin="Default">
</telerik:RadAjaxLoadingPanel>
    <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadAjaxPanel ID="rapObjectData" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" >
    <table class="style1">
       
        <tr>
            <td class="style3">
            </td>
            <td>
                Leverantör :&nbsp;
                    <telerik:RadComboBox ID="rcbSupplier" runat="server" Width="462px" DataTextField="Supplier"
                    DataValueField="SupplierNo" AllowCustomText="true" MarkFirstMatch="true"
                    >
                </telerik:RadComboBox>
            </td>
            <td class="style6">
                &nbsp;
            </td>
            <td class="style4">
            </td>
            <td class="style4">
            </td>
            <td class="style4">
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                Period :&nbsp;&nbsp;&nbsp;
                <telerik:RadComboBox ID="rcbPeriods" runat="server" Width="179px" DataTextField="Period"
                    DataValueField="PeriodStartDate"  
                    >
                </telerik:RadComboBox>
                &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Sök" />
            </td>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
       
        <tr>
            <td class="style2">
                &nbsp;
            </td>
            <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" 
                    AllowSorting="True" AutoGenerateColumns="False" BorderStyle="Solid" 
                    CellSpacing="0" GridLines="Vertical" OnItemCommand="RadGrid1_ItemCommand" 
                    onitemdatabound="RadGrid1_ItemDataBound" 
                    OnNeedDataSource="RadGrid1_NeedDataSource" ShowStatusBar="True" 
                    Skin="Sunset" onprerender="RadGrid1_PreRender" AllowPaging="True">
                    <groupingsettings retaingroupfootersvisibility="True" 
                        showungroupbutton="True" />
                    <GroupingSettings RetainGroupFootersVisibility="True" 
                        ShowUnGroupButton="True" />
                    <exportsettings exportonlydata="True" filename="Payments">
                    </exportsettings>
                    <mastertableview commanditemdisplay="Top" datakeynames="ID">


                        <CommandItemSettings addnewrecordtext="Lägg till post" refreshtext="Uppdatera" 
                            showaddnewrecordbutton="False" showexporttoexcelbutton="True" 
                            showrefreshbutton="False" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <CommandItemTemplate>
                    <telerik:RadToolBar runat="server" ID="RadToolBar2"  OnButtonClick="ToolBar_ButtonClick" OnClientButtonClicking="confirmation">
                        <Items>
                         <telerik:RadToolBarButton ID="del" Text="Ta bort" CommandName="delete" Value="Delete"
                                ImagePosition="Left"/>
                                <telerik:RadToolBarButton ID="Transfer" Text="Överför data till Intranet Namn" CommandName="Transfer" Value="Transfer"
                                ImagePosition="Left"/>
                        </Items>
                    </telerik:RadToolBar>
                </CommandItemTemplate>
                        <Columns>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Edit" 
                                UniqueName="EditButtonColumn">
                                <HeaderStyle Width="30px" />
                            </telerik:GridButtonColumn>
                            <telerik:GridBoundColumn DataField="ID" EditFormColumnIndex="1" 
                                UniqueName="ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SupplierNo" 
                                HeaderText="Leverantör No" UniqueName="SupplierNo"  Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MemberNo" 
                                EditFormColumnIndex="2" HeaderText="No" 
                                UniqueName="MemberNo">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MemberName" EditFormColumnIndex="3" 
                                HeaderText="Namn" UniqueName="MemberName">
                                <HeaderStyle Width="60px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Location" EditFormColumnIndex="4" 
                                HeaderText="Plats" UniqueName="Location">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Komments" EditFormColumnIndex="5" 
                                HeaderText="Komments" UniqueName="Komments" visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalInkopAmountKv1" EditFormColumnIndex="6" 
                                HeaderText="Kvartal 1" UniqueName="TotalInkopAmountKv1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalInkopAmountKv2" EditFormColumnIndex="7" 
                                HeaderText="Kvartal 2" UniqueName="TotalInkopAmountKv2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SumKv12" EditFormColumnIndex="8" 
                                HeaderText="Summa av kvartal 1 & 2" UniqueName="SumKv12">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalInkopAmountKv3" EditFormColumnIndex="9" 
                                HeaderText="Kvartal 3" UniqueName="TotalInkopAmountKv3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SumKv123" EditFormColumnIndex="10" 
                                HeaderText="Summa av kvartal 1,2 & 3" UniqueName="SumKv123">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalInkopAmountKv4" EditFormColumnIndex="11" 
                                HeaderText="Kvartal 4" UniqueName="TotalInkopAmountKv4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SumAllQuarters" EditFormColumnIndex="12" 
                                HeaderText="Summa av alla kvartal" UniqueName="SumAllQuarters">                                                                
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BonusSetID" EditFormColumnIndex="13" 
                                HeaderText="BonusSetID" UniqueName="BonusSetID"  Visible="False">                                                                
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BonusSetName" EditFormColumnIndex="14" 
                                HeaderText="Bonusgruppnamn" UniqueName="BonusSetName">                                                                
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BonusSetAmount" EditFormColumnIndex="15" 
                                HeaderText="Bonusgruppbelopp" UniqueName="BonusSetAmount">                                                                
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                                ConfirmText="Är du säker på att du vill ta bort denna medlem?" 
                                UniqueName="DeleteButtonColumn">
                                <HeaderStyle Width="30px" />
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings EditFormType="Template">
                            <EditColumn UniqueName="EditCommandColumn1">
                            </EditColumn>
                            <FormTemplate>
                                <table>
                                    <tr>
                                        <td colspan="3">
                                            Betalning
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label1" runat="server" Text="Medlemsnamn"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <asp:Label ID="rtx_MemberName" Runat="server" Text='<%# Bind( "MemberName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label2" runat="server" Text="Plats"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="Label14" Runat="server" Text='<%# Bind( "Location") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label3" runat="server" Text="Komments"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadTextBox ID="rtx_Komments" Runat="server" 
                                                Text='<%# Bind( "Komments") %>' Width="300">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label4" runat="server" Text="Kvartal 1"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtx_TotalInkopAmountKv1" Runat="server" 
                                                DbValue ='<%# Bind( "TotalInkopAmountKv1") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label5" runat="server" Text="Kvartal 2"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtxTotalInkopAmountKv2" Runat="server" 
                                                DbValue ='<%# Bind( "TotalInkopAmountKv2") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label6" runat="server" Text="Summa av kvartal 1 & 2"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtxSumKv12" Runat="server" 
                                                DbValue ='<%# Bind( "SumKv12") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label7" runat="server" Text="Kvartal 3"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtxTotalInkopAmountKv3" Runat="server" 
                                                DbValue ='<%# Bind( "TotalInkopAmountKv3") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label8" runat="server" Text="Summa av kvartal 1,2 & 3"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtxSumKv123" Runat="server" 
                                                DbValue ='<%# Bind( "SumKv123") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label9" runat="server" Text="Kvartal 4"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtxTotalInkopAmountKv4" Runat="server" 
                                                DbValue ='<%# Bind( "TotalInkopAmountKv4") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label10" runat="server" Text="Summa av alla kvartal"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtxSumAllQuarters" Runat="server" 
                                                DbValue ='<%# Bind( "SumAllQuarters") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label11" runat="server" Text="EgetKundnummer"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadTextBox ID="rtxEgetKundnummer" Runat="server" 
                                                Text='<%# Bind( "EgetKundnummer") %>'>
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label12" runat="server" Text="Bonusgruppnamn"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <asp:Label ID="Label15" Runat="server" Text='<%# Bind( "BonusSetName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                                                        
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="Label13" runat="server" Text="Bonusgruppbelopp"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                             <telerik:RadNumericTextBox ID="rtxBonusSetAmount" Runat="server" 
                                                DbValue ='<%# Bind( "BonusSetAmount") %>'>
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                   

                                  
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnSave" runat="server" 
                                                CommandName='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>' 
                                                Text='<%# (Container is GridEditFormInsertItem) ? "L&auml;gg till" : "Uppdatera" %>' 
                                                ToolTip="Save Changes"></asp:LinkButton>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnClose" runat="server" CausesValidation="False" 
                                                CommandName="Cancel" Text="Stäng"></asp:LinkButton>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td valign="top">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </FormTemplate>
                        </EditFormSettings>
                    </mastertableview>
                    <filtermenu enableimagesprites="False">
                    </filtermenu>
                    <headercontextmenu cssclass="GridContextMenu GridContextMenu_Default">
                    </headercontextmenu>
                </telerik:RadGrid>
            </td>
            <td class="style5">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>       
    </table>
    </telerik:RadAjaxPanel>
    </div>
    </form>

</body>
</html>
