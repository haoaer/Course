using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYQK.Models
{
    public class QKB
    {
        string ID;
        string 名称;
        string 类别号;
        string 出版社;
        string 出版日期;
        int 期号;
        string 简介;
        string 状态;

        public QKB(string iD, string 名称, string 类别号, string 出版社, 
            string 出版日期, int 期号, string 简介, string 状态)
        {
            ID1 = iD;
            this.名称1 = 名称;
            this.类别号1 = 类别号;
            this.出版社1 = 出版社;
            this.出版日期1 = 出版日期;
            this.期号1 = 期号;
            this.简介1 = 简介;
            this.状态1 = 状态;
        }

        public string ID1 { get => ID; set => ID = value; }
        public string 名称1 { get => 名称; set => 名称 = value; }
        public string 类别号1 { get => 类别号; set => 类别号 = value; }
        public string 出版社1 { get => 出版社; set => 出版社 = value; }
        public string 出版日期1 { get => 出版日期; set => 出版日期 = value; }
        public int 期号1 { get => 期号; set => 期号 = value; }
        public string 简介1 { get => 简介; set => 简介 = value; }
        public string 状态1 { get => 状态; set => 状态 = value; }
    }
}