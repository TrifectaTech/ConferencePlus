<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BrowseConference.aspx.cs" Inherits="ConferencePlus.BrowseConference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		<asp:Label runat="server" Text="Browse Conferences" />
	</h1>
	<br />
	<br />
	<asp:Label ID="lblMessage" runat="server" ForeColor="Red"/>
	<telerik:RadGrid runat="server" ID="grdConference" OnNeedDataSource="grdConference_NeedDataSource"
		OnItemDataBound="grdConference_ItemDataBound" Skin="MetroTouch" OnDetailTableDataBind="grdConference_DetailTableDataBind"
		OnInsertCommand="grdConference_InsertCommand" OnUpdateCommand="grdConference_UpdateCommand" OnDeleteCommand="grdConference_DeleteCommand">
		<MasterTableView Name="Conference" DataKeyNames="ConferenceId" AutoGenerateColumns="false" AllowSorting="true" AllowFilteringByColumn="true" CommandItemDisplay="None">
			<Columns>
				<telerik:GridBoundColumn HeaderText="Name" UniqueName="Name" DataField="Name" />
				<telerik:GridBoundColumn HeaderText="Activity Type" UniqueName="ActivityType" DataField="ActivityType" />
				<telerik:GridBoundColumn HeaderText="Description" UniqueName="Description" DataField="Description" />
				<telerik:GridBoundColumn HeaderText="Start Date" UniqueName="StartDate" DataField="StartDate" />
				<telerik:GridBoundColumn HeaderText="End Date" UniqueName="EndDate" DataField="EndDate" />
				<telerik:GridBoundColumn HeaderText="Base Fee" UniqueName="BaseFee" DataField="BaseFee" />
			</Columns>
			<DetailTables>
				<telerik:GridTableView Name="Event" DataKeyNames="EventId" AllowSorting="true" AllowFilteringByColumn="true"
					CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Register for Event" AutoGenerateColumns="false">
					<Columns>
						<telerik:GridEditCommandColumn EditText="Edit"/>
						<telerik:GridButtonColumn CommandName="Delete" Text="Delete" ButtonType="LinkButton"
							ConfirmDialogType="RadWindow" ConfirmText="Are you sure you want to delete your registration for this conference?" />
						
						<telerik:GridBoundColumn HeaderText="Comments" UniqueName="Name" DataField="Name" />
					</Columns>
					<EditFormSettings EditFormType="WebUserControl" UserControlName="~/Controls/EventRegistration.ascx"/>
				</telerik:GridTableView>
			</DetailTables>
		</MasterTableView>
	</telerik:RadGrid>
</asp:Content>
