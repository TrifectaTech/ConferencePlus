<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConferenceConfiguration.ascx.cs" Inherits="ConferencePlus.Controls.ConferenceConfiguration" %>
<table>
    <tr>
        <td>
            Activity Type:
        </td>
        <td>
            <telerik:RadComboBox ID="ddlActivties" runat="server" EnableVirtualScrolling="true" />
            <asp:RequiredFieldValidator ID="valactivites" runat="server" Text="*" ControlToValidate="ddlActivties" InitialValue="Select One" ForeColor="Red" />
        </td>
        <td>

        </td>
        <td>
            Conference Name:
        </td>
        <td>
            <telerik:RadTextBox ID="txtName" runat="server"/>
            <asp:RequiredFieldValidator ID="valName" runat="server" Text="*" ForeColor="Red" ControlToValidate="txtName" />
        </td>
    </tr>
    <tr>
        <td>
            Base Fee:
        </td>
        <td>
            <telerik:RadNumericTextBox ID="txtBaseFee" runat="server" Type="Currency" />
            <asp:RequiredFieldValidator ID="valfee" runat="server" Text="*" ForeColor="Red" ControlToValidate="txtBaseFee" />
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
            <asp:RequiredFieldValidator ID="valstart" ForeColor="Red" runat="server" Text="*" ControlToValidate="dtStartPicker" />
        </td>
        <td>
            End Date:
        </td>
        <td>
            <telerik:RadDateTimePicker ID="dtEndPicker" runat="server"/>
            <asp:RequiredFieldValidator ID="valend" ForeColor="Red" runat="server" Text="*" ControlToValidate="dtEndPicker" />
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
            <asp:RequiredFieldValidator ID="valDescription" ForeColor="Red" runat="server" Text="*" ControlToValidate="txtDescription" />
         </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <telerik:RadButton ID="btnSave" CommandName="Update" runat="server" Text="Save" CausesValidation="true" Skin="MetroTouch" />
        </td>
        <td>
            <telerik:RadButton ID="btnCancel" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false" Skin="MetroTouch" />
        </td>
    </tr>
</table>