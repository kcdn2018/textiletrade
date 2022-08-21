using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tools
{
   public static  class 获取模板
    {
        public static List<string > 获取所有模板(string path)
        {
            var filelist = new List<string>();
            //第一种方法
            var files = Directory.GetFiles(path, "*.frx");

            foreach (var file in files)
            {
                var filename = file.Split('\\');
                filelist.Add(filename[filename.Length-1]);
            }
            return filelist;       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <param name="cankao"></param>
        /// <param name="reportstyle">1表示是票签 2表示唛头</param>
        public static void 新增模板(string path, string filename, string cankao, string  reportstyle)
        {
            var filelist = new List<string>();
            //第一种方法
            var files = Directory.GetFiles(path, "*.frx");
            if (files.Length >0)
            {
                File.Copy(path +cankao, path+filename+".frx");
            }
            if (reportstyle == ReportService.标签 )
            {
                打印标签.打印(0, new 纺织贸易管理系统.db(), new Model.PrintSetting() { Path = path + filename + ".frx", Printmodel = PrintModel.Design, PrintNum = 1 }, new List<纺织贸易管理系统.ShengChengGongYi>(), new 纺织贸易管理系统.JiYangBaoJia());
            }
            else
            {
                new Tools.打印唛头() { copyies = 0, PrinterName = string.Empty , userful = PrintModel.Design, moban = path + filename + ".frx", juan = new 纺织贸易管理系统.JuanHaoTable() }.打印();
            }
         }
        public static void 新增唛头模板(string path, string filename)
        {
            var filelist = new List<string>();
            //第一种方法
            var files = Directory.GetFiles(path, "*.frx");
            if (files.Length > 0)
            {
                File.Copy(files[0], path + filename + ".frx");
            }
        }
        public static void 删除模板(string path)
        {
            File.Delete(path);
        }
    }
}
