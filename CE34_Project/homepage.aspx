<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="CE34_Project.homepage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="~/homepage.css" rel="stylesheet" />
</head>
<body>
    <nav class="navbar">
        <p id="app-header">Blog Application</p>

        <ul class="navbar-menu">
            <form runat="server">
                <asp:Button ID="createbtn" runat="server" CssClass="navbar-link" Text="Create Blog" OnClick="createbtn_Click" />
                <asp:Button ID="signoutbtn" runat="server" CssClass="navbar-link" Text="Sign Out" OnClick="signoutbtn_Click" />
                <asp:Button ID="profilebtn" runat="server" Text="Profile" OnClick="profilebtn_Click" CssClass="navbar-link" />
            </form>
        </ul>
    </nav>

    <div class="center-container">
        <h1>My Blogs</h1>
        <asp:Repeater ID="BlogRepeater" runat="server">
            <ItemTemplate>
                <fieldset class="blog">
                    <legend class="blog-title"><%# Eval("title") %></legend>
                    <header class="blog-author"><%# Eval("author") %></header>
                    <p class="blog-body"><%# Eval("body") %></p>
                </fieldset>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</body>
</html>