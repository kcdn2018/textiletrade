using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.自定义类
{
    public class ExcelService
    {
        public static void ExportExcels(string fileName, Sunny.UI.UIDataGridView dgv )
        {
            IWorkbook workbook;
            ISheet sheet;
            Stopwatch sw = null;

            //判断datagridview中内容是否为空
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("DataGridView中内容为空,请先导入数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //保存文件
            string saveFileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "Excel文件保存路径";
            saveFileDialog.FileName = fileName;
            MemoryStream ms = new MemoryStream(); //MemoryStream
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //**程序开始计时**//
                sw = new Stopwatch();
                sw.Start();
                saveFileName = saveFileDialog.FileName;
            }
            else
            {
                workbook = null;
                ms.Close();
                ms.Dispose();
            }

            //*** 根据扩展名xls和xlsx来创建对象
            string fileExt = Path.GetExtension(saveFileName).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = null;
            }
            //***

            //创建Sheet
            if (workbook != null)
            {
                sheet = workbook.CreateSheet("Sheet1");//Sheet的名称  
            }
            else
            {
                return;
            }

            //设置单元格样式
            ICellStyle cellStyle = workbook.CreateCellStyle();
            //水平居中对齐和垂直居中对齐
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //设置字体
            IFont font = workbook.CreateFont();
            font.FontName = "微软雅黑";//字体名称
            font.FontHeightInPoints = 9;//字号
            font.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;//字体颜色
            cellStyle.SetFont(font);

            //添加列名
            IRow headRow = sheet.CreateRow(0);
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                //隐藏行列不导出
                if (dgv.Columns[i].Visible == true)
                {
                    headRow.CreateCell(i).SetCellValue(dgv.Columns[i].HeaderText);
                    headRow.GetCell(i).CellStyle = cellStyle;
                }
            }

            //根据类型写入内容
            for (int rowNum = 0; rowNum < dgv.Rows.Count; rowNum++)
            {
                ///跳过第一行,第一行为列名
                IRow dataRow = sheet.CreateRow(rowNum + 1);
                for (int columnNum = 0; columnNum < dgv.Columns.Count; columnNum++)
                {
                    int columnWidth = sheet.GetColumnWidth(columnNum) / 256; //列宽

                    //隐藏行列不导出
                    if (dgv.Rows[rowNum].Visible == true && dgv.Columns[columnNum].Visible == true)
                    {
                        //防止行列超出Excel限制
                        if (fileExt == ".xls")
                        {
                            //03版Excel最大行数是65536行,最大列数是256列
                            if (rowNum > 65536)
                            {
                                MessageBox.Show("行数超过Excel限制!");
                                return;
                            }
                            if (columnNum > 256)
                            {
                                MessageBox.Show("列数超过Excel限制!");
                                return;
                            }
                        }
                        else if (fileExt == ".xlsx")
                        {
                            //07版Excel最大行数是1048576行,最大列数是16384列
                            if (rowNum > 1048576)
                            {
                                MessageBox.Show("行数超过Excel限制!");
                                return;
                            }
                            if (columnNum > 16384)
                            {
                                MessageBox.Show("列数超过Excel限制!");
                                return;
                            }
                        }

                        ICell cell = dataRow.CreateCell(columnNum);
                        if (dgv.Rows[rowNum].Cells[columnNum].Value == null)
                        {
                            cell.SetCellType(CellType.Blank);
                        }
                        else
                        {
                            if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Int32"))
                            {
                                cell.SetCellValue(Convert.ToInt32(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.String"))
                            {
                                cell.SetCellValue(dgv.Rows[rowNum].Cells[columnNum].Value.ToString());
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Single"))
                            {
                                cell.SetCellValue(Convert.ToSingle(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Double"))
                            {
                                cell.SetCellValue(Convert.ToDouble(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.Decimal"))
                            {
                                cell.SetCellValue(Convert.ToDouble(dgv.Rows[rowNum].Cells[columnNum].Value));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.DateTime"))
                            {
                                cell.SetCellValue(Convert.ToDateTime(dgv.Rows[rowNum].Cells[columnNum].Value).ToString("yyyy-MM-dd"));
                            }
                            else if (dgv.Rows[rowNum].Cells[columnNum].ValueType.FullName.Contains("System.DBNull"))
                            {
                                cell.SetCellValue("");
                            }
                        }

                        //设置列宽
                        IRow currentRow;
                        if (sheet.GetRow(rowNum) == null)
                        {
                            currentRow = sheet.CreateRow(rowNum);
                        }
                        else
                        {
                            currentRow = sheet.GetRow(rowNum);
                        }

                        if (currentRow.GetCell(columnNum) != null)
                        {
                            ICell currentCell = currentRow.GetCell(columnNum);
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;

                            if (columnWidth < length)
                            {
                                columnWidth = length + 10; //设置列宽数值
                            }
                        }
                        sheet.SetColumnWidth(columnNum, columnWidth * 256);

                        //单元格样式
                        dataRow.GetCell(columnNum).CellStyle = cellStyle;
                    }
                }
            }
            //保存为Excel文件                  
            workbook.Write(ms);
            FileStream file = new FileStream(saveFileName, FileMode.Create);
            workbook.Write(file);
            file.Close();
            workbook = null;
            ms.Close();
            ms.Dispose();
            //**程序结束计时**//
            sw.Stop();
            double totalTime = sw.ElapsedMilliseconds / 1000.0;
            MessageBox.Show(fileName + " 导出成功\n耗时" + totalTime + "s", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 读取Execl数据到DataTable(DataSet)中
        /// </summary>
        /// <param name="filePath">指定Execl文件路径</param>
        /// <param name="isFirstLineColumnName">设置第一行是否是列名</param>
        /// <returns>返回一个DataTable数据集</returns>
        public static DataSet ExcelToDataSet(string filePath, bool isFirstLineColumnName)
        {
            DataSet dataSet = new DataSet();
            int startRow = 0;
            try
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    IWorkbook workbook = null;
                    // 如果是2007+的Excel版本
                    if (filePath.IndexOf(".xlsx") > 0)
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    // 如果是2003-的Excel版本
                    else if (filePath.IndexOf(".xls") > 0)
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    if (workbook != null)
                    {
                        //循环读取Excel的每个sheet，每个sheet页都转换为一个DataTable，并放在DataSet中
                        for (int p = 0; p < workbook.NumberOfSheets; p++)
                        {
                            ISheet sheet = workbook.GetSheetAt(p);
                            DataTable dataTable = new DataTable();
                            dataTable.TableName = sheet.SheetName;
                            if (sheet != null)
                            {
                                int rowCount = sheet.LastRowNum;//获取总行数
                                if (rowCount > 0)
                                {
                                    IRow firstRow = sheet.GetRow(0);//获取第一行
                                    int cellCount = firstRow.LastCellNum;//获取总列数

                                    //构建datatable的列
                                    if (isFirstLineColumnName)
                                    {
                                        startRow = 1;//如果第一行是列名，则从第二行开始读取
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            ICell cell = firstRow.GetCell(i);
                                            if (cell != null)
                                            {
                                                if (cell.StringCellValue != null)
                                                {
                                                    DataColumn column = new DataColumn(cell.StringCellValue);
                                                    dataTable.Columns.Add(column);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                        {
                                            DataColumn column = new DataColumn("column" + (i + 1));
                                            dataTable.Columns.Add(column);
                                        }
                                    }

                                    //填充行
                                    for (int i = startRow; i <= rowCount; ++i)
                                    {
                                        IRow row = sheet.GetRow(i);
                                        if (row == null) continue;

                                        DataRow dataRow = dataTable.NewRow();
                                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                                        {
                                            ICell cell = row.GetCell(j);
                                            if (cell == null)
                                            {
                                                dataRow[j] = "";
                                            }
                                            else
                                            {
                                                //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)
                                                switch (cell.CellType)
                                                {
                                                    case CellType.Blank:
                                                        dataRow[j] = "";
                                                        break;
                                                    case CellType.Numeric:
                                                        short format = cell.CellStyle.DataFormat;
                                                        //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                                        if (format == 14 || format == 31 || format == 57 || format == 58)
                                                            dataRow[j] = cell.DateCellValue;
                                                        else
                                                            dataRow[j] = cell.NumericCellValue;
                                                        break;
                                                    case CellType.String:
                                                        dataRow[j] = cell.StringCellValue;
                                                        break;
                                                }
                                            }
                                        }
                                        dataTable.Rows.Add(dataRow);
                                    }
                                }
                            }
                            dataSet.Tables.Add(dataTable);
                        }

                    }
                }
                return dataSet;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
