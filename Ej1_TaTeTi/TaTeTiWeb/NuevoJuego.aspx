<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoJuego.aspx.cs" Inherits="TaTeTiWeb.NuevoJuego" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h3 class="display-4">Inicio del Juego</h3>
        <p class="lead">Ingrese su nombre de jugador</p>
    </div>

    <asp:Panel runat="server">

        <div class="container text-center">

            <div class="form-group row">
                <label for="tbNombre" class="col-4">Nombre</label><asp:TextBox ID="tbNombre" CssClass="form-control col-5" runat="server"/>
            </div>    
            
            <div class="form-group text-center">
                <asp:Button ID="btnAceptar" CssClass="btn btn-primary" Text="Comenzar el juego" OnClick="btnAceptar_Click" runat="server"/>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
