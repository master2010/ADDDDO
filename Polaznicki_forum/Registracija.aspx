<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="Polaznicki_forum.Registracija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>REGISTRACIJA - unesite podatke</h3>

    <p>USERNAME:   
        <asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox></p>

    <p>PASSWORD:   
        <asp:TextBox ID="tbxPw1" runat="server" TextMode="Password"></asp:TextBox></p>

    <p>PASSWORD_again:   
        <asp:TextBox ID="tbxPw2" runat="server" TextMode="Password"></asp:TextBox></p>

    <p id="par_obj" runat="server"></p>

    <asp:Button ID="btnReg" runat="server" Text="registracija" />




</asp:Content>
