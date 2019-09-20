<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewUploadCtrl.aspx.cs"
    Inherits="WebApplication1.ViewUploadCtrl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>SpeedUp Utility</title>
    <link href="http://fonts.googleapis.com/css?family=Oswald" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        @import "gallery.css";
        .style1
        {
            width: 101px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="header">
            <div id="logo">
                <h1>
                    <a href="#"></a></h1>
            </div>
        </div>
        <div id="menu">
            <ul>
                <li><a href="#">
                    <asp:LinkButton ID="btnHome" runat="server" OnClick="btnHome_Click">Hem</asp:LinkButton></a></li>
                <li><a href="#">
                    <asp:LinkButton ID="btnBackToImport" runat="server" OnClick="btnBackToImport_Click">Importera Filer</asp:LinkButton></a></li>
                <li><a href="#">
                    <asp:LinkButton ID="btnBackToView" runat="server" OnClick="btnBackToView_Click">Visa Filer</asp:LinkButton></a></li>
                <li><a href="#">
                    <asp:LinkButton ID="btnBackToExport" runat="server" Visible="false">Export</asp:LinkButton></a></li>
            </ul>
        </div>
    </div>   
    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" Skin="Default">
</telerik:RadAjaxLoadingPanel>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>   
    <telerik:RadAjaxPanel ID="rapObjectData" runat="server" LoadingPanelID="RadAjaxLoadingPanel1" >
    <table cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td class="style1">
                <asp:Label ID="lbl_FileType" runat="server" Font-Size="Small" Text="Filtyper"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rb_FileType" runat="server" Font-Size="Small" Height="30px"
                    RepeatDirection="Horizontal" Width="255px">
                    <asp:ListItem Selected="True" Value="NewFile">Excel ACE</asp:ListItem>
                    <asp:ListItem Value="OldFile">Excel jet</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Font-Size="Small" Text="Typ"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdo" runat="server" Font-Size="Small" Height="30px" RepeatDirection="Horizontal"
                    Width="160px" style="margin-left: 0px">
                    <asp:ListItem Selected="True" Value="Folder">Katalog</asp:ListItem>
                    <asp:ListItem Value="File">Fil</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
         <tr>
            <td class="style1">
                <asp:Label ID="lbl_Folderpath" runat="server" Font-Size="Small" Text="Katalog väg"></asp:Label>
            </td>
            <td>
               
                <asp:TextBox ID="txt_FolderPath" runat="server"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Fil"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_FileName" 
                    runat="server"></asp:TextBox>
                <telerik:RadButton ID="btnImport" runat="server" OnClick="btnImport_Click"
                    Text="Importera">
                </telerik:RadButton>
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Size="Smaller" Text="i.e. xls"></asp:Label>              
                
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblCountHead" runat="server" Font-Size="X-Small" Text="Count:" ForeColor="Blue"></asp:Label>
                &nbsp;<asp:Label ID="lblCount" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="lblMessage" runat="server" BorderColor="Black" BorderStyle="None"
                    EnableTheming="True" Font-Size="X-Small" Height="630px" ReadOnly="True" TextMode="MultiLine"
                    Width="864px"></asp:TextBox>
            </td>
        </tr>
    </table>   
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
