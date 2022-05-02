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
    public partial class 新增物流 : Sunny.UI.UIForm
    {
        public WuliuTable  infoTable =new WuliuTable  ();
        public int Useful=FormUseful.新增 ;
        public 新增物流()
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
                txtBianhao.Text    = BianhaoBLL.CreatWuliuBianhao();                                        
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

        }
        private void EditText()
        {
            txtBianhao.Text =infoTable.Bianhao  ;                   
            txtcheliangleixing.Text = infoTable.CarLeixing  ;
            txtchepai.Text = infoTable.CarNum ;           
            txtname.Text = infoTable.name   ;
           
        }
        private void InitPingzhong()
        {
            infoTable.Bianhao   = txtBianhao.Text;
            infoTable.CarLeixing   = txtcheliangleixing.Text;
            infoTable.CarNum    = txtchepai.Text;
            infoTable.name    = txtname.Text;
            
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname .Text))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "请输入物流名称！物流名称不能为空");
                return;
            }
           
            InitPingzhong();
            if (Useful == FormUseful.新增)
            { 
                if (!string.IsNullOrWhiteSpace(WuliuTableService .GetOneWuliuTable(x => x.name  == txtname .Text).name ))
            {
                Sunny.UI.UIMessageDialog.ShowErrorDialog(this, "该物流信息已经存在！保存失败");
                return;
            }
                WuliuTableService .InsertWuliuTable  (infoTable );
               
            }
            else
            {
                WuliuTableService.UpdateWuliuTable  (infoTable , x=>x.Bianhao ==infoTable .Bianhao   );
              
            }
            infoTable  = new WuliuTable  ();
            Useful = FormUseful.新增;
            InitText();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
