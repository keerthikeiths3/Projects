<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="test_home.aspx.cs" Inherits="test_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Panel ID="Panel1" runat="server" Width="500px" ScrollBars="None" Wrap="false" BorderStyle="Groove" BackColor="#ffcc00">
        <marquee>
            <p style="font-style:italic;font-size:larger;font-weight:bold;">
         Upcoming Movies
                </p>
    </marquee>
        </asp:Panel>
    <asp:Panel runat="server" Width="500px" ScrollBars="Horizontal" Wrap="false" BorderStyle="Groove">
        <ul style="list-style-type:none;display:inline-block;float:left;">

        <li style="display:inline">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="135px" 
            ImageUrl="~/Images/The-Avengers-Age-of-Ultron-movie-wallpaper.jpg" 
            onclick="ImageButton1_Click" Width="225px" />
            </li>
            <li style="display:inline">
                <asp:ImageButton ID="ImageButton3" runat="server" Height="135px" 
            ImageUrl="~/Images/Kick-2_Poster-300x212.jpg" onclick="ImageButton3_Click" 
            Width="225px" />
            </li>
            <li style="display:inline">
                <asp:ImageButton ID="ImageButton2" runat="server" Height="135px" 
            ImageUrl="~/Images/Golmaal-4-1.jpg" onclick="ImageButton2_Click" 
            Width="225px" />
            </li>
            <li style="display:inline">
                <asp:ImageButton ID="ImageButton4" runat="server" Height="135px" 
            ImageUrl="~/Images/furious7.jpg" onclick="ImageButton4_Click" 
            Width="225px" />
            </li>
            <li style="display:inline">
                <asp:ImageButton ID="ImageButton5" runat="server" Height="135px" 
            ImageUrl="~/Images/longest_ride.jpg" onclick="ImageButton5_Click" 
            Width="225px" />
            </li>
            </ul>
    </asp:Panel>
    <br /><br />
    <asp:Label ID="lblMovieName" runat="server" Text="Click on a movie" ForeColor="Black" Font-Underline="True" Font-Overline="False" Font-Bold="True" Font-Size="Large" Font-Italic="True" Font-Names="Segoe UI" ></asp:Label>
    <br /><br />
    <asp:TextBox ID="lblMovieSummary" runat="server" Height="120px" Width="500px" Wrap="true" TextMode="MultiLine" ForeColor="#993333" Font-Bold="true" Font-Size="Large" Font-Italic="true" Text="Movie Summary" ReadOnly="true" BackColor="#FFFFCC"></asp:TextBox>
    <br /><br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

