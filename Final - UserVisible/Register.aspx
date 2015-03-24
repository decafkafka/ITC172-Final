<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Ultimate Music Database - Registration</title>
    <link href="UMDStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>The Ultimate Music Database - Registration</h1>
    <table>
        <tr>
            <td>Name</td>
            <td>
                <asp:TextBox ID="txtFanName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Venue Email</td>
            <td>
                <asp:TextBox ID="txtFanEmail" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>User Name</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password">
                </asp:TextBox></td>
        </tr>
         <tr>
            <td>Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password">
                </asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" style="height: 26px" /></td>
            <td>
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </td>
        </tr>
    </table>
        <asp:RequiredFieldValidator ID="FanNameValidator" ControlToValidate="txtFanName" runat="server" ErrorMessage="Your name is required" Display="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="FanEmailValidator" ControlToValidate="txtFanEmail" runat="server" ErrorMessage="A valid email address is required" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="FanLoginUserNameValidator" ControlToValidate="txtUserName" runat="server" ErrorMessage="User name is required"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="FanLoginPasswordPlainValidator" ControlToValidate="txtPassword" runat="server" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="FanLoginConfirmValidator" ControlToValidate="txtConfirm" runat="server" ErrorMessage="Please confirm your password"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="PasswordCompare" ControlToValidate="txtPassword" ControlToCompare="txtConfirm" runat="server" ErrorMessage="Passwords don't match"></asp:CompareValidator>  </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
    <a href="Default.aspx">Log In</a>
</body>
</html>