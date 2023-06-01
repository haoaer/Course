<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="XYQK.demo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
    	<link rel="stylesheet" type="text/css"href="./css/index.css"/>
		<link rel="stylesheet" type="text/css"href="./css/iconfont.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div id="login-box">
            <h1>Login</h1>
			<div class="input-box">
				<i class="iconfont">&#xe609;</i>
				
				<input type="text" id="inp1" placeholder="UserName" name="bh" />
			</div>
			<div class="input-box">
				<i class="iconfont">&#xe605;</i>
				<input type="password" id="inp2" placeholder="UserPassword"  name="mm" />
			</div>
			<div>
				<br />
<asp:Button ID="Button1" CssClass="btn" runat="server" Text="教师登录" OnClick="Button1_Click" />
<asp:Button ID="Button2" CssClass="btn" runat="server" Text="管理员登录" OnClick="Button2_Click" />
				</div>
			
			<div> 
				<br />
				<asp:Label  font ID="Label1" runat="server" Text="" ForeColor="#CC0066"></asp:Label>

			</div>

		</div>

        </div>





		<div>
		</div>
    </form>
</body>
</html>
