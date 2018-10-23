<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TicketBookingPage1.aspx.cs" Inherits="TicketBookingPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <style type="text/css">
        .style1
        {
            font-family: "Times New Roman", Times, serif;
            font-size: large;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            text-align: right;
            width: 113px;
        }
        .style4
        {
            text-align: left;
            width: 173px;
        }
        .style5
        {
            width: 173px;
        }
        .style6
        {
        text-align: left;
        width: 113px;
    }
        .style7
        {
            width: 384px;
        }
        .style8
        {
            text-align: left;
            width: 150px;
        }
    .style9
    {
        width: 264px;
    }
    </style>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <strong><span class="style1">&nbsp;&nbsp; </span>
        <asp:Label ID="lblTicketBooking" runat="server" CssClass="style1" 
            Text="Welcome To The Ticket Booking Page"></asp:Label>
        </strong>
    
    </div>
    &nbsp;
    <asp:Label ID="Label1" runat="server" Text="Choose Your Combo"></asp:Label>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <table class="style2">
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="lblCombo_name" runat="server" Text="Combo_Name"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="lblCombo_Menu" runat="server" Text="Combo_Menu"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCombo_Price" runat="server" Text="Combo_Price"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:RadioButton ID="RadioButton1" runat="server" 
                    oncheckedchanged="RadioButton1_CheckedChanged" Text="Select Combo" 
                    AutoPostBack="True" GroupName="Combo" />
            </td>
            <td class="style4">
                <asp:TextBox ID="tbtMiniCombo" runat="server" ReadOnly="True">Mini Combo</asp:TextBox>
            </td>
            <td class="style9">
                <asp:TextBox ID="tbtComboMenuSmall" runat="server" Width="200px" 
                    ontextchanged="tbtComboMenuSmall_TextChanged" ReadOnly="True">Coke,Nachos,Popcorn(Small)</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbtComboPriceSmall" runat="server" ReadOnly="True">10</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" 
                    GroupName="Combo" oncheckedchanged="RadioButton2_CheckedChanged" 
                    Text="Select Combo" />
            </td>
            <td class="style4">
                <asp:TextBox ID="tbtMediumCombo" runat="server" ReadOnly="True">Medium Combo</asp:TextBox>
            </td>
            <td class="style9">
                <asp:TextBox ID="tbtComboMenuMedium" runat="server" Width="200px" 
                    ReadOnly="True">Coke,Nachos,Popcorn(Medium)</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbtComboPriceMedium" runat="server" ReadOnly="True">15</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" 
                    GroupName="Combo" oncheckedchanged="RadioButton3_CheckedChanged" 
                    Text="Select Combo" />
            </td>
            <td class="style4">
                <asp:TextBox ID="tbtLargeCombo" runat="server" ReadOnly="True">Large Combo</asp:TextBox>
            </td>
            <td class="style9">
                <asp:TextBox ID="tbtComboMenuLarge" runat="server" Width="200px" 
                    ReadOnly="True">Coke,Nachos,Popcorn(Large)</asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbtComboPriceLarge" runat="server" ReadOnly="True">20</asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblComboSelected" runat="server" Text="Combo Selected"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbxComboSelected" runat="server" 
    ontextchanged="TextBox1_TextChanged"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblPrice" runat="server" Text="Cost"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbtPrice" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="tbxReset" runat="server" onclick="tbxReset_Click" 
        Text="Reset" />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" 
        Text="Please Select Class And Number of Seats :-"></asp:Label>
    <br />
    <br />
    <asp:DropDownList ID="drdClass" runat="server" 
    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
        AutoPostBack="True">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="drdSeats" runat="server" 
        onselectedindexchanged="drdSeats_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;
    <asp:Label ID="lblSeatsRemaining" runat="server" Text="Seats Available :"></asp:Label>
&nbsp;
    <asp:TextBox ID="tbxSeatsAvailable" runat="server" ReadOnly="True" 
        ontextchanged="tbxSeatsAvailable_TextChanged"></asp:TextBox>
    <br />
    <br />
    <table class="style2">
        <tr>
            <td class="style8">
                <asp:Label ID="lblTicketPrice" runat="server" Text="Ticket Price"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="tbxTicketPrice" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="lblComboPrice" runat="server" Text="Combo Price"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="tbxComboPrice" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="lblTax" runat="server" Text="Tax"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="tbxTax" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amout Payable"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="tbxTotalAmount" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnPay" runat="server" Text=" Proceed To Checkout" 
        Enabled="False" onclick="btnPay_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

