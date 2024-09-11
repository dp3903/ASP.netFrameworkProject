<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="CE34_Project.homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="~/homepage.css" rel="stylesheet" />
</head>
<body>

    <!-- Navigation Bar -->
    <nav class="navbar">
        <p id="app-header">Blog Application</p>

        <ul class="navbar-menu">
            <form runat="server">
                <asp:Button ID="createbtn" runat="server" CssClass="navbar-link" Text="Create-blog" OnClick="createbtn_Click" />
                <asp:Button ID="searchbtn" runat="server" CssClass="navbar-link" Text="Search" OnClick="searchbtn_Click" />
                <asp:Button ID="signoutbtn" runat="server" CssClass="navbar-link" Text="Sign-Out" OnClick="signoutbtn_Click" />
            </form>
        </ul>
    </nav>

    <h1>Blogs</h1>

    <asp:Label ID="content" runat="server" CssClass="content" Text="Label"></asp:Label>
    
</body>
</html>
