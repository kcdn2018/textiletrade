using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class DanjuTable
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int id { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string dh { get; set; }
        /// <summary>
        /// 单据日期
        /// </summary>
        public DateTime rq { get; set; } = DateTime.Now;
        /// <summary>
        /// 客商电话
        /// </summary>
        public string ksbh { get; set; }
        /// <summary>
        /// 客商名称
        /// </summary>
        public string ksmc { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal  je { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string bz { get; set; }
       /// <summary>
       /// 单据类型
       /// </summary>
        public string djlx { get; set; }
        /// <summary>
        /// 建档者
        /// </summary>
        public string own { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string ckmc { get; set; }
        /// <summary>
        /// 合计米数
        /// </summary>
        public decimal  TotalMishu { get; set; }
        /// <summary>
        /// 合计卷数
        /// </summary>
        public decimal  totaljuanshu { get; set; }
       /// <summary>
       /// 合计金额
       /// </summary>
        public decimal  totalmoney { get; set; }
       /// <summary>
       /// 备注
       /// </summary>
        public string remarker { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string ordernum { get; set; }
        /// <summary>
        /// 物流公司
        /// </summary>
        public string wuliugongsi { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal  yunfei { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string telephonenum { get; set; }
        /// <summary>
        /// 合计未税
        /// </summary>
        public decimal  totalweishuimoney { get; set; }
        /// <summary>
        /// 要求
        /// </summary>
        public string yaoqiu { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string shouhuodizhi { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string lianxidianhua { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string lianxiren { get; set; }
        /// <summary>
        /// 加工类型
        /// </summary>
        public string jiagongleixing { get; set; }
        /// <summary>
        /// 单号来源
        /// </summary>
        public string fromDanhao { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string zhuangtai { get; set; }
        /// <summary>
        /// 投坯米数
        /// </summary>
        public decimal  toupimishu { get; set; }
        /// <summary>
        /// 投坯卷数
        /// </summary>
        public decimal  toupijuanshu { get; set; }
        /// <summary>
        /// 缩率
        /// </summary>
        public int suolv { get; set; }
        /// <summary>
        /// 物流编号
        /// </summary>
        public string wuliuBianhao { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNum { get; set; }
        /// <summary>
        /// 车辆类型
        /// </summary>
        public string CarLeixing { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// 剩余金额
        /// </summary>
        public decimal  RemainMoney { get; set; }
        /// <summary>
        /// 欠款
        /// </summary>
        public string Qiankuan { get; set; }
        /// <summary>
        /// 收款方式
        /// </summary>
        public string ShoukuanFangshi { get; set; }
        /// <summary>
        /// 采购含税
        /// </summary>
        public string CaiGouHanshui { get; set; }
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
        /// <summary>
        /// 利润
        /// </summary>
        public decimal Profit { get; set; }
        /// <summary>
        /// 叉车费
        /// </summary>
        public decimal ChaCheFei { get; set; }
        /// <summary>
        /// 装卸费
        /// </summary>
        public decimal ZhuangXieFei { get; set; }
        /// <summary>
        /// 最晚进仓时间
        /// </summary>
        public DateTime LastTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 最晚托柜时间
        /// </summary>
        public DateTime LastHoldingtime { get; set; } = DateTime.Now;
        /// <summary>
        /// 发货日期
        /// </summary>
        public DateTime Deliverytime { get; set; } = DateTime.Now;
        /// <summary>
        /// 克重
        /// </summary>
        public String Weight { get; set; }
        /// <summary>
        /// 跟单员
        /// </summary>
        public String Gengdanyuan { get; set; }
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
