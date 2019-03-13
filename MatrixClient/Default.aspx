<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MatrixClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label><br/><br/>

    Dataset Size:&nbsp; <asp:TextBox ID="txtSize" runat="server" Width="50"></asp:TextBox>
    &nbsp;<asp:Button ID="btnValidate" runat="server" Text="Validate" OnClick="Validate_Click" /><br/><br/><br/>
    
    
    A = <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <br/> X<br/>
    B = <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br/><br/>
   AXB (MD5 hash value) = <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br/><br/><br/>

    Validation Result = <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
 
</asp:Content>
