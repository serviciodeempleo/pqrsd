<%@ Page Language="C#" MasterPageFile="~/Interna.Master" AutoEventWireup="true" CodeBehind="MenuOPE.aspx.cs" Inherits="WebApplication1.menu" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <asp:Label ID="Label4" runat="server" Text="" CssClass = "LetraNormal">Para entrar a la página haga click sobre el nombre de la misma.</asp:Label>
    <br /><br />
    <table style="width:590px;">
        <tr>
            <td colspan = "2" align = "center">
                <asp:Label ID="Label1" runat="server" Text="" CssClass = "LetraTitulo">Menú Principal</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnRespuestasPQRs" runat="server" Text="Respuestas a PQRs" 
                    CssClass="boton" onclick="btnRespuestasPQRs_Click" Width="190px" />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="" CssClass = "LetraNormal">Permite dar respuestas a PQRs con formatos preestablecidos</asp:Label></td></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnllamadas" runat="server" Text="Apoyo a Llamadas" CssClass="boton"
                    Width="190px" onclick="btnllamadas_Click" Enabled="False" 
                    Visible="False" />
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" 
                    Text="Base de Información de conocimiento." CssClass = "LetraNormal" 
                    Visible="False"></asp:Label></td>
        </tr>
    </table>
    
</asp:Content>
