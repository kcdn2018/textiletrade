using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 纺织贸易管理系统
{
   public  class ColumnTable
    {
        public string FormName { get; set; }
        public string GridName { get; set; }
        public string ColumnName { get; set; }
        public bool Visible { get; set; }
        public int VisibleID { get; set; }
        public int Width { get; set; }
        public string ColumnText { get; set; }
        public string DataProperty { get; set; }
        public bool Edit { get; set; }
        public bool Summary { get; set; }
        public string UserID { get; set; }
        /// <summary>
        /// 是否允许合并单元格
        /// </summary>
        public int AllowMerge { get; set; } 
    }
}
