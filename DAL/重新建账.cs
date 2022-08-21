using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace DAL
{
   public static  class 重新建账
    {
        public static void Clear()
        {
            var DB = Connect.CreatConnect();
            DB.Update("truncate table StockTable ");
            DB.Update("truncate table skmx ");
            DB.Update("truncate table danjutable");
            DB.Update("truncate table danjumingxitable ");
            DB.Update("truncate table LwDetail ");
            DB.Update("truncate table RukuTable ");
            DB.Update("truncate table ProcessTable ");
            DB.Update("truncate table RangChangStockTable");
            DB.Update("truncate table OrderTable ");
            DB.Update("truncate table OrderDetailTable  ");
            DB.Update("truncate table RemainMoneyTable ");
            DB.Update("truncate table RangShequpiTable ");
            DB.Update("UPDATE LXR SET JE=0");
            DB.Update("UPDATE LXR SET fp=0");
            DB.Update("UPDATE LXR SET USD=0");
            DB.Update("UPDATE LXR SET YingKaifapiao=0");
            DB.Update("UPDATE LXR SET YingShouFapiao=0");
            DB.Update("truncate table juanhaotable");
            DB.Update("truncate table jiyangbaojia");
            DB.Update("truncate table fahuodan");
            DB.Update("truncate table RangsetoupiTable");
            DB.Update("truncate table shengchandantable");
            DB.Update("truncate table yangbustock");
            DB.Update("truncate table yangburukumingxi");
            DB.Update("UPDATE SKFS SET zhanghuyue=0");
            DB.Update("truncate table ChangliangTable");
            DB.Update("truncate table ShengchandanGongyi");           
        }
    }
}
