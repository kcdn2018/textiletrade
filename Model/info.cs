using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class info
     {
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
    }
}
