<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cambio_Fech_Vacantes.aspx.cs" Inherits="WebApplication1.Cambio_Fech_Vacantes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


.LetraErro
{
	color: #FF0000;
	text-decoration: underline;
	font-family: Arial;
	font-size: 10px;
}

.LetraTituloVerdeNegrilla
{
	font-family: Arial, Helvetica, sans-serif;
	font-size: 16px;
	color: #33CC33;
	text-align: justify;
	font-style: normal;
	font-weight: bold;
}


    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" ForeColor="#CC0000" Text="CAMBIO FECHA DE VACANTES"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Este formulario, permitirá"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" ForeColor="#0000CC" Text="Paso 1"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Escriba el código de la vacante deseado para actualizar la fecha"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Codigo_Vacante" runat="server" OnTextChanged="txt_Codigo_Vacante_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Traer_Datos_Vacante" runat="server" OnClick="btn_Traer_Datos_Vacante_Click" Text="Traer_Datos" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
&nbsp;<asp:Label ID="Label14" runat="server" Text="Fecha de Ingreso:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Ingreso" runat="server"></asp:TextBox>
&nbsp;<br />
        <br />
&nbsp;
        <asp:Label ID="Label15" runat="server" Text="Fecha Fin Publicación"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Fin_Publicacion" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label16" runat="server" Text="Fecha de Incorporación"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Incorporacion" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Nombre del Centro:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Centro" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="Nombre de la sede:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Sede_Centro" runat="server"></asp:TextBox>
        &nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label10" runat="server" Text="Nombre de la Empresa:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Empresa" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label11" runat="server" Text="Nombre de la sede:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Sede_Empresa" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label13" runat="server" Text="Texto Anuncio:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Texto_Anuncio" runat="server" Height="86px" TextMode="MultiLine" Width="332px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btn_Mostrar_Grilla" runat="server" Text="Mostrar Grilla" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:GridView ID="Grid_informacion_vacante" runat="server">
        </asp:GridView>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Actualizar_Fechas" runat="server" OnClick="btn_Actualizar_Fechas_Click" Text="Actualizar Fechas" style="height: 26px" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label19" runat="server" Text="Asunto:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txt_Asunto" runat="server" Width="333px"></asp:TextBox>
&nbsp;&nbsp;

            <asp:Label ID="lblAsunto" runat="server" CssClass = "LetraErro"></asp:Label>
            
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label18" runat="server" Text="E_mail"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Email" runat="server" Width="218px"></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="chk_con_numero_PQRSD" runat="server" Text="Si la solicitud tiene identificador de PQRSD, por favor digitarlo" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_ID_PQRSD" runat="server" Width="218px"></asp:TextBox>
&nbsp;&nbsp;
            <br />
        <br />
                        <asp:Label ID="lblerror" runat="server" CssClass = "LetraErro"></asp:Label>
        
            <br />
        <br />
        <asp:Button ID="btn_Enviar_Respuesta" runat="server" Text="Actualizar Fechas y Enviar Respuesta" OnClick="Button2_Click" />
        <br />
        <br />
        <br />
        
        
    <asp:Label ID="lblMensajeFinal" runat="server" Text="" CssClass = "LetraTituloVerdeNegrilla"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
