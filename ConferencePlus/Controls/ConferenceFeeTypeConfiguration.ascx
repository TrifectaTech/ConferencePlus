<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConferenceFeeTypeConfiguration.ascx.cs" Inherits="ConferencePlus.Controls.ConferenceFeeTypeConfiguration" %>
<table>
    <tr>
        <td>
            Fee Adjustment Type:
        </td>
        <td>
            <telerik:RadComboBox ID="ddlAdjustmentType" runat="server" EnableVirtualScrolling="true" />
        </td>
        <td>
            Fee Type:
        </td>
        <td>
            <telerik:RadComboBox ID="ddlFeeType" runat="server" EnableVirtualScrolling="true" />
        </td>
    </tr>
    <tr>
        <td>
            Multiplier:
        </td>
        <td>
            <telerik:RadNumericTextBox ID="txtMultiplier" runat="server" NumberFormat-DecimalDigits="2"/>
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