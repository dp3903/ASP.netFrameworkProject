<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CE34_Project.Profile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
    <link href="~/Profile.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="backbtn" runat="server" Text="Back to Homepage" OnClick="backbtn_Click" CssClass="back-button" />

        <div class="center-container">
            <h2>User Profile</h2>
            <asp:Label ID="UsernameLabel" runat="server" CssClass="profile-info" Text="Username"></asp:Label>
        </div>

        <div class="center-container">
            <h2>My Blogs</h2>
            <asp:Repeater ID="BlogRepeater" runat="server">
                <ItemTemplate>
                    <fieldset class="blog">
                        <legend class="blog-title">
                            <a href="BlogDetails.aspx?blogId=<%# Eval("Id") %>"><%# Eval("title") %></a>
                        </legend>
                        <header class="blog-author"><%# Eval("author") %></header>
                        <p class="blog-body"><%# Eval("body") %></p>
                        <asp:Button ID="DeleteBlog" runat="server" Text="Delete" CommandArgument='<%# Eval("Id") %>' OnClick="DeleteBlog_Click" CssClass="delete-button" />
                    </fieldset>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>