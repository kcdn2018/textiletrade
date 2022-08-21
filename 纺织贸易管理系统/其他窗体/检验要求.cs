using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纺织贸易管理系统.其他窗体
{
    public partial class 检验要求 : Sunny.UI.UIForm 
    {
        public List<StockTable > Stocks { get; set; }
        public 检验要求()
        {
            InitializeComponent();
            try
            {
                cmbmaitou.Items.AddRange(Tools.获取模板.获取所有模板(PrintPath.唛头模板).ToArray());              
            }
            catch
            {
                Sunny.UI.UIMessageBox.ShowError("没有找到任何唛头模板信息");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Stocks != null)
            {
                foreach (var stock in Stocks)
                {
                    stock.Remarkers = txtbeizhu.Text;
                    stock.Shippingmark = cmbmaitou.Text;
                    stock.ShippingmarkUnite = cmbdanwei.Text;
                }
                Connect.DbHelper().Updateable<StockTable>(Stocks).ExecuteCommand();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void 检验要求_Load(object sender, EventArgs e)
        {
            cmbdanwei.SelectedIndex = 0;
            if(Stocks!=null )
            {
                if(Stocks.Count >0)
                {
                    if (string.IsNullOrWhiteSpace(Stocks[0].Shippingmark))
                    {
                        var customer = LXRService.GetOneLXR(x => x.MC == Stocks[0].CustomName);
                        var maitou = MaitouService.GetOneMaitou(x => x.khbh == customer.BH);
                        if (string.IsNullOrWhiteSpace(maitou.path))
                        {
                            if (cmbmaitou.Items.Count > 0)
                            {
                                cmbmaitou.SelectedIndex = 0;
                            }
                            else
                            {
                                MessageBox.Show("没有找到任何唛头信息");
                            }
                        }
                        else
                        {
                            cmbmaitou.Text = maitou.path;
                        }
                    }
                    else
                    {
                        cmbdanwei.Text = Stocks[0].ShippingmarkUnite;
                        cmbmaitou.Text = Stocks[0].Shippingmark;
                        txtbeizhu.Text = Stocks[0].Remarkers;
                    }
                }
            }
        }
    }
}
