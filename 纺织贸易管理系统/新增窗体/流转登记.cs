using Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    public partial class 流转登记 : Sunny.UI.UIForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIForm”(是否缺少程序集引用?)
    {
        public string Liuzhuankahao { get; set; }
        public int Useful { get; set; }
        /// <summary>
        /// 日志ID
        /// </summary>
        public int ID { get; set; }
        private List<liuzhuanmingxi> danjumingxis;
        public 流转登记()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
            cmbjigong.DataSource = YuanGongTableService.GetYuanGongTablelst ().Select(x => x.Xingming).Distinct().ToList();
            cmbjitaihao.DataSource = MachineTableService.GetMachineTablelst ().Select(x => x.MachineID).ToList();
        }

        private void 流转登记_Load(object sender, EventArgs e)
        {
            if (Useful == FormUseful.新增)
            {
                try
                {
                    txtliuzhuankaNum.Text = Liuzhuankahao;
                    danjumingxis = liuzhuanmingxiService .Getliuzhuanmingxilst (x => x.CardNum == Liuzhuankahao && x.Employee != string.Empty);
                    cmbgongxv.Text = danjumingxis.Select(x => x.GongyiYaoqiu).ToList().First();
                    txtdanjunum.Text = LiuzhuancardService .GetOneLiuzhuancard (x => x.CardNum == Liuzhuankahao).Shuliang.ToString();
                    txtNum.Text = txtdanjunum.Text;
                }
                catch
                {
                    Sunny.UI.UIMessageBox.ShowError("没有找到相关信息！");
                }
            }
            else
            {
                if(Useful==FormUseful.修改 )
                {
                    var liuzhuanka = liuzhuanlogService.GetOneliuzhuanlog(x => x.ID == ID);
                    txtbeizhu.Text = liuzhuanka.Beizhu;
                    txtdanjunum.Text = LiuzhuancardService.GetOneLiuzhuancard(x => x.CardNum == liuzhuanka.CardNum).Shuliang.ToString() ;
                    cmbjitaihao .Text = liuzhuanka.MachineID ;
                    cmbjigong.Text = liuzhuanka.Employee;
                    cmbgongxv.Text = liuzhuanka.GongyiYaoqiu;
                    cmbcishu.Text = liuzhuanka.Cishu.ToString ();
                    uiDatePicker1.Value = liuzhuanka._date;
                    txtNum.Text = liuzhuanka.Num.ToString();
                    txtliuzhuankaNum.Text =liuzhuanka.CardNum ;
                }
            }
        }

        private void cmbjigong_TextChanged(object sender, EventArgs e)
        {
            if (danjumingxis != null)
            {
                cmbgongxv.DataSource = danjumingxis.Where(x => x.Employee == cmbjigong.Text).ToList();
                cmbgongxv.DisplayMember = "GongyiYaoqiu";
            }
        }

        private void cmbgongxv_TextChanged(object sender, EventArgs e)
        {
            if (danjumingxis != null)
            {
                if (danjumingxis.Where(x => x.GongyiYaoqiu == cmbgongxv.Text).ToList().Count > 0)
                {
                    var d = danjumingxis.First(x => x.GongyiYaoqiu == cmbgongxv.Text);
                    cmbcishu.Text = d.Cishu.ToString();
                    cmbjigong.Text = d.Employee;
                    cmbjitaihao.Text = d.MachineID;
                }
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            var liuzhuanlog = new liuzhuanlog()
            {
                Cishu = cmbcishu.Text.ToDecimal(),
                GongyiYaoqiu = cmbgongxv.Text,
                Beizhu = txtbeizhu.Text,
                CardNum = txtliuzhuankaNum.Text,
                Employee = cmbjigong.Text,
                MachineID = cmbjitaihao.Text,
                Num = txtNum.Text.ToDecimal (),
                _date = uiDatePicker1.Value.Date
            };
            if (Useful == FormUseful .新增)
            {
               liuzhuanlogService .Insertliuzhuanlog (liuzhuanlog);
            }
            else
            {
                liuzhuanlogService .Updateliuzhuanlog (liuzhuanlog,x=>x.ID==ID);
            }
            this.Close();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtliuzhuankaNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                danjumingxis = liuzhuanmingxiService.Getliuzhuanmingxilst(x => x.CardNum == txtliuzhuankaNum.Text  && x.Employee != string.Empty);
                cmbgongxv.Text = danjumingxis.Select(x => x.GongyiYaoqiu).ToList().First();
                var liuzhuanka = LiuzhuancardService.GetOneLiuzhuancard(x => x.CardNum == txtliuzhuankaNum.Text );
                txtNum.Text = txtdanjunum.Text = liuzhuanka.Shuliang.ToString();
            }
        }
    }
}
