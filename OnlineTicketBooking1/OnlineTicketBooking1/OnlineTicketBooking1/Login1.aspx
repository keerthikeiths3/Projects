<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login1.aspx.cs" Inherits="Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <style type="text/css">
        .style10
        {
            font-size: xx-large;
            color: #660033;
            text-align: center;
        }
        .style11
        {
            font-size: xx-large;
            color: #660033;
            text-align: justify;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 169px;
        }
        .style4
        {
            width: 169px;
            text-align: right;
        }
        .style5
        {
            font-family: "Times New Roman", Times, serif;
            font-size: large;
        }
    .auto-style1 {
        width: 169px;
        text-align: right;
        font-weight: bold;
    }
    </style>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <%--<div class="style10">
        <strong>Login Page</strong></div>--%>
    <table class="style2">
        <tr>
            <td class="style11" colspan="3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <strong>Login Page </strong>
            </td>


        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td class="auto-style1">
                UserName</td>
            <td>
                <asp:TextBox ID="TextBoxUN" runat="server" style="height: 22px" Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldUN" runat="server" ErrorMessage="Username Required" ValidationGroup="btnLogin" ControlToValidate="TextBoxUN"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                Password</td>
            <td>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" style="height: 22px" 
                    Width="180px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldPW" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Password Required" ValidationGroup="btnLogin"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonLogin" runat="server" onclick="ButtonLogin_Click" 
                    Text="Login" Width="84px" ValidationGroup="btnLogin" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <strong>
                <asp:Label ID="lblExistingUser" runat="server" CssClass="style5" 
                    Text="Not an existing user ???"></asp:Label>
                </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="hypRegisteration" runat="server" 
                    NavigateUrl="~/Registration1.aspx" style="font-weight: 700">Register Here !!</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

