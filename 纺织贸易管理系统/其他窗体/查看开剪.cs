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

namespace 纺织贸易管理系统.其他窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 查看开剪 : Sunny.UI.UIForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public int stockid { get; set; }
        List<KaijianTable> kaijians = new List<KaijianTable>();
        public 查看开剪()
        {
            InitializeComponent();
           
        }

        private void 查看开剪_Load(object sender, EventArgs e)
        {
            uiDataGridView1.AutoGenerateColumns = false;
            kaijians = KaijianTableService.GetKaijianTablelst(x => x.state == stockid);
            uiDataGridView1.DataSource = kaijians;
            uiDataGridViewFooter1.Clear();
            uiDataGridViewFooter1["biaoqianMishuDataGridViewTextBoxColumn"] = kaijians.Sum(x => x.MiShu).ToString();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if(Sunny.UI.UIMessageBox.ShowAsk ("您确定要删除改开剪信息吗？"))
            {
                StockTableService.UpdateStockTable($"kaijianmishu=kaijianmishu-{uiDataGridView1.Rows[uiDataGridView1.CurrentRow.Index].Cells[biaoqianMishuDataGridViewTextBoxColumn.Name].Value.TryToDecmial()}", x => x.ID == stockid);
                KaijianTableService.DeleteKaijianTable(x=>x.ID==kaijians[uiDataGridView1.CurrentRow.Index].ID );
                uiDataGridView1.AutoGenerateColumns = false;
                kaijians = KaijianTableService.GetKaijianTablelst(x => x.state == stockid);
                uiDataGridView1.DataSource = kaijians;
                uiDataGridViewFooter1.Clear();
                uiDataGridViewFooter1["biaoqianMishuDataGridViewTextBoxColumn"] = kaijians.Sum(x => x.MiShu).ToString();
            }
        }
    }
}
