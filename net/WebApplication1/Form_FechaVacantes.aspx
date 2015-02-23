<%@ Page Title="" Language="C#" MasterPageFile="~/Interna.Master" AutoEventWireup="true" CodeBehind="Form_FechaVacantes.aspx.cs" Inherits="WebApplication1.Form_FechaVacantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <br />
        <asp:Label ID="Label4" runat="server" Text="Cambio Fecha de Vacantes" CssClass = "LetraTitulo"></asp:Label>
  
        &nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label5" runat="server" Text="Este formulario permite cambiar la fecha de ingreso y fecha fin publicación de una vacante, y enviar el correo al solicitante." CssClass = "LetraNormal"></asp:Label>
            
        <br />
        <br />
                <asp:Label ID="lblCedula0" runat="server" Text="Paso 1:     " 
                CssClass = "LetraTituloVerdeNegrilla"></asp:Label>
        
                <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Escriba el código de la vacante deseada para actualizar la fecha:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txt_Codigo_Vacante" runat="server" OnTextChanged="txt_Codigo_Vacante_TextChanged" Height="18px" MaxLength="20"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Traer_Datos_Vacante" runat="server" OnClick="btn_Traer_Datos_Vacante_Click" Text="Consultar" Height="28px" />
&nbsp;
        <asp:RegularExpressionValidator ID="RegExValid_txt_Codigo_Vacante" runat="server" ControlToValidate="txt_Codigo_Vacante" ErrorMessage="El código de la vacante sólo acepta números" ValidationExpression="[0-9]+" CssClass="LetraErro"></asp:RegularExpressionValidator>
        <br />
        <br />
        <br />
        <asp:Label ID="Label14" runat="server" Text="*Fecha de Ingreso:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Ingreso" runat="server" Height="18px" Width="240px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Lbl_validac_alconsultar" runat="server" ForeColor="#3333CC" Text="VALIDACIONES AL CONSULTAR"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label15" runat="server" Text="*Fecha Fin Publicación:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;
        <asp:TextBox ID="dt_Fecha_Fin_Publicacion" runat="server" Width="240px" Height="18px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Btn_Fecha_Fin_Publicacion" runat="server" Height="26px" OnClick="Btn_Fecha_Fin_Publicacion_Click" Text="Seleccionar Fecha Fin Publicación" Width="229px" style="margin-left: 8px" />
        <br />
        <br />
        <asp:Calendar ID="Calend_fec_finpublic" runat="server" Height="95px" OnSelectionChanged="Calend_fec_finpublic_SelectionChanged" SelectionMode="DayWeekMonth" Visible="False" Width="16px" BackColor="#FFCC00" BorderStyle="Double" CssClass="boton"></asp:Calendar>
        <br />
        <br />
        <asp:Label ID="Label23" runat="server" Text="Número de días transcurridos entre fecha de ingreso y publicación:" CssClass="LetraNormalNegrilla"></asp:Label>
    &nbsp;
        <asp:TextBox ID="txt_diasentrefeingreyfefinpub" runat="server" Height="18px" Width="231px"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label16" runat="server" Text="*Fecha de Incorporación:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="dt_Fecha_Incorporacion" runat="server" Width="273px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="Btn_FechaIncorporacion" runat="server" Height="26px" OnClick="Btn_FechaIncorporacion_Click" Text="Seleccionar Fecha  de Incorporación" Width="239px" />
        <br />
        <br />
        <asp:Calendar ID="Calendar_fecha_incorporacion" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Height="95px" SelectionMode="DayWeekMonth" Visible="False" Width="16px" BackColor="#FFCC00" BorderStyle="Double" CssClass="boton"></asp:Calendar>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Nombre del Centro:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Centro" runat="server" Width="330px" Height="18px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="Nombre de la sede:" CssClass="LetraNormalNegrilla"></asp:Label>
        &nbsp; <asp:TextBox ID="txt_Nombre_Sede_Centro" runat="server" style="margin-left: 0px" Width="261px" Height="18px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Nombre de la Empresa:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;
        <asp:TextBox ID="txt_Nombre_Empresa" runat="server" Width="306px" Height="18px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label11" runat="server" Text="Nombre de la sede:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txt_Nombre_Sede_Empresa" runat="server" Width="255px" style="margin-left: 0px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label22" runat="server" Text="Oferta:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_Oferta" runat="server" Width="317px" Height="18px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label13" runat="server" Text="Texto Anuncio:" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txt_Texto_Anuncio" runat="server" Height="86px" TextMode="MultiLine" Width="332px"></asp:TextBox>
        <br />
        <br />
                <asp:Label ID="lblCedula1" runat="server" Text="Paso 2:     " 
                CssClass = "LetraTituloVerdeNegrilla"></asp:Label>
        
                <br />
        <br />
        <asp:Label ID="Label24" runat="server" Text="Ingrese los datos y de click en el botón &quot;Actualizar Fechas y Enviar Respuesta&quot;." CssClass="LetraNormalNegrilla"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lbl_Asunto" runat="server" Text="*Asunto:" CssClass="LetraNormalNegrilla"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txt_Asunto" runat="server" Width="333px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label18" runat="server" Text="*E-mail" CssClass="LetraNormalNegrilla"></asp:Label>
&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="txt_Email_destino" runat="server" Width="335px" style="margin-left: 0px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegExValid_txt_Email_destino" runat="server" ControlToValidate="txt_Email_destino" ErrorMessage="El campo E-mail debe tener formato de correo electrónico" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="LetraErro"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:CheckBox ID="chk_con_numero_PQRSD" runat="server" Text="Si la solicitud tiene identificador de PQRSD, por favor digitarlo" OnCheckedChanged="chk_con_numero_PQRSD_CheckedChanged" AutoPostBack="True" CssClass="LetraNormalNegrilla" />
&nbsp;&nbsp;
        <asp:TextBox ID="txt_ID_PQRSD" runat="server" Width="89px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:RegularExpressionValidator ID="RegExValid_txt_ID_PQRSD" runat="server" ControlToValidate="txt_ID_PQRSD" ErrorMessage="El ID de PQRSD sólo acepta números" ValidationExpression="[0-9]+" CssClass="LetraErro"></asp:RegularExpressionValidator>
            <br />
                        <asp:Label ID="lblerrorotr" runat="server" CssClass = "LetraErro"></asp:Label>
        
            <br />
        <br />
        <asp:Button ID="btn_Enviar_Respuesta" runat="server" Text="Actualizar Fechas y Enviar Respuesta" OnClick="Button2_Click" />
        &nbsp;&nbsp;
        <asp:Label ID="LblError4" runat="server" Text="Otros errores:" CssClass="LetraErro"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HiddenField ID="CuadroMensConsultAct" runat="server" Value="" OnValueChanged="msg_ValueChanged" />
        <br />
        <asp:Label ID="Lbl_Valid_al_actualizar" runat="server" ForeColor="#3333CC" Text="VALIDACIONES AL ACTUALIZAR"></asp:Label>
        <br />
        <br />


         <script type="text/javascript">
             if (document.getElementById("ctl00_ContentPlaceHolder1_CuadroMensConsultAct").value != "") {
                 alert(document.getElementById("ctl00_ContentPlaceHolder1_CuadroMensConsultAct").value);
                 document.getElementById("ctl00_ContentPlaceHolder1_CuadroMensConsultAct").value = "";
             }

    </script>

        </asp:Content>
