using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
  public   class 更新数据库版本
    {
        public static void UpdateInfo (version info )
        {
            Connect.CreatConnect ().Update<version > (x=>x.Version ==info.Version , x => x.own  == info.own );
        }
    }
}
