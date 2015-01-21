<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link  rel="stylesheet" type="text/css" href="Principal.css"/>
</head>
<body>
    <form d="form1" runat="server" >
    <div>
        <div>
        
            <asp:Label ID="Label3" runat="server" Text="E-mail:" CssClass = "LetraNormal"></asp:Label>
            <asp:TextBox ID="txtemail" runat="server" Width="354px"></asp:TextBox>
            </asp:DropDownList>
        
                <br />
                <asp:Label ID="lblCedula" runat="server" Text="Numero Identificación:" CssClass = "LetraNormal"></asp:Label>
            <asp:TextBox ID="txtCedula" runat="server" Width="354px"></asp:TextBox>
            </asp:DropDownList>
        
        </div>
        <div>
        
            <asp:Label ID="Label1" runat="server" Text="Tipo Pregunta:" CssClass = "LetraNormal"></asp:Label>
            <asp:DropDownList ID="dplModelos" runat="server" Height="25px" Width="272px">
            </asp:DropDownList>
        
            <asp:Button ID="Button1" runat="server" Text="Hagalé" onclick="Button1_Click" />
        <br /><br />
            <asp:Label ID="lblerror" runat="server" CssClass = "LetraError"></asp:Label>
        <br /><br />
        </div>
        <div>
        
            <asp:Label ID="Label2" runat="server" Text="Respuesta:" CssClass = "LetraNormal"></asp:Label><br />
        </div>
        <div>
            <asp:Label ID="lblrespuesta" runat="server" CssClass = "  class = "LetraNormal"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
