<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageConference.aspx.cs" Inherits="ConferencePlus.Admin.ManageConference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    	<h1>
		<asp:Label ID="Label1" runat="server" Text="Manage Conferences"/>
	</h1>
    
	<br />
    <asp:Label ID="lblmessage" runat="server" ForeColor="Red"/>
	<br />
    <telerik:RadGrid ID="grdConference" OnNeedDataSource="grdConference_NeedDataSource" OnUpdateCommand="grdConference_UpdateCommand" 
        runat="server" OnItemDataBound="grdConference_ItemDataBound" AutoGenerateColumns="false" AllowSorting="true" AllowFilteringByColumn="true"
        AllowPaging="true" OnDetailTableDataBind="grdConference_DetailTableDataBind" OnDeleteCommand="grdConference_DeleteCommand" Skin="MetroTouch">
        <MasterTableView Name="Conferences" DataKeyNames="ConferenceId" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add Conference" AutoGenerateColumns="false">
            <Columns>
                <telerik:GridEditCommandColumn EditText="Edit" />
                <telerik:GridButtonColumn Text="Remove" UniqueName="Delete" ConfirmText="Do you want this Conference?" CommandName="Delete" />
                <telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Conference Name" />
                <telerik:GridBoundColumn DataField="ActivityType" UniqueName="ActivityType" HeaderText="Activity Type" />
                <telerik:GridBoundColumn DataField="Description" UniqueName="Description" HeaderText="Description" />
                <telerik:GridNumericColumn DataField="BaseFee" UniqueName="BaseFee" HeaderText="Base Fee" NumericType="Currency" />
                <telerik:GridBoundColumn DataField="StartDate" UniqueName="StartDate" HeaderText="Start Date" />
                <telerik:GridBoundColumn DataField="EndDate" UniqueName="EndDate" HeaderText="End Date" />
            </Columns>
            <EditFormSettings EditFormType="WebUserControl" UserControlName="~/Controls/ConferenceConfiguration.ascx"/>
            <DetailTables>
                <telerik:GridTableView Name="ConferenceFeeTypes" DataKeyNames="ConferenceFeeId" CommandItemDisplay="Top" AutoGenerateColumns="false"
                    CommandItemSettings-AddNewRecordText="Add Conference Fee Type">
                    <Columns>
                        <telerik:GridEditCommandColumn EditText="Edit" />
                        <telerik:GridButtonColumn Text="Remove" UniqueName="Delete" ConfirmText="Do you want to remove fee on Conference?" CommandName="Delete" />
                        <telerik:GridBoundColumn DataField="FeeAdjustment" UniqueName="FeeAdjustment" HeaderText="FeeAdjustment" />
                        <telerik:GridBoundColumn DataField="FeeType" UniqueName="FeeType" HeaderText="FeeType" />
                        <telerik:GridNumericColumn DataField="Multiplier" UniqueName="Multiplier" HeaderText="Multiplier" NumericType="Currency" />
                    </Columns>
                    <EditFormSettings EditFormType="WebUserControl" UserControlName="~/Controls/ConferenceFeeTypeConfiguration.ascx"/>
                </telerik:GridTableView>
            </DetailTables>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>