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
using 纺织贸易管理系统;
using Tools;
using 纺织贸易管理系统.新增窗体;
using 纺织贸易管理系统.其他窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 流程卡查询 : Form
    {
        private List<Liuzhuancard> liuzhuancards = new List<Liuzhuancard> ();
        public 流程卡查询()
        {
            InitializeComponent();
            uiDatePicker2.Value = DateTime.Now;
            uiDatePicker1.Value = uiDatePicker2.Value.AddDays(-QueryTime.间隔);
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 流转卡() { Useful=FormUseful.新增 }) ;
        }

        private void 流程卡查询_Load(object sender, EventArgs e)
        {
            query();
        }
        private void query()
        {
            //liuzhuancards =LiuzhuancardService.GetLiuzhuancardlst (x=>x.Card_Date >=uiDatePicker1.Value.Date &&x.Card_Date <=uiDatePicker2.Value.Date &&
            //x.Customer.Contains (txtkehu.Text )&&x.Color .Contains (txtyanse.Text )&&x.Pingming.Contains (txtpingming.Text ));
            liuzhuancards = LiuzhuancardService.GetLiuzhuancardlst($"Select liuzhuancard.* from liuzhuancard,danjumingxitable where liuzhuancard.card_date between '{uiDatePicker1.Value.Date}' " +
                $" and '{uiDatePicker2.Value }' and liuzhuancard.Customer like '%{txtkehu.Text }%' and danjumingxitable.yanse like '%{txtyanse.Text }%' and danjumingxitable.pingming like '%{txtpingming.Text }%'" +
                $" and danjumingxitable.ganghao like '%{txtganghao.Text }%' and danjumingxitable.danhao=liuzhuancard.CardNum  order by liuzhuancard.id desc");
            var res = new List<Liuzhuancard>();
            foreach(string c in liuzhuancards.Select (x=>x.CardNum ).Distinct ().ToList ())
            {
                res.Add ( liuzhuancards.First(x => x.CardNum == c));
            }
                uiDataGridView1.DataSource =res ;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query();
        }

        private void txtkehu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Enter )
            {
                query();
            }
        }

        private void uiDatePicker1_ValueChanged(object sender, DateTime value)
        {
            query();
        }

        private void uiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                string cardnum = uiDataGridView1.Rows[e.RowIndex].Cells[cardNumDataGridViewTextBoxColumn.Name].Value.ToString();
                uiDataGridView2.DataSource = liuzhuanmingxiService.Getliuzhuanmingxilst(x => x.CardNum == cardnum);
                uiDataGridView3.DataSource = liuzhuanlogService.Getliuzhuanloglst(x => x.CardNum == cardnum);
                uiDataGridView4.DataSource = danjumingxitableService.Getdanjumingxitablelst(x => x.danhao == cardnum);
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cardnum = uiDataGridView1.Rows[uiDataGridView1.CurrentRow.Index ].Cells[cardNumDataGridViewTextBoxColumn.Name].Value.ToString();
            MainForm.mainform.AddMidForm(new 流转卡() { Useful = FormUseful.修改, liuzhuancard =LiuzhuancardService.GetOneLiuzhuancard  (x=>x.CardNum ==cardnum) });
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var liuzhuankahao = uiDataGridView1.CurrentRow.Cells[cardNumDataGridViewTextBoxColumn.Name].Value.ToString();
            if(liuzhuanlogService .Getliuzhuanloglst  (x=>x.CardNum==liuzhuankahao ).Count >0)
            {
                Sunny.UI.UIMessageBox.ShowError("该流转卡号" + liuzhuankahao + "已经存在操作日志！删除失败");
                return;
            }
            if(Sunny.UI.UIMessageBox.ShowAsk ($"您确定要删除{liuzhuankahao }该流转单吗?")==true )
            {
                try
                {
                    var id = uiDataGridView1.CurrentRow.Cells[CID.Name].Value.TryToInt ();
                    LiuzhuancardService.DeleteLiuzhuancard (x => x.ID == id);
                    liuzhuanmingxiService .Deleteliuzhuanmingxi (x => x.CardNum == liuzhuankahao);
                    liuzhuanlogService.Deleteliuzhuanlog (x => x.CardNum == liuzhuankahao);
                    danjumingxitableService.Deletedanjumingxitable(x => x.danhao == liuzhuankahao);
                    AlterDlg.Show("删除成功");
                    query();
                }
                catch(Exception ex)
                {
                    Sunny.UI.UIMessageBox.ShowError ("删除失败！原因是：" + ex.Message);
                }              
            }
        }

        private void uiDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            修改ToolStripMenuItem_Click(null, null);
        }

        private void 流转登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 流转登记 () { Useful = FormUseful .新增,Liuzhuankahao=string.Empty };
            fm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Sunny.UI.UIMessageDialog.ShowAskDialog(this, "您确定要删除该流转工序吗？"))
            {
                if (uiDataGridView3.CurrentRow != null)
                {
                    liuzhuanlogService.Deleteliuzhuanlog(x => x.ID == (int)uiDataGridView3.Rows[uiDataGridView3.CurrentRow.Index].Cells[ID.Name].Value);
                }
                else
                {
                    AlterDlg.Show("没有任何记录被选中！");
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (uiDataGridView3.CurrentRow != null)
            {
                var fm = new 流转登记() { Useful = FormUseful.修改, ID = (int)uiDataGridView3.Rows[uiDataGridView3.CurrentRow.Index].Cells[ID.Name].Value };
                fm.ShowDialog();
            }
            else
            {
                AlterDlg.Show("没有任何记录被选中！");
            }
        }

    }
}
