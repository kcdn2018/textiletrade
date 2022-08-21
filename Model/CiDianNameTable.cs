using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class CiDianNameTable
     {
        public string CiDianName { get; set; }
        public int KouFen { get; set; }
        public decimal  KouMi { get; set; }
        public string Guisuo { get; set; }
        public string Daihao { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
     }
}
