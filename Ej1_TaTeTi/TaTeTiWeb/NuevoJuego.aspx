<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="NuevoJuego.aspx.cs" Inherits="TaTeTiWeb.NuevoJuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    </style>

    <asp:Panel runat="server">
        <div class="container">
            <div class="row">
                <div class="col-6" style="text-align: right;" >
                    <asp:Label Text="Nombre:" runat="server"/>
                </div>
                <div class="col-6" style="text-align: left;">
                    <asp:TextBox ID="tbNombre" runat="server"/>
                </div>
            </div>    
            
            <div class="row">
                <div class="col" style="text-align: center;" >
                    <asp:Button ID="btnAceptar" Text="Comenzar el juego" OnClick="btnAceptar_Click" runat="server"/>
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
