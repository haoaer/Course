<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher1.aspx.cs" Inherits="XYQK.teacher1"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>教师</title>
    <link rel="stylesheet" type="text/css"href="./css/table1.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="title">
            个人信息：&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="编号"></asp:Label>：
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="姓名"></asp:Label>：
        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="专业"></asp:Label>：
        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>&nbsp;<asp:Button ID="Button2" runat="server" Text="退出登录" OnClick="Button2_Click" style="float:right" BackColor="#ff6600"/>

    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="修改密码" OnClick="Button1_Click" style="float:right" BackColor="#ff6600"/>
                </div>
        <br />
        <asp:Label ID="Label7" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="类别"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="50px" AutoPostBack="True"></asp:DropDownList>

        <asp:DropDownList ID="DropDownList2" runat="server" Width="70px"></asp:DropDownList>
       
        <asp:Label ID="Label9" runat="server" Text="出版社"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
        <asp:Label ID="Label10" runat="server" Text="状态"></asp:Label>
        <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>

        <asp:Button ID="Button3" runat="server" Text="查询" OnClick="Button3_Click" />
               &nbsp;<asp:Button ID="Button13" runat="server" Text="导出内容成excel" OnClick="Button13_Click"  />

        <br />

         <asp:Table ID="Table1" runat="server" Width=99% GridLines="Both"></asp:Table>

        </div>
        




        
    </form>
</body>
</html>
