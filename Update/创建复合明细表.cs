using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
  public   class 创建复合明细表
    {
		public static void CreatTable()
		{
			try
			{
				string Create = " CREATE TABLE[dbo].[ShengChanFuHeMingxi] ( [ID][int] IDENTITY(1,1) NOT NULL,[ShengChanDanHao] [nvarchar] (50) NULL,[MianBuColor] [nvarchar] (200) NULL,[MianBuColorSample] [nvarchar] (200) NULL,[DiBuColor] [nvarchar] (200) NULL,[DibuColorSample] [nvarchar] (200) NULL,	[Mishu] [decimal](18, 2) NULL, CONSTRAINT[PK_ShengChanFuHeMingxi] PRIMARY KEY CLUSTERED(  [ID] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]";
				Connect.CreatConnect().DoSQL(Create);
				Console.WriteLine("创建复合明细表成功");
			}
			catch
            {
				Console.WriteLine("创建复合明细表发生错误");
            }
		}
		public static void AddLiuzhunka()
		{
			try
			{
				string Create = "alter table danjumingxitable add LiuzhuanCard nvarchar(200)";
				Connect.CreatConnect().DoSQL(Create);
				Connect.CreatConnect().DoSQL("update danjumingxitable set LiuzhuanCard=''");
				Console.WriteLine("创建流转卡列成功");
			}
			catch
			{
				Console.WriteLine("创建流转卡列成功");
			}
		}
		/// <summary>
		/// 创建自增列
		/// </summary>
		public static void CreateDBId()
		{
			try
			{
				string Create = "alter table db add ID  int identity(1,1) not null";
				Connect.CreatConnect().DoSQL(Create);

				Console.WriteLine("创建品种表自增列成功");
			}
			catch
			{
				Console.WriteLine("创建品种表自增列失败");
			}
		}
	}
}
