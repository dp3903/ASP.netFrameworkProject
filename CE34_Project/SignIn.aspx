<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CE34_Project.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign-in</title>
    <link href="~/signin.css" rel="stylesheet" />
</head>
<body>
    <h1>Blog Application</h1>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td> 
                    <label for="userName">Username:</label>
                </td>
                <td>
                     <asp:TextBox ID="userName" runat="server" AccessKey="u" ToolTip="Enter Username"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="usrnameValidator" runat="server" ErrorMessage="Username is Required." ControlToValidate="userName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True">Username is Required.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                     <label for="password">Password:</label>
                </td>
                <td>
                    <asp:TextBox ID="password" runat="server" AccessKey="p" ToolTip="Enter Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="password" ErrorMessage="Password is Required." ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
       

       
        
        <br />
        <asp:Button ID="loginbtn" runat="server" OnClick="loginbtn_Click" Text="Sign In" />
       
         <p>
            Don't have an account? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignUp.aspx">Register Here.</asp:HyperLink>
        </p>
       
        <asp:Label ID="message" runat="server" CssClass="message" Text="Label" Visible="False"></asp:Label>
        
    </form>
</body>
</html>
