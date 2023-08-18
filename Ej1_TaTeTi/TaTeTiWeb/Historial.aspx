<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Historial.aspx.cs" Inherits="TaTeTiWeb.Historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ltwHistorial" runat="server">
        <ItemTemplate>
            <asp:Label Text='<%#Eval("Ganador")%>' runat="server"/>
            <asp:Label Text='<%#Eval("Ganadas")%>' runat="server"/>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
