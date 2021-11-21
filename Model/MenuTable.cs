using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class MenuTable
     {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public string FatherMenu { get; set; }
        public string FormName { get; set; }
        public bool Visitable { get; set; }
        public string UserID { get; set; }
     }
}
