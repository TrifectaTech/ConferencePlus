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
				<asp:RadioButtonList runat="server" ID="rblFeeType" OnSelectedIndexChanged="rblFeeType_SelectedIndexChanged" AutoPostBack="True" RepeatDirection="Horizontal" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="lblFeeAdjustment" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				<telerik:RadNumericTextBox ID="txtFee" runat="server" NumberFormat-DecimalDigits="2" Type="Currency" ReadOnly="True" />
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td>
				<asp:Panel runat="server" ID="pnlPaymentInfo">
					<telerik:RadComboBox runat="server" ID="rcbPaymentInfo" EnableVirtualScrolling="True" MaxHeight="200px" Width="200px" AutoPostBack="True" CausesValidation="False"
						OnSelectedIndexChanged="rcbPaymentInfo_SelectedIndexChanged">
						<CollapseAnimation Duration="200" Type="OutQuint" />
					</telerik:RadComboBox>
				</asp:Panel>
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td>
				<fieldset>
					<legend>Billing Information</legend>
					<table>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblCreditCardType" Text="Credit Card Type: " />
							</td>
							<td>
								<telerik:RadComboBox runat="server" ID="rcbCreditCardType" EmptyMessage="Please select a credit card type"
									EnableVirtualScrolling="True" MaxHeight="200px" Width="200px" />

								<asp:RequiredFieldValidator runat="server" ID="valCreditCardType" ControlToValidate="rcbCreditCardType" InitialValue="" Display="Dynamic"
									ErrorMessage="*Credit Card Type Is Required" CssClass="text-danger" />
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblCreditCardNumber" Text="Credit Card Number: " />
							</td>
							<td>
								<telerik:RadTextBox runat="server" ID="txtCreditCardNumber" MaxLength="16" />
								<asp:RequiredFieldValidator runat="server" ID="valCreditCardNumber" ControlToValidate="txtCreditCardNumber" Display="Dynamic"
									ErrorMessage="*Credit Card Number Is Required" CssClass="text-danger" />
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblExpirationDate" Text="Expiration Date: " />
							</td>
							<td>
								<telerik:RadDatePicker runat="server" ID="rdpExpirationDate" MinDate="1/1/2000" MaxDate="1/1/2099">
									<DateInput runat="Server" DateFormat="MM/yyyy" DisplayDateFormat="MM/yyyy" />
								</telerik:RadDatePicker>

								<asp:RequiredFieldValidator runat="server" ID="valExpirationDate" ControlToValidate="rdpExpirationDate" Display="Dynamic"
									ErrorMessage="*Expiration Date Is Required" CssClass="text-danger" />
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblCCV" Text="CCV: " />
							</td>
							<td>
								<telerik:RadNumericTextBox runat="server" ID="txtCCV" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MaxValue="9999" />

								<asp:RequiredFieldValidator runat="server" ID="valCCV" ControlToValidate="txtCCV" Display="Dynamic" ErrorMessage="*CCV Is Required" CssClass="text-danger" />
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblBillingAddress" Text="Billing Address: " />
							</td>
							<td>
								<telerik:RadTextBox runat="server" ID="txtBillingAddress" />

								<asp:RequiredFieldValidator runat="server" ID="valBillingAddress" ControlToValidate="txtBillingAddress" Display="Dynamic"
									ErrorMessage="*Billing Address Is Required" CssClass="text-danger" />
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblCity" Text="Billing City: " />
							</td>
							<td>
								<telerik:RadTextBox runat="server" ID="txtCity" />

								<asp:RequiredFieldValidator runat="server" ID="valCity" ControlToValidate="txtCity" Display="Dynamic"
									ErrorMessage="*City Is Required" CssClass="text-danger" />
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblState" Text="Billing State: " />
							</td>
							<td>
								<telerik:RadComboBox runat="server" ID="rcbStates" EmptyMessage="Please select a state" EnableVirtualScrolling="True" MaxHeight="200px" Width="200px" />

								<asp:RequiredFieldValidator runat="server" ID="valState" ControlToValidate="rcbStates" InitialValue="" Display="Dynamic"
									ErrorMessage="*State Is Required" CssClass="text-danger" />
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label runat="server" ID="lblZip" Text="Zip: " />
							</td>
							<td>
								<telerik:RadTextBox runat="server" ID="txtZip" />
								<asp:RequiredFieldValidator runat="server" ID="valZip" ControlToValidate="txtZip" Display="Dynamic"
									ErrorMessage="*Zip Is Required" CssClass="text-danger" />
							</td>
						</tr>
					</table>
				</fieldset>
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td>
				<telerik:RadButton runat="server" ID="btnGoBack" Text="Go Back" CausesValidation="False" OnClick="btnGoBack_Click" Width="100px" Height="30px" />
				<telerik:RadButton runat="server" ID="btnSave" Text="Save" CommandName="Update" Width="100px" Height="30px" />
				<telerik:RadButton runat="server" ID="btnCancelTransaction" CausesValidation="False" CommandName="Cancel" Text="Cancel" Width="100px" Height="30px" />
			</td>
		</tr>
	</table>
</asp:Panel>
