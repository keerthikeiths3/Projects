<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookingTicket1.aspx.cs" Inherits="BookingTicket1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Reset1_onclick() {

        }

// ]]>
    </script>
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
            width: 257px;
            text-align: right;
        }
            #Reset1
            {
                width: 73px;
            }
    </style>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
    
        <asp:Label ID="lbl_Welcome" runat="server" 
            style="font-family: 'Times New Roman', Times, serif; font-weight: 700; font-size: large; color: #000099" 
            Text="Welcome...."></asp:Label>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Select Movie</td>
                <td>
                    <asp:DropDownList ID="drdSelectMovie" runat="server" Height="24px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="169px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Select Theatre</td>
                <td>
                    <asp:DropDownList ID="drdSelectTheatre" runat="server" Height="24px" 
                        onselectedindexchanged="DropDownList2_SelectedIndexChanged" Width="166px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Select Date</td>
                <td>
                    <asp:DropDownList ID="drdSelectDate" runat="server" Height="24px" 
                        onselectedindexchanged="DropDownList3_SelectedIndexChanged" Width="168px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Select Time</td>
                <td>
                    <asp:DropDownList ID="drdSelectTime" runat="server" Height="24px" 
                        onselectedindexchanged="DropDownList4_SelectedIndexChanged" Width="168px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="btnBookNow" runat="server" onclick="btnBookNow_Click" 
                        Text="Book Now" />
                </td>
                <td>
                    <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
                        Text="Reset" />
                </td>
            </tr>
        </table>
        <br />
        <br />
    
    </div>
    <asp:Button ID="btn_Logout" runat="server" onclick="btn_Logout_Click" 
        style="height: 26px" Text="Logout" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

