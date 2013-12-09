﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageConference.aspx.cs" Inherits="ConferencePlus.Admin.ManageConference" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    	<h1>
		<asp:Label ID="Label1" runat="server" Text="Manage Car Makes/Models"/>
	</h1>
    
	<br />
	<br />
    <telerik:RadGrid ID="grdConference" OnNeedDataSource="grdConference_NeedDataSource" OnUpdateCommand="grdConference_UpdateCommand" 
        runat="server" OnItemDataBound="grdConference_ItemDataBound" AutoGenerateColumns="false" AllowSorting="true" AllowFilteringByColumn="true"
        AllowPaging="true" OnDetailTableDataBind="grdConference_DetailTableDataBind">
        <MasterTableView Name="Conferences" DataKeyNames="ConferenceId">
            <Columns>
                <telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Conference Name" />
                <telerik:GridBoundColumn DataField="ActivityType" UniqueName="ActivityType" HeaderText="Activity Type" />
                <telerik:GridBoundColumn DataField="Description" UniqueName="Description" HeaderText="Description" />
                <telerik:GridNumericColumn DataField="BaseFee" UniqueName="BaseFee" HeaderText="Base Fee" NumericType="Currency" />
                <telerik:GridBoundColumn DataField="StartDate" UniqueName="StartDate" HeaderText="Start Date" />
                <telerik:GridBoundColumn DataField="EndDate" UniqueName="EndDate" HeaderText="End Date" />
            </Columns>
            <DetailTables>
                <telerik:GridTableView Name="ConferenceFeeTypes" DataKeyNames="ConferenceFeeId">
                    <Columns>
                        <telerik:GridBoundColumn DataField="FeeAdjustment" UniqueName="FeeAdjustment" HeaderText="FeeAdjustment" />
                        <telerik:GridBoundColumn DataField="FeeType" UniqueName="FeeType" HeaderText="FeeType" />
                        <telerik:GridNumericColumn DataField="Multiplier" UniqueName="Multiplier" HeaderText="Multiplier" NumericType="Currency" />
                    </Columns>
                </telerik:GridTableView>
            </DetailTables>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>