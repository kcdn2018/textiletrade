using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 系统设定
    {
        public static Setting GetSet(Setting setting )
        {
            var acc = SettingService .GetSetting (setting);
            if(acc.settingname ==string.Empty )
            {
                SettingService.InsertSetting (setting);
                return setting;
            }
            else
            {
                return acc ;
            }
        }
    }
}
