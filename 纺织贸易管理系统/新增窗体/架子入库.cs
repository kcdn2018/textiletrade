using DAL;
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
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 架子入库 : Sunny.UI.UIForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public 架子入库()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
        }

        private void 确认出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace ( txtkehu.Text))
            {
                Sunny.UI.UIMessageBox.ShowError("请选择客户。\r\n客户不能为空");
                return;
            }
            foreach (string  j in uiTransfer1.ItemsRight)
            {
                string[] jiazi = j.Split('-');
                JiaziTableService.UpdateJiaziTable($"State='自己公司'", X => X.JiaziID == jiazi[0] && X.Guisuo == jiazi[1]);
                ZhijiaMingxiTableService.InsertZhijiaMingxiTable(new ZhijiaMingxiTable() {  Danhao ="RK"+DateTime.Now .ToString (), Bianhao =JiaziTableService.GetOneJiaziTable (X => X.JiaziID == jiazi[0] && X.Guisuo == jiazi[1]).ID.ToString (), _date =uiDatePicker1.Value , Remarker =txtbeizhu.Text, Leixing = "入库",
                Kehu=txtkehu.Text });
            }            
            txtbeizhu.Text = "";
            txtkehu.Text = "";
            导入在库的子架号();
        }
        private void 导入在库的子架号()
        {
            uiTransfer1.ItemsLeft.Clear();
            uiTransfer1.ItemsRight.Clear();
            foreach (var n in JiaziTableService.GetJiaziTablelst(x => x.State == txtkehu.Text))
            {
                uiTransfer1.ItemsLeft.Add(n.JiaziID +"-"+n.Guisuo );
            }
        }

        private void txtkehu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fm = new 客户选择();
            fm.ShowDialog();
            txtkehu.Text = fm.linkman.MC;
            导入在库的子架号();
        }
    }
}
