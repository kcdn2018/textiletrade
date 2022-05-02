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
    public partial class 库位登记 : Sunny.UI.UIForm
    {
        public string StockName { get; set; }
        public string Kuwei { get; set; } = string.Empty;
        public 库位登记()
        {
            InitializeComponent();           
        }

        private void 库位登记_Load(object sender, EventArgs e)
        {
            var dblist = ZhijiaTableService.GetZhijiaTablelst(x => x.StockName == StockName );
            foreach (var zhijia in dblist)
            {
                cmb_kuwei.Items.Add(zhijia.Zhijiahao);
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Kuwei = cmb_kuwei.Text;
            this.Close();
        }
    }
}
