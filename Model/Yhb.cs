using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class Yhb
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string MM { get; set; }
        public string YHMC { get; set; }
        public string YHBH { get; set; }
        public string hs { get; set; }
        public string 备注 { get; set; }
        public string own { get; set; }
        public string access { get; set; }
        public string cheshi { get; set; }
        public decimal deccheshi { get; set; }
        public Int32 intcheshi { get; set; }
        public Boolean bolcheshi { get; set; }
     }
}
