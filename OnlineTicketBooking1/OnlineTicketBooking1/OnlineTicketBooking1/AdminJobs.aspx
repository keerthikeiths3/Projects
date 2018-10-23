<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminJobs.aspx.cs" Inherits="AdminJobs" MasterPageFile="~/MasterPage.master"  %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

    <table class="style1">
        <tr>
            <td style="text-align: right; color: #000066; font-size: xx-large; font-variant: normal; font-style: oblique; text-transform: capitalize;" 
                class="style7">
                user operations</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style6" 
                
                style="text-transform: capitalize; font-size: xx-large; font-style: oblique; font-variant: normal; color: #000066;">
                Movie operations</td>
            <td class="style11">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7" 
                
                style="font-size: medium; font-weight: bold; font-style: normal; font-variant: normal; color: #000000; text-align: right;">
                Username</td>
            <td class="style10">
                <asp:TextBox ID="TextBoxUN1" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style8" 
                
                
                style="color: #000000; font-size: medium; font-style: normal; font-variant: normal; text-transform: none; font-weight: bold;">
                Movie Id</td>
            <td class="style11">
                <asp:TextBox ID="TextBoxMovieId" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:Button ID="ButtonMovieVerify" runat="server" Text="Verify" Width="70px" 
                    onclick="ButtonMovieVerify_Click" />
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style10">
                <asp:Button ID="ButtonVerify" runat="server" onclick="ButtonVerify_Click" 
                    Text="Verify" Width="70px" />
            </td>
            <td class="style8" 
                style="font-size: medium; font-weight: bold; font-style: normal; font-variant: normal; color: #000000">
                Movie Name</td>
            <td class="style11">
                <asp:TextBox ID="TextBoxMovieName" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style8" 
                style="font-size: medium; font-weight: bold; font-style: normal; font-variant: normal; color: #000000">
                Language</td>
            <td class="style11">
                <asp:TextBox ID="TextBoxML" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style8" 
                style="font-size: medium; font-weight: bold; font-style: normal; font-variant: normal; color: #000000">
                Genre</td>
            <td class="style11">
                <asp:TextBox ID="TextBoxMG" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style8" 
                style="font-size: medium; font-weight: bold; font-style: normal; font-variant: normal; color: #000000">
                Description</td>
            <td class="style11">
                <asp:TextBox ID="TextBoxMD" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style8" 
                style="font-size: medium; font-weight: bold; font-style: normal; font-variant: normal; color: #000000">
                Release Date</td>
            <td class="style11">
                <asp:TextBox ID="tbxRelDt" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style10">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style11">
                <asp:Button ID="btnAddUpdate" runat="server" onclick="btnAddUpdate_Click" 
                    Text="Add/Update" Width="70px" />
                <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
                    Text="Delete" Width="70px" />
                <asp:Button ID="btnReset1" runat="server" onclick="btnReset1_Click" 
                    Text="Reset" Width="70px" />
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
</asp:Content>
