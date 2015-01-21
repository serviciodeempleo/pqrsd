<%@ Page Language="C#" MasterPageFile="~/Interna.Master" AutoEventWireup="true" CodeBehind="llamadas.aspx.cs" Inherits="WebApplication1.llamadas" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHbotones" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Verificación Información por Teléfono:" 
                CssClass = "LetraTitulo"></asp:Label>
        <br /><br />
        <asp:Label ID="Label5" runat="server" Text="" CssClass = "LetraNormal">Por medio de este formulario se puede verificar la informaicón registrada en la plataforma por parte del usuario.<br><br>En caso de requerirse reiniciar el usuario y la contraseña por favor verificar si el correo electronico es similar, si no existe correo en el sistema, verificar contra la otra información. <br /><br />El sistema envia un correo directamente al ingresado en esta página.</asp:Label>
        <br /><br />
            <asp:Label ID="Label3" runat="server" Text="E-mail:" CssClass = "LetraNormalNegrilla"></asp:Label>
            <asp:TextBox ID="txtemail" runat="server" Width="354px" CssClass = "LetraNormal:"></asp:TextBox>
            </asp:DropDownList>
        
                <br /><br />
                <asp:Label ID="lblCedula" runat="server" Text="Número Identificación:" 
                CssClass = "LetraNormalNegrilla"></asp:Label>
            <asp:TextBox ID="txtCedula" runat="server" Width="354px" CssClass = "LetraNormal"></asp:TextBox>
            </asp:DropDownList>
            <br /><br />
            <asp:Button ID="btnEjecutarConsulta" runat="server" 
                Text="Realizar la Consulta..." onclick="Button1_Click" 
                CssClass="boton" />
            <br />
        
        <br />
            <br />
            <asp:GridView ID="tblResultado" runat="server" BorderStyle="None" 
                CellPadding="4" Font-Names="Arial" Font-Size="8pt" ForeColor="Gray">
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
        
            <asp:Button ID="btnReiniciarContrasegna" runat="server" 
                Text="Enviar Contraseña" onclick="btnReiniciarContrasegna_Click" 
                CssClass="boton" />
            <br />
            <br />
                        <asp:Label ID="lblerror" runat="server" CssClass = "LetraErro"></asp:Label>
        
            <br />
        
        </div>
            <asp:Label ID="lblMensajeFinal" runat="server" CssClass = "LetraNormal"></asp:Label>
    </div>

</asp:Content>
