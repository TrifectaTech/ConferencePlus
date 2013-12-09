<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KarzPlus.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <asp:Panel runat="server" CssClass="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <asp:CreateUserWizard runat="server" ID="cuwUserWizard" 
            ContinueDestinationPageUrl="~/Default.aspx"
            MembershipProvider="ConferencePlusAspNetSqlMembershipProvider" OnCreatedUser="cuwUserWizard_OnCreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                    <ContentTemplate>
                        <h4>
                            <table>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="">User Name:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" CssClass="input-lg" />
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="cuwUserWizard" CssClass="text-danger">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input-lg" />
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="cuwUserWizard" CssClass="text-danger">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="input-lg" />
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server"
                                            ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required."
                                            ToolTip="Confirm Password is required." ValidationGroup="cuwUserWizard" CssClass="text-danger">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Email" runat="server" CssClass="input-lg" />
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required."
                                            ToolTip="E-mail is required." ValidationGroup="cuwUserWizard" CssClass="text-danger">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic"
                                            ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="cuwUserWizard" CssClass="text-danger" />
                                    </td>
                                </tr>
                                <tr>
                                    <div class="text-danger">
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </div>
                                </tr>
                            </table>
                        </h4>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                        <table border="0" cellspacing="5" style="width:100%;height:100%;">
                            <tr align="right">
                                <td align="right" colspan="0">
                                    <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Create User" 
                                        ValidationGroup="cuwUserWizard" OnPreRender="StepNextButton_OnPreRender" CssClass="btn btn-primary" />
                                </td>
                            </tr>
                        </table>
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                    <ContentTemplate>
                        <table>
                            <h4>
                                <tr>
                                    <td align="center">Complete</td>
                                </tr>
                                <tr>
                                    <td>Your account has been successfully created.</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <br />
                                        <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue" Text="Continue" 
                                            ValidationGroup="cuwUserWizard" CssClass="btn btn-primary" OnPreRender="ContinueButton_OnPreRender" />
                                    </td>
                                </tr>
                            </h4>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </asp:Panel>
</asp:Content>
