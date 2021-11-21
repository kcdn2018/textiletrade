using BLL;
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
using 纺织贸易管理系统;
using 纺织贸易管理系统.设置窗体;

namespace 纺织贸易管理系统.报表窗体
{
    public partial class 生产退卷查询 : Form
    {

        public 生产退卷查询()
        {
            InitializeComponent();
            uiDatePicker2.Value = DateTime.Now;
            uiDatePicker1.Value = uiDatePicker2.Value.AddDays(-QueryTime.间隔);
            CreateGrid.Create(this.Name, gridView1);
            query();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.mainform.AddMidForm(new 来货退卷单 () { Useful =FormUseful.新增 }) ;
        }
        private void query()
        {
            CreateGrid.Query(gridControl1, $"select danjutable.*,danjumingxitable.* from danjutable,danjumingxitable where danjutable.rq between '{ uiDatePicker1.Value.Date }' and '{uiDatePicker2.Value.Date }' and danjutable.ksmc like '%{txtkehu.Text}%' " +
                    $"and danjumingxitable.pingming like '%{txtpingming.Text }%' " +
                    $"and danjumingxitable.ganghao like '%{txtganghao .Text }%' " +
                    $"and danjumingxitable.ColorNum like '%{txtyanse.Text }%' " +
                    $"and danjutable.djlx='{DanjuLeiXing.退卷单  }' " +
                    $"and danjutable.dh=danjumingxitable.danhao order by danjutable.id desc");
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query();
        }

        private void 来货入库_Load(object sender, EventArgs e)
        {
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var danhao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString ();
                MainForm.mainform.AddMidForm(new 来货退卷单() { Useful = FormUseful.修改, danju = Connect.CreatConnect().Query<DanjuTable>().First(x => x.dh == danhao) });
                query();
            }
            else
            {
                Sunny.UI.UIMessageBox.ShowError("没有任何内容被选中!");
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var danao = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "dh").ToString();
            if (Sunny.UI.UIMessageBox.ShowAsk($"您确定要删除{danao  }该来货登记单吗?") == true)
            {
                try
                {
                    来货退卷单BLL.Delete(danao );
                    Sunny.UI.UIMessageBox.ShowSuccess("删除成功!");
                    query();
                }
                catch (Exception ex)
                {
                    Sunny.UI.UIMessageBox.ShowError("删除失败！原因是：" + ex.Message);
                }
            }
        }

        private void 导出到EXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile.导出到文件(gridControl1, "生产入库清单");
        }

        private void 配置列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fm = new 配置列(gridView1) { formname = this.Name, Obj = null, dt = gridControl1.DataSource as DataTable };
            fm.ShowDialog();
        }

        private void 保存样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid.SaveGridview(this.Name, gridView1);
        }
    }
}
