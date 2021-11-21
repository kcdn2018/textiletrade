using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class RemainMoneyTable
     {
        public string ReceiptNum { get; set; }
        public decimal  DanJuJinE { get; set; }
        public decimal  ShengYuMoney { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNum { get; set; }
        public string MachineType { get; set; }
        public DateTime Rq { get; set; }
        public string OrderNum { get; set; }
        public bool Debt { get; set; }
     }
}
