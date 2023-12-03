<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tablero.aspx.cs" Inherits="TaTeTiWeb.Tablero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        /* Estilos personalizados */
    </style>

    <asp:Panel ID="plTablero" runat="server">

        <div class="container align-content-center">
            <div class="container-fluid col-12">
                <div class="row" style="justify-content: center;">
                    <div class="btn-group">
                        <asp:Button ID="btn1" type="button" TabIndex="1" CssClass="btn btn-outline-primary " style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                        <asp:Button ID="btn2" type="button" TabIndex="2" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                        <asp:Button ID="btn3" type="button" TabIndex="3" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                    </div>
                </div>
                <div class="row" style="justify-content: center;">
                    <div class="btn-group">
                        <asp:Button ID="btn4" type="button" TabIndex="4" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                        <asp:Button ID="btn5" type="button" TabIndex="5" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                        <asp:Button ID="btn6" type="button" TabIndex="6" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                    </div>
                </div>
                <div class="row" style="justify-content: center;">
                    <div class=" btn-group">
                        <asp:Button ID="btn7" type="button" TabIndex="7" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                        <asp:Button ID="btn8" type="button" TabIndex="8" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                        <asp:Button ID="btn9" type="button" TabIndex="9" CssClass="btn btn-outline-primary" style="width:120px; height:120px;" runat="server" OnClick="btnJugar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <div class="container">
        <div class="row">
            <div class="col" style="text-align: center;">
                <asp:Button ID="btnNuevo" CssClass="btn btn-primary" Text="Nuevo Juego" runat="server" OnClick="btnNuevo_Click" />
                <!--
                <asp:Button ID="btnVerHistorial" Text="Historial" runat="server" OnClick="btnVerHistorial_Click"/>
                -->
            </div>
        </div>
    </div>

</asp:Content>
