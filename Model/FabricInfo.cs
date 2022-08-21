using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class FabricPriceInfo
    {
        /// <summary>
        /// 坯布厂布料编号
        /// </summary>
        public string GonghuoShangBianHao { get; set; }
        /// <summary>
        /// 后整理价格
        /// </summary>
        public string hzljg { get; set; }
        /// <summary>
        /// 坯布厂
        /// </summary>
        public string GHSMC { get; set; }
        /// <summary>
        /// 坯布价格
        /// </summary>
        public string PBPrice { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string jg { get; set; }
    }
}
