<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Polaznicki_forum.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
        <h3>login:&nbsp;&nbsp;
        <asp:textbox id="tbxlogin" runat="server"></asp:textbox>
        </h3>

        <h3>pass:&nbsp;&nbsp;&nbsp;
        <asp:textbox id="tbxpass" runat="server" textmode="password"></asp:textbox>
        </h3>
        <p>
            &nbsp;
        </p>

            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    </div>



</asp:Content>
