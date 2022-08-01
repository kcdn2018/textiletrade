using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect.Environmen = "公司";
            try
            {
                创建复合明细表.CreatDuanTongZhiMenu();
            }catch
            { }
            try
            {
                创建复合明细表.修改客户归属();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2015();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2016();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2017();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2018();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2018();
            }
            catch
            { }
            //创建复合明细表.CreateDBId();
            //创建复合明细表.CreatTable();
            //创建复合明细表.AddLiuzhunka();
            //创建复合明细表.EditAv ();
            //创建复合明细表.增加坯布门幅();
            Console.WriteLine("更新数据库完成，按任意键退出");
        }
    }
}
