using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Update
{
   public  class V2015

    {
        public static void UpdateToV2021()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (verinfo.Version == "1.0.2.20")
            {
                verinfo.Version = "1.0.2.21";
                更新数据库版本.UpdateInfo(verinfo);
                Console.WriteLine($"更新版本到{verinfo.Version }");
                Console.WriteLine("增加外检直销功能");
                AddNewMenu.Add(new MenuTable() {  FatherMenu ="销售管理", FormName = "外检直销单" , MenuName = "外检直销单", UserID ="10001", Visitable =false  });
                AddNewMenu.AddNewForm("外检直销单");
                AddNewMenu.AddNewForm("外检直销单列表");
            }
        }
        public static void UpdateToV2020()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (verinfo.Version== "1.0.2.19")
            {         
                verinfo.Version = "1.0.2.20";
                更新数据库版本.UpdateInfo(verinfo);
                Console.WriteLine($"更新版本到{verinfo.Version }");
                Console.WriteLine("增加公司信息");
                AddColumn.AddNewColumn("info", "BankNo", "nvarchar(250)", string.Empty);

            }
        }
        public static void UpdateToV2019()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (verinfo.Version == "1.0.2.18")
            {        
                verinfo.Version = "1.0.2.19";
                更新数据库版本.UpdateInfo(verinfo);
                Console.WriteLine($"更新版本到{verinfo.Version }");
                Console.WriteLine("增加订单信息");
                AddColumn.AddNewColumn("OrderTable", "Scopefrom", "nvarchar(250)", string.Empty);
                AddColumn.AddNewColumn("OrderTable", "ScopeEnd", "nvarchar(250)", string.Empty);
                AddColumn.AddNewColumn("OrderTable", "ShipmentTime", "date", DateTime.Now.ToShortDateString () );
                AddColumn.AddNewColumn("OrderTable", "LoadingPort", "nvarchar(250)", string.Empty);
                AddColumn.AddNewColumn("OrderTable", "SignCompany", "nvarchar(250)", string.Empty);
                AddColumn.AddNewColumn("OrderTable", "CustomerFullName", "nvarchar(250)", string.Empty);
                AddColumn.AddNewColumn("OrderTable", "FOB", "nvarchar(250)", string.Empty);

            }
        }
        public static void UpdateToV2018()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (verinfo.Version.Trim(' ') == "1.0.2.17")
            {  verinfo.Version = "1.0.2.18";
                更新数据库版本.UpdateInfo(verinfo);
                Console.WriteLine($"更新版本到{verinfo.Version }");
                Connect.CreatConnect().DoSQL("alter table OrderDetailTable add  Require nvarchar(250)");
                Connect.CreatConnect().DoSQL("updateOrderDetailTable set  Require =''");
              
            }
        }
        public static void UpdateToV2017()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (verinfo.Version.Trim(' ') == "1.0.2.16")
            { verinfo.Version = "1.0.2.17";
                更新数据库版本.UpdateInfo(verinfo);
                Console.WriteLine($"更新版本到{verinfo.Version }");
                Connect.CreatConnect().DoSQL("alter table YuanGongTable add  TiCheng decimal(18,2)");
                Connect.CreatConnect().DoSQL("update YuanGongTable set  TiCheng =33.33");
                Connect.CreatConnect().DoSQL("alter table PriceTable alter column hanshui decimal(18,2)");
                Connect.CreatConnect().DoSQL("alter table PriceTable alter column kehumingcheng nvarchar(250)");
                Connect.CreatConnect().DoSQL("alter table PriceTable alter column kehubianhao nvarchar(250)");
                Connect.CreatConnect().DoSQL("alter table PriceTable alter column rq datetime");
                Connect.CreatConnect().DoSQL("alter table WuliuTable add  Yinghangzhanghao nvarchar(250)");
                Connect.CreatConnect().DoSQL("update WuliuTable set  Yinghangzhanghao =''");
                Connect.CreatConnect().DoSQL("alter table WuliuTable add  Kaihuyinghang nvarchar(250)");
                Connect.CreatConnect().DoSQL("update WuliuTable set  Kaihuyinghang =''");
                Connect.CreatConnect().DoSQL("alter table WuliuTable add  LinkMan nvarchar(250)");
                Connect.CreatConnect().DoSQL("update WuliuTable set  LinkMan =''");
               
            }
        }
        public static void UpdateToV2016()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (verinfo.Version.Trim(' ') == "1.0.2.15")
            { 
                verinfo.Version = "1.0.2.16";
                更新数据库版本.UpdateInfo(verinfo);
                Console.WriteLine($"更新版本到{verinfo.Version }");
                增加联系人信息();
                Console.WriteLine("增加联系人信息");
               
            }
        }
        private static void 增加联系人信息()
        {
            try
            {
                 AddNewMenu.Add(new MenuTable() {FormName="报关单列表", FatherMenu ="销售管理", MenuName ="报关单列表", UserID ="10001", Visitable =false  });
                AddNewMenu.AddNewForm("新增报关单");
                //AddNewMenu.Add(new MenuTable() { FormName = "找样单列表", FatherMenu = "样品管理", MenuName = "找样任务单", UserID = "10001", Visitable = false });
                AddNewMenu.AddNewForm("销售单选择");
                Connect.CreatConnect().DoSQL("alter table lxr add  FullName nvarchar(250)");
                Connect.CreatConnect().DoSQL("update lxr set  FullName =''");
                Connect.CreatConnect().DoSQL("alter table lxr add  FAX nvarchar(250)");
                Connect.CreatConnect().DoSQL("update lxr set  FAX =''");
                Connect.CreatConnect().DoSQL("alter table lxr add  TexCode nvarchar(250)");
                Connect.CreatConnect().DoSQL("update lxr set  TexCode =''");
                Connect.CreatConnect().DoSQL("alter table lxr add  ZIPCODE nvarchar(250)");
                Connect.CreatConnect().DoSQL("update lxr set  ZIPCODE =''");
                Connect.CreatConnect().DoSQL("alter table lxr add  HAIPHONGPORT nvarchar(250)");
                Connect.CreatConnect().DoSQL("update lxr set  HAIPHONGPORT =''");
                Connect.CreatConnect().DoSQL("alter table StockTable add  EnglishName nvarchar(250)");
                Connect.CreatConnect().DoSQL("update StockTable set  EnglishName =''");
                Connect.CreatConnect().DoSQL("alter table danjumingxitable add  EnglishName nvarchar(250)");
                Connect.CreatConnect().DoSQL("update danjumingxitable set  EnglishName =''");
                Connect.CreatConnect().DoSQL("CREATE TABLE [dbo].[BaoGuanTable] ([ID][int] IDENTITY(1, 1) NOT NULL,[InvoiceNo][nvarchar](250) NOT NULL, " +
                    " [FromAddress][nvarchar](250) NOT NULL,  [Payment][nvarchar](250) NOT NULL,  [InvoiceDate][date] NULL,  [LCDate][date] NULL, [LCNO][nvarchar](250) NULL, " +
                    "  [Notify][nvarchar](250) NULL,[LoadingPort][nvarchar](250) NULL,  [DesPort][nvarchar](250) NULL,  [LCBank][nvarchar](250) NULL,  [Remarks][nvarchar](250) NULL," +
                    " [Carrier][nvarchar](250) NULL,  [Sailing][nvarchar](250) NULL,  [FromSaleNo][nvarchar](50) NOT NULL, [Customer][nvarchar](250) NOT NULL, " +
                    " [CompanyName][nvarchar](250) NOT NULL, [SalingOnDate][date] NULL, [CustomerFax][nvarchar](250) NULL, [CustomerEmail][nvarchar](250) NULL" +
                    ", [CustomerTexCode][nvarchar](250) NULL, [CustomerZIPCODE][nvarchar](250) NULL, [CustomerHAIPHONGPORT][nvarchar](250) NULL," +
                    " [CustomerAddress][nvarchar](250) NULL, [CustomerTel][nvarchar](250) NULL, [SaleTel][nvarchar](250) NULL, [SaleAddress][nvarchar](250) NULL" +
                    " CONSTRAINT[PK_BaoGuanTable] PRIMARY KEY CLUSTERED(  [ID] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, " +
                    "IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]");
            }
            catch
            { }
        }
        public static void UpdateToV2015()
        {
            var verinfo = versionService.GetOneversion(x => x.own == "2.20");
            if (verinfo.Version == "1.0.2.14")
            {  verinfo.Version = "1.0.2.15";
               更新数据库版本.UpdateInfo(verinfo);
                Console.WriteLine($"更新版本到{verinfo.Version }");
                修改长度();
                Console.WriteLine("修改长度成功");
              
            }
        }
        private  static void 修改长度()
        {
            try
            {
                Connect.CreatConnect().DoSQL("alter table madanpicture alter column ckdh nvarchar(250)");
                Connect.CreatConnect().DoSQL("alter table madanpicture alter column khbh nvarchar(250)");
                Connect.CreatConnect().DoSQL("alter table ShengchanHouzhengli alter column yaoqiu nvarchar(250)");
            }
            catch
            { }
        }
    }
}
