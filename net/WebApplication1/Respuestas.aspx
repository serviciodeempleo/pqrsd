<%@ Page Language="C#" MasterPageFile="~/Interna.Master" AutoEventWireup="true" CodeBehind="Respuestas.aspx.cs" Inherits="WebApplication1.Respuestas" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="margin-left: 40px">
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="Cambio de Contraseñas" CssClass = "LetraTitulo"></asp:Label>
        <br /><br />
        <asp:Label ID="Label5" runat="server" Text="Este formulario permite realizar el restablecimiento de contraseña para que un usuario o empleador pueda ingresar a la plataforma de RedEmpleo." CssClass = "LetraNormal"></asp:Label>
            
        <br /><br />
                <asp:Label ID="lblCedula0" runat="server" Text="Paso 1:     " 
                CssClass = "LetraTituloVerdeNegrilla"></asp:Label>
        
                <br /><br />
                <asp:Label ID="lblCedula" runat="server" Text="Numero Identificación:" CssClass = "LetraNormalNegrilla"></asp:Label>
            <asp:TextBox ID="txtCedula" runat="server" Width="162px" 
                CssClass = "LetraNormal" MaxLength="20"></asp:TextBox>
            <asp:Label ID="lblrespuesta" runat="server" CssClass = "LetraErro"></asp:Label>
            
            <br /><br />
            <asp:Button ID="btnEjecutarConsulta0" runat="server" 
                Text="Verificar" onclick="btnEjecutarConsulta0_Click" 
                CssClass="boton" CausesValidation="False" />
        
            <br /><br />
            </div>

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
            
            <br /><br />
            <asp:Label ID="Label6" runat="server" Text="Solicitud:" 
            CssClass = "LetraNormalNegrilla"></asp:Label>
            <asp:DropDownList ID="dplModelos" runat="server" Height="25px" 
            Width="272px" CssClass = "LetraNormal" Enabled="False" OnSelectedIndexChanged="dplModelos_SelectedIndexChanged">
            </asp:DropDownList><br /><br />
            <asp:Label ID="Label3" runat="server" Text="E-mail:" CssClass = "LetraNormalNegrilla"></asp:Label>
            <asp:TextBox ID="txtemail" runat="server" Width="354px" 
                CssClass = "LetraNormal:"></asp:TextBox>
<br /><br />
            <asp:CheckBox ID="chkPQRSD" runat="server" 
                
                Text="En caso que la solicitud sea de PQRSD por favor digitar el consecutivo:" 
                CssClass = "LetraNormalNegrilla" AutoPostBack="True" 
                oncheckedchanged="chkPQRSD_CheckedChanged"/>
            <asp:TextBox ID="txtConsecutivo" runat="server" Width="80px" 
                CssClass = "LetraNormal:"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPQRSD" runat="server" 
                ErrorMessage="RequiredFieldValidator" CssClass = "LetraErro" 
                ControlToValidate="txtConsecutivo">El ID del PQRSD es necesario</asp:RequiredFieldValidator>
            <br />
            <br />
        <asp:Label ID="Label7" runat="server" Text="Asunto:" CssClass = "LetraNormalNegrilla" ></asp:Label>
                    <asp:TextBox ID="txtAsunto" runat="server" Width="354px" 
                CssClass = "LetraNormal:"></asp:TextBox>

            <asp:Label ID="lblAsunto" runat="server" CssClass = "LetraErro"></asp:Label>
            
        <br />

        <br />
                <asp:Label ID="lblCedula1" runat="server" Text="Paso 2:     " 
                CssClass = "LetraTituloVerdeNegrilla"></asp:Label>
            <asp:Button ID="btnEjecutarConsulta" runat="server" 
                Text="Generar y enviar respuesta" onclick="Button1_Click" 
                CssClass="boton" />
            <br />
                        <asp:Label ID="lblerror" runat="server" CssClass = "LetraErro"></asp:Label>
        
        <br /><br />
        <br />
        
        
    <asp:Label ID="lblMensajeFinal" runat="server" Text="" CssClass = "LetraTituloVerdeNegrilla"></asp:Label>
    </div>
</asp:Content>
