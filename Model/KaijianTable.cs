using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class KaijianTable
     {
        public int ID { get; set; }
        public string OrderNum { get; set; }
        public string CustomerName { get; set; }
        public string MachineID { get; set; }
        public string CheckID { get; set; }
        public string SampleNum { get; set; }
        public string SampleName { get; set; }
        public string Guige { get; set; }
        public string Yanse { get; set; }
        public string JuanHao { get; set; }
        public string GangHao { get; set; }
        public string PiHao { get; set; }
        public string BeiZhu { get; set; }
        public decimal MiShu { get; set; }
        public decimal MaShu { get; set; }
        public decimal JiaJian { get; set; }
        public string DengJI { get; set; }
        public decimal SumKouFeng { get; set; }
        public int state { get; set; }
        public DateTime rq { get; set; }
        public string BiaoqianMishu { get; set; }
     }
}
