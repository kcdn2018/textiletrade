using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace Tools
{
  public   class ReportService
    {
        public const string 报表 = "Report";
        public const string 唛头 = "唛头模板";
        public const string 标签 = "Labels";
        public  static void  LoadReport(string filename,ReportTable report)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                byte[] infbytes = new byte[(int)fs.Length];
                fs.Read(infbytes, 0, infbytes.Length);
                fs.Close();
                report.ReportFile = infbytes;
                ReportTableService.InsertReportTable(report);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void  DownLoad(string path)
        {
            Task.Run(new Action(() => {
                DirectoryInfo dir = new DirectoryInfo(path+"\\Labels\\");
                FileInfo[] files = dir.GetFiles();
                foreach (var item in files )
                {
                    File.Delete(item.FullName );
                }
                dir = new DirectoryInfo(path + "\\唛头模板\\");
                files  = dir.GetFiles();
                foreach (var item in files)
                {
                    File.Delete(item.FullName);
                }
                var reportlist = ReportTableService.GetReportTablelst();
            foreach (var r in reportlist )
            {
                    Save(r.reportName ,r.reportStyle ,path );
            }
            }));
        }
        public static void Save(string reportname,string reportstyle,string path)
        {
            var report = ReportTableService.GetOneReportTable(x => x.reportName == reportname && x.reportStyle == reportstyle);
            if (!string.IsNullOrEmpty(report.reportName))
            {
                var filepath = path + "\\" + reportstyle + "\\"+reportname;
                FileStream fs = new FileStream(filepath , FileMode.Create, FileAccess.Write);
                fs.Write(report.ReportFile, 0, report.ReportFile.Length);
                fs.Close();
            }
        }
        public static void Delete(ReportTable report,string path)
        {
            ReportTableService.DeleteReportTable(x => x.reportName == report.reportName  && x.reportStyle == report.reportStyle );
            path += "\\" + report.reportStyle + "\\" + report.reportName;
            File.Delete(path);
        }
    }
}
