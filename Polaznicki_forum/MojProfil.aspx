<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MojProfil.aspx.cs" Inherits="Polaznicki_forum.MojProfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> PROFIL
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblKorisnik" runat="server"></asp:Label>
&nbsp;[<asp:Label ID="lblGrupa" runat="server"></asp:Label>
    ]<br />
    <br />
    <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
    <span class="auto-style1">UREDI PASSWORD </span>&nbsp;
    <br />
    <br />
    STARI PASSWORD:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbxPwdStari" runat="server"></asp:TextBox>
    <br />
    <br />
    NOVI PASSWORD:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbxPwdNovi" runat="server"></asp:TextBox>
    <br />
    <br />
    NOVI PASSWORD:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbxPwdNoviPonovo" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnPswd" runat="server" OnClick="btnPswd_Click" Text="Button" />
    <br />
    <br />
    <br />
    <br />
    <br />
    EMAIL:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnEmail" runat="server" OnClick="btnEmail_Click" Text="Button" />
    <br />
</asp:Content>
