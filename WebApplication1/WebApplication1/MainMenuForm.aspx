<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenuForm.aspx.cs" Inherits="WebApplication1.MainMenuForm" %>

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
            width: 624px;
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
			<li><a href="#">
                <asp:LinkButton ID="btnHome" 
                    runat="server" onclick="btnHome_Click">Hem</asp:LinkButton></a></li>
			<li><a href="#"> <asp:LinkButton ID="btnImport" runat="server" onclick="btnImport_Click">Importera Filer</asp:LinkButton></a></li>
            <li><a href="#"><asp:LinkButton ID="btnView" runat="server" onclick="btnView_Click">Visa Filer</asp:LinkButton></a></li>			
            <li><a href="#"> <asp:LinkButton ID="btnExport" runat="server" onclick="btnImport_Click" Visible="false">Export</asp:LinkButton></a></li>
			
		</ul>
	</div>
	
	<div id="welcome">
		<h2 class="title">Välkommen till Import Verktyget</h2>
		<div class="entry">
			<p>Innan import görs, var säker på att alla filerna är exporterade genom Speed Up´s export verktyg</p>
		</div>
	</div>
</div>

    </form>
</body>


</html>
