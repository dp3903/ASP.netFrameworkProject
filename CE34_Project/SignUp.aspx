<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CE34_Project.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign-up</title>
    <link href="~/signup.css" rel="stylesheet" />
</head>
<body>
    <h1>Blog Application</h1>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td> 
                    <label for="userName">User Name</label>
                </td>
                <td>
                     <asp:TextBox ID="userName" runat="server" AccessKey="u" ToolTip="Enter Username"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="usrnameValidator" runat="server" ErrorMessage="Username is Required." ControlToValidate="userName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True">Username is Required.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                     <label for="password">Password</label>
                </td>
                <td>
                    <asp:TextBox ID="password" runat="server" AccessKey="p" ToolTip="Enter Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="password" ErrorMessage="Password is Required." ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>
                     <label for="confirmPassword">Confirm Password</label>
                </td>
                <td>
                    <asp:TextBox ID="confirmPassword" runat="server" AccessKey="c" ToolTip="Re-Enter/Confirm Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="confirmPasswordValidator" runat="server" ControlToValidate="confirmPassword" ErrorMessage="Please confirm the Password." ForeColor="Red" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password" ControlToValidate="confirmPassword" Display="Dynamic" ErrorMessage="Confirm Password must be equal to Password." ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                </td>
            </tr>
        </table>
        
        <br />
        <asp:Button ID="registerbtn" runat="server" Text="Sign up" OnClick="registerbtn_Click" />
  
        <p>
            Already have an account? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignIn.aspx">Go to sign-in</asp:HyperLink>
        </p>
  
        <asp:Label ID="message" runat="server" CssClass="message" Text="Label" Visible="False"></asp:Label>
  
    </form>
</body>
</html>
