using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// 报关单
    /// </summary>
    public class BaoGuanTable
    {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        ///发票号
        /// </summary>
        public string InvoiceNo { get; set; } = String.Empty;
        /// <summary>
        ///发货地址
        /// </summary>
        public string FromAddress { get; set; } = String.Empty;
        /// <summary>
        ///支付方式
        /// </summary>
        public string Payment { get; set; } = String.Empty;
        /// <summary>
        ///发票日期
        /// </summary>
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        /// <summary>
        ///信用证日期
        /// </summary>
        public DateTime LCDate { get; set; } = DateTime.Now;
        /// <summary>
        ///信用证编号
        /// </summary>
        public string LCNO { get; set; } = String.Empty;
        /// <summary>
        ///公告说明
        /// </summary>
        public string Notify { get; set; } = String.Empty;
        /// <summary>
        ///发货港口
        /// </summary>
        public string LoadingPort { get; set; } = String.Empty;
        /// <summary>
        ///目的地港口
        /// </summary>
        public string DesPort { get; set; } = String.Empty;
        /// <summary>
        ///信用证银行
        /// </summary>
        public string LCBank { get; set; } = String.Empty;
        /// <summary>
        ///备注
        /// </summary>
        public string Remarks { get; set; } = String.Empty;
        /// <summary>
        ///运算方式
        /// </summary>
        public string Carrier { get; set; } = String.Empty;
        /// <summary>
        ///销售单位
        /// </summary>
        public string Sailing { get; set; } = String.Empty;
        /// <summary>
        ///销售单号
        /// </summary>
        public string FromSaleNo { get; set; } = String.Empty;
        /// <summary>
        /// 客户名称
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// 发货公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 开船日期
        /// </summary>
        public DateTime SalingOnDate { get; set; }
        /// <summary>
        /// 客户传真
        /// </summary>
        public string CustomerFax { get; set; }
        /// <summary>
        /// 客户邮箱
        /// </summary>
        public string CustomerEmail { get; set; }
        /// <summary>
        /// 免税代码
        /// </summary>
        public string CustomerTexCode { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string CustomerZIPCODE { get; set; }
        /// <summary>
        /// 海防港港口
        /// </summary>
        public string CustomerHAIPHONGPORT { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string CustomerAddress { get; set; }
        /// <summary>
        /// 客户联系电话
        /// </summary>
        public string CustomerTel { get; set; }
              /// <summary>
              /// 发货电话
              /// </summary>
        public string SaleTel { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>
        public string SaleAddress { get; set; }
    }
}
