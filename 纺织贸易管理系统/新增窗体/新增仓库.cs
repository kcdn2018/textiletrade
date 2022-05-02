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
    public partial class 新增仓库 : Sunny.UI.UIForm
    {
        public StockInfoTable infoTable =new StockInfoTable ();
        public int Useful=FormUseful.新增 ;
        public 新增仓库()
        {
            InitializeComponent();
            
        }
        private void InitText()
        {
          
                foreach (Control  c in this.Controls )
                {
                    if(c is DevComponents.DotNetBar.Controls .TextBoxX )
                    {
                        c.Text = "";
                    }
                }    
                txtBianhao.Text    = BianhaoBLL.CreatStockBianhao ("CK");                                        
        }

        private void 新增品种_Load(object sender, EventArgs e)
        {
            if (Useful == FormUseful.新增)
            {
                InitText();
            }
            else
            {
                EditText();
            }        
            cmbleixing.Items.AddRange(new string[] { "成品仓库", "次品仓库", "半成品仓库", "原料仓库", "五金仓库", "样布库" });
            cmbleixing.SelectedIndex = 0;
        }
        private void EditText()
        {
            txtBianhao.Text =infoTable.bianhao ;        
            txtdizhi.Text = infoTable.address ;
            txtlianxidianhua.Text = infoTable.telNum ;
            txtlianxiren.Text = infoTable.guanliyuan ;           
            txtpingming.Text = infoTable.mingcheng  ;
            cmbleixing.Text = infoTable.Leixing;
        }
        private void InitPingzhong()
        {
            infoTable.bianhao  = txtBianhao.Text;
            infoTable.address  = txtdizhi.Text;
            infoTable.telNum  = txtlianxidianhua.Text;
            infoTable.guanliyuan   = txtlianxiren.Text;
            infoTable.mingcheng   = txtpingming.Text;
            infoTable.Leixing = cmbleixing.Text;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpingming.Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请输入仓库名称！仓库名称不能为空");
                return;
            }
           
            if (cmbleixing.Text =="")
            {
                MessageBox.Show("请填写仓库类型", "提醒",MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }
            InitPingzhong();
            if (Useful == FormUseful.新增)
            {
                if (!string.IsNullOrWhiteSpace(StockInfoTableService.GetOneStockInfoTable(x => x.mingcheng == txtpingming.Text).mingcheng))
                {
                    Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "该仓库名称已经存在！保存失败");
                    return;
                }
                StockInfoTableService.InsertStockInfoTable(infoTable);

            }
            else
            {
                StockInfoTableService.UpdateStockInfoTable  (infoTable , x=>x.bianhao  ==infoTable .bianhao  );
              
            }
            infoTable  = new StockInfoTable ();
            Useful = FormUseful.新增;
            InitText();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
