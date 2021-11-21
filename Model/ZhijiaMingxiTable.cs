using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ZhijiaMingxiTable
    {
        /// <summary>
        ///ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        ///Danhao
        /// </summary>
        public string Danhao { get; set; }
        /// <summary>
        ///Bianhao
        /// </summary>
        public string Bianhao { get; set; }
        /// <summary>
        ///_date
        /// </summary>
        public DateTime _date { get; set; }
        /// <summary>
        ///Remarker
        /// </summary>
        public string Remarker { get; set; }
        /// <summary>
        ///类型
        /// </summary>
        public string Leixing { get; set; }
        /// <summary>
        ///客户
        /// </summary>
        public string Kehu { get; set; }
    }
}
