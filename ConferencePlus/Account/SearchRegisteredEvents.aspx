<%@ Page Title="Registered Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchRegisteredEvents.aspx.cs" Inherits="ConferencePlus.Account.SearchRegisteredEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <telerik:RadCodeBlock runat="server">
        <script type="text/javascript">
            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("btnExportToCsv") >= 0)
                    args.set_enableAjax(false);
            }
    </script>
    </telerik:RadCodeBlock>

    <telerik:RadFormDecorator runat="server" ID="decorator" DecoratedControls="Default" Skin="MetroTouch" />

    <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="MetroTouch" />

    <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1" LoadingPanelID="LoadingPanel1" ClientEvents-OnRequestStart="onRequestStart">

        <h2>
            <asp:Label ID="lblTitle" runat="server" />
            <br/>
        </h2>
        
        <div class="container">
            
            <fieldset>
                <legend class="text-left">Export Participated Events</legend>
                <table>
                    <tr>
                        <td>
                            <telerik:RadButton runat="server" ID="btnExportToCsv" Text="Export To CSV" OnClick="btnExportToCsv_OnClick"/>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br/>

            <fieldset>
                <legend class="text-info">You have participated in the following events</legend>
                <telerik:RadGrid runat="server" ID="grdRegisteredEvents" AllowSorting="True" AutoGenerateColumns="False" AllowFilteringByColumn="True" Skin="MetroTouch"
                    OnItemDataBound="grdRegisteredEvents_OnItemDataBound" OnNeedDataSource="grdRegisteredEvents_OnNeedDataSource">
                    <MasterTableView Name="RegisteredEvents" DataKeyNames="ConferenceId, UserId, PaperId" NoMasterRecordsText="No events registered">
                        <Columns>
                            <telerik:GridBoundColumn DataField="ConferenceName" UniqueName="ConferenceName" HeaderText="Conference Name" />
                            <telerik:GridBoundColumn DataField="FormattedConferenceDate" UniqueName="FormattedConferenceDate" HeaderText="Conference Date"/>
                            <telerik:GridBoundColumn DataField="FormattedActivityType" UniqueName="FormattedActivityType" HeaderText="Activity Type" />
                            <telerik:GridBoundColumn DataField="StartDate" UniqueName="StartDate" HeaderText="Event Date" DataFormatString="{0:MM/dd/yyyy}" />
                            <telerik:GridBoundColumn DataField="FormattedFoodPreference" UniqueName="FormattedFoodPreference" HeaderText="Food Preference" />
                            <telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Paper Name" />
                            <telerik:GridBoundColumn DataField="FormattedPaperCategory" UniqueName="FormattedPaperCategory" HeaderText="Paper Category" />
                            <telerik:GridBoundColumn DataField="Author" UniqueName="Author" HeaderText="Author" />
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </fieldset>
        </div>
        <br />
    </telerik:RadAjaxPanel>

</asp:Content>
