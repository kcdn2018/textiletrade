using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 白坯码单
    /// </summary>
  public   class FabricMadan
    {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string Danhao { get; set; }
        public decimal C1 { get; set; }
        public decimal C2 { get; set; }
        public decimal C3 { get; set; }
        public decimal C4 { get; set; }
        public decimal C5 { get; set; }
        public decimal C6 { get; set; }
        public decimal C7 { get; set; }
        public decimal C8 { get; set; }
        public decimal C9 { get; set; }
        public decimal C10 { get; set; }
    }
}
