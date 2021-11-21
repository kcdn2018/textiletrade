using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 生产计划单BLL
    {
        public static void Save(ShengChanDanTable shengChanDanTable ,List<ShengchanBuliaoInfo> shengchanBuliaoInfos ,List  <ShengchanHouzhengli> shengchanHouzhenglis,List<ShengchanChanshangTable > shengchans  )
        {
            shengChanDanTable.shengchandanhao = 单据BLL.检查生产单号 (shengChanDanTable.shengchandanhao );
            ShengChanDanTableService.InsertShengChanDanTable(shengChanDanTable);
            foreach (var buliao in shengchanBuliaoInfos)
            {
                buliao.ShengChanDanhao = shengChanDanTable.shengchandanhao;
                
            }
            ShengchanBuliaoInfoService .InsertShengchanBuliaoInfolst (shengchanBuliaoInfos);
            foreach (var houzhengli in shengchanHouzhenglis )
            {
                houzhengli.shengchandanhao = shengChanDanTable.shengchandanhao;  
            }
            ShengchanHouzhengliService.InsertShengchanHouzhenglilst(shengchanHouzhenglis);
            foreach (var houzhengli in shengchans )
            {
                houzhengli.ShengChandanhao  = shengChanDanTable.shengchandanhao;       
            } 
            ShengchanChanshangTableService .InsertShengchanChanshangTablelst  (shengchans);
        }
        public static void Edit(ShengChanDanTable shengChanDanTable, List<ShengchanBuliaoInfo> shengchanBuliaoInfos, List<ShengchanHouzhengli> shengchanHouzhenglis, List<ShengchanChanshangTable> shengchans)
        {
            Delete(shengChanDanTable.shengchandanhao );
            Save(shengChanDanTable ,shengchanBuliaoInfos ,shengchanHouzhenglis,shengchans  );
        }
        public static void Delete(string danhao)
        {
            ShengChanDanTableService.DeleteShengChanDanTable(x => x.shengchandanhao == danhao);
            ShengchanBuliaoInfoService.DeleteShengchanBuliaoInfo(x => x.ShengChanDanhao == danhao);
            ShengchanHouzhengliService.DeleteShengchanHouzhengli(x => x.shengchandanhao == danhao);
            ShengchanChanshangTableService.DeleteShengchanChanshangTable(x => x.ShengChandanhao == danhao);
        }
        public static void 结束生产单(string danhao)
        {
            ShengChanDanTableService.UpdateShengChanDanTable("State='已结束'", x => x.shengchandanhao == danhao) ;
        }
        public static void 重启生产单(string danhao)
        {
            ShengChanDanTableService.UpdateShengChanDanTable("State='未完成'", x => x.shengchandanhao == danhao);
        }
    }
}
