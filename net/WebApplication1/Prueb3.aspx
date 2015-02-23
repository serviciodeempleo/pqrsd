<%@ Page Title="" Language="C#" MasterPageFile="~/Interna.Master" AutoEventWireup="true" CodeBehind="Prueb3.aspx.cs" Inherits="WebApplication1.Prueb3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHbotones" runat="server">
  
    <asp:HiddenField ID="msg" runat="server" Value="" OnValueChanged="msg_ValueChanged" />
    <div style="margin-left: 40px">
        
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" ForeColor="#CC0000" Text="CAMBIO FECHA DE VACANTES"></asp:Label>
        <br />
        <br />
        ESTE NO ES EL FORMULARIO<br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Este formulario permitirá"></asp:Label>
        &nbsp;realizar el cambio de la fecha de ingreso y la fecha fin publicación de una vacante, y enviar el correo al solicitante.<br />
        <br />
        <asp:Label ID="Label7" runat="server" ForeColor="#0000CC" Text="Paso 1:"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Escriba el código de la vacante deseado para actualizar la fecha"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Codigo_Vacante" runat="server" OnTextChanged="txt_Codigo_Vacante_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Traer_Datos_Vacante" runat="server" OnClick="btn_Traer_Datos_Vacante_Click" Text="Consultar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <asp:RegularExpressionValidator ID="RegExValid_txt_Codigo_Vacante" runat="server" ControlToValidate="txt_Codigo_Vacante" ErrorMessage="El código de la vacante sólo acepta números" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;<asp:Label ID="Label14" runat="server" Text="*Fecha de Ingreso:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Ingreso" runat="server" Height="22px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
        <br />
&nbsp;
        <asp:Label ID="Label15" runat="server" Text="*Fecha Fin Publicación"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Fin_Publicacion" runat="server" Width="221px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Btn_Fecha_Fin_Publicacion" runat="server" Height="26px" OnClick="Btn_Fecha_Fin_Publicacion_Click" Text="Seleccionar Fecha Fin Publicación" Width="211px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <asp:Calendar ID="Calend_fec_finpublic" runat="server" Height="148px" OnSelectionChanged="Calend_fec_finpublic_SelectionChanged" SelectionMode="DayWeekMonth" Visible="False" Width="36px"></asp:Calendar>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;<asp:Label ID="Label16" runat="server" Text="*Fecha de Incorporación"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Incorporacion" runat="server" Width="211px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="Btn_FechaIncorporacion" runat="server" Height="26px" OnClick="Btn_FechaIncorporacion_Click" Text="Seleccionar Fecha  de Incorporación" Width="232px" />
        <br />
        <asp:Calendar ID="Calendar_fecha_incorporacion" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" FirstDayOfWeek="Sunday" Height="147px" SelectionMode="DayWeekMonth" Visible="False" Width="159px"></asp:Calendar>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Nombre del Centro:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Centro" runat="server" Width="263px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="Nombre de la sede:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_Nombre_Sede_Centro" runat="server" style="margin-left: 0px" Width="261px"></asp:TextBox>
        &nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label10" runat="server" Text="Nombre de la Empresa:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Empresa" runat="server" Width="262px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label11" runat="server" Text="Nombre de la sede:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Sede_Empresa" runat="server" Width="262px" style="margin-left: 0px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label22" runat="server" Text="Oferta:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Oferta" runat="server" Width="254px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;
        <br />
&nbsp;<asp:Label ID="Label13" runat="server" Text="Texto Anuncio:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Texto_Anuncio" runat="server" Height="86px" TextMode="MultiLine" Width="332px"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <asp:Label ID="Label21" runat="server" ForeColor="#0000CC" Text="Paso 2: Ingrese los datos y de click en el botón &quot;Actualizar Fechas y Enviar Respuesta&quot;"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lbl_Asunto" runat="server" Text="*Asunto:"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txt_Asunto" runat="server" Width="333px"></asp:TextBox>
&nbsp;&nbsp;

            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label18" runat="server" Text="*E-mail"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Email_destino" runat="server" Width="294px" style="margin-left: 0px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegExValid_txt_Email_destino" runat="server" ControlToValidate="txt_Email_destino" ErrorMessage="El campo E-mail debe tener formato de correo electrónico" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:CheckBox ID="chk_con_numero_PQRSD" runat="server" Text="Si la solicitud tiene identificador de PQRSD, por favor digitarlo" OnCheckedChanged="chk_con_numero_PQRSD_CheckedChanged" AutoPostBack="True" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_ID_PQRSD" runat="server" Width="89px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegExValid_txt_ID_PQRSD" runat="server" ControlToValidate="txt_ID_PQRSD" ErrorMessage="El ID de PQRSD sólo acepta números" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
            <br />
        <br />
                        <asp:Label ID="lblerrorotr" runat="server" CssClass = "LetraErro"></asp:Label>
        
            <br />
        <br />
        <asp:Button ID="btn_Enviar_Respuesta" runat="server" Text="Actualizar Fechas y Enviar Respuesta" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblError4" runat="server" Text="Error reportado:"></asp:Label>
        <br />
        <br />
        <br />
        
        
    <asp:Label ID="lblMensajeFinal" runat="server" Text="" CssClass = "LetraTituloVerdeNegrilla"></asp:Label>
        <br />
        <br />
    
    </div>
      <script type="text/javascript">
          if (document.getElementById("ctl00_CPHbotones_msg").value != "") {
              alert(document.getElementById("ctl00_CPHbotones_msg").value);
              document.getElementById("ctl00_CPHbotones_msg").value = "";
          }
            
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
