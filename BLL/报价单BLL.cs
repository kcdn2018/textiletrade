using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace BLL
{
  public static   class 报价单BLL
    {
        public static void 保存报价单(List <JiYangBaoJia > listjiyang)
        {         
            DanjuTableService.InsertDanjuTable(CreateDanju (listjiyang ));
            string bh = listjiyang.Count > 0 ? LXRService.GetOneLXR(x => x.MC == listjiyang[0].KHMC).BH : string.Empty;
            foreach (var j in listjiyang )
            {
                j.KHBH = bh; 
            }
            JiYangBaoJiaService.InsertJiYangBaoJialst(listjiyang);
        }
        private static DanjuTable CreateDanju(List<JiYangBaoJia> listjiyang)
        {
            if (listjiyang.Count > 0)
            {
                var jiyang = listjiyang[0];
                var danju = new DanjuTable()
                {
                    dh = jiyang.DH,
                    ksbh = LXRService.GetOneLXR(x => x.MC == jiyang.KHMC).BH,
                    ksmc = jiyang.KHMC,
                    rq = jiyang.RQ,
                    je = listjiyang.Sum(x => x.HejiJinE),
                    TotalMishu = listjiyang.Sum(x => x.sl),
                    wuliuBianhao = jiyang.ydh,
                    wuliugongsi = jiyang.kdgs,
                    djlx = DanjuLeiXing.来样登记单,
                    yunfei = jiyang.yf,
                    bz = jiyang.bz,
                };
                return danju;
            }else
            {
                return new DanjuTable()
                {
                    rq = DateTime.Now.Date ,
                    je = listjiyang.Sum(x => x.HejiJinE),
                    TotalMishu = listjiyang.Sum(x => x.sl),
                    djlx = DanjuLeiXing.来样登记单 ,
                };
            }
        }
        public static void 修改单据(List<JiYangBaoJia> listjiyang)
        {
            var danju = CreateDanju(listjiyang);
            DanjuTableService.UpdateDanjuTable(danju ,x=>x.dh==danju.dh );
            JiYangBaoJiaService.DeleteJiYangBaoJia(x => x.DH == danju.dh);
            JiYangBaoJiaService.InsertJiYangBaoJialst(listjiyang);
        }
        public static void 删除(string danhao)
        {
            JiYangBaoJiaService.DeleteJiYangBaoJia(x => x.DH == danhao);
            DanjuTableService.DeleteDanjuTable(x => x.dh == danhao);
        }
    }
 }

