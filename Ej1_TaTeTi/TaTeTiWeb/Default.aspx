<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaTeTiWeb._Default" %>

<asp:Content ID="BodyContent"  ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Bienvenido!</h3>
        <p>Comience un nuevo y apasionante Ta-Te-Tí</p>
    </div>

    <div class="container row">
        <div class="card col-lg-3 col-md-5 col-sm-10 m-2 p-3">
            <img src="img/tateti.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body text-center">
                <div class="card-title">
                    <h5>Ta-Te-Tí</h5>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Iniciar nuevo juego</p>
                </div>
            </div>
            <div class="text-center">
                <asp:HyperLink ID="btnGetToken" CssClass="btn btn-primary" Text="Iniciar Juego" NavigateUrl="NuevoJuego.aspx" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
