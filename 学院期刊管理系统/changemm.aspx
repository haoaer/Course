<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changemm.aspx.cs" Inherits="XYQK.demo21" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css"href="./css/box.css"/>
</head>
<body>
   <form id="form1" runat="server">
    
<div id="login-box">
    <br />
    <br />
    <br />
    <asp:Label  font Font-Size="Larger" ID="Label4" runat="server" Text="密码修改"></asp:Label>
     
    <br />
    <br />
    <br />
    <br />


    <asp:Label ID="Label1" runat="server" Text="原始密码"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="更改密码"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Width="60px" Height="30px" Text="确认" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Width="60px" Height="30px" Text="返回" OnClick="Button2_Click" />
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
</div>
</form>

</body>
</html>
