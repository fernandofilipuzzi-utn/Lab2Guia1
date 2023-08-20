<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Tablero.aspx.cs" Inherits="TaTeTiWeb.Tablero" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <style>
        /* Estilos personalizados */
        .custom-panel {
            min-width: 300px; /* Tamaño mínimo */
            max-width: 400px; /* Tamaño máximo */
            margin: 0 auto; /* Centrado horizontal */
            padding: 20px;
        }
    </style>

    <asp:Panel ID="plTablero" CssClass="custom-panel" runat="server">
        <div class="container">
            <div class="col" style="text-align: center;" >
                <div class="row">
                    <asp:Button ID="btn1" TabIndex="1" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg" 
                                        runat="server" OnClick="btnJugar_Click"/>
                    <asp:Button ID="btn2" TabIndex="2" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg" 
                                        runat="server" OnClick="btnJugar_Click"/>
                    <asp:Button ID="btn3" TabIndex="3" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg"  
                                        runat="server" OnClick="btnJugar_Click"/>
                </div>

                <div class="row">
                    <asp:Button ID="btn4" TabIndex="4" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg" 
                                        runat="server" OnClick="btnJugar_Click"/>
                    <asp:Button ID="btn5" TabIndex="5" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg"  
                                        runat="server" OnClick="btnJugar_Click"/>
                    <asp:Button ID="btn6" TabIndex="6" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg"  
                                        runat="server" OnClick="btnJugar_Click"/>
                </div>

                <div class="row">
                    <asp:Button ID="btn7" TabIndex="7" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg"  
                                        runat="server" OnClick="btnJugar_Click"/>
                    <asp:Button ID="btn8" TabIndex="8" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg"  
                                        runat="server" OnClick="btnJugar_Click"/>
                    <asp:Button ID="btn9" TabIndex="9" CssClass="boton-imagen btn btn-primary btn-custom btn-custom-lg"  
                                        runat="server" OnClick="btnJugar_Click"/>
                </div>
            </div>
        </div>
    </asp:Panel>

    <div class="container">
        <div class="row">
            <div class="col" style="text-align: center;" >
                <asp:Button ID="btnNuevo" Text="Nuevo" runat="server" OnClick="btnNuevo_Click"/>
                <!--
                <asp:Button ID="btnVerHistorial" Text="Historial" runat="server" OnClick="btnVerHistorial_Click"/>
                -->
             </div>
        </div>
    </div>

</asp:Content>
