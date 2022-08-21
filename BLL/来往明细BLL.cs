using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统;

namespace BLL
{
  public static   class 来往明细BLL
    {
        public static void 增加来往记录(DanjuTable danju )
        {
            LwDetail lwDetail = new LwDetail();
            switch (danju.djlx )
            {
                case DanjuLeiXing.外检直销单 :
                    lwDetail = LXRService.GetOneLXR(x => x.MC == danju.ksmc).LX == "客户" ? 销售单(danju) : 白坯直销单(danju);
                    break;
                case DanjuLeiXing.白坯直销单 :
                    lwDetail =LXRService.GetOneLXR (x=>x.MC==danju.ksmc ).LX =="客户"? 销售单(danju):白坯直销单(danju);
                    break;
                case DanjuLeiXing.白坯销售单 :
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.销售出库单:             
                     lwDetail = 销售单(danju);                  
                    break ;
                case DanjuLeiXing.色卡采购单:
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.色卡销售单 :
                    lwDetail = 销售单 (danju);
                    break;
                case DanjuLeiXing.采购入库单:
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.销售退货单 :
                    lwDetail = 销售退货单 (danju);
                    break;
                case DanjuLeiXing.采购退货单 :
                    lwDetail = 采购退货单 (danju);
                    break;
                case DanjuLeiXing.委外取货单 :
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.付款单 :
                    lwDetail = 付款单(danju);
                    break;
                case DanjuLeiXing.收款单:
                    lwDetail = 收款单 (danju);
                    break;
                case DanjuLeiXing.发票签收:
                    lwDetail = 发票签收(danju);
                    break;
                case DanjuLeiXing.发票开具 :
                    lwDetail = 发票开具 (danju);
                    break;
                case DanjuLeiXing.寄样单 :
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.费用单 :
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.打样工艺单 :
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.销售订单 :
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.入库单 :
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.退卷单 :
                    lwDetail = 销售单(danju);
                    break;
            }              
            LwDetailService.InsertLwDetail(lwDetail );
            新增刷新(danju);
        }
        #region "生成对应来往明细单据"
        private static LwDetail 费用单(DanjuTable danju )
        {
            var lw = new LwDetail()
            {
                AddYingFukuan = danju.je,
                DH = danju.dh,
                JE = danju.je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,

            };
            if (danju.Hanshui == "含税")
            {
                lw.FapiaoJine = danju.je;
                lw.AddYingShouFapiao = danju.je;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            lw.QichuJine = LXRService.GetOneLXR(x => x.BH == danju.ksbh).JE;
            lw.QiMojine = lw.QichuJine + danju.je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 销售单(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                AddYingshoukuan = danju.je,
                DH = danju.dh,
                JE = danju.je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,     
            };
            var hanshuijine = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == danju.dh).Where (x=>x.IsHanshui==IsHanshuiModel.含税 ).Sum (x=>x.hanshuiheji );
            if(danju.Hanshui=="含税")
            {
                lw.FapiaoJine = hanshuijine ;
                lw.AddYingKaiFapiao = hanshuijine;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            var lxr = LXRService.GetOneLXR(x => x.MC == danju.ksmc );
            lw.QichuJine = lxr.JE +lxr.USD  ;
            lw.QiMojine = lw.QichuJine + danju.je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 销售单(DanjuTable danju,danjumingxitable mingxi)
        {
            var lw = new LwDetail()
            {
                AddYingshoukuan = mingxi.hanshuiheji ,
                DH = danju.dh,
                JE = mingxi.hanshuiheji,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
            };
            if (mingxi .IsHanshui  == "含税")
            {
                lw.FapiaoJine = mingxi.hanshuiheji;
                lw.AddYingKaiFapiao = mingxi.hanshuiheji;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
            lw.QichuJine = lxr.JE + lxr.USD;
            lw.QiMojine = lw.QichuJine + mingxi.hanshuiheji;
            lw.own = danju.own;
            lw.Hanshui = mingxi.IsHanshui ;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 采购退货单(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                AddYingshoukuan = danju.je,
                DH = danju.dh,
                JE = danju.je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
               
            };
            if (danju.Hanshui == "含税")
            {
                lw.FapiaoJine = danju.je;
               lw. ReduceYingShouFapiao = danju.je;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            lw.QichuJine = LXRService.GetOneLXR(x => x.BH == danju.ksbh).JE;
            lw.QiMojine = lw.QichuJine + danju.je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 采购单(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                AddYingFukuan  = danju.je,
                DH = danju.dh,
                JE = danju.je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,               
            };
            if (danju.Hanshui == "含税")
            {
                lw.FapiaoJine = danju.je;
                lw.AddYingShouFapiao = danju.je;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            lw.QichuJine = LXRService.GetOneLXR(x => x.BH == danju.ksbh).JE;
            lw.QiMojine = lw.QichuJine + danju.je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 白坯直销单(DanjuTable danju)
        {
            var je = danju.je - danju.Profit;
            var lw = new LwDetail()
            {
                AddYingFukuan =je,
                DH = danju.dh,
                JE = je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
            };
            if (danju.Hanshui == "含税")
            {
                lw.FapiaoJine = je;
                lw.AddYingShouFapiao = je;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            lw.QichuJine = LXRService.GetOneLXR(x => x.BH == danju.ksbh).JE;
            lw.QiMojine = lw.QichuJine + je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 销售退货单(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                AddYingFukuan = danju.je,
                DH = danju.dh,
                JE = danju.je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
               
            };
            if (danju.Hanshui == "含税")
            {
                lw.FapiaoJine = danju.je;
                lw.ReduceYingKaiFapiao = danju.je;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
            lw.QichuJine = lxr.JE + lxr.USD;
            lw.QiMojine = lw.QichuJine+ danju.je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 付款单(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                ReduceYingFuKuan = danju.je +danju.totalmoney ,
                DH = danju.dh,
                JE = danju.je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
            };
            if (danju.Hanshui == "含税")
            {
                lw.FapiaoJine = danju.je;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            lw.QichuJine = LXRService.GetOneLXR(x => x.BH == danju.ksbh).JE;
            lw.QiMojine = lw.QichuJine- danju.je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            return lw;
        }
        private static LwDetail 收款单(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                ReduceYingShouKuan = danju.je+danju.totalmoney ,
                DH = danju.dh,
                JE = danju.je,
                bz = danju.bz,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
            };
            if (danju.Hanshui == "含税")
            {
                lw.FapiaoJine = danju.je;
            }
            else
            {
                lw.FapiaoJine = 0;
            }
            var lxr = LXRService.GetOneLXR(x => x.BH == danju.ksbh);
            lw.QichuJine = lxr.JE + lxr.USD;
            lw.QiMojine = lw.QichuJine - danju.je;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;        
            lw.debt = false;
            return lw;
        }
        private static LwDetail 发票签收(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                ReduceYingShouFapiao = danju.je,
                DH = danju.dh,
                bz = danju.bz,
                FapiaoJine = danju.je,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
            };
            lw.QichuJine = LXRService.GetOneLXR(x => x.BH == danju.ksbh).JE;
            lw.QiMojine = lw.QichuJine ;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        private static LwDetail 发票开具(DanjuTable danju)
        {
            var lw = new LwDetail()
            {
                ReduceYingKaiFapiao = danju.je,
                DH = danju.dh,
                bz = danju.bz,
                FapiaoJine = danju.je,
                KHBH = danju.ksbh,
                KHMC = danju.ksmc,
                LX = danju.djlx,
                rq = danju.rq,
            };
            lw.QichuJine = LXRService.GetOneLXR(x => x.BH == danju.ksbh).JE;
            lw.QiMojine = lw.QichuJine;
            lw.own = danju.own;
            lw.Hanshui = danju.Hanshui;
            if (danju.Qiankuan == "欠款")
            {
                lw.debt = true;
            }
            else
            {
                lw.debt = false;
            }
            return lw;
        }
        #endregion 
        public static void 删除来往记录(DanjuTable danju)
        {
            var lwlist = Connect.DbHelper().Queryable<LwDetail>().Where(x => x.rq >= danju.rq && x.KHBH == danju.ksbh).OrderBy(x => x.rq).OrderBy(x => x.ID).ToList();
            if (lwlist.Count > 1)
            {
                var qichu = lwlist[0].QichuJine;
                foreach (var lw in lwlist.Where(x=>x.rq >danju.rq))
                {
                    if (lw.LX != DanjuLeiXing.发票开具 && lw.LX != DanjuLeiXing.发票签收)
                    {
                        lw.QichuJine = qichu;
                        lw.QiMojine = lw.QichuJine + lw.AddYingFukuan + lw.AddYingshoukuan - lw.ReduceYingShouKuan - lw.ReduceYingFuKuan;
                        qichu = lw.QiMojine;
                    }
                    else
                    {
                        lw.QichuJine = qichu;
                        lw.QiMojine = qichu;
                    }
                }
                Connect.DbHelper().Updateable<LwDetail>(lwlist).ExecuteCommand(); 
            }
            LwDetailService.DeleteLwDetail(x => x.DH == danju.dh);
        }
        private static void 刷新(DanjuTable Olddanju )
        {
            var lwlist = Connect.DbHelper().Queryable<LwDetail>().Where(x => x.rq >= Olddanju.rq && x.KHBH == Olddanju.ksbh).OrderBy(x => x.rq).OrderBy(x => x.ID).ToList();
            if (lwlist.Count > 1)
            {
                var qichu = lwlist[0].QichuJine;
                foreach (var lw in lwlist)
                {
                    if (lw.LX != DanjuLeiXing.发票开具 && lw.LX != DanjuLeiXing.发票签收)
                    {
                        lw.QichuJine = qichu;
                        lw.QiMojine = lw.QichuJine + lw.AddYingFukuan + lw.AddYingshoukuan - lw.ReduceYingShouKuan - lw.ReduceYingFuKuan;
                        qichu = lw.QiMojine;
                    }
                    else
                    {
                        lw.QichuJine = qichu;
                        lw.QiMojine = qichu;
                    }
                }
                Connect.DbHelper().Updateable<LwDetail>(lwlist).ExecuteCommand();
            }
        }
        private static void 新增刷新(DanjuTable Olddanju)
        {
            var lwlist = Connect.DbHelper().Queryable<LwDetail>().Where(x => x.rq >= Olddanju.rq && x.KHBH == Olddanju.ksbh).OrderBy(x => x.rq).OrderBy(x => x.ID).ToList();
            if(lwlist.Count >1)
            {
                var qichu = lwlist[1].QichuJine;
                foreach (var lw in lwlist)
                {
                    if (lw.LX != DanjuLeiXing.发票开具 && lw.LX != DanjuLeiXing.发票签收 )
                    {
                        lw.QichuJine = qichu;
                        lw.QiMojine = lw.QichuJine + lw.AddYingFukuan + lw.AddYingshoukuan - lw.ReduceYingShouKuan - lw.ReduceYingFuKuan;
                        qichu = lw.QiMojine;
                    }
                    else
                    {
                        lw.QichuJine = qichu;
                        lw.QiMojine = qichu;
                    }
                }
                Connect.DbHelper().Updateable<LwDetail>(lwlist).ExecuteCommand();
            }
          
        }
        public static void 修改(DanjuTable danju )
        {
            var l = LwDetailService.GetOneLwDetail(x => x.DH == danju.dh);
            LwDetail lwDetail = new LwDetail();
            switch (danju.djlx)
            {
                case DanjuLeiXing.外检直销单 :
                    lwDetail = LXRService.GetOneLXR(x => x.MC == danju.ksmc).LX == "客户" ? 销售单(danju) : 白坯直销单(danju);
                    break;
                case DanjuLeiXing.白坯直销单:
                    lwDetail = LXRService.GetOneLXR(x => x.MC == danju.ksmc).LX == "客户" ? 销售单(danju) : 白坯直销单(danju);
                    break;
                case DanjuLeiXing.销售出库单:
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.色卡采购单:
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.色卡销售单:
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.采购入库单:
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.销售退货单:
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.采购退货单:
                    lwDetail = 销售单(danju);
                    break;
                case DanjuLeiXing.委外取货单:
                    lwDetail = 采购单(danju);
                    break;
                case DanjuLeiXing.付款单:
                    lwDetail = 付款单(danju);
                    break;
                case DanjuLeiXing.收款单:
                    lwDetail = 收款单(danju);
                    break;
                case DanjuLeiXing.发票签收:
                    lwDetail = 发票签收(danju);
                    break;
                case DanjuLeiXing.发票开具:
                    lwDetail = 发票开具(danju);
                    break;
                case DanjuLeiXing.寄样单 :
                    lwDetail = 销售单(danju);
                    break;
            }
            lwDetail.QichuJine = l.QichuJine;
            LwDetailService.UpdateLwDetail(lwDetail, x => x.DH == danju.dh);
            刷新(danju);
        }
    }
}
