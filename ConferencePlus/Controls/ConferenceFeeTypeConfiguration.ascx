﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConferenceFeeTypeConfiguration.ascx.cs" Inherits="ConferencePlus.Controls.ConferenceFeeTypeConfiguration" %>
<table>
    <tr>
        <td>
            Fee Adjustment Type:
        </td>
        <td>
            <telerik:RadComboBox ID="ddlAdjustmentType" runat="server" EnableVirtualScrolling="true" />
            <asp:RequiredFieldValidator ID="valadjustment" runat="server" Text="*" ForeColor="Red" ControlToValidate="ddlAdjustmentType" InitialValue="Select One" />
        </td>
        <td>
            Fee Type:
        </td>
        <td>
            <telerik:RadComboBox ID="ddlFeeType" runat="server" EnableVirtualScrolling="true" />
            <asp:RequiredFieldValidator ID="valfeetype" runat="server" Text="*" ForeColor="Red" ControlToValidate="ddlFeeType" InitialValue="Select One" />
        </td>
    </tr>
    <tr>
        <td>
            Multiplier:
        </td>
        <td>
            <telerik:RadNumericTextBox ID="txtMultiplier" runat="server" NumberFormat-DecimalDigits="2"/>
            <asp:RequiredFieldValidator ID="valMultiplier" runat="server" ForeColor="Red" Text="*" ControlToValidate="txtMultiplier" />
        </td>
    </tr>
</table>
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
            <telerik:RadButton ID="btnSave" CommandName="Update" runat="server" Text="Save" CausesValidation="true"/>
        </td>
        <td>
            <telerik:RadButton ID="btnCancel" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false"/>
        </td>
    </tr>
</table>