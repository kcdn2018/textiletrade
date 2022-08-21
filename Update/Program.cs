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
            var vs=  Connect.CreatConnect().Query<version>();
            if(vs.Count ==2)
            {
                Connect.CreatConnect().Insert<version>(new version() { Version = "1.0.2.20",  own ="2.20"});
            }
            try
            {
                CheckDB.dbcompar ();
            }
            catch(Exception ex)
            {
                Console.WriteLine("比较表的时候发生错误" + ex.Message);
            }
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
                V2015.UpdateToV2019();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2020();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2021();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2022();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2023();
            }
            catch
            { }
            try
            {
                V2015.UpdateToV2024();
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
