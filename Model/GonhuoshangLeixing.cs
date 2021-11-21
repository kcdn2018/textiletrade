using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public static class Gonhuoshang
    {
        public const string 坯布厂 = "坯布厂";
        public const string 染厂 = "染厂";
        public const string 后整理厂 = "后整理厂";
        public const string 涂层厂 = "涂层厂";
        public const string 印花厂 = "印花厂";
        public const string 水洗厂 = "水洗厂";
        public const string 已合作 = "已合作";
        public const string 未合作 = "未合作";
        public const string 正合作 = "正合作";
        public static  List<string> 类型 = new List<string> () {坯布厂 ,染厂,后整理厂,涂层厂 ,印花厂 ,水洗厂  };
        public static List<string> 合作 = new List<string>() { 已合作 , 未合作 , 正合作  };
    }
}
