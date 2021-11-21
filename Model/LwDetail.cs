using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class LwDetail
     {
        public int ID { get; set; }
        public string DH { get; set; }
        public string LX { get; set; }
        public decimal  JE { get; set; }
        public string KHBH { get; set; }
        public string KHMC { get; set; }
        public DateTime rq { get; set; }
        public string own { get; set; }
        public string bz { get; set; }
        public bool debt { get; set; }
        public string Hanshui { get; set; }
        public decimal  FapiaoJine { get; set; }
        public decimal  QichuJine { get; set; }
        public decimal  QiMojine { get; set; }
        public decimal  AddYingshoukuan { get; set; }
        public decimal  AddYingFukuan { get; set; }
        public decimal  ReduceYingShouKuan { get; set; }
        public decimal  ReduceYingFuKuan { get; set; }
        public decimal  AddYingKaiFapiao { get; set; }
        public decimal  AddYingShouFapiao { get; set; }
        public decimal  ReduceYingKaiFapiao { get; set; }
        public decimal  ReduceYingShouFapiao { get; set; }
        /// <summary>
        /// 是否已经对过账
        /// </summary>
        public Boolean IsCheck { get; set; }
     }
}
