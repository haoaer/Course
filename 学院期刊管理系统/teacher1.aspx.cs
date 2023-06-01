using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace XYQK
{
    public partial class teacher1 : System.Web.UI.Page
    {
        static mytool1 mytool =  new mytool1();
        static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string bh = Request.QueryString["bh"];
                string sql = "select*from 教师表 where 编号='" + bh + "'";
                DataTable T = mytool.getTable(sql);

                Label4.Text = T.Rows[0]["编号"].ToString();
                Label5.Text = T.Rows[0]["姓名"].ToString();
                Label6.Text = T.Rows[0]["专业名"].ToString();

                //填充 DropList  插入一个空项目
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

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string bh = Request.QueryString["bh"];

            Response.Redirect("changemm.aspx?bh="+bh+"&tab=教师表");
           // Response.Redirect("changemm.aspx?bh=310501&tab=教师表");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string km=DropDownList1.SelectedValue.ToString();
            string lm = "select distinct(类名) as Name, 类名 as Value from 类别信息表 where" +
               " 类别方向 = '" + km + "'";
       
            mytool.FillDropDownList(lm, DropDownList2);
            ListItem item = new ListItem("", "");
            DropDownList2.Items.Insert(0, item);

        }

        protected void Button3_Click(object sender, EventArgs e)
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