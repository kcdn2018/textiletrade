using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class info
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string gsmc { get; set; }
        public string GHSMC { get; set; }
        public string own { get; set; }
        public string Version { get; set; }
        public string cost { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankNum { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string BankName{ get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        public string TaxNum { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        ///电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        ///银行行号
        /// </summary>
        public string BankNo { get; set; }
    }
}
