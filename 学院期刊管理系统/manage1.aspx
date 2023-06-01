<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage1.aspx.cs" Inherits="XYQK.manage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员</title>
    <link rel="stylesheet" type="text/css"href="./css/motai.css"/>
    <link rel="stylesheet" type="text/css"href="./css/table1.css"/>

   
    </head>
<body>
    <form id="form1" runat="server">
        <div style="border-style:double;position:relative;width:100%;height:30px;">

        个人信息：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="编号" ></asp:Label>：
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="姓名" ></asp:Label>：
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label> 
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
         <asp:Label ID="Label5" runat="server" Text="尊敬的管理员欢迎您！"  ></asp:Label>
        
            <div style="position:absolute;right:0px;width:100px;height:30px;top:3px" > 
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BorderStyle="Groove" ForeColor="Black" OnMenuItemClick="Menu1_MenuItemClick"   >
                <Items>
                    <asp:MenuItem Text="菜单" Value="菜单" >
                        <asp:MenuItem Text="教师管理" Value="教师管理"></asp:MenuItem>
                        <asp:MenuItem Text="期刊管理" Value="期刊管理"></asp:MenuItem>
                        <asp:MenuItem Text="修改密码" Value="修改密码"></asp:MenuItem>
                        <asp:MenuItem Text="注销" Value="注销"></asp:MenuItem>
                    </asp:MenuItem>
                </Items>
            </asp:Menu>
                </div>

        </div>
          
        <br />
        <br />
        <div id ="dv1" runat="server" >
            <asp:Label ID="Label6" runat="server" Text="编号"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             <asp:Label ID="Label11" runat="server" Text="专业"></asp:Label>
            <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>
             <asp:Label ID="Label12" runat="server" Text="性别"></asp:Label>
            
            <asp:DropDownList ID="DropDownList6" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button7" runat="server" Text="查询" OnClick="Button7_Click"  />
            
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button8" runat="server" Text="添加教师" OnClick="Button8_Click"   />
            &nbsp;<asp:Button ID="Button13" runat="server" Text="导出内容成excel" OnClick="Button13_Click" />
            <br />
            <asp:Label id="count2" runat="server"></asp:Label>
            <br />
         <asp:Table ID="Table2" runat="server" Width=99% GridLines="Both"></asp:Table>

        </div>

         <div id ="dv2" runat="server">

             <asp:Label ID="Label7" runat="server" Text="ID"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="类别"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="50px" AutoPostBack="True"></asp:DropDownList>

        <asp:DropDownList ID="DropDownList2" runat="server" Width="70px"></asp:DropDownList>
       
        <asp:Label ID="Label9" runat="server" Text="出版社"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
        <asp:Label ID="Label10" runat="server" Text="状态"></asp:Label>
        <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>

        <asp:Button ID="Button5" runat="server" Text="查询" OnClick="Button5_Click" />


        &nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button6" runat="server" Text="添加期刊" OnClick="Button6_Click" />

                &nbsp;<asp:Button ID="Button14" runat="server" Text="导出内容成excel" OnClick="Button13_Click" />

        <br />
             <asp:Label id="count1" runat="server"></asp:Label>
        <br />
         <asp:Table ID="Table1" runat="server" Width=99% GridLines="Both"></asp:Table>

        </div>

        


        <div id="addteacher" class="modal"  runat="server">
            <div class="modal-content">
                <dialog runat="server" open>
                      <h2>教师添加</h2>

            <br />
                     <asp:Label ID="Label21" runat="server" Text="编号" Width="100px" ></asp:Label>
            <asp:TextBox ID="TextBox9" runat="server" placeholder="只能六位数字" ></asp:TextBox>
                <br />
            <br />
            <asp:Label ID="Label22" runat="server" Text="姓名" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                <br />
            <br />
            <asp:Label ID="Label23" runat="server" Text="专业名" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                <br />
            <br />
            <asp:Label ID="Label24" runat="server" Text="密码" Width="100px" ></asp:Label>
            <asp:TextBox ID="TextBox12" runat="server" TextMode="Password" placeholder="6-10位" ></asp:TextBox>
                <br />
             <br />
             <asp:Label ID="Label25" runat="server" Text="性别" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
                <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="添加" OnClick="Button3_Click" />
&nbsp;
            <asp:Button ID="Button4" runat="server" Text="返回" OnClick="Button4_Click"  />
                </dialog>
            </div>
        </div>

         <div class="modal" id="addbook"  runat="server" >  
            <div class="modal-content">
                <dialog  runat="server" open >

                     <h2>期刊添加</h2>

            <br />

        
            <asp:Label ID="Label13" runat="server" Text="ID" Width="100px"></asp:Label>
            <asp:TextBox ID="ID" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;<br />
  
            <br />
            
            <asp:Label ID="Label14" runat="server" Text="名称" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;<br />
                
            <br />
                
            <asp:Label ID="Label15" runat="server" Text="类别号" Width="100px" ></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"  MaxLength="9"  style="margin-bottom: 0px" placeholder="Dxxx" ></asp:TextBox>
        &nbsp;
                    
            <br />
                    
            <br />
                    
            <asp:Label ID="Label16" runat="server" Text="出版社" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;<br />
                        
            <br />
                        
            <asp:Label ID="Label17" runat="server" Text="期号" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
        
            <br />
        
            <br />
        
            <asp:Label ID="Label18" runat="server" Text="简介" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
            <br />
            <br />
            <asp:Label ID="Label19" runat="server" Text="状态" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
            <br />
            <br />
            <asp:Label ID="Label20" runat="server" Text="出版日期" Width="100px"></asp:Label>
            <asp:DropDownList ID="year1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="year_SelectedIndexChanged">
            </asp:DropDownList>
            年<asp:DropDownList ID="month1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="month_SelectedIndexChanged">
            </asp:DropDownList>
            月<asp:DropDownList ID="day1" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            日<br />
        <br />
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click"   />
                </dialog>
            </div>
        </div>

         <div id="modteacher" class="modal"  runat="server">
            <div class="modal-content">
                <dialog runat="server" open>
                         <h2>教师修改</h2>
            <asp:Label ID="Label34" runat="server" Text="编号" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox21" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label35" runat="server" Text="姓名" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label36" runat="server" Text="专业名" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label37" runat="server" Text="密码" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox24" runat="server"></asp:TextBox>
             <br />
             <br />
             <asp:Label ID="Label38" runat="server" Text="性别" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox25" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button11" runat="server" Text="修改" OnClick="Button11_Click"  />
&nbsp;
            <asp:Button ID="Button12" runat="server" Text="返回" OnClick="Button12_Click"  />
                </dialog>
            </div>
        </div>
         <div id="modbook" class="modal"  runat="server">
            <div class="modal-content">
                <dialog runat="server" open>
                          <h2> 期刊修改</h2>
            <asp:Label ID="Label26" runat="server" Text="ID" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox14" runat="server"  MaxLength="9"  style="margin-bottom: 0px" Enabled="False" ></asp:TextBox>
            <br />
            <br />
            
            <asp:Label ID="Label27" runat="server" Text="名称" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox15" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
                
            <br />
                
            <br />
                
            <asp:Label ID="Label28" runat="server" Text="类别号" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox16" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
                    
            <br />
                    
            <br />
                    
            <asp:Label ID="Label29" runat="server" Text="出版社" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox17" runat="server"  MaxLength="9"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
                        
            <br />
                        
            <br />
                        
            <asp:Label ID="Label30" runat="server" Text="期号" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox18" runat="server"  MaxLength="2"  style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
        
            <br />
        
            <br />
        
            <asp:Label ID="Label31" runat="server" Text="简介" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox19" runat="server"    style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
            <br />
            <br />
            <asp:Label ID="Label32" runat="server" Text="状态" Width="100px"></asp:Label>
            <asp:TextBox ID="TextBox20" runat="server"    style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
            <br />
            <br />
            <asp:Label ID="Label33" runat="server" Text="出版日期" Width="100px"></asp:Label>
            <asp:DropDownList ID="year2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="year_SelectedIndexChanged">
            </asp:DropDownList>
            年<asp:DropDownList ID="month2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="month_SelectedIndexChanged">
            </asp:DropDownList>
            月<asp:DropDownList ID="day2" runat="server" AutoPostBack="True">
            </asp:DropDownList>
            日<br />
            <br />
            <asp:Button ID="Button9" runat="server" Text="修改" OnClick="Button9_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" Text="返回" OnClick="Button10_Click" />
                </dialog>
            </div>
        </div>
     

    </form>
</body>
</html>
      


