<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration1.aspx.cs" Inherits="Registration1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>   
        <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: right;
            width: 176px;
        }
        .style3
        {
            width: 176px;
        }
        .style4
        {
            text-align: right;
            width: 176px;
            height: 26px;
        }
        .style5
        {
            height: 26px;
            width: 202px;
        }
        .style6
        {
            text-align: left;
            margin-left: 40px;
        }
        .style7
        {
            height: 26px;
            text-align: left;
        }
        #Reset1
        {
            width: 88px;
        }
        .style8
        {
            width: 202px;
        }
        .style9
        {
            font-family: "Times New Roman", Times, serif;
            font-size: x-large;
            color: #660066;
        }
            .auto-style1 {
                text-align: right;
                width: 176px;
                height: 26px;
                font-weight: bold;
            }
            .auto-style2 {
                text-align: right;
                width: 176px;
                font-weight: bold;
            }
    </style>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
    
        <table class="style1">
            <caption class="style9">
                <strong>REGISTRATION PAGE</strong></caption>
            <tr>
                <td id="Registration Page" class="auto-style1">
                    UserName</td>
                <td class="style5">
                    <asp:TextBox ID="TextBoxUserName" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style7">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBoxUserName" ErrorMessage="UserName is required." 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red" ValidationGroup="btnUserRegistration"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <b>E-mail</b></td>
                <td class="style8">
                    <asp:TextBox ID="TextBoxEmail" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBoxEmail" ErrorMessage="E-mail Id is required." 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red" ValidationGroup="btnUserRegistration"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="TextBoxEmail" ErrorMessage="Please enter a valid e-mail id." 
                        Font-Bold="True" Font-Size="Smaller" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="btnUserRegistration"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Password</td>
                <td class="style8">
                    <asp:TextBox ID="TextBoxPwd" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBoxPwd" ErrorMessage="Password is required." 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red" ValidationGroup="btnUserRegistration"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Confirm Password</td>
                <td class="style8">
                    <asp:TextBox ID="TextBoxConfirmPwd" runat="server" TextMode="Password" 
                        Width="180px"></asp:TextBox>
                </td>
                <td class="style6">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TextBoxConfirmPwd" 
                        ErrorMessage="Confirm Password is required." Font-Bold="True" Font-Size="Small" 
                        ForeColor="Red" ValidationGroup="btnUserRegistration"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TextBoxPwd" ControlToValidate="TextBoxConfirmPwd" 
                        ErrorMessage="Both passwords should match." Font-Bold="True" 
                        Font-Size="Smaller" ForeColor="Red" ValidationGroup="btnUserRegistration"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Phone Number</td>
                <td class="style8">
                    <asp:TextBox ID="TextBoxPh" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="TextBoxPh" ErrorMessage="Ph.no should be a valid one." 
                        Font-Bold="True" Font-Size="Small" ForeColor="Red" 
                        ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ValidationGroup="btnUserRegistration"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style8">
                    <asp:Button ID="UserRegistration" runat="server" onclick="Button1_Click" 
                        Text="Submit" Width="90px" ValidationGroup="btnUserRegistration" />
                    <asp:Button ID="tbxReset" runat="server" onclick="tbxReset_Click" 
                        Text="Reset" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

