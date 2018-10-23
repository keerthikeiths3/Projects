<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMovieOp.aspx.cs" Inherits="AdminMovieOp" MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size: xx-large; font-weight: normal; font-style: oblique; font-variant: normal; text-transform: capitalize; color: #000066">
    
    </div>
    <table class="style1">
        <tr>
            <td class="style2" 
                style="font-size: xx-large; font-weight: normal; font-style: oblique; font-variant: small-caps; text-transform: capitalize; color: #000066">
                Movie operations</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="font-weight: bold">
                Movie Id</td>
            <td>
                <asp:TextBox ID="TextBoxMovieId1" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="font-weight: bold">
                Movie Name</td>
            <td>
                <asp:TextBox ID="TextBoxMovieName1" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="font-weight: bold">
                Language</td>
            <td>
                <asp:TextBox ID="TextBoxMovieLang" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="font-weight: bold">
                Genre</td>
            <td>
                <asp:TextBox ID="TextBoxMovieGenre" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="font-weight: bold">
                Description</td>
            <td>
                <asp:TextBox ID="TextBoxMovieDesc" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="font-weight: bold">
&nbsp;Movie Timings</td>
            <td>
                <asp:TextBox ID="TextBoxMovieTimings" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" style="font-weight: bold">
                Available seats</td>
            <td>
                <asp:TextBox ID="TextBoxMovieSeats" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <strong>Theaters</strong></td>
            <td>
                <asp:TextBox ID="TextBoxMovieTheaters" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonMovieUpdate" runat="server" 
                    onclick="ButtonMovieUpdate_Click" Text="Update" Width="70px" />
                <asp:Button ID="ButtonMovieDelete" runat="server" 
                    onclick="ButtonMovieDelete_Click" Text="Delete" Width="70px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
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