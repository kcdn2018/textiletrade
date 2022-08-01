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
    public partial class 新增价格 : Sunny.UI.UIForm
    {
        /// <summary>
        /// 新增还是修改
        /// </summary>
        public int Useful { get; set; }
        public string Bianhao { get; set; }
        public int ID { get; set; }
        public 新增价格()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var price = new PriceTable()
            {
                beizhu = txtbeizhu.Text,
                bianhao = Bianhao,
                jiage = txtweishuidanjia.Text.ToDecimal(),
                hanshui = txthanshuidanjia.Text.ToDecimal (),
                shuliang = txtqidingliang.Text.ToDecimal(),
                kehubianhao = txtpibubianhao.Text,
                kehumingcheng = txtPibuchang.Text,
                rq=dateTimePicker1.Value ,
            };
            try
            {
                if (Useful == FormUseful.新增)
                {
                    PriceTableService.InsertPriceTable(price);
                }
                else
                {
                    price.Id = ID;
                    Connect.DbHelper().Updateable<PriceTable>(price ).ExecuteCommandAsync ();
                }
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 新增价格_Load(object sender, EventArgs e)
        {
            if(Useful==FormUseful.修改 )
            {
                var price = PriceTableService.GetOnePriceTable(x => x.Id == ID);
                txtbeizhu.Text = price.beizhu;
                txthanshuidanjia.Text = price.hanshui.ToString ();
                txtpibubianhao.Text = price.kehubianhao;
                txtPibuchang.Text = price.kehumingcheng;
                txtqidingliang.Text = price.shuliang.ToString();
                txtweishuidanjia.Text = price.jiage.ToString();
                txtdahuojia.Text = price.Dahuojia.ToString();
                dateTimePicker1.Value = price.rq;
            }
        }
    }
}
