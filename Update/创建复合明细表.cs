using SQLHelper;
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
		/// <summary>
		/// 创建点色和配桶信息单
		/// </summary>
		public static void CreatDuanTongZhiMenu()
		{
			var dbhelper = Connect.SoftkcDBHelper();
			var dt = Connect.DbHelper().Queryable<MenuTable>().Where(x => x.FormName == "检验通知单").ToList();
			if (dt.Count == 0)
			{
				Console.WriteLine("正在创建检验通知单菜单功能，请等待。。。。。。");
				var yhs = Connect.CreatConnect().Query<Yhb>();
				foreach (var yh in yhs)
				{
					Connect.CreatConnect().Insert<MenuTable>(new MenuTable() { FatherMenu = "生产管理", FormName = "检验通知单", MenuName = "检验通知单", UserID = yh.YHBH, Visitable = true });
					var columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "检验通知单").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
					columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "委外通知单").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
					Connect.CreatConnect().Insert<MenuTable>(new MenuTable() { FatherMenu = "生产管理", FormName = "委外通知单", MenuName = "委外通知单", UserID = yh.YHBH, Visitable = true });
					columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "细码库存").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
					Connect.CreatConnect().Insert<MenuTable>(new MenuTable() { FatherMenu = "库存管理", FormName = "细码库存", MenuName = "细码库存", UserID = yh.YHBH, Visitable = true });
					//columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "配桶登记列表").ToList();
					//columns.ForEach(x => x.UserID = yh.YHBH);
					//Connect.CreatConnect().Insert<ColumnTable>(columns);
					//columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "配桶登记单").ToList();
					//columns.ForEach(x => x.UserID = yh.YHBH);
					//Connect.CreatConnect().Insert<ColumnTable>(columns);
				}
				var report = dbhelper.Queryable<ReportTable>().Where(x => x.reportName == "委外通知单").ToList();
				Connect.CreatConnect().Insert<ReportTable>(report);
				report = dbhelper.Queryable<ReportTable>().Where(x => x.reportName == "检验通知单").ToList();
				Connect.CreatConnect().Insert<ReportTable>(report);
				Console.WriteLine("创建检验通知单菜单菜单成功");
			}
		}
		/// <summary>
		/// 创建点色和配桶信息单
		/// </summary>
		public static void CreatDianSeMenu()
        {
			var dbhelper = Connect.SoftkcDBHelper();
			var dt = Connect.DbHelper ().Queryable<MenuTable>().Where (x => x.FormName == "点色通知列表").ToList  ();
			if (dt.Count == 0)
			{
				Console.WriteLine("正在创建点色和配桶菜单功能，请等待。。。。。。");
				var yhs = Connect.CreatConnect().Query<Yhb>();
				 foreach (var yh in yhs)
                {
					Connect.CreatConnect().Insert<MenuTable>(new MenuTable() {  FatherMenu ="生产管理", FormName ="点色通知列表", MenuName ="点色通知单", UserID =yh.YHBH , Visitable =true });
					var columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "点色通知列表").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
					columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "点色通知单").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
					Connect.CreatConnect().Insert<MenuTable>(new MenuTable() { FatherMenu = "生产管理", FormName = "配桶登记列表", MenuName = "配桶登记单", UserID = yh.YHBH, Visitable = true });
					 columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "配桶登记列表").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
					columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "配桶登记单").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
				}
				var report = dbhelper.Queryable<ReportTable>().Where(x => x.reportName == "点色通知单").ToList();
				Connect.CreatConnect().Insert<ReportTable>(report);
				 report = dbhelper.Queryable<ReportTable>().Where(x => x.reportName == "配桶登记单").ToList();
				Connect.CreatConnect().Insert<ReportTable>(report);
				Console.WriteLine("创建点色和配桶菜单成功");
			}
			 dt = Connect.DbHelper ().Queryable<MenuTable>().Where (x => x.FormName == "进出记录").ToList ();
			if (dt.Count == 0)
			{
				Console.WriteLine("正在创建进出记录菜单功能，请等待。。。。。。");
				var yhs = Connect.CreatConnect().Query<Yhb>();
				foreach (var yh in yhs)
				{					
					Connect.CreatConnect().Insert<MenuTable>(new MenuTable() { FatherMenu = "库存管理", FormName = "进出记录", MenuName = "进出记录", UserID = yh.YHBH, Visitable = true });
					var columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "进出记录").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
					columns = dbhelper.Queryable<ColumnTable>().Where(x => x.FormName == "进出记录").ToList();
					columns.ForEach(x => x.UserID = yh.YHBH);
					Connect.CreatConnect().Insert<ColumnTable>(columns);
				}
				Console.WriteLine("创建进出记录菜单成功");
			}
		}
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
		public static void EditAv()
		{
			try
			{
				var verinfo = infoService.Getinfolst()[0];
				if (Version.Parse(verinfo.Version) < Version.Parse("1.0.2.56"))
				{
					string Create = "alter table RangShequpiTable alter column  AveragePrice  decimal(18, 2)";
					Connect.CreatConnect().DoSQL(Create);
					Console.WriteLine("修改平均价格为2位小数成功");
					Create = "alter table danjumingxitable alter column  AveragePrice  decimal(18, 2)";
					Connect.CreatConnect().DoSQL(Create);
					Console.WriteLine("修改平均价格为2位小数成功");
					verinfo.Version = "1.0.2.56";				
					 Create = "alter table JiYangBaoJia add  SupplierNum  nvarchar(200)";
					Connect.CreatConnect().DoSQL(Create);
					Create = "update jiyangbaojia set SupplierNum=(select GonghuoShangBianHao from db where db.bh=jiyangbaojia.spbh)";
					Connect.CreatConnect().DoSQL(Create);
					更新数据库版本.UpdateInfo(verinfo);
				}
			}
			catch
			{
				Console.WriteLine("修改平均价格为2位小数成功失败");
			}
		}
		public static void 增加坯布门幅()
		{
			try
			{
				var verinfo = infoService.Getinfolst()[0];
				if (Version.Parse(verinfo.Version) < Version.Parse("1.0.2.59"))
				{
					string Create = "alter table RangShequpiTable  add FrabicWidth nvarchar(200)";
					Connect.CreatConnect().DoSQL(Create);
					Console.WriteLine("染色取坯增加坯布门幅成功");
					Create = "alter table danjumingxitable add FrabicWidth nvarchar(200)";
					Connect.CreatConnect().DoSQL(Create);
					Console.WriteLine("单据明细增加坯布门幅成功");
					verinfo.Version = "1.0.2.57";
					Create = "alter table StockTable add  FrabicWidth  nvarchar(200)";
					Connect.CreatConnect().DoSQL(Create);
					Console.WriteLine("库存信息增加坯布门幅成功");
					Create = "alter table DanjuTable add  ChaCheFei  decmail(18,2)";
					Connect.CreatConnect().DoSQL(Create);
					Console.WriteLine("单据增加叉车费成功");
					Create = "alter table DanjuTable add  ZhuangXieFei  decmail(18,2)";
					Connect.CreatConnect().DoSQL(Create);
					Console.WriteLine("单据增加装卸费成功");
					Create = "update RangShequpiTable set FrabicWidth=''";
					Connect.CreatConnect().DoSQL(Create);
					Create = "update danjumingxitable set FrabicWidth=''";
					Connect.CreatConnect().DoSQL(Create);
					Create = "update StockTable set FrabicWidth=''";
					Connect.CreatConnect().DoSQL(Create);
					Create = "update DanjuTable set ChaCheFei='0'";
					Connect.CreatConnect().DoSQL(Create);
					Create = "update DanjuTable set ZhuangXieFei='0'";
					Connect.CreatConnect().DoSQL(Create);
					更新数据库版本.UpdateInfo(verinfo);
				}
			}
			catch
			{
				Console.WriteLine("增加字段失败");
			}
		}
	}
}
