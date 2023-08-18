<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="NuevoJuego.aspx.cs" Inherits="TaTeTiWeb.NuevoJuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label Text="Nombre:" runat="server"/>
        <asp:TextBox ID="tbNombre" runat="server"/>
    </div>
    <asp:Button ID="btnAceptar" Text="Comenzar el juego" 
                OnClick="btnAceptar_Click" runat="server"/>
</asp:Content>
