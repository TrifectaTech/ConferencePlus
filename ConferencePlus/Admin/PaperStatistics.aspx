<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PaperStatistics.aspx.cs" Inherits="ConferencePlus.Admin.PaperStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("btnExportCSV") >= 0)
                args.set_enableAjax(false);
        }
    </script>
    <h1>
        <asp:Label ID="Label1" runat="server" Text="Paper Statistics" />
    </h1>

    <br />
    <telerik:RadAjaxLoadingPanel ID="LdingPnl" Skin="MetroTouch" runat="server"/>
    <telerik:RadAjaxPanel ID="ajxPnl" LoadingPanelID="LdingPnl" runat="server" ClientEvents-OnRequestStart="onRequestStart">
    <asp:Label ID="lblmessage" runat="server" ForeColor="Red" />
    <br />
        <div class="container">
        <fieldset>
            <legend>Export</legend>
        </fieldset>
        <table>
            <tr>
                <td>
                    <telerik:RadButton ID="btnExportCSV" runat="server" OnClick="btnExportCSV_OnClick" Text="Export to CSV" />
                </td>
            </tr>
        </table>
          
    <br />
            <div class="container">
        <fieldset>
            <legend class="text-info">Paper Statistics Display List</legend>
        </fieldset>
    <telerik:RadGrid ID="grdStatistics" OnNeedDataSource="grdStatistics_NeedDataSource" runat="server" 
        AutoGenerateColumns="false" AllowSorting="true" AllowFilteringByColumn="true"
        AllowPaging="true" Skin="MetroTouch">
        <MasterTableView Name="Statistics" DataKeyNames="ConferenceId"  AutoGenerateColumns="false">
            <Columns>
                <telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Conference Name" />
                <telerik:GridBoundColumn DataField="PaperCategory" UniqueName="PaperCategory" HeaderText="Paper Category" />
                <telerik:GridBoundColumn DataField="PaperCategoryDescription" UniqueName="PaperCategoryDescription" HeaderText="Paper Description" />
                <telerik:GridNumericColumn DataField="PaperCategoryCount" UniqueName="PaperCategoryCount" HeaderText="Paper Count" NumericType="Number" />
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
                  </div>
        </telerik:RadAjaxPanel>
</asp:Content>
