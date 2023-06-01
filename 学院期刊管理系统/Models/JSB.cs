using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYQK.Models
{
    public class JSB
    {
        string 编号;
        string 姓名;
        string 专业名;
        string 密码;
        string 性别;

        public JSB(string 编号, string 姓名, string 专业名, string 密码, string 性别)
        {
            this.编号1 = 编号;
            this.姓名1 = 姓名;
            this.专业名1 = 专业名;
            this.密码1 = 密码;
            this.性别1 = 性别;
        }

        public string 编号1 { get => 编号; set => 编号 = value; }
        public string 姓名1 { get => 姓名; set => 姓名 = value; }
        public string 专业名1 { get => 专业名; set => 专业名 = value; }
        public string 密码1 { get => 密码; set => 密码 = value; }
        public string 性别1 { get => 性别; set => 性别 = value; }
    }
}