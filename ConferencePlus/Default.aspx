<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConferencePlus._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Everything is "learnable"</h1>
        <p class="lead">Conference Plus is a website to connect users to all sorts of interesting content.</p>
        <asp:LoginView runat="server" ViewStateMode="Disabled">
            <AnonymousTemplate>
                <p>
                    <asp:LinkButton runat="server" ID="btnSignUp" Text="Get Started For Free" PostBackUrl="~/Register.aspx" CssClass="btn btn-primary btn-lg" />
                </p>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <p>
                    <asp:LinkButton runat="server" ID="btnManageAccount" Text="Manage Account" PostBackUrl="~/Account/Manage.aspx" CssClass="btn btn-primary btn-lg" />
                </p>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Research</h2>
            <p>
                Interested in a topic? Curious about who we are and what we do?
            </p>
            <p>
                <asp:LinkButton runat="server" ID="btnResearch" Text="Learn More" PostBackUrl="~/About.aspx" CssClass="btn btn-default" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Learn</h2>
            <p>
                Have questions about a certain field? Learn more about your passion using Conference Plus
            </p>
            <p>
                <asp:LinkButton runat="server" ID="btnLearn" Text="Browse" PostBackUrl="~/Browse/BrowseConference.aspx" CssClass="btn btn-default" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Connect</h2>
            <asp:LoginView runat="server" ViewStateMode="Disabled">
                <AnonymousTemplate>
                    <p>
                        Build connections with professionals like yourself to last a lifetime. Create a free account today!
                    </p>
                    <p>
                        <asp:LinkButton runat="server" ID="btnSignUp" Text="Sign Up" PostBackUrl="~/Register.aspx" CssClass="btn btn-default" />

                    </p>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <p>
                        Build connections with professionals like yourself to last a lifetime. Manage your account with ease!
                    </p>
                    <p>
                        <asp:LinkButton runat="server" ID="btnManageAccount" Text="Manage Account" PostBackUrl="~/Account/Manage.aspx" CssClass="btn btn-default" />
                    </p>
                </LoggedInTemplate>
            </asp:LoginView>
        </div>
    </div>

</asp:Content>
