using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class AccessBLL
    {
        public static string userid { get; set; }
        /// <summary>
        /// 检查是否有权限
        /// </summary>
        /// <param name="formname"></param>
        /// <returns>有权限返回True,否则返回False</returns>
        public static bool CheckAccess(string formname)
        {
            var acc = AccessTableService.GetOneAccessTable(x => x.AccessName == formname&&x.UserID ==userid);
            if(acc.AccessName ==string.Empty )
            {
                AccessTableService.InsertAccessTable(new AccessTable() { Access=true , AccessName =formname , UserID=userid });
                return true;
            }
            else
            {
                return acc.Access;
            }
        }
    }
}
