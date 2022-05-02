using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using 纺织贸易管理系统.自定义类;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 应付款汇总 : Form
    {
        public 应付款汇总()
        {
            InitializeComponent();
            dateEdit2.DateTime = DateTime.Now;
            dateEdit1.DateTime = dateEdit2.DateTime.AddDays(-QueryTime.间隔);
        }
        private void Query()
        {
            var lxrllist = LXRService.GetLXRlst(x=>x.MC.Contains (txtkehu.Text)&&x.LX=="供货商");
            dataGridViewX1.Rows.Add(lxrllist.Count );
            int row = 0;
            decimal bencixiaoshou=0, benciyingshoukuan=0, bencitiaochong=0, benqixvkaipiao=0, benqiyikaipiaoe=0, benqiqianpiao=0, qianpiao=0, yikiaopaiaoweifukuan=0, yuqijine=0,shangqiyue=0,benciyue=0,zongyue=0,bencixiaoshoue=0;
            foreach (var l in lxrllist )
            {
                var drow = dataGridViewX1.Rows[row];
                drow .Cells [ckehu.Name ].Value =l.MC ;
                drow.Cells[Czhangqi.Name].Value = l.ZhangQi;
                drow.Cells[Czongyue.Name].Value = l.JE;
                //累加总余额
                zongyue += l.JE;
                //
                var lw = LwDetailService.GetLwDetaillst(x => x.rq >= dateEdit1.DateTime.Date && x.rq <= dateEdit2.DateTime.Date && x.KHMC == l.MC);
                if (lw.Count > 0)
                {
                    drow.Cells[Cshangqiyue.Name].Value = lw[0].QichuJine;
                    //累加总上期余额
                    shangqiyue += lw[0].QichuJine;
                    ///
                    ///累加总本次余额
                    drow.Cells[Cbenciyue.Name].Value = lw[lw.Count - 1].QiMojine;
                    benciyue += lw[lw.Count - 1].QiMojine;
                }
                var danjumx = DanjuTableService.GetDanjuTablelst(x => x.rq >= dateEdit1.DateTime.Date && x.rq <= dateEdit2.DateTime.Date && x.ksmc == l.MC );
                drow.Cells[Cbencixiaoshoue.Name].Value = danjumx.Where (x=>x.djlx==DanjuLeiXing.采购入库单 ||x.djlx==DanjuLeiXing.色卡采购单 ||x.djlx ==DanjuLeiXing.委外取货单  ).Sum(x => x.je);
                //累加本次销售额
                bencixiaoshoue  += Convert.ToDecimal(drow.Cells[Cbencixiaoshoue.Name].Value);
                ////
                drow.Cells[Cbencixiaoshoushu.Name].Value = danjumx.Where(x => x.djlx == DanjuLeiXing.采购入库单 || x.djlx == DanjuLeiXing.色卡采购单 || x.djlx == DanjuLeiXing.委外取货单).Sum(x => x.TotalMishu);
                ///累计本次销售数
                bencixiaoshou += Convert.ToDecimal(drow.Cells[Cbencixiaoshoushu.Name].Value);
                //
                drow.Cells [Cbenciyingshoukuan .Name ].Value = danjumx.Where(x => x.djlx == DanjuLeiXing.采购入库单 || x.djlx == DanjuLeiXing.色卡采购单 || x.djlx == DanjuLeiXing.委外取货单).Sum(x => x.je);
                //累计本次应收款
                benciyingshoukuan += Convert.ToDecimal(drow.Cells[Cbenciyingshoukuan.Name].Value);
                //
                drow.Cells[Cbencitiaochong.Name ].Value = danjumx.Where(x => x.djlx == DanjuLeiXing.付款单).Sum(x => x.totalmoney );
                //累计本次调充数
                bencitiaochong += Convert.ToDecimal(drow.Cells[Cbencitiaochong .Name].Value);
                ///
                drow.Cells[Cbenqixvkaipiaoe .Name].Value = danjumx.Where(x => x.djlx == DanjuLeiXing.采购入库单 || x.djlx == DanjuLeiXing.色卡采购单 || x.djlx == DanjuLeiXing.委外取货单).Where (x =>x.Hanshui=="含税" ).Sum(x => x.je);
               ///累计本次需开票额
               benqixvkaipiao += Convert.ToDecimal(drow.Cells[Cbenqixvkaipiaoe .Name].Value);
                ////
                drow.Cells[Cbenqiyikaipiaoe .Name ].Value = danjumx.Where(x => x.djlx==DanjuLeiXing.发票签收  ).Sum(x => x.je);
                ///累计本期已开票额
                benqiyikaipiaoe += Convert.ToDecimal(drow.Cells[Cbenqiyikaipiaoe .Name].Value); 
                ////
                
                drow.Cells[Cbenqiqianpiao .Name ].Value = drow.Cells[Cbenqixvkaipiaoe.Name].Value.TryToDecmial(0) - drow.Cells[Cbenqiyikaipiaoe.Name].Value.TryToDecmial(0);
                ///累计本期欠票
                benqiqianpiao += Convert.ToDecimal(drow.Cells[Cbenqiqianpiao .Name].Value);
                ///
                drow.Cells[Cqianpiaoe.Name].Value = l.YingKaifapiao ;
                ///累计欠票额
                qianpiao+= Convert.ToDecimal(drow.Cells[Cqianpiaoe .Name].Value);
                ////
                var remainlist = RemainMoneyTableService.GetRemainMoneyTablelst(x => x.Rq >= dateEdit1.DateTime.Date && x.Rq <= dateEdit2.DateTime.Date && x.SupplierName == l.MC && x.ShengYuMoney != 0);
                drow.Cells[Cyikaipiaoweifukuan.Name].Value  =remainlist.Where (x=>x.MachineType ==DanjuLeiXing.发票签收  ).Sum (x=>x.ShengYuMoney );
                ////累计已开票未付款
                yikiaopaiaoweifukuan+= Convert.ToDecimal(drow.Cells[Cyikaipiaoweifukuan .Name].Value);
                ////
                var lxr = LXRService.GetOneLXR(y => y.MC == l.MC);
                drow.Cells[Cyuqijine.Name].Value = RemainMoneyTableService.GetRemainMoneyTablelst (x=>x.MachineType ==DanjuLeiXing.发票签收 &&x.ShengYuMoney>0&&x.Rq <=DateTime.Now.AddDays(-lxr.ZhangQi )).Sum(x=>x.ShengYuMoney );
               /////累计逾期款
               yuqijine+= Convert.ToDecimal(drow.Cells[Cyuqijine .Name].Value);
                row++;
            }
            dataGridViewX1.Rows.Add();
            var rowcount = dataGridViewX1.Rows.Count - 1;
            dataGridViewX1.Rows[rowcount].Cells[Czongyue.Name].Value = zongyue;
            dataGridViewX1.Rows[rowcount].Cells[Cshangqiyue.Name].Value = shangqiyue ;
            dataGridViewX1.Rows[rowcount].Cells[Cbenciyue .Name].Value = benciyue ;
            dataGridViewX1.Rows[rowcount].Cells[Cbencixiaoshoue.Name].Value = bencixiaoshoue ;
            dataGridViewX1.Rows[rowcount].Cells[Cbencixiaoshoushu .Name].Value = bencixiaoshou ;
            dataGridViewX1.Rows[rowcount].Cells[Cbenciyingshoukuan .Name].Value = benciyingshoukuan ;
            dataGridViewX1.Rows[rowcount].Cells[Cbencitiaochong .Name].Value = bencitiaochong ;
            dataGridViewX1.Rows[rowcount].Cells[Cbenqixvkaipiaoe .Name].Value = benqixvkaipiao ;
            dataGridViewX1.Rows[rowcount].Cells[Cbenqiyikaipiaoe .Name].Value = benqiyikaipiaoe ;
            dataGridViewX1.Rows[rowcount].Cells[Cbenqiqianpiao .Name].Value = benqiqianpiao ;
            dataGridViewX1.Rows[rowcount].Cells[Cqianpiaoe .Name].Value = qianpiao ;
            dataGridViewX1.Rows[rowcount].Cells[Cyikaipiaoweifukuan .Name].Value = yikiaopaiaoweifukuan ;
            dataGridViewX1.Rows[rowcount].Cells[Cyuqijine .Name].Value = yuqijine ;
        }

        private void 应收款汇总_Load(object sender, EventArgs e)
        {
            Query();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelService.ExportExcels("应付款汇总", dataGridViewX1);
        }
    }
}
