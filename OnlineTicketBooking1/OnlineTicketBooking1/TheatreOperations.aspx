<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TheatreOperations.aspx.cs" Inherits="TheatreOperations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <ContentTemplate>
    

<asp:GridView ID="GridView1" runat="server"  Width = "550px"

AutoGenerateColumns = "false" Font-Names = "Arial" 

Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  

HeaderStyle-BackColor = "green"  ShowFooter = "true"

PageSize = "10" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" >

<Columns>

<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Theatre_Name" HeaderStyle-ForeColor = "White" >

    <ItemTemplate>

        <asp:Label ID="lblTheatreName" runat="server" 

        Text='<%# Bind("Theatre_Name")%>'></asp:Label>

    </ItemTemplate> 

    <FooterTemplate>

        <asp:TextBox ID="txtTheatreName" Width = "140px" 

            MaxLength = "25" runat="server"></asp:TextBox>

    </FooterTemplate> 

</asp:TemplateField> 

<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Theatre_Id" HeaderStyle-ForeColor = "White">

    <ItemTemplate>

        <asp:Label ID="lblTheatreId" runat="server" 

        Text='<%# Bind("Theatre_Id")%>'></asp:Label>

    </ItemTemplate> 

    <FooterTemplate>

        <asp:TextBox ID="txtTheatreId" Width = "140px" 

            MaxLength = "25" runat="server"></asp:TextBox>

    </FooterTemplate> 

</asp:TemplateField> 



<asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Movie_Id" HeaderStyle-ForeColor = "White">

    <ItemTemplate>

        <asp:Label ID="lblMovieId" runat="server" 

        Text='<%# Bind("Movie_Id")%>'></asp:Label>

    </ItemTemplate> 

    <FooterTemplate>

        <asp:TextBox ID="txtMovieId" Width = "140px" 

            MaxLength = "25" runat="server"></asp:TextBox>

    </FooterTemplate> 
    </asp:TemplateField> 

    <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Movie_Name" HeaderStyle-ForeColor = "White">
     <ItemTemplate>

        <asp:Label ID="lblMovieName" runat="server" 

        Text='<%# Bind("Movie_Name")%>'></asp:Label>

    </ItemTemplate> 
   
    </asp:TemplateField> 

   
          <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Movie_Language" HeaderStyle-ForeColor = "White">
     <ItemTemplate>

        <asp:Label ID="lblMovieLanguage" runat="server" 

        Text='<%# Bind("Movie_Language")%>'></asp:Label>

    </ItemTemplate> 
   
    </asp:TemplateField>  
           <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Show_Time" HeaderStyle-ForeColor = "White">
     <ItemTemplate>

        <asp:Label ID="lblShowTime" runat="server" 

        Text='<%# Bind("Show_Time")%>'></asp:Label>

    </ItemTemplate> 
   
    </asp:TemplateField> 
    	 <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Show_Date" HeaderStyle-ForeColor = "White">
     <ItemTemplate>

        <asp:Label ID="lblShowDate" runat="server" 

        Text='<%# Bind("Show_Date")%>'></asp:Label>

    </ItemTemplate> 
   
    </asp:TemplateField> 

<asp:TemplateField>
    <EditItemTemplate>
          <asp:LinkButton ID="lnkBtnUpdate" runat="server" CausesValidation="True"
                         CommandName="Update" Text="Update"></asp:LinkButton>
                         &nbsp;<asp:LinkButton ID="lnkBtnCancel" runat="server"
                         CausesValidation="False"
                         CommandName="Cancel" Text="Cancel">
          </asp:LinkButton>
    </EditItemTemplate>
    <FooterTemplate>
       <asp:Button ID="btnAdd" runat="server" Text="Add" 

            OnClick = "AddNewCustomer" />

    </FooterTemplate>
    <ItemTemplate>
          <asp:LinkButton ID="lnkBtnEdit" runat="server" CausesValidation="False"
                          CommandName="Edit" Text="Edit"></asp:LinkButton>
                          &nbsp;<asp:LinkButton ID="lnkBtnDelete" runat="server"
                          CausesValidation="False"
                          CommandName="Delete" Text="Delete">
          </asp:LinkButton>
    </ItemTemplate>
</asp:TemplateField>

</Columns> 

<AlternatingRowStyle BackColor="#C2D69B"  />

</asp:GridView> 

</ContentTemplate> 

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

