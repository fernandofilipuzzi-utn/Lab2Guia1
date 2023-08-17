<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Tablero.aspx.cs" Inherits="TaTeTiWeb.Tablero" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Panel ID="plTablero" runat="server">

        <style>
            .boton-imagen {
                width: 100px;
                height: 100px;
                 background-image: url('./Resources/N.png');
                 background-size: cover; 
             }
        </style>

        <div>
            <asp:Button ID="btn1" TabIndex="1" CssClass="boton-imagen" runat="server" OnClick="btn_Click"/>
            <asp:Button ID="btn2" TabIndex="2" CssClass="boton-imagen" runat="server" OnClick="btn_Click"/>
            <asp:Button ID="btn3" TabIndex="3" CssClass="boton-imagen"  runat="server" OnClick="btn_Click"/>
        </div>
                   
        <div>
            <asp:Button ID="btn4" TabIndex="4" CssClass="boton-imagen"  runat="server" OnClick="btn_Click"/>
            <asp:Button ID="btn5" TabIndex="5" CssClass="boton-imagen"  runat="server" OnClick="btn_Click"/>
            <asp:Button ID="btn6" TabIndex="6" CssClass="boton-imagen"  runat="server" OnClick="btn_Click"/>
        </div>
       
        <div>
            <asp:Button ID="btn7" TabIndex="7" CssClass="boton-imagen"  runat="server" OnClick="btn_Click"/>
            <asp:Button ID="btn8" TabIndex="8" CssClass="boton-imagen"  runat="server" OnClick="btn_Click"/>
            <asp:Button ID="btn9" TabIndex="9" CssClass="boton-imagen"  runat="server" OnClick="btn_Click"/>
        </div>

    </asp:Panel>

</asp:Content>
