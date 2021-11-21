using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纺织贸易管理系统.其他窗体
{
  public   class AlterDlg
    {
        public static void Show(string txt)
        {
            eDesktopAlertColor color = (eDesktopAlertColor) eDesktopAlertColor.Default;
            eAlertPosition position = (eAlertPosition) eAlertPosition.BottomRight;
            DesktopAlert.Show(txt, "\uf005", eSymbolSet.Awesome, Color.Empty, color, position,3,3, AlertClicked);
        }
        private static void AlertClicked(long alertId)
        {
            
        }
    }
}
