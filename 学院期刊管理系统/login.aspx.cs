using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace XYQK
{
    public partial class demo2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string bh = Request["bh"].ToString();
            string mm = Request["mm"].ToString();
            string sql = "select*from 教师表 where 编号='" + bh + "'";
            DataTable T = new mytool1().getTable(sql);
            bool tag = false;
            if (T.Rows.Count > 0)
            {
                if (T.Rows[0]["密码"].ToString().Trim() == mm)
                    tag = true;
            }

            if (tag) //登陆成功
            {
                Response.Redirect("teacher1.aspx?bh=" + bh);
            }
            else Label1.Text = "输入错误，请重新输入";

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            string bh = Request["bh"].ToString();
            string mm = Request["mm"].ToString();
            string sql = "select*from 管理员表 where 编号='" + bh + "'";
            DataTable T = new mytool1().getTable(sql);
            bool tag = false;
            if (T.Rows.Count > 0)
            {
                if (T.Rows[0]["密码"].ToString().Trim() == mm)
                    tag = true;
            }

            if (tag) //登陆成功
            {
                Response.Redirect("manage1.aspx?bh=" + bh);
            }
            else Label1.Text = "输入错误，请重新输入";
        }

        protected void d1_Click(object sender, EventArgs e)
        {

        }
    }
}