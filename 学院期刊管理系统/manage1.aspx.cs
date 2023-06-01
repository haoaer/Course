using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XYQK.Models;
namespace XYQK
{
    public partial class manage1 : System.Web.UI.Page
    {
         static mytool1 mytool =new mytool1() ;
        static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                string bh = Request.QueryString["bh"];
                string sql = "select*from 管理员表 where 编号='" + bh + "'";
                DataTable T = mytool.getTable(sql);
                Label3.Text = T.Rows[0]["编号"].ToString();
                Label4.Text = T.Rows[0]["姓名"].ToString();
                dv1.Visible = false;
                dv2.Visible = false;
                FillDrop();
                addbook.Visible = false;
                addteacher.Visible = false;
                modbook.Visible = false;
                modteacher.Visible = false;
                int y = DateTime.Now.Year;
                for (int i = y; i >= y - 40; i--)
                {
                    year1.Items.Add(i.ToString());
                    year2.Items.Add(i.ToString());
                }
                for (int i = 1; i <= 12; i++)
                {
                    month1.Items.Add(i.ToString());
                    month2.Items.Add(i.ToString());
                }
            }
            else
            {
                
            }
            Button7_Click(sender, e);
            Button5_Click(sender, e);
        }
       

        public void FillDrop()
        {
            //填充下拉列表
            string sqlstr = "select distinct(类别方向) as Name, 类别方向 as Value from 类别信息表";
            mytool.FillDropDownList(sqlstr, DropDownList1);
            ListItem item = new ListItem("", "");
            DropDownList1.Items.Insert(0, item);

            sqlstr = "select distinct(出版社) as Name, 出版社 as Value from 期刊信息表";
            mytool.FillDropDownList(sqlstr, DropDownList3);
            DropDownList3.Items.Insert(0, item);

            sqlstr = "select distinct(状态) as Name, 状态 as Value from 期刊信息表";
            mytool.FillDropDownList(sqlstr, DropDownList4);
            DropDownList4.Items.Insert(0, item);

            sqlstr = "select distinct(专业名) as Name, 专业名 as Value from 教师表";
            mytool.FillDropDownList(sqlstr, DropDownList5);
            DropDownList5.Items.Insert(0, item);

            sqlstr = "select distinct(性别) as Name, 性别 as Value from 教师表";
            mytool.FillDropDownList(sqlstr, DropDownList6);
            DropDownList6.Items.Insert(0, item);
        }
        

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string km = DropDownList1.SelectedValue.ToString();
            string lm = "select distinct(类名) as Name, 类名 as Value from 类别信息表 where" +
               " 类别方向 = '" + km + "'";
            
            mytool.FillDropDownList(lm, DropDownList2);
            ListItem item = new ListItem("", "");
            DropDownList2.Items.Insert(0, item);
        }

        protected void Button5_Click(object sender, EventArgs e)
            //实现期刊查询
        {
            
            string sql = "select ID,名称,a.类别号,出版社,出版日期,期号,简介,状态 from 期刊信息表 a inner join 类别信息表 b on a.类别号=b.类别号";

            bool tag = false;
            if (TextBox1.Text != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where ID= '" + TextBox1.Text + "'";
                }
                else
                    sql += " and ID=' " + TextBox1.Text + "'";
            }
            if (DropDownList1.SelectedValue != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where 类别方向= '" + DropDownList1.SelectedValue + "'";
                }
                else
                    sql += " and 类别方向='" + DropDownList1.SelectedValue + "'";
            }
            if (DropDownList2.SelectedValue != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where 类名= '" + DropDownList2.SelectedValue + "'";
                }
                else
                    sql += " and 类名='" + DropDownList2.SelectedValue + "'";
            }
            if (DropDownList3.SelectedValue != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where 出版社= '" + DropDownList3.SelectedValue + "'";
                }
                else
                    sql += " and 出版社='" + DropDownList3.SelectedValue + "'";
            }
            if (DropDownList4.SelectedValue != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where 状态= '" + DropDownList4.SelectedValue + "'";
                }
                else
                    sql += " and 状态='" + DropDownList4.SelectedValue + "'";
            }

            mytool.Mydisplay(sql, Table1);
            dt = mytool.getTable(sql);
            Addbutton1();
            count1.Text = "一共有" + (Table1.Rows.Count-1).ToString() + "条记录";
        }

        public void Addbutton1()
        {
            TableCell modify = new TableCell(); modify.Text = "修改";
            Table1.Rows[0].Cells.Add(modify);
            
            TableCell delete = new TableCell(); delete.Text = "删除";
            Table1.Rows[0].Cells.Add(delete);
            

            for (int i = 1; i < Table1.Rows.Count; i++)
            {
                Button del = new Button(); del.Text = "删除"; del.BackColor = System.Drawing.Color.Pink;
                Button mod = new Button(); mod.Text = "修改"; mod.BackColor = System.Drawing.Color.CornflowerBlue;
                string ID = Table1.Rows[i].Cells[0].Text.Trim();
                string sqldel = "delete from 期刊信息表 where ID= '" + ID + "'";

                mod.Click += new EventHandler((object sender, EventArgs e)=>
                {
                    
                    Application["id"] = ID;
                    modbook.Visible = true;

                    bookmod();

                });
                
                del.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    int x = -1;
                    try
                    {
                        x = mytool.MynoQuery(sqldel);
                    }
                    catch { };

                    if (x > 0)
                    {
                        Response.Write("<script> alert(\"删除成功\") </script>");
                    }
                    else
                    {
                        Response.Write("<script> alert(\"删除成功\") </script>");
                    }
                });
                TableCell M = new TableCell(); M.Controls.Add(mod);
                Table1.Rows[i].Cells.Add(M);
                TableCell D = new TableCell(); D.Controls.Add(del);
                Table1.Rows[i].Cells.Add(D);
            }

            
            
        }


        public void bookmod()
        {
            string id = Application["id"].ToString().Trim();
            string sql = "select*from 期刊信息表 where ID='" + id + "'";
            DataTable T = new mytool1().getTable(sql);
            TextBox14.Text = id;
            TextBox15.Text = T.Rows[0]["名称"].ToString().Trim();
            TextBox16.Text = T.Rows[0]["类别号"].ToString().Trim();
            TextBox17.Text = T.Rows[0]["出版社"].ToString().Trim();
            TextBox18.Text = T.Rows[0]["期号"].ToString().Trim();
            TextBox19.Text = T.Rows[0]["简介"].ToString().Trim();
            TextBox20.Text = T.Rows[0]["状态"].ToString().Trim();
            
        }

        public void teachermod()
        {
            string id = Application["teacherbh"].ToString().Trim();
            string sql = "select*from 教师表 where 编号='" + id + "'";
            DataTable T = new mytool1().getTable(sql);
            TextBox21.Text = T.Rows[0]["编号"].ToString().Trim();
            TextBox22.Text = T.Rows[0]["姓名"].ToString().Trim();
            TextBox23.Text = T.Rows[0]["专业名"].ToString().Trim();
            TextBox24.Text = T.Rows[0]["密码"].ToString().Trim();
            TextBox25.Text = T.Rows[0]["性别"].ToString().Trim();
        }
        public void Addbutton2()
        {
            TableCell modify = new TableCell(); modify.Text = "修改";
            TableCell delete = new TableCell(); delete.Text = "删除";
            Table2.Rows[0].Cells.Add(modify);
            Table2.Rows[0].Cells.Add(delete);

            for (int i = 1; i < Table2.Rows.Count; i++)
            {
            
                Button del = new Button(); del.Text = "删除"; del.BackColor = System.Drawing.Color.Pink;
                Button mod = new Button(); mod.Text = "修改"; mod.BackColor = System.Drawing.Color.CornflowerBlue;
                string ID = Table2.Rows[i].Cells[0].Text.Trim();
                string sqldel = "delete from 教师表 where 编号 = '" + ID + "'";

                mod.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    
                    Application["teacherbh"] = ID;
                    teachermod();
                    modteacher.Visible = true;
                });

                del.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    int x = -1;
                    try
                    {
                        x = mytool.MynoQuery(sqldel);
                    }
                    catch { };

                    if (x > 0)
                    {
                        Response.Write("<script> alert(\"删除成功\") </script>");
                        
                    }
                    else
                    {
                        Response.Write("<script> alert(\"删除失败\") </script>");
                    }
                });
                TableCell M = new TableCell(); M.Controls.Add(mod);
                Table2.Rows[i].Cells.Add(M);
                TableCell D = new TableCell(); D.Controls.Add(del);
                Table2.Rows[i].Cells.Add(D);
            }
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
       
            addbook.Visible = true;

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //教师查询
            string sql = "select 编号,姓名,专业名,性别 from 教师表 ";
            bool tag = false;
            if (TextBox2.Text != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where 编号= '" + TextBox2.Text + "'";
                }
                else
                    sql += " and 编号=' " + TextBox2.Text + "'";
            }
            if (DropDownList5.SelectedValue != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where 专业名= '" + DropDownList5.SelectedValue + "'";
                }
                else
                    sql += " and 专业名='" + DropDownList5.SelectedValue + "'";
            }
            if (DropDownList6.SelectedValue != "")
            {
                if (!tag)
                {
                    tag = true;
                    sql += " where 性别= '" + DropDownList6.SelectedValue + "'";
                }
                else
                    sql += " and 性别='" + DropDownList6.SelectedValue + "'";
            }
    
            mytool.Mydisplay(sql, Table2);
            dt = mytool.getTable(sql);
            Addbutton2();
            count2.Text = "一共有"+(Table2.Rows.Count-1).ToString()+"条记录";
            
               
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
           
            addteacher.Visible = true;
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (Menu1.SelectedValue == "教师管理")
            {
               
                dv1.Visible = true;
                dv2.Visible = false;
            }
            else if(Menu1.SelectedValue == "期刊管理")
            {
             
                dv1.Visible = false;
                dv2.Visible = true;
            }
            else if (Menu1.SelectedValue == "修改密码")
            {
                string bh = Request.QueryString["bh"];
                Response.Redirect("changemm.aspx?bh=" + bh + "&tab=管理员表");
            }
            else if (Menu1.SelectedValue == "注销")
            {
                Response.Redirect("login.aspx");
            }
        }
        protected void datenew()
        {
            day1.Items.Clear();
            day2.Items.Clear();
            int y = int.Parse(year1.SelectedValue);
            int m = int.Parse(month1.SelectedValue);
            int[] mon = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int d;
            if ((y % 400 == 0 || y % 4 == 0 && y % 100 != 0) && m == 2)//如果是闰年的二月
            {
                d = mon[2] + 1;
            }
            else d = mon[m];
            for (int i = 1; i <= d; i++)
            {
                day1.Items.Add(i.ToString());
                day2.Items.Add(i.ToString());
            }
                
        }

        protected void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            datenew();
        }

        protected void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            datenew();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string id = ID.Text.Trim();
                string 名称 = TextBox3.Text.Trim();
                string 类别号 = TextBox4.Text.Trim();
                string 出版社 = TextBox5.Text.Trim();
                int 期号 = int.Parse(TextBox6.Text.Trim());
                string 简介 = TextBox7.Text.Trim();
                string 状态 = TextBox8.Text.Trim();
                string 出版日期 = year1.Text + "-" + month1.Text + "-" + day1.Text;
                QKB qKB = new QKB(id, 名称, 类别号, 出版社, 出版日期, 期号, 简介, 状态);
                string sql = mytool.Getinsertsql(qKB, "期刊信息表");


                int x = mytool.MynoQuery(sql);
                if (x > 0)
                {
                    Response.Write("<script> alert(\"添加成功\") </script>");
                }
                else Response.Write("<script> alert(\"添加失败\") </script>");
            }
            catch { Response.Write("<script> alert(\"添加失败\") </script>"); }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            addbook.Visible = false;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string 编号 = TextBox9.Text.Trim();
            string 姓名 = TextBox10.Text.Trim();
            string 专业名 = TextBox11.Text.Trim();
            string 密码 = TextBox12.Text.Trim();
            string 性别 = TextBox13.Text.Trim();
            JSB jSB = new JSB(编号, 姓名, 专业名, 密码, 性别);
            string sql = mytool.Getinsertsql(jSB, "教师表");
            try
            {
                int x =  mytool.MynoQuery(sql);
                if (x > 0)
                {
                    Response.Write("<script> alert(\"添加成功\") </script>");
                }
                else Response.Write("<script> alert(\"添加失败\") </script>");

            }

            catch
            {
                Response.Write("<script> alert(\"添加失败\") </script>");

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            addteacher.Visible = false;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            modbook.Visible = false;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string id = TextBox14.Text.Trim();
            string 名称 = TextBox15.Text.Trim();
            string 类别号 = TextBox16.Text.Trim();
            string 出版社 = TextBox17.Text.Trim();
            int 期号 = int.Parse(TextBox18.Text.Trim());
            string 简介 = TextBox19.Text.Trim();
            string 状态 = TextBox20.Text.Trim();
            string 出版日期 = year2.Text + "-" + month2.Text + "-" + day2.Text;
            QKB qKB = new QKB(id, 名称, 类别号, 出版社, 出版日期, 期号, 简介, 状态);
            string sql =  mytool.Getupdatesql(qKB, "期刊信息表");
            try
            {
                int x =  mytool.MynoQuery(sql);
                if (x > 0)
                {
                    Response.Write("<script> alert(\"修改成功\") </script>");
                }
                else Response.Write("<script> alert(\"修改失败\") </script>");
            }
            catch { Response.Write("<script> alert(\"修改失败\") </script>"); }

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            string 编号 = TextBox21.Text.Trim();
            string 姓名 = TextBox22.Text.Trim();
            string 专业名 = TextBox23.Text.Trim();
            string 密码 = TextBox24.Text.Trim();
            string 性别 = TextBox25.Text.Trim();

            JSB jSB = new JSB(编号, 姓名, 专业名, 密码, 性别);
            string sql = mytool.Getupdatesql(jSB, "教师表");
            try
            {
                int x =  mytool.MynoQuery(sql);
                if (x > 0)
                {
                    Response.Write("<script> alert(\"修改成功\") </script>");
                }
                else Response.Write("<script> alert(\"修改失败\") </script>");
            }
            catch { Response.Write("<script> alert(\"修改失败\") </script>"); }
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            modteacher.Visible = false;
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            //将DataTable绑定到DataGird控件
            System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
            dg.DataSource = dt.DefaultView;
            dg.AllowPaging = false;
            dg.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
            dg.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            dg.HeaderStyle.Font.Bold = true;
            dg.DataBind();
            Response.Clear();
            Response.Buffer = true;

            //防止出现乱码,加上这行可以防止在只有一行数据时出现乱码
            Response.Write("<meta http-equiv=Content-Type content=text/html;charset=UTF-8>");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("导出" + ".xls", System.Text.Encoding.UTF8));
            Response.ContentType = "application/ms-excel";

            Response.Charset = "UTF-8";
            //指定编码 防止中文乱码现象
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            //关闭控件的视图状态
            this.EnableViewState = false;

            //初始化HtmlWriter
            System.IO.StringWriter writer = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(writer);
            //将DataGird内容输出到HtmlTextWriter对象中
            dg.RenderControl(htmlWriter);
            string outputStr = writer.ToString();
            //输出
            Response.Write(outputStr);
            Response.Flush();
            Response.End();
        }
    }
       
    


}