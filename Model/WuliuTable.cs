using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class WuliuTable
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public string Bianhao { get; set; }
        public string CarLeixing { get; set; }
        public string CarNum { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string Yinghangzhanghao { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Kaihuyinghang { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string Pingyingma { get; set; }
        /// <summary>
        /// 开户人
        /// </summary>
        public string AccountHolder { get; set; }
        /// <summary>
        /// 全称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Style { get; set; }
    }
}
