using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 纺织贸易管理系统
{
    public class db
     {
        /// <summary>
        /// 行号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        public string bh { get; set; }
        public string lb { get; set; }
        public string pm { get; set; }
        public string gg { get; set; }
        public string kz { get; set; }
        public string cf { get; set; }
        public string mf { get; set; }
        public DateTime  rq { get; set; }
        public string bz { get; set; }
        public string ys { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string jg { get; set; }
        public string zb { get; set; }
        /// <summary>
        /// 坯布价格
        /// </summary>
        public string PBPrice { get; set; }
        public string GHSBH { get; set; }
        /// <summary>
        /// 坯布厂
        /// </summary>
        public string GHSMC { get; set; }
        public string md { get; set; }
        public string own { get; set; }
        public string hzl { get; set; }
        /// <summary>
        /// 后整理价格
        /// </summary>
        public string hzljg { get; set; }
        public string lxr { get; set; }
        public string lxdh { get; set; }
        public string cbj { get; set; }
        public string HH { get; set; }
        public string wz { get; set; }
        public string sl { get; set; }
        public string lx { get; set; }
        public string gz { get; set; }
        public string zzjg { get; set; }
        public string EnglishName { get; set; }
        /// <summary>
        /// 坯布厂布料编号
        /// </summary>
        public string GonghuoShangBianHao { get; set; }
        public bool caiyang { get; set; }
        public string YongTu { get; set; }
        public string Fengge { get; set; }
        public string Huahao { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string Zhuyishixiang { get; set; }
        /// <summary>
        /// 特点
        /// </summary>
        public string Characteristic { get; set; }
            /// <summary>
            /// 英文描述
            /// </summary>
        public string Descript { get; set; }
        /// <summary>
        /// 坯布名称
        /// </summary>
        public string PibuName { get; set; }
        /// <summary>
        /// 上机门幅
        /// </summary>
        public string ShangjiWidth { get; set; }
        /// <summary>
        /// 下机门幅
        /// </summary>
        public string XiajiWidth { get; set; }
        /// <summary>
        /// 经纱
        /// </summary>
        public string Jinsha { get; set; }
        /// <summary>
        /// 经纱厂家
        /// </summary>
        public string JinshaSupplier { get; set; }
        /// <summary>
        /// 经纱批号
        /// </summary>
        public string JinshaPihao { get; set; }
        /// <summary>
        /// 纬纱
        /// </summary>
        public string Weisha { get; set; }
        /// <summary>
        /// 纬纱厂家
        /// </summary>
        public string WeishaSupplier { get; set; }
        /// <summary>
        /// 纬纱批号
        /// </summary>
        public string WeishaPihao { get; set; }

    }
}
