<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="style1">
    
        <h1 class="style2" 
            style="font-size: xx-large; font-weight: normal; font-style: oblique; font-variant: normal; text-transform: capitalize; color: #000066">
            Admin Login</h1>
    
    </div>
    <table class="style3">
        <tr>
            <td class="style4">
                <strong>Admin Username</strong></td>
            <td>
                <asp:TextBox ID="TextBoxAdminUN" runat="server" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxAdminUN" ErrorMessage="please enter admin username" 
                    Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <strong>Password</strong></td>
            <td>
                <asp:TextBox ID="TextBoxAdminPwd" runat="server" TextMode="Password" 
                    Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBoxAdminPwd" ErrorMessage="Please enter password" 
                    Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Login" 
                    Width="70px" />
                <asp:Button ID="btnReset9" runat="server" onclick="btnReset9_Click" 
                    Text="Reset" Width="70px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </asp:Content>