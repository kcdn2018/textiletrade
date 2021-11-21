using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纺织贸易管理系统
{
    public  class ShengChanFuHeMingxi
    {
        /// <summary>
        ///ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        ///生产单号
        /// </summary>
        public string ShengChanDanHao { get; set; }
        /// <summary>
        ///面板颜色
        /// </summary>
        public string MianBuColor { get; set; }
        /// <summary>
        ///面布色样
        /// </summary>
        public string MianBuColorSample { get; set; }
        /// <summary>
        ///底布颜色
        /// </summary>
        public string DiBuColor { get; set; }
        /// <summary>
        ///底布色样
        /// </summary>
        public string DibuColorSample { get; set; }
        /// <summary>
        ///米数
        /// </summary>
        public decimal Mishu { get; set; }
    }
}
