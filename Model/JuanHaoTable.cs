using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
namespace 纺织贸易管理系统
{
    public class JuanHaoTable
     {
        /// <summary>
        /// 自增列
        /// </summary>
       [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
        public int ID { get; set; }
        public string OrderNum { get; set; }
        public string CustomerName { get; set; }
        public string MachineID { get; set; }
        public string CheckID { get; set; }
        public string SampleNum { get; set; }
        public string SampleName { get; set; }
        public string guige { get; set; }
        public string yanse { get; set; }
        public string JuanHao { get; set; }
        public string GangHao { get; set; }
        public int PiHao { get; set; }
        public string Houzhengli { get; set; }
        public decimal  MiShu { get; set; }
        public decimal  MaShu { get; set; }
        public decimal  JiaJian { get; set; }
        public string DengJI { get; set; }
        public decimal  SumKouFeng { get; set; }
        public int state { get; set; }
        public DateTime rq { get; set; }
        public decimal  biaoqianmishu { get; set; }
        public string kuanhao { get; set; }
        public string Danwei { get; set; }
        public string Danhao { get; set; }
        public string Huahao { get; set; }
        public string ColorNum { get; set; }
        public string CustomerPingMing { get; set; }
        public string CustomerColorNum { get; set; }
        /// <summary>
        /// 门幅
        /// </summary>
        public string Menfu { get; set; }
        /// <summary>
        /// 克重
        /// </summary>
        public string Kezhong { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Ckmc { get; set; }
        /// <summary>
        /// 流转卡号日志ID
        /// </summary>
        public int LogID;
        /// <summary>
        /// 疵点
        /// </summary>
        public string Cidian { get; set; }
        /// <summary>
        /// 合同号
        /// </summary>
        public string Hetonghao { get; set; }
    }
}
