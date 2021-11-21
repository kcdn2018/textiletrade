using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 纺织贸易管理系统;

namespace BLL
{
   public static  class 财务BLL
    {
        public static void 增加应收款(DanjuTable danju )
        {
            if (danju.Qiankuan == "欠款")
            {
                if (!string.IsNullOrEmpty (danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    if (danju.Bizhong != "美金")
                    {
                        lxr.JE += (danju.je + danju.totalmoney);
                        LXRService.UpdateLXR($"JE='{lxr.JE }'", x => x.BH == danju.ksbh);
                    }
                    else
                    {
                        lxr.USD  += (danju.je + danju.totalmoney);
                        LXRService.UpdateLXR($"USD='{lxr.USD }'", x => x.BH == danju.ksbh);
                    }
                }
            }
        }
        public static void 减少应收款(DanjuTable danju)
        {
            if (danju.Qiankuan == "欠款")
            {
                if (!string.IsNullOrEmpty(danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    if (danju.Bizhong != "美金")
                    {
                        lxr.JE -= (danju.je + danju.totalmoney);
                        LXRService.UpdateLXR($"JE='{lxr.JE }'", x => x.BH == danju.ksbh);
                    }
                    else
                    {
                        lxr.USD -= (danju.je + danju.totalmoney);
                        LXRService.UpdateLXR($"USD='{lxr.USD }'", x => x.BH == danju.ksbh);
                    }
                }
            }
        }
        public static void 增加应付款(DanjuTable danju)
        {
            if (danju.Qiankuan == "欠款")
            {
                if (!string.IsNullOrEmpty(danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    lxr.JE += (danju.je + danju.totalmoney);
                    LXRService.UpdateLXR($"JE='{lxr.JE }'", x => x.BH == danju.ksbh);
                }
            }
        }
        public static void 减少应付款(DanjuTable danju)
        {
            if (danju.Qiankuan == "欠款")
            {
                if (!string.IsNullOrEmpty(danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    lxr.JE-= (danju.je + danju.totalmoney);
                    LXRService.UpdateLXR($"JE='{lxr.JE }'", x => x.BH == danju.ksbh);
                }
            }
        }
        public static void 增加应收发票(DanjuTable danju)
        {
            if (danju.Hanshui == "含税")
            {
                if (!string.IsNullOrEmpty(danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    lxr.YingShouFapiao += danju.je;
                    LXRService.UpdateLXR($"YingShouFapiao='{lxr.YingShouFapiao }'", x => x.BH == danju.ksbh);
                }
            }
        }
        public static void 减少应收发票(DanjuTable danju)
        {
            if (danju.Hanshui == "含税")
            {
                if (!string.IsNullOrEmpty(danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    lxr.YingShouFapiao -= danju.je;
                    LXRService.UpdateLXR($"YingShouFapiao='{lxr.YingShouFapiao }'", x => x.BH == danju.ksbh);
                }
            }
        }
        public static void 增加应开发票(DanjuTable danju)
        {
            if (danju.Hanshui == "含税")
            {
                if (!string.IsNullOrEmpty(danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    lxr.YingKaifapiao += danju.je;
                    LXRService.UpdateLXR($"YingKaifapiao='{lxr.YingKaifapiao }'", x => x.BH == danju.ksbh);
                }
            }
        }
        public static void 增加应开发票(List <danjumingxitable >  danjumingxis,DanjuTable danju )
        {
            foreach (var danjumingxi in danjumingxis)
            {
                if (danjumingxi.IsHanshui == IsHanshuiModel.含税)
                {
                    if (!string.IsNullOrEmpty(danju.ksbh))
                    {
                        var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                        lxr.YingKaifapiao += danjumingxi.hanshuiheji;
                        LXRService.UpdateLXR($"YingKaifapiao='{lxr.YingKaifapiao }'", x => x.BH == danju.ksbh);
                    }
                }
            }
        }
        public static void 减少应开发票(DanjuTable danju)
        {
            if (danju.Hanshui == "含税")
            {
                if (!string.IsNullOrEmpty(danju.ksbh))
                {
                    var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
                    lxr.YingKaifapiao -= danju.je;
                    LXRService.UpdateLXR($"YingKaifapiao='{lxr.YingKaifapiao }'", x => x.BH == danju.ksbh);
                }
            }
        }
        public static void 减少应开发票(DanjuTable danju,List<danjumingxitable > danjumingxis)
        {
            foreach (var danjumingxi in danjumingxis)
            {
                if (danjumingxi.IsHanshui == IsHanshuiModel.含税)
                {
                    if (!string.IsNullOrEmpty(danju.ksbh ))
                    {
                        var lxr = LXRService.GetOneLXR(x => x.MC  == danju.ksbh);
                        lxr.YingKaifapiao -= danjumingxi.hanshuiheji;
                        LXRService.UpdateLXR($"YingKaifapiao='{lxr.YingKaifapiao }'", x => x.BH == danju.ksbh);
                    }
                }
            }
        }
        /// <summary>
        /// 查询额度
        /// </summary>
        /// <param name="customerNum"></param>
        /// <returns>true 表明额度够 false 表示额度不够了</returns>
        public static Boolean 查询额度(string customerNum,decimal jine)
        {
            if (!string.IsNullOrEmpty(customerNum))
            {
                var lxr = LXRService.GetOneLXR(x => x.BH == customerNum);
                return lxr.sxed - jine > 0 ? true : false;
            }
            else
            {
                return true;
            }
        }
       /// <summary>
       /// 减少剩余额度
       /// </summary>
       /// <param name="CustomerNum">客户编号</param>
       /// <param name="jine">要减少的金额</param>
        public static void 减少剩余额度(string CustomerNum,decimal jine)
        {
            if (string.IsNullOrEmpty(CustomerNum))
            {
                return;
            }
            var lxr = LXRService.GetOneLXR(x => x.BH == CustomerNum);
            lxr.sxed -= jine;
            LXRService.UpdateLXR($"sxed='{lxr.sxed }'", x => x.BH == CustomerNum);
        }
        /// <summary>
        /// 增加剩余额度
        /// </summary>
        /// <param name="CustomerNum">客户编号</param>
        /// <param name="jine">要增加的额度</param>
        public static void 增加剩余额度(string CustomerNum, decimal jine)
        {
            if (string.IsNullOrEmpty(CustomerNum))
            {
                return;
            }
            var lxr = LXRService.GetOneLXR(x => x.BH == CustomerNum);
            lxr.sxed += jine;
            LXRService.UpdateLXR($"sxed='{lxr.sxed }'", x => x.BH == CustomerNum);
        }
        /// <summary>
        /// 检查是否有超期订单。有返回true 没有返回false
        /// </summary>
        /// <param name="CustomerNum"></param>
        /// <returns></returns>
        public static bool  检查是否有超期(string CustomerNum)
        {
            if (string.IsNullOrEmpty(CustomerNum))
            {
                return true;
            }
            var linkman = LXRService.GetOneLXR(x => x.BH == CustomerNum);
            var order = OrderTableService.GetOrderTablelst(x => x.CustomerNum == CustomerNum && x.ShengYuMoney >= 0).OrderBy (x=>x.Orderdate ).ToList ();
            if(order.Count >0)
            {
                TimeSpan sp =  DateTime.Now.Subtract(order[0].Orderdate );
               if( sp.Days >linkman.ZhangQi)
                {
                    return true;
                }
               else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
