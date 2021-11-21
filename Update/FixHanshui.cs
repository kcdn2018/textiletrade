using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class FixHanshui
    {
        public static void hanshui()
        {
            var dbhelp = new SQLHelper.SQLHelper("server=3502s31m75.wicp.vip,42700;uid=sa;pwd=Kc123456;database=textiletradedb");
            var danjulist = dbhelp.Query<DanjuTable>(x => x.djlx == Model.DanjuLeiXing.销售出库单);
            foreach (var d in danjulist )
            {
                Console.WriteLine("正在修复单据编号{0}", d.dh);
              Console.WriteLine ("一共修复" + dbhelp.Update($"update danjumingxitable set IsHanshui='{d.Hanshui }' where danhao='{d.dh }'").ToString ()+"条记录");
            }
            Console.WriteLine("修复完毕！");
        }
    }
}
