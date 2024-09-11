<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newBlog.aspx.cs" Inherits="CE34_Project.newBlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/newBlog.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 645px;
        }
        .auto-style2 {
            width: 529px;
        }
    </style>
</head>
<body>
    <h1>New Blog</h1>
    <form id="newblog" runat="server">
        
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <label for="title">Blog-Title</label>
                </td>
                <td>
                    <asp:TextBox ID="title" runat="server" CssClass="textbox" ToolTip="Enter Blog Title" AccessKey="t"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="title" Display="Dynamic" ErrorMessage="Blog Title is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <label for="body">Blog-Body</label>
                </td>
                <td>
                    <asp:TextBox ID="body" runat="server" CssClass="textbox" ToolTip="Enter Blog Body" AccessKey="b" TextMode="MultiLine"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="body" Display="Dynamic" ErrorMessage="Blog Body is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <label>Created by:</label>
                </td>
                <td>
                    <asp:Label ID="creator" runat="server"></asp:Label>
                </td>
            </tr>
            
        </table>
        
        <!-- #region name -->
        <p class="btns">
            <asp:Button runat="server" OnClick="cancelbtn_Click" ID="cancelbtn" AccessKey="c" CssClass="cancelbtn" Text="Cancel" CausesValidation="False" UseSubmitBehavior="False" />
            <asp:Button runat="server" OnClick="createbtn_Click" ID="createbtn" AccessKey="s" CssClass="createbtn" Text="Create" />
        </p>

        <!-- #endregion -->
    </form>

    <asp:Label runat="server" ID="message" ></asp:Label>
</body>
</html>
