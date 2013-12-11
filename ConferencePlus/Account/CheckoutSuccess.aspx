<%@ Page Title="Success" Language="C#" AutoEventWireup="true" CodeBehind="CheckoutSuccess.aspx.cs" Inherits="ConferencePlus.Account.CheckoutSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />

</head>
<body class="alert-dismissable">
    <form id="form1" runat="server">

        <script type="text/javascript">

            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog  
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)  

                return oWindow;
            }

            function CloseAndReload() {

                var radWindow = GetRadWindow();

                radWindow.close();

                radWindow.BrowserWindow.RedirectToRegisteredEvents();

            }
            
            function PrintOrderDetails() {
                
                var prtContent = document.getElementById("printer-dialog");
                
                var winPrint = window.open('', '', 'letf=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
                
                winPrint.document.write(prtContent.innerHTML);
                
                winPrint.document.close();
                
                winPrint.focus();
                
                winPrint.print();
                
                winPrint.close();
            }

        </script>

        <div class="container">
            <h3>Congratulations <%= Username %>! You have successfully checked out!
            </h3>
            <h4>
                Thanks for choosing Conference Plus. The details of your order is below. You will receive an email confirmation shortly.
            </h4>

            <br />
            
            <fieldset>
                <legend>Printer Friendly Version</legend>
                <table>
                    <tr>
                        <td>
                            
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-sm btn-primary" OnClientClick="PrintOrderDetails();" />
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
            </fieldset>

            <br />
            <br />
            <div id="printer-dialog">
                <fieldset>
                    <legend class="text-primary">Order Details</legend>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblTransactionIdHeader" Text="Transaction Id:" />
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblTransactionId" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblConferenceHeader" Text="Conference:"/>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblConferenceName" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblRegisteredPaperHeader" Text="Paper:"/>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblPaperName"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblTopicHeader" Text="Paper Topic:"/>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblPaperTopic"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblEventDateHeader" Text="Event Date:"/>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblEventDate" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <br />
            <br />
            <asp:Button runat="server" ID="btnClose" CssClass="btn btn-lg" Text="Close" OnClientClick="CloseAndReload()" />
        </div>
    </form>
</body>
</html>
