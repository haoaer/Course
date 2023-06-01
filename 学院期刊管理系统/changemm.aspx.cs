using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace XYQK
{
    public partial class demo21 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string bh = Request.QueryString["bh"];
            string tab = Request.QueryString["tab"];
            string sql1 = "select 密码 from " + tab + " where 编号='" + bh + "'";
            DataTable T = new mytool1().getTable(sql1);
            bool tag = false;
            try
            {
                if (TextBox1.Text == T.Rows[0]["密码"].ToString().Trim())
                {
                    string sql = "update " + tab + " set 密码='" + TextBox2.Text + "' where 编号='" + bh + "'";
                    int falg = new mytool1().MynoQuery(sql);
                    if (falg > 0)
                        tag = true;
                }

            }
            catch { }
            if (tag)
            {
                Label3.Text = "修改成功";
            }
            else
            {
                Label3.Text = "输入信息有误";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["tab"] == "教师表")
                Response.Redirect("teacher1.aspx?bh=" + Request.QueryString["bh"]);
            else
                Response.Redirect("manage1.aspx?bh=" + Request.QueryString["bh"]);
           // Response.Write("<script language=javascript>history.go(-2);</script>");
        }
    }
}