<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TicketSummary.aspx.cs" Inherits="TicketSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            width: 226px;
        }
        .style5
        {
            height: 23px;
            width: 226px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <p style="font-size: x-large; font-weight: bold; font-style: oblique; font-variant: normal; color: #000066">
        Ticket Summary
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="style2">
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Your confirmation No:</td>
            <td>
                <asp:TextBox ID="tbxConfirmationId" runat="server" Width="180px" 
                    ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Name on the ticket</td>
            <td>
                <asp:TextBox ID="tbxNameOnTicket" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Movie Name</td>
            <td>
                <asp:TextBox ID="tbxMovieName" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Theatre Name</td>
            <td class="style3">
                <asp:TextBox ID="tbxTheatreName" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="style3">
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Number of seats booked</td>
            <td>
                <asp:TextBox ID="tbxSeats" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Combo selected</td>
            <td>
                <asp:TextBox ID="tbxCombo" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Seat Type</td>
            <td>
                <asp:TextBox ID="tbxSeatType" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Show Date</td>
            <td>
                <asp:TextBox ID="tbxShowDate" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Show Time</td>
            <td>
                <asp:TextBox ID="tbxShowTime" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                Price</td>
            <td>
                <asp:TextBox ID="tbxPrice" runat="server" Width="180px" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Print PDF" 
                    onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" 
                style="font-size: medium; font-weight: bold; font-style: italic; text-transform: none; color: #800000">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

