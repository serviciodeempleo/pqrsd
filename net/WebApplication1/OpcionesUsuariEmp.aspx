<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpcionesUsuariEmp.aspx.cs" Inherits="WebApplication1.OpcionesUsuariEmp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 164px">
    
        <br />
        <br />
        <asp:Button ID="btn_Opc_Usuario" runat="server" Text="Buscador " Width="130px" OnClick="btn_Opc_Usuario_Click" />
        <br />
        <br />
        <asp:Button ID="btn_Opc_Empresa" runat="server" Text="Empresa" Width="125px" OnClick="btn_Opc_Empresa_Click" />
    
    </div>
    </form>
</body>
</html>
