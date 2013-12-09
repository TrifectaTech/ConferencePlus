<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConferenceConfiguration.ascx.cs" Inherits="ConferencePlus.Controls.ConferenceConfiguration" %>
<table>
    <tr>
        <td>
            Activity Type:
        </td>
        <td>
            <telerik:RadComboBox ID="ddlActivties" runat="server" EnableVirtualScrolling="true" />
        </td>
        <td>
            Conference Name:
        </td>
        <td>
            <telerik:RadTextBox ID="txtName" runat="server"/>
        </td>
    </tr>
</table>
<br />

<table>
    <tr>
        <td>
            Start Date:
        </td>
        <td>
            <telerik:RadDateTimePicker ID="dtStartPicker" runat="server"/>
        </td>
        <td>
            End Date:
        </td>
        <td>
            <telerik:RadDateTimePicker ID="dtEndPicker" runat="server"/>
        </td>
    </tr>
</table>
<br />
<br />

<table>
    <tr>
        <td style="vertical-align:top" >
            Description:
        </td>
        <td>
            <telerik:RadTextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="200px" Width="450px" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <asp:Button ID="btnSave" CommandName="Update" runat="server" Text="Save" />
        </td>
        <td>
            <asp:Button ID="btnCancel" CommandName="Cancel" runat="server" Text="Cancel" />
        </td>
    </tr>
</table>