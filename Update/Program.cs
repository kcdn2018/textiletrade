﻿using System;
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
            创建复合明细表.CreateDBId();
            创建复合明细表.CreatTable();
            创建复合明细表.AddLiuzhunka();
            Console.WriteLine("更新数据库完成，按任意键退出");

        }
    }
}