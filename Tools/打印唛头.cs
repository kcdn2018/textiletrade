using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace Tools
{
   public   class 打印唛头
    { 
        public  string PrinterName { get; set; }
        public  decimal copyies { get; set; }
        public string moban { get; set; }
        public JuanHaoTable juan { get; set; }
        public int userful { get; set; }

        public  void 打印( )
        {
            var dt =ShippingMark. CreateShippingDatatable(juan,1 );
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dt);
            var fs = new FastReport.Report();        
            fs.RegisterData(dataSet);     
            try
            {
                fs.Load(moban); 
                switch (userful )
                {
                    case PrintModel.Design:
                        fs.Design();
                        var arr = moban .Split('\\');
                        ReportTableService.DeleteReportTable(x => x.reportName == arr[arr.Length - 1] && x.reportStyle == ReportService.唛头);
                        ReportService.LoadReport(moban , new ReportTable { reportStyle = ReportService.唛头, reportName = arr[arr.Length - 1] });
                        break;
                    case PrintModel.Privew:
                        fs.Show();
                        break;
                    case PrintModel.Print:
                        fs.PrintSettings.Printer = PrinterName;
                        fs.PrintSettings.Copies  =(int) copyies;
                        fs.PrintSettings.ShowDialog = false;
                        fs.Print();
                        break;
                }
            }
            catch
            {               
                fs.Design();
            }
        }
    }
}
