using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 寄样单BLL
    {
        public static void 保存寄样单(List<JiYangBaoJia > listjiyang,DanjuTable danju ,Boolean usekucun)
        {
            danju.dh = 单据BLL.检查单号(danju.dh);
            DanjuTableService.InsertDanjuTable(danju);
            财务BLL.增加应收款(danju);
            来往明细BLL.增加来往记录(danju);
            保存单据(listjiyang,danju.dh );
            if (usekucun == true)
            {
                减少库存(listjiyang, danju);
            }
        }
        private static void 保存单据(List<JiYangBaoJia> listjiyang,string danhao)
        {
           string   bh = listjiyang.Count > 0 ? LXRService.GetOneLXR(x => x.MC == listjiyang[0].KHMC).BH : string.Empty;
            foreach (var jiyangdan in listjiyang )
            {
                jiyangdan.DH = danhao;
                jiyangdan.KHBH = bh;       
            }
            JiYangBaoJiaService.InsertJiYangBaoJialst(listjiyang);
        }
        private static void 减少库存(List<JiYangBaoJia >listjiyang,DanjuTable danju )
        {
            List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
            foreach (var jiyangdan in listjiyang)
            {
                danjumingxitables.Add(new danjumingxitable()
                {
                    Bianhao = jiyangdan.SPBH,
                    yanse   = jiyangdan.ys,
                    ganghao = jiyangdan.Ganghao,
                    OrderNum = jiyangdan.OrderNum,
                    ContractNum = jiyangdan.Hetonghao,
                    kuanhao = jiyangdan.Kuanhao ,
                    houzhengli=jiyangdan.GHSMC,
                    Kuwei =jiyangdan.Kuwei ,
                    chengpingmishu=jiyangdan.sl ,
                    Huahao=string.Empty ,
                    ColorNum=string.Empty,
                    CustomName=string.Empty ,
                    PiBuChang=string.Empty ,
                    Pihao =string.Empty ,
                    menfu=jiyangdan.mf ,
                }) ;
            } 
            库存BLL .减少库存 (danjumingxitables,danju );
        }
        private static void 增加库存(List<JiYangBaoJia> listjiyang, DanjuTable danju)
        {
            List<danjumingxitable> danjumingxitables = new List<danjumingxitable>();
            foreach (var jiyangdan in listjiyang)
            {
                danjumingxitables.Add(new danjumingxitable()
                {
                    Bianhao = jiyangdan.SPBH,
                    yanse   = jiyangdan.ys,
                    ganghao = jiyangdan.Ganghao,
                    OrderNum = jiyangdan.OrderNum,
                    ContractNum = jiyangdan.Hetonghao,
                    kuanhao = jiyangdan.Kuanhao,
                    houzhengli = jiyangdan.GHSMC,
                    Kuwei=jiyangdan.Kuwei,
                    chengpingmishu=jiyangdan.sl,
                     Huahao = string.Empty,
                    ColorNum = string.Empty,
                    CustomName = string.Empty,
                    PiBuChang = string.Empty,
                    Pihao = string.Empty,
                    menfu=jiyangdan.mf ,
                });
            }
            库存BLL.增加库存 (danjumingxitables, danju);
        }
        public static void 修改单据(List<JiYangBaoJia> listjiyang,DanjuTable danju, Boolean usekucun)
        {
            财务BLL.减少应收款(DanjuTableService.GetOneDanjuTable(x => x.dh == danju.dh));
            来往明细BLL.删除来往记录(danju);
            DanjuTableService.UpdateDanjuTable(danju, x => x.dh == danju.dh);
            //删除单据(danju.dh );
            var jiyang = JiYangBaoJiaService.GetOneJiYangBaoJia(x => x.DH == danju.dh);
            删除单据(danju.dh);
            保存单据(listjiyang,danju.dh );
            财务BLL.增加应收款(danju);
            来往明细BLL.增加来往记录(danju);
            if (jiyang.zt == 1)
            {
                增加库存(listjiyang, DanjuTableService.GetOneDanjuTable(x => x.dh == danju.dh));
                减少库存(listjiyang, danju);
            }
        }
        private  static void 删除单据(string danhao)
        {
            JiYangBaoJiaService.DeleteJiYangBaoJia(x => x.DH == danhao);
        }
        public static void 删除寄样单据(string danhao)
        {  
            var danju = DanjuTableService.GetOneDanjuTable(x => x.dh == danhao);
            var jiyang = JiYangBaoJiaService.GetOneJiYangBaoJia(x => x.DH == danhao);
            if (jiyang.zt == 1)
            {
                增加库存(JiYangBaoJiaService.GetJiYangBaoJialst(x => x.DH == danhao), danju);
            }
            来往明细BLL.删除来往记录(danju);
            财务BLL.减少应收款(danju); 
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
            删除单据(danhao);     
        }
    }
}
