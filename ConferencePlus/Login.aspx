<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KarzPlus.Login" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" ID="pnlLogin" DefaultButton="lgnKarzPlus$LoginButton">
        <asp:Login ID="lgnKarzPlus" runat="server" DisplayRememberMe="False" RememberMeSet="False" 
            TitleText="Please Log In" MembershipProvider="ConferencePlusAspNetSqlMembershipProvider" OnLoginError="lgnKarzPlus_LoginError">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LayoutTemplate>
                <div>
                    <h1>
                        <asp:Literal ID="LogInText" runat="server" Text="Please Log In" />
                    </h1>
                    <br />
                </div>
                <h4>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Text="User Name:" />
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" CssClass="input-lg" />
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="*User name is required." CssClass="text-danger"
                                    ToolTip="User Name is required." ValidationGroup="Login1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Password:" />
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input-lg" />
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="*Password is required." CssClass="text-danger"
                                    ToolTip="Password is required." ValidationGroup="Login1" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" Width="100px" CssClass="btn btn-primary" />
                    <br />
                    <br />
                    <span class="text-danger">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                    </span>
                </h4>
            </LayoutTemplate>
            <LoginButtonStyle Width="100px" />
            <TitleTextStyle Font-Bold="True" />
        </asp:Login>
    </asp:Panel>
</asp:Content>
