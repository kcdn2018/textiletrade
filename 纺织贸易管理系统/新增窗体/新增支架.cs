using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 纺织贸易管理系统.设置窗体;
using 纺织贸易管理系统.选择窗体;

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 新增支架 : Sunny.UI.UIForm
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public ZhijiaTable zhijiaTable  { get; set; } = new ZhijiaTable();
        public int Useful=FormUseful.新增 ;
        private string zhijiahao ="";
        public 新增支架()
        {
            InitializeComponent();
           
        }
        private void InitText()
        {

            foreach (Control c in this.Controls)
            {
                if (c is DevComponents.DotNetBar.Controls.TextBoxX)
                {
                    c.Text = "";
                }
            }
            txtBianhao.Text = "";
            cmbleixing.Text = zhijiaTable.StockName;
            txtckbh.Text = zhijiaTable.StockIndex;
            txtweizhi.Text = "";
        }

        private void 新增品种_Load(object sender, EventArgs e)
        {
             zhijiahao = zhijiaTable.Zhijiahao;
            if (Useful == FormUseful.新增)
            {
                InitText();
            }
            else
            {
                EditText();
            }

        }
        private void EditText()
        {
            txtBianhao.Text = zhijiaTable.Zhijiahao  ;                     
            txtckbh.Text = zhijiaTable.StockIndex   ;
            cmbleixing.Text = zhijiaTable.StockName ;
            txtweizhi.Text = zhijiaTable.Weizhi;
        }
        private void InitPingzhong()
        {
            zhijiaTable.StockIndex   = txtckbh.Text;
            zhijiaTable.Zhijiahao = txtBianhao.Text;
            zhijiaTable.StockName  = cmbleixing.Text;
            zhijiaTable.Weizhi = txtweizhi.Text ;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cmbleixing.Text =="")
            {
                MessageBox.Show("请填写仓库类型", "提醒",MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }
            InitPingzhong();
            if (Useful == FormUseful.新增)
            {
                ZhijiaTableService .InsertZhijiaTable  (zhijiaTable);             
            }
            else
            {
                zhijiaTable.Zhijiahao = txtBianhao.Text;
                ZhijiaTableService .UpdateZhijiaTable   (zhijiaTable, x=>x.StockName  == zhijiaTable.StockName &&x.StockIndex== zhijiaTable.StockIndex &&x.Zhijiahao ==zhijiahao   );             
            }
            zhijiaTable = new ZhijiaTable ();
            Useful = FormUseful.新增;
            InitText();
        } 
    }
}
