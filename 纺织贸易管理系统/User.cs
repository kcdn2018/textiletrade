using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纺织贸易管理系统
{
    public  static  class User
     {
        public static Yhb user = new Yhb { YHBH = "10001", YHMC = "管理员" };
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIStyleManager”(是否缺少程序集引用?)
        public static Sunny.UI.UIStyleManager styleManager = new Sunny.UI.UIStyleManager();
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIStyleManager”(是否缺少程序集引用?)
     }
}
