<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventRegistration.ascx.cs" Inherits="ConferencePlus.Controls.EventRegistration" %>

<table>
	<tr>
		<td class="alignRight">
			<asp:Label runat="server" Text="Start Date:" />
		</td>
		<td class="alignLeft">
			<telerik:RadDateTimePicker runat="server" ID="rdtpStartDate" Width="200px" />
		</td>
	</tr>
	<tr>
		<td class="alignRight">
			<asp:Label runat="server" Text="End Date:" />
		</td>
		<td class="alignLeft">
			<telerik:RadDateTimePicker runat="server" ID="rdtpEndDate" Width="200px" />
		</td>
	</tr>
	<tr>
		<td class="alignRight">
			<asp:Label runat="server" Text="Paper:" />
		</td>
		<td class="alignLeft">
			<telerik:RadComboBox runat="server" ID="rcbPaper" EnableVirtualScrolling="True" MaxHeight="200px" Width="400px">
				<CollapseAnimation Duration="200" Type="OutQuint" />
			</telerik:RadComboBox>
		</td>
	</tr>
	<tr>
		<td colspan="3">
			<asp:Panel runat="server" ID="pnlNoPaper" Visible="False">
				<asp:HyperLink runat="server" NavigateUrl="~/Account/Manage.aspx?SelectedTabIndex=1" Text="No Papers? Create One!"/>
			</asp:Panel>
		</td>
	</tr>
	<tr>
		<td class="alignRight">
			<asp:Label runat="server" Text="Food Preference:" />
		</td>
		<td class="alignLeft">
			<telerik:RadComboBox runat="server" ID="rcbFoodPreference" EnableVirtualScrolling="True" MaxHeight="200px" Width="200px">
				<CollapseAnimation Duration="200" Type="OutQuint" />
			</telerik:RadComboBox>
		</td>
	</tr>
	<tr>
		<td class="alignRight">
			<asp:Label runat="server" Text="Comments:" />
		</td>
		<td class="alignLeft">
			<telerik:RadTextBox runat="server" ID="txtComments" TextMode="MultiLine" />
		</td>
	</tr>
	<tr>
		<td colspan="3">
			<telerik:RadButton runat="server" ID="btnSave" ValidationGroup="EventValidation" Text="Save" />
			<telerik:RadButton runat="server" ID="btnCancel" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
		</td>
	</tr>
</table>
