using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统
{
    public class ExcelService
    {
        public static void ExportExcels(string fileName, DataGridView myDGV)
        {

            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                                                                  //写入标题
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                if (myDGV.Columns[i].Visible == true)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    if (myDGV.Columns[i].Visible == true)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                }
            }
            xlApp.Quit();
            GC.Collect();//强行销毁
            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void PrintExcels(string fileName, DataGridView myDGV)
        {

            //string saveFileName = "c://temp.xls";
            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.DefaultExt = "xls";
            //saveDialog.Filter = "Excel文件|*.xls";
            //saveDialog.FileName = fileName;
            //saveDialog.ShowDialog();
            //saveFileName = saveDialog.FileName;
            //if (saveFileName.IndexOf(":") < 0) return; //被点了取消
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                                                                  //写入标题
            for (int i = 0; i < myDGV.ColumnCount; i++)
            {
                if (myDGV.Columns[i].Visible == true)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
            }
            //写入数值
            for (int r = 0; r < myDGV.Rows.Count; r++)
            {
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    if (myDGV.Columns[i].Visible == true)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            //if (saveFileName != "")
            //{
            //    try
            //    {
            //        workbook.Saved = true;
            //        workbook.SaveCopyAs(fileName );
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
            //    }
            //}        
            xlApp.Visible = true;
            worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;//纸张大小
            //worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;//页面横向
                                                                                  //workSheet.PageSetup.Zoom = 75; //打印时页面设置,缩放比例百分之几
            worksheet.PageSetup.Zoom = false; //打印时页面设置,必须设置为false,页高,页宽才有效
            worksheet.PageSetup.FitToPagesWide = 1; //设置页面缩放的页宽为1页宽
            worksheet.PageSetup.FitToPagesTall = false; //设置页面缩放的页高自动
            //worksheet.PageSetup.CenterHeader  = infoService.Getinfolst()[0].gsmc;//页面左上边的标志
            worksheet.PageSetup.CenterFooter = "第 &P 页，共 &N 页";//页面下标
            worksheet.PageSetup.PrintGridlines = true; //打印单元格网线
            worksheet.PageSetup.TopMargin = 1.5 / 0.035; //上边距为2cm（转换为in）
            worksheet.PageSetup.BottomMargin = 1.5 / 0.035; //下边距为1.5cm
            worksheet.PageSetup.LeftMargin = 2 / 0.035; //左边距为2cm
            worksheet.PageSetup.RightMargin = 2 / 0.035; //右边距为2cm
            worksheet.PageSetup.CenterHorizontally = true; //文字水平居中
            workbook.PrintPreview  ();  
            //xlApp.Quit(); 
            File.Delete(fileName );
            KillProcess(xlApp); //杀掉生成的进程
            GC.Collect();//强行销毁
            //MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr Hwnd, out int PID);
        /// <summary>
        /// 杀掉生成的进程
        /// </summary>
        /// <param name="AppObject">进程程对象</param>
        private static void KillProcess(Microsoft.Office.Interop.Excel.Application AppObject)
        {
            int Pid = 0;
            IntPtr Hwnd = new IntPtr(AppObject.Hwnd);
            System.Diagnostics.Process p = null;
            try
            {
                GetWindowThreadProcessId(Hwnd, out Pid);
                p = System.Diagnostics.Process.GetProcessById(Pid);
                if (p != null)
                {
                    p.Kill();
                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("进程关闭失败！异常信息：" + ex);
            }
        }
    }
}
