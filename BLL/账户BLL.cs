using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using 纺织贸易管理系统;

namespace BLL
{
    public class 账户BLL
    {
        #region "新增刷新"
        private static void 计算(DanjuTable danju, decimal remainmoney,SKFS sKFS )
        {
            switch (danju.djlx)
            {
                case DanjuLeiXing.付款单:
                    danju.RemainMoney = remainmoney - danju.je;
                    break;
                case DanjuLeiXing.收款单:
                    danju.RemainMoney = remainmoney + danju.je;
                    break;
                case DanjuLeiXing.费用单:
                    if (danju.yaoqiu == "收入")
                    {
                        danju.RemainMoney = remainmoney + danju.totalmoney;
                    }
                    else
                    {
                        danju.RemainMoney = remainmoney - danju.je;
                    }
                    break;
            }
            sKFS.Zhanghuyue = danju.RemainMoney;
            DanjuTableService.UpdateDanjuTable($"RemainMoney='{danju.RemainMoney }'", x => x.dh == danju.dh);
           
        }
        public static void 刷新剩余金额(DanjuTable danju)
        {
            string zhanghumingcheng =danju.ShoukuanFangshi ;
            var s = SKFSService.GetOneSKFS(x => x.Skfs == danju.ShoukuanFangshi);
            List<DanjuTable> danjulist = Connect.CreatConnect().Query<DanjuTable>($"select * from danjutable where rq>='{danju.rq}' and shoukuanfangshi='{danju.ShoukuanFangshi }' order by rq asc,id asc");
            decimal remainmoney = 0;
            int i = 0;
            foreach (var d in danjulist)
            {
                if (d.dh != danju.dh)
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            if (i < danjulist.Count - 1)
            {
                switch (danjulist[i+1].djlx)
                {
                    case DanjuLeiXing.付款单:
                        remainmoney = danjulist[i + 1].RemainMoney + danjulist[i + 1].je;
                        break;
                    case DanjuLeiXing.收款单:
                        remainmoney = danjulist[i + 1].RemainMoney - danjulist[i + 1].je;
                        break;
                    case DanjuLeiXing.费用单:
                        if (danjulist[0].yaoqiu == "收入")
                        {
                            remainmoney = danjulist[i + 1].RemainMoney - danjulist[i + 1].totalmoney;
                        }
                        else
                        {
                            remainmoney = danjulist[i + 1].RemainMoney + danjulist[i + 1].je;
                        }
                        break;
                }
                计算(danju, remainmoney,s);
                remainmoney = danju.RemainMoney;
                for (var index = i + 1; index < danjulist.Count; index++)
                {
                    switch (danjulist[index].djlx)
                    {
                        case DanjuLeiXing.付款单:
                            remainmoney -= danjulist[index].je;
                            break;
                        case DanjuLeiXing.收款单:
                            remainmoney += danjulist[index].je;
                            break;
                        case DanjuLeiXing.费用单:
                            if (danjulist[index].yaoqiu == "收入")
                            {
                                remainmoney += danjulist[index].totalmoney;
                            }
                            else
                            {
                                remainmoney -= danjulist[index].je;
                            }
                            break;
                    }
                    danjulist[index].RemainMoney = remainmoney;
                    DanjuTableService.UpdateDanjuTableList(danjulist );
                    SKFSService.UpdateSKFS(s, x => x.BH == s.BH);
                }
            }
            else
            {
                remainmoney =s .Zhanghuyue;
                switch (danju.djlx)
                {
                    case DanjuLeiXing.付款单:
                        remainmoney += danju.je;
                        break;
                    case DanjuLeiXing.收款单:
                        remainmoney -= danju.je;
                        break;
                    case DanjuLeiXing.费用单:
                        if (danju.yaoqiu == "收入")
                        {
                            remainmoney -= danju.totalmoney;
                        }
                        else
                        {
                            remainmoney += danju.je;
                        }
                        break;
                }
                计算(danju, remainmoney,s);
                SKFSService.UpdateSKFS(s, x => x.BH == s.BH);
            }
        }
        #endregion
        #region "删除刷新"
        public static void 删除刷新(DanjuTable danju)
        {
            var danjulist = Connect.CreatConnect().Query<DanjuTable>($"select top 1 * from danjutable where id<'{danju.id}' and shoukuanfangshi='{danju.ShoukuanFangshi }' and rq<='{danju.rq }'order by id desc");
            if (danjulist.Count > 0)
            {
                修改刷新(danjulist[0]);
            }
            
        }
        #endregion
        #region "修改刷新"
        public static async  void 修改刷新(DanjuTable danju)
        { 
           await  Task.Run (() => { 
            var danjulist = Connect.CreatConnect().Query<DanjuTable>($"select * from danjutable where rq>='{danju.rq }' and shoukuanfangshi='{danju.ShoukuanFangshi }' order by rq asc,id asc");
            var danhao = danju.dh;
            string zhanghumingcheng = danju.ShoukuanFangshi;
            var s = SKFSService.GetOneSKFS(x => x.Skfs == danju.ShoukuanFangshi);

               {
                   decimal remainmoney = 0;
                   int i = 0;
                   foreach (var d in danjulist)
                   {
                       if (d.dh != danhao)
                       {
                           i++;
                       }
                       else
                       {
                           break;
                       }
                   }
                   switch (danjulist[i].djlx)
                   {
                       case DanjuLeiXing.付款单:
                           remainmoney = danjulist[i].RemainMoney + danjulist[i].je;
                           break;
                       case DanjuLeiXing.收款单:
                           remainmoney = danjulist[i].RemainMoney - danjulist[i].je;
                           break;
                       case DanjuLeiXing.费用单:
                           if (danjulist[i].yaoqiu == "收入")
                           {
                               remainmoney = danjulist[i].RemainMoney - danjulist[i].totalmoney;
                           }
                           else
                           {
                               remainmoney = danjulist[i].RemainMoney + danjulist[i].je;
                           }
                           break;
                   }
                   计算(danju, remainmoney, s);
                   remainmoney = danju.RemainMoney;
                   for (int row = i + 1; row < danjulist.Count; row++)
                   {
                       switch (danjulist[row].djlx)
                       {
                           case DanjuLeiXing.付款单:
                               danjulist[row].RemainMoney = remainmoney - danjulist[row].je;
                               break;
                           case DanjuLeiXing.收款单:
                               danjulist[row].RemainMoney = remainmoney + danjulist[row].je;
                               break;
                           case DanjuLeiXing.费用单:
                               if (danjulist[row].yaoqiu == "收入")
                               {
                                   danjulist[row].RemainMoney = remainmoney + danjulist[row].totalmoney; ;
                               }
                               else
                               {
                                   danjulist[row].RemainMoney = remainmoney - danjulist[row].je;
                               }
                               break;
                       }
                       s.Zhanghuyue = danjulist[row].RemainMoney;
                   }
               }
            DanjuTableService.UpdateDanjuTableList(danjulist); 
           Connect.CreatConnect().Update<SKFS>($"Zhanghuyue='{s.Zhanghuyue }'", x => x.BH == s.BH); 
           }); 
        }
        #endregion 
    }
}
