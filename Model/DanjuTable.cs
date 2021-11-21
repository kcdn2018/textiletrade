using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class DanjuTable
     {
        public int id { get; set; }
        public string dh { get; set; }
        public DateTime rq { get; set; }
        public string ksbh { get; set; }
        public string ksmc { get; set; }
        public decimal  je { get; set; }
        public string bz { get; set; }
        public string djlx { get; set; }
        public string own { get; set; }
        public string ckmc { get; set; }
        public decimal  TotalMishu { get; set; }
        public decimal  totaljuanshu { get; set; }
        public decimal  totalmoney { get; set; }
        public string remarker { get; set; }
        public string ordernum { get; set; }
        public string wuliugongsi { get; set; }
        public decimal  yunfei { get; set; }
        public string telephonenum { get; set; }
        public decimal  totalweishuimoney { get; set; }
        public string yaoqiu { get; set; }
        public string shouhuodizhi { get; set; }
        public string lianxidianhua { get; set; }
        public string lianxiren { get; set; }
        public string jiagongleixing { get; set; }
        public string fromDanhao { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string zhuangtai { get; set; }
        public decimal  toupimishu { get; set; }
        public decimal  toupijuanshu { get; set; }
        public int suolv { get; set; }
        public string wuliuBianhao { get; set; }
        public string CarNum { get; set; }
        public string CarLeixing { get; set; }
        public string StockName { get; set; }
        public decimal  RemainMoney { get; set; }
        public string Qiankuan { get; set; }
        public string ShoukuanFangshi { get; set; }
        /// <summary>
        /// 实际发货地址
        /// </summary>
        //public string Fahuodizhi { get; set; }
        public string Hanshui { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public string SaleMan { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string Bizhong { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string HetongHao { get; set; }
        /// <summary>
        /// 流转卡
        /// </summary>
        public string LiuzhuanCard { get; set; }
        public  DanjuTable()
        {
            dh = string.Empty;
            rq = DateTime.Now;
            ckmc = string.Empty;
            StockName = string.Empty;
            ksbh = string.Empty;
            Bizhong = "人民币";
        }
     }
}
