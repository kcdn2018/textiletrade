using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
  public   class PrintSetting
    {
        public string PrintName { get; set; }
        public int Printmodel { get; set; }
        public string Path { get; set; }
        public int PrintNum { get; set; }
        /// <summary>
        /// 是否取消打印
        /// </summary>
        public Boolean IsCancelPrint { get; set; }
    }
}
