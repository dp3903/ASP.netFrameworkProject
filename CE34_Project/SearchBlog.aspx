<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchBlog.aspx.cs" Inherits="CE34_Project.SearchBlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Blogs</title>
    <link href="~/SearchBlog.css" rel="stylesheet" />
</head>
<body>
    <!-- Navbar or header can be added here -->
    <h1>Search Blogs</h1>
    
    <!-- Search Form -->
    <form id="searchForm" runat="server" class="search-form">
        <div class="search-container">
            <asp:TextBox ID="searchInput" runat="server" CssClass="search-input" Placeholder="Search by blog title..."></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" CssClass="search-button" Text="Search" OnClick="searchButton_Click" />
        </div>
    </form>
    
    <!-- Search Results -->
    <div id="searchResults" class="search-results">
        <!-- Dynamic content will be inserted here from server-side -->
        <!-- Example of a single blog post result -->
        <asp:Repeater ID="searchResultsRepeater" runat="server">
            <ItemTemplate>
                <div class="blog-card">
                    <h2 class="blog-title"><%# Eval("title") %></h2>
                    <p class="blog-author">By: <%# Eval("author") %></p>
                    <p class="blog-body"><%# Eval("body") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</body>
</html>
