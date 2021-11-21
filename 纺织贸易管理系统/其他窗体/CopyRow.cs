using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纺织贸易管理系统.其他窗体
{
   public static  class CopyRow
    {
        public static void Copy<T>(List<T> obj,int rowindex,DevExpress.XtraGrid.Views.Grid.GridView gridView,int torowindex )
        {
            T t = obj[rowindex];
            var pros = t.GetType().GetProperties();
            foreach (var p in pros )
            {
                gridView.SetRowCellValue(torowindex, p.Name, p.GetValue(t));
            }
            gridView.RefreshData();
        }
        public static void Copy<T>(BindingList<T> obj, int rowindex, DevExpress.XtraGrid.Views.Grid.GridView gridView, int torowindex)
        {
            T t = obj[rowindex];
            var pros = t.GetType().GetProperties();
            foreach (var p in pros)
            {
                gridView.SetRowCellValue(torowindex, p.Name, p.GetValue(t));
            }
            gridView.RefreshData();
        }
    }
}
