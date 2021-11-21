using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class RangsetoupiTable
     {
        public string DocumentNum { get; set; }
        public string FactoryID { get; set; }
        public string FactoryName { get; set; }
        public DateTime RQ { get; set; }
        public string SampleNum { get; set; }
        public string SampleName { get; set; }
        public string Specifications { get; set; }
        public string CaigoudocumentNum { get; set; }
        public decimal  Mishu { get; set; }
        public decimal  Juanshu { get; set; }
        public string Remarker { get; set; }
        public decimal  TotalMishu { get; set; }
        public decimal  TotalJuanshu { get; set; }
        public decimal  Danjia { get; set; }
        public decimal  Hejine { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public System.String Pihao { get; set; }
        /// <summary>
        /// 坯布厂
        /// </summary>
        public System.String PibuChang { get; set; }
    }
}
