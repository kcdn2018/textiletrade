using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class ClothPlane
     {
        public string PlaneNum { get; set; }
        public DateTime PlaneDate { get; set; }
        public string CustomerNum { get; set; }
        public string CustomerName { get; set; }
        public decimal  TotalMoney { get; set; }
        public decimal  TotalNum { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Remarker { get; set; }
        public string HetongHao { get; set; }
        public string Status { get; set; }
     }
}
