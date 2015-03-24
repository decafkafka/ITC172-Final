<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Ultimate Music Database - Search for Shows</title>
    <%--<link href="UMDStyles.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>The Ultimate Music Database - Search for Shows</h1>
        <table>
        <tr>
            <td>Search shows by artist:</td>
            <td>
                <asp:DropDownList ID="ddArtist" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddArtist_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Search shows by genre:</td>
            <td>
                <asp:DropDownList ID="ddGenre" runat="server" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Search shows by venue:</td>
            <td>
                <asp:DropDownList ID="ddVenue" runat="server" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
    </table>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
