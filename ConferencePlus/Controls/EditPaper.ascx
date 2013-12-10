<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPaper.ascx.cs" Inherits="ConferencePlus.Controls.EditPaper" %>

<asp:Panel runat="server" ID="pnlError" CssClass="alert-danger">
    <asp:Label runat="server" ID="lblError" />
</asp:Panel>

<div class="container">

    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblPaperName" Text="Paper Name:" />
            </td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtPaperName" Width="300px" />

                <asp:RequiredFieldValidator runat="server" ID="valPaperName" ControlToValidate="txtPaperName"
                    ErrorMessage="*Paper name is required" Display="Dynamic" CssClass="text-danger" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblPaperDescription" Text="Paper Description:" />
            </td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtPaperDescription" TextMode="MultiLine" Height="200px" Width="350px" MaxLength="600" />

                <asp:RequiredFieldValidator runat="server" ID="valPaperDescription" ControlToValidate="txtPaperDescription"
                    ErrorMessage="*Paper description is required" Display="Dynamic" CssClass="text-danger" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblAuthor" Text="Author:" />
            </td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtAuthor" />

                <asp:RequiredFieldValidator runat="server" ID="valAuthor" ControlToValidate="txtAuthor"
                    ErrorMessage="*Author is required" Display="Dynamic" CssClass="text-danger" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblPaperCategory" Text="Category:" />
            </td>
            <td>
                <telerik:RadComboBox runat="server" ID="ddlPaperCategory" Height="200px" Width="200px" EmptyMessage="Please select a category" />

                <asp:RequiredFieldValidator runat="server" ID="valPaperCategory" ControlToValidate="ddlPaperCategory" InitialValue="" 
                    ErrorMessage="*Category is required" CssClass="text-danger" />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadButton ID="btnSave" runat="server" CommandName="Update" Text="Save" Width="150px" Height="35px"/>
                
                <telerik:RadButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" Width="150px" Height="35px" CausesValidation="False" />
            </td>
        </tr>
    </table>
</div>
