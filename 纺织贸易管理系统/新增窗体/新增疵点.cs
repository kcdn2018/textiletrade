using BLL;
using Model;
using Sunny.UI;
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
    public partial class 新增疵点 : Sunny.UI.UIForm
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public CiDianNameTable  infoTable =new CiDianNameTable  ();
        public int Useful=FormUseful.新增 ;
        private string cidianname = "";
        public 新增疵点()
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
            cidianname = infoTable.CiDianName;
            txtkoufeng.Text = infoTable.KouFen.ToString () ;
            txtKoumi.Text = infoTable.KouMi.ToString () ;           
            txtpingming.Text = infoTable.CiDianName   ;
            cmbWenti .Text = infoTable.Guisuo ;
        }
        private void InitPingzhong()
        {
         
            infoTable.CiDianName  = txtpingming .Text;
            infoTable.KouMi    = txtKoumi.Text.ToDecimal(0);
            infoTable.KouFen    = txtkoufeng .Text.ToInt ();
            infoTable.Guisuo  = cmbWenti .Text;
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cmbWenti .Text =="")
            {
                MessageBox.Show("请填写疵点问题归属", "提醒",MessageBoxButtons.OK , MessageBoxIcon.Information);
                return;
            }
            InitPingzhong();
            if (Useful == FormUseful.新增)
            {
              if(  CiDianNameTableService.CheckName (infoTable )==false )
                {
                    MessageBox.Show("改疵点名称已经存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CiDianNameTableService.InsertCiDianNameTable(infoTable);
                }

            }
            else
            {              
                 CiDianNameTableService.UpdateCiDianNameTable  (infoTable , x=>x.CiDianName == cidianname );  
            }
            infoTable  = new CiDianNameTable ();
            Useful = FormUseful.新增;
            InitText();
        } 
    }
}
