using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
  public static  class 白坯日产量BLL
    {
        public static void  保存(List<ChangliangTable > changliangTables )
        {                 
                foreach (var c in changliangTables)
                {
                   ChangliangTableService.InsertChangliangTable(c);
                }
            库存BLL.增加库存(changliangTables);
        }
        public static void 修改(List<ChangliangTable> changliangTables)
        {
            库存BLL.减少库存(changliangTables);
            库存BLL.增加库存(changliangTables);
            ChangliangTableService.DeleteChangliangTable(x=>x.Danhao==changliangTables[0].Danhao );
            foreach (var c in changliangTables)
            {
                ChangliangTableService.InsertChangliangTable(c);
            }
        }
        public static void 删除(string danhao)
        {
            var changliangTables = ChangliangTableService.GetChangliangTablelst(x=>x.Danhao==danhao );
            库存BLL.减少库存(changliangTables);
            ChangliangTableService.DeleteChangliangTable(x => x.Danhao == changliangTables[0].Danhao);
        }
    }
}
