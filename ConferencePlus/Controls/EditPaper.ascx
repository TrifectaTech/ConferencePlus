<%@ Control AutoEventWireup="true" CodeBehind="EditPaper.ascx.cs" Inherits="ConferencePlus.Controls.EditPaper" Language="C#" %>

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
				<telerik:radtextbox runat="server" id="txtPaperName" width="200px" />

				<asp:RequiredFieldValidator runat="server" ID="valPaperName" ControlToValidate="txtPaperName"
					ErrorMessage="*Paper name is required" Display="Dynamic" CssClass="text-danger" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label runat="server" ID="lblPaperDescription" Text="Paper Description:" />
			</td>
			<td>
				<telerik:radtextbox runat="server" id="txtPaperDescription" textmode="MultiLine" height="200px" width="350px" maxlength="600" />

				<asp:RequiredFieldValidator runat="server" ID="valPaperDescription" ControlToValidate="txtPaperDescription"
					ErrorMessage="*Paper description is required" Display="Dynamic" CssClass="text-danger" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label runat="server" ID="lblAuthor" Text="Author:" />
			</td>
			<td>
				<telerik:radtextbox runat="server" id="txtAuthor" />

				<asp:RequiredFieldValidator runat="server" ID="valAuthor" ControlToValidate="txtAuthor"
					ErrorMessage="*Author is required" Display="Dynamic" CssClass="text-danger" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label runat="server" ID="lblPaperCategory" Text="Category:" />
			</td>
			<td>
				<telerik:radcombobox runat="server" id="ddlPaperCategory" height="200px" width="200px" emptymessage="Please select a category" />

				<asp:RequiredFieldValidator runat="server" ID="valPaperCategory" ControlToValidate="ddlPaperCategory" InitialValue=""
					ErrorMessage="*Category is required" CssClass="text-danger" />
			</td>
		</tr>
		<tr>
			<td>
				<telerik:radbutton id="btnSave" runat="server" commandname="Update" text="Save" width="150px" height="35px" />

				<telerik:radbutton id="btnCancel" runat="server" commandname="Cancel" text="Cancel" width="150px" height="35px" />
			</td>
		</tr>
	</table>
</div>
