<%@ Page Title="Manage Your Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ConferencePlus.Account.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<telerik:RadFormDecorator runat="server" ID="decorator" DecoratedControls="Default" Skin="MetroTouch" />
	<telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="MetroTouch" />
	<telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="LoadingPanel1">

		<h2>
			<asp:Label ID="lblTitle" runat="server" />
		</h2>

		<br />

		<telerik:RadTabStrip runat="server" ID="tbManageYourAccount" MultiPageID="mpManageAccount" Skin="MetroTouch">
			<Tabs>
				<telerik:RadTab runat="server" Text="Payment Information" PageViewID="pvPaymentInformation" Selected="True" />

				<telerik:RadTab runat="server" Text="View/Edit Papers" PageViewID="pvPapers" />
			</Tabs>
		</telerik:RadTabStrip>

		<telerik:RadMultiPage runat="server" ID="mpManageAccount" SelectedIndex="0">
			<telerik:RadPageView runat="server" ID="pvPaymentInformation">
				<telerik:RadGrid runat="server" ID="grdPaymentInfo" AllowSorting="True" AllowAutomaticDeletes="False" Skin="MetroTouch"
					AllowAutomaticInserts="False" AllowAutomaticUpdates="False" AllowMultiRowEdit="False"
					AutoGenerateColumns="False" AllowPaging="True" OnNeedDataSource="grdPaymentInfo_OnNeedDataSource" OnInsertCommand="grdPaymentInfo_OnInsertCommand"
					OnDeleteCommand="grdPaymentInfo_OnDeleteCommand" OnUpdateCommand="grdPaymentInfo_OnUpdateCommand" OnItemDataBound="grdPaymentInfo_OnItemDataBound">
					<MasterTableView Name="grdPaymentInfo" DataKeyNames="UserId,PaymentInfoId" CommandItemDisplay="Top"
						NoMasterRecordsText="No payment information" InsertItemPageIndexAction="ShowItemOnCurrentPage" CommandItemSettings-AddNewRecordText="Add New Payment Information">
						<Columns>
							<telerik:GridButtonColumn ButtonType="PushButton" Text="Delete" CommandName="Delete" ConfirmText="Are you sure you want to delete this payment profile?"
								ConfirmDialogType="RadWindow" />
							<telerik:GridBoundColumn DataField="CreditCardNumber" HeaderText="Credit Card Number" UniqueName="CreditCardNumber" />
							<telerik:GridBoundColumn DataField="FormattedCreditCardType" HeaderText="Credit Card Type" UniqueName="FormattedCreditCardType" />
							<telerik:GridBoundColumn DataField="CCV" HeaderText="CCV" UniqueName="CCV" />
							<telerik:GridDateTimeColumn DataField="ExpirationDate" HeaderText="Expiration Date" UniqueName="ExpirationDate" DataFormatString="{0:MM/dd/yyyy}" />
							<telerik:GridBoundColumn DataField="BillingAddress" HeaderText="Billing Address" UniqueName="BillingAddress" />
							<telerik:GridBoundColumn DataField="BillingCity" HeaderText="Billing City" UniqueName="BillingCity" />
							<telerik:GridBoundColumn DataField="BillingState" HeaderText="Billing State" UniqueName="BillingState" />
							<telerik:GridBoundColumn DataField="BillingZip" HeaderText="Billing Zip" UniqueName="BillingZip" />
						</Columns>
						<EditFormSettings EditFormType="Template">
							<FormTemplate>
								<asp:Panel runat="server" ID="pnlErrorMessage" Visible="False">
									<p class="alert-danger">
										<asp:Literal runat="server" ID="ltErrorMessage" />
									</p>
								</asp:Panel>

								<fieldset>
									<legend>Billing Information</legend>
									<table>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblCreditCardType" Text="Credit Card Type: " />
											</td>
											<td>
												<telerik:RadComboBox runat="server" ID="ddlCreditCardType" EmptyMessage="Please select a credit card type"
													EnableVirtualScrolling="True" MaxHeight="200px" Width="200px" />

												<asp:RequiredFieldValidator runat="server" ID="valCreditCardType" ControlToValidate="ddlCreditCardType" InitialValue="" Display="Dynamic"
													ErrorMessage="*Credit Card Type Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblCreditCardNumber" Text="Credit Card Number: " />
											</td>
											<td>
												<telerik:RadTextBox runat="server" ID="txtCreditCardNumber" MaxLength="16" />
												<asp:RequiredFieldValidator runat="server" ID="valCreditCardNumber" ControlToValidate="txtCreditCardNumber" Display="Dynamic"
													ErrorMessage="*Credit Card Number Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblExpirationDate" Text="Expiration Date: " />
											</td>
											<td>
												<telerik:RadDatePicker runat="server" ID="dtExpirationDate" MinDate="1/1/2000" MaxDate="1/1/2099">
													<DateInput DateFormat="MM/yyyy" DisplayDateFormat="MM/yyyy" />
												</telerik:RadDatePicker>

												<asp:RequiredFieldValidator runat="server" ID="valExpirationDate" ControlToValidate="dtExpirationDate" Display="Dynamic"
													ErrorMessage="*Expiration Date Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblCCV" Text="CCV: " />
											</td>
											<td>
												<telerik:RadNumericTextBox runat="server" ID="txtCCV" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MaxValue="9999" />

												<asp:RequiredFieldValidator runat="server" ID="valCCV" ControlToValidate="txtCCV" Display="Dynamic"
													ErrorMessage="*CCV Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblBillingAddress" Text="Billing Address: " />
											</td>
											<td>
												<telerik:RadTextBox runat="server" ID="txtBillingAddress" />

												<asp:RequiredFieldValidator runat="server" ID="valBillingAddress" ControlToValidate="txtBillingAddress" Display="Dynamic"
													ErrorMessage="*Billing Address Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblCity" Text="Billing City: " />
											</td>
											<td>
												<telerik:RadTextBox runat="server" ID="txtCity" />

												<asp:RequiredFieldValidator runat="server" ID="valCity" ControlToValidate="txtCity" Display="Dynamic"
													ErrorMessage="*City Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblState" Text="Billing State: " />
											</td>
											<td>
												<telerik:RadComboBox runat="server" ID="ddlStates" EmptyMessage="Please select a state" EnableVirtualScrolling="True" MaxHeight="200px" Width="200px" OnLoad="ddlState_OnLoad" />

												<asp:RequiredFieldValidator runat="server" ID="valState" ControlToValidate="ddlStates" InitialValue="" Display="Dynamic"
													ErrorMessage="*State Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
										<tr>
											<td>
												<asp:Label runat="server" ID="lblZip" Text="Zip: " />
											</td>
											<td>
												<telerik:RadTextBox runat="server" ID="txtZip" />

												<asp:RequiredFieldValidator runat="server" ID="valZip" ControlToValidate="txtZip" Display="Dynamic"
													ErrorMessage="*Zip Is Required" ValidationGroup="PaymentInfoValidationGroup" CssClass="text-danger" />
											</td>
										</tr>
									</table>
									<br />

									<telerik:RadButton runat="server" ID="btnSave" CommandName="Update" Text="Save" ValidationGroup="PaymentInfoValidationGroup" Width="150px" Height="35px" />

									<telerik:RadButton runat="server" ID="btnCancel" CommandName="Cancel" Text="Cancel" CausesValidation="False" Width="150px" Height="35px" />
								</fieldset>
							</FormTemplate>
						</EditFormSettings>
					</MasterTableView>
				</telerik:RadGrid>
			</telerik:RadPageView>
			<telerik:RadPageView runat="server" ID="pvPapers">
				<telerik:RadGrid runat="server" ID="grdPapers" AllowSorting="True" Skin="MetroTouch"
					AutoGenerateColumns="False" AllowPaging="True" OnNeedDataSource="grdPapers_OnNeedDataSource"
					OnDeleteCommand="grdPapers_OnDeleteCommand" OnUpdateCommand="grdPapers_OnUpdateCommand" OnItemDataBound="grdPapers_OnItemDataBound">
					<MasterTableView Name="grdPapers" DataKeyNames="PaperId, UserId" NoMasterRecordsText="No papers available" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New Paper">
						<Columns>
							<telerik:GridEditCommandColumn EditText="Edit" />
							<telerik:GridButtonColumn ButtonType="LinkButton" Text="Delete" ConfirmText="Are you sure you want to delete this paper?" CommandName="Delete" />
							<telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Name" />
							<telerik:GridBoundColumn DataField="Author" UniqueName="Author" HeaderText="Author" />
							<telerik:GridBoundColumn DataField="FormattedPaperCategory" UniqueName="FormattedPaperCategory" HeaderText="Category" />
						</Columns>
						<EditFormSettings EditFormType="WebUserControl" UserControlName="~/Controls/EditPaper.ascx" />
					</MasterTableView>
				</telerik:RadGrid>
			</telerik:RadPageView>
		</telerik:RadMultiPage>

	</telerik:RadAjaxPanel>

</asp:Content>
