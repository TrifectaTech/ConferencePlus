<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageConference.aspx.cs" Inherits="ConferencePlus.Admin.ManageConference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    	<h1>
		<asp:Label ID="Label1" runat="server" Text="Manage Car Makes/Models"/>
	</h1>
    
	<br />
	<br />
    <telerik:RadGrid ID="RadGrid1" runat="server"></telerik:RadGrid>
</asp:Content>