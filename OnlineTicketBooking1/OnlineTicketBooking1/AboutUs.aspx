<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Sample3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 751px;
            margin-left: 280px;
        }
        .style5
        {
            color: #000066;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="style2">
        <tr>
            <td class="style3">
                <asp:ImageButton ID="ImageButton5" runat="server" 
                    ImageUrl="~/Images/Untitled.jpg" Height="130px" Width="362px" />
            </td>
        </tr>
        <tr>
            <td class="style3" 
                style="font-size: medium; font-weight: bold; font-style: italic; font-variant: normal; text-transform: none; color: #800000">
                Get Movie Times and Tickets in Minutes on Online Ticket Booking. Find movie 
                theater showtimes, watch trailers, read reviews and buy movie tickets here. 
                Online Ticket Booking is your place for movie information.. !!<br />
                <span class="style5">Follow this site to buy tickets online and beat the movie 
                crowd! </span>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:ImageButton ID="ImageButton6" runat="server" Height="126px" 
                    ImageUrl="~/Images/T 118A-1.jpg" Width="143px" />
            </td>
        </tr>
    </table>
</asp:Content>

