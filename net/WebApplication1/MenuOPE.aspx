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
                <asp:Label ID="Label3" runat="server" Text="" CssClass = "LetraNormal">Buscador</asp:Label>&nbsp;

            </td>
            <td><asp:Button ID="btnRespuestasPQRs" runat="server" Text="Reinicio de contraseña" 
                    CssClass="boton" onclick="btnRespuestasPQRs_Click" Width="202px" />
            </td>
        </tr>
        <tr>
            <td>
               <asp:Label ID="Label2" runat="server" Text="" CssClass = "LetraNormal">Empleador</asp:Label>
            </td>
            <td>
                <asp:Button ID="btnEmpleador" runat="server" Text="Cambio de Fecha de Vacantes" 
                    CssClass="boton" Width="199px" OnClick="btnEmpleador_Click" />
            </td>
        </tr>
    </table>
    
</asp:Content>
