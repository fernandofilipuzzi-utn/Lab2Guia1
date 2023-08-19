<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Historial.aspx.cs" Inherits="TaTeTiWeb.Historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="ltwHistorial" runat="server">
         <LayoutTemplate>            
            <table>
                <tr>
                    <th>Jugador</th>
                    <th>Partidas</th>

                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </tr>
            </table>
        </LayoutTemplate> 
        <ItemTemplate>
            <tr>
                <td>    
                        <%#Eval("Ganador")%>
                </td>
                <td>
                        <%#Eval("Ganadas")%>
                </td>
           </tr>
        </ItemTemplate>
    </asp:ListView>
        
</asp:Content>
