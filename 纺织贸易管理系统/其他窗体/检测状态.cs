using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.其他窗体
{
   public  class 检测状态
    {
        public static void 检测(List <danjumingxitable > danjumingxitables )
        {
            var orderNumlist = danjumingxitables.Select(x => x.OrderNum).Distinct().ToList ();
            foreach (var num in orderNumlist )
            {
                if(num!=null)
                {
                    if(num!=string .Empty )
                    {
                      if(订单BLL.检查是否发完(num)==true)
                        {
                            if(MessageBox.Show ($"该订单号{num}所有布料的发货数量已经超过所定数量了。是否意味着该订单已经完成，如果完成按确定，否则按取消，按确定后该订单将标识为已完成","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question )==DialogResult.OK )
                            {
                                订单BLL.结束订单(num);
                            }
                        }
                    }
                }
            }
        }
    }
}
