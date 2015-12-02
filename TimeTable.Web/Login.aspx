<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VIKO EIF TimeTable Log In</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css" />
    <link href="styles/bootstrap-grid.css" rel="stylesheet" type="text/css" />
    <link href="styles/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="login" runat="server">
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <h1><a href="/">VIKO EIF <span>TimeTable</span></a></h1>
        <div id="loginform-block">
            <asp:Login ID="loginform" runat="server" TitleText="" DisplayRememberMe="false" PasswordLabelText="Password" UserNameLabelText="Username" OnAuthenticate="loginform_Authenticate"  DestinationPageUrl="~/Admin/Admin.aspx" OnLoggedIn="loginform_LoggedIn"></asp:Login>
        </div>       
    </form>
</body>
</html>
