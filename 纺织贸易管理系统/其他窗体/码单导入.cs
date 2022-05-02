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
    public partial class 码单导入 : Sunny.UI.UIForm 
    {
        public DataSet GetDataSet  { get; set; }
        public List<StockTable > stockTables { get; set; }
        public 码单导入()
        {
            InitializeComponent();
        }

        private void 码单导入_Load(object sender, EventArgs e)
        {
            if (GetDataSet != null)
            {
                foreach (DataTable dt in GetDataSet.Tables)
                {
                    cmb_worksheetS.Items.Add(dt.TableName);
                }
                cmb_worksheetS.SelectedIndex = 0;
                uiDataGridView1.DataSource = GetDataSet.Tables[0];
                foreach (DataColumn  col in GetDataSet.Tables[0].Columns)
                {
                    cmb_ganghao.Items.Add(col.ColumnName);
                    cmb_biaoqianmishu.Items.Add(col.ColumnName);
                    cmb_mabiao .Items.Add(col.ColumnName);
                    cmb_juanhao .Items.Add(col.ColumnName);
                }
                cmb_danwei.SelectedIndex = 0;
                cmb_ganghao .SelectedIndex = 0;
                cmb_juanhao .SelectedIndex = 0;
                cmb_mabiao .SelectedIndex = 0;
                cmb_biaoqianmishu .SelectedIndex = 0;
            }           
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() => {
            }));
        }
    }
}
