<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogDetails.aspx.cs" Inherits="CE34_Project.BlogDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blog Details</title>
    <link href="~/BlogDetails.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="backbtn" runat="server" Text="Back to Homepage" OnClick="backbtn_Click" CssClass="back-button" />

        <div class="blog-details-container">
            <!-- Blog Title -->
            <h1><asp:Label ID="lblTitle" runat="server" CssClass="blog-title" /></h1>
            
            <!-- Blog Author -->
            <h3>Written by: <asp:Label ID="lblAuthor" runat="server" CssClass="blog-author" /></h3>
            
            <!-- Blog Content -->
            <p><asp:Label ID="lblBody" runat="server" CssClass="blog-body" /></p>

            <!-- Add New Comment Section -->
            <h3>Add a Comment:</h3>
            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" CssClass="comment-input"></asp:TextBox>
            <asp:Button ID="submitCommentBtn" runat="server" Text="Submit Comment" OnClick="submitCommentBtn_Click" />
            <asp:Label ID="message" runat="server" ForeColor="Red" Visible="false"></asp:Label>

            <!-- Comments Section -->
            <h3>Comments:</h3>
            <asp:Repeater ID="CommentsRepeater" runat="server">
                <ItemTemplate>
                    <fieldset class="comment">
                        <legend><%# Eval("username") %> said on <%# Eval("timestamp") %>:</legend>
                        <p><%# Eval("comment") %></p>
                    </fieldset>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>