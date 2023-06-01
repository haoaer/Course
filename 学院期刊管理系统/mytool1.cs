using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Reflection;

namespace XYQK
{
    public class mytool1
    {
        static string cnstr = "server=HAOHAOHAO; database=学院期刊; uid=sa;pwd=denghao123;";
        static SqlConnection cn = new SqlConnection(cnstr);
        public DataTable getTable(string sql)
        {
            try
            {
                cn.Open();
                DataSet ds = new DataSet(); //内存数据库
                SqlDataAdapter dap = new SqlDataAdapter(sql, cn);
                dap.Fill(ds, "t"); // 把查询结果存到内存数据库ds中，取名为t表
                DataTable T = ds.Tables["t"];
                cn.Close();
                return T;
            }
            catch { cn.Close(); }
            return new DataTable();
        }

        public void Mydisplay(DataTable T, Table Table1)
        {
            Table1.Rows.Clear();
            
            //生成列名
            TableRow tr0 = new TableRow();
            for (int i = 0; i < T.Columns.Count; i++)
            {
                TableCell td = new TableCell();

                td.Text = T.Columns[i].Caption.ToString().Trim();
                tr0.Cells.Add(td);
            }
            Table1.Rows.Add(tr0);
            //生成行对象
            for (int j = 0; j < T.Rows.Count; j++)
            {
                TableRow tr = new TableRow();
                for (int i = 0; i < T.Columns.Count; i++)
                {
                    TableCell td = new TableCell();
                    td.Text = T.Rows[j][i].ToString().Trim();
                    tr.Cells.Add(td);

                }
                Table1.Rows.Add(tr);
            }
        }

        public void Mydisplay(String sql, Table table1)//重载实现使用sql字符串查询
        {
            DataTable dt = getTable(sql);
            Mydisplay(dt, table1);
        }


        public void FillDropDownList(string sqlstr, DropDownList list)
        {
            DataTable T = new mytool1().getTable(sqlstr);
            list.DataSource = T;
            list.DataTextField = "Name";
            list.DataValueField = "Value";
            list.DataBind();
        }

        public int MynoQuery(string sql)
        {
            int tag = -1;
            try
            {
                
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                tag = cmd.ExecuteNonQuery();
                cmd.Clone();
                cn.Close();
               
            }
            catch { cn.Close(); }
            return tag;
        }

        public string Getinsertsql(object Model, string table)
        {
            Type class0 = Model.GetType();
            FieldInfo[] fields = class0.GetFields(BindingFlags.Instance
                | BindingFlags.NonPublic);//获取类的字段
            object val = "";
            string name = "";
            for(int i = 0; i < fields.Length; i++)
            {
                name += fields[i].Name.Trim()+",";
                val += "'" + fields[i].GetValue(Model)+"',";
            }
            name = name.Substring(0, name.Length - 1);
            string v = val.ToString();
            v = v.Substring(0, v.Length - 1);
            string sql = "insert into " + table + "(" + name + ") values (" + v + ")";

            return sql;
        }

        public string Getupdatesql(object Model,string table) //注意：改方法是默认修改是根据第一个属性名来修改
        {
            Type class0 = Model.GetType();
            FieldInfo[] fields = class0.GetFields(BindingFlags.Instance
                | BindingFlags.NonPublic);//获取类的字段
            string tem = " set ";
            string name="" ;
            object val;
            for (int i = 1; i < fields.Length; i++) //从第二个属性开始修改
            {
                name = fields[i].Name.Trim() ;
                val = "'" + fields[i].GetValue(Model) + "'";
                tem += name + "= " + val+",";
            }
            tem = tem.Substring(0, tem.Length - 1);
            string sql = "update " + table + tem + " where " + fields[0].Name + "='" + fields[0].GetValue(Model)+"'" ;

            return sql;
        }
    
    }

}