<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventRegistration.ascx.cs" Inherits="ConferencePlus.Controls.EventRegistration" %>

<asp:Panel runat="server" ID="pnlNoPaper" Visible="False">
	<asp:HyperLink runat="server" NavigateUrl="~/Account/Manage.aspx?SelectedTabIndex=1" Text="No Papers? Create One!" />
</asp:Panel>
<asp:Panel runat="server" ID="pnlEventForm">
	<table>
		<tr>
			<td class="alignRight">
				<asp:Label runat="server" Text="Start Date:" />
			</td>
			<td class="alignLeft">
				<telerik:RadDateTimePicker runat="server" ID="rdtpStartDate" Width="200px" />
			</td>
			<td>
				<asp:RequiredFieldValidator runat="server" ControlToValidate="rdtpStartDate" ErrorMessage="*Required" Display="Dynamic" CssClass="text-danger" />
			</td>
		</tr>
		<tr>
			<td class="alignRight">
				<asp:Label runat="server" Text="End Date:" />
			</td>
			<td class="alignLeft">
				<telerik:RadDateTimePicker runat="server" ID="rdtpEndDate" Width="200px" />
			</td>
			<td>
				<asp:RequiredFieldValidator runat="server" ControlToValidate="rdtpEndDate" ErrorMessage="*Required" Display="Dynamic" CssClass="text-danger" />
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
			<td>
				<asp:RequiredFieldValidator runat="server" ControlToValidate="rcbPaper" ErrorMessage="*Required" Display="Dynamic" CssClass="text-danger" InitialValue="--SELECT PAPER--" />
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
			<td>
				<asp:RequiredFieldValidator runat="server" ControlToValidate="rcbFoodPreference" ErrorMessage="*Required" Display="Dynamic" CssClass="text-danger" InitialValue="--SELECT FOOD PREF--" />
			</td>
		</tr>
		<tr>
			<td class="alignRight">
				<asp:Label runat="server" Text="Comments:" />
			</td>
			<td class="alignLeft">
				<telerik:RadTextBox runat="server" ID="txtComments" TextMode="MultiLine" Height="200px" Width="350px" MaxLength="600" />
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td colspan="3">
				<telerik:RadButton runat="server" ID="btnContinue" Text="Save" OnClick="btnContinue_Click" Width="100px" Height="30px" />
				<telerik:RadButton runat="server" ID="btnCancel" CausesValidation="False" CommandName="Cancel" Text="Cancel" Width="100px" Height="30px" />
			</td>
		</tr>
	</table>
</asp:Panel>
<asp:Panel runat="server" ID="pnlTransactionForm" Visible="False">
	<table>
		<tr>
			<td>
				<asp:RadioButtonList runat="server" ID="rblFeeType" OnSelectedIndexChanged="rblFeeType_SelectedIndexChanged" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:RadioButtonList runat="server" ID="rblFeeAdjustment" OnSelectedIndexChanged="rblFeeAdjustment_SelectedIndexChanged" />
			</td>
		</tr>
		<tr>
			<td>
				<telerik:RadNumericTextBox ID="txtFee" runat="server" NumberFormat-DecimalDigits="2" Type="Currency"/>
			</td>
		</tr>
		<tr>
			<td>
				<telerik:RadButton runat="server" ID="btnGoBack" Text="Go Back" CausesValidation="False" OnClick="btnGoBack_Click" Width="100px" Height="30px" />
				<telerik:RadButton runat="server" ID="btnSave" Text="Save" CommandName="Update" Width="100px" Height="30px" />
				<telerik:RadButton runat="server" ID="btnCancelTransaction" CausesValidation="False" CommandName="Cancel" Text="Cancel" Width="100px" Height="30px" />
			</td>
		</tr>
	</table>
</asp:Panel>
