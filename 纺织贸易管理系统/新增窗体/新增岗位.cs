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

namespace 纺织贸易管理系统.新增窗体
{
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIEditForm”(是否缺少程序集引用?)
    public partial class 新增岗位 : Sunny.UI.UIEditForm 
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIEditForm”(是否缺少程序集引用?)
    {
        public int Useful { get; set; }
        public MachineTable station { get; set; }
        public 新增岗位()
        {
            InitializeComponent();
        }

        private void 新增岗位_Load(object sender, EventArgs e)
        {
            if (Useful == FormUseful.修改)
            {
                edit();
            }
        }
        private void Clear()
        {
            station = new MachineTable ();
            txtnum.Text = station.MachineID ;
        }
        private void edit()
        {
            txtnum.Text = station.MachineID ;
        }

        private void 新增岗位_ButtonOkClick(object sender, EventArgs e)
        {
            var stat = new MachineTable ();
            stat.MachineID  = txtnum.Text;
            if (Useful == FormUseful.新增)
            {
                MachineTableService.InsertMachineTable(stat);
            }
            else
            {
                stat.ID = station.ID;
                MachineTableService.UpdateMachineTable (stat,x=>x.ID ==stat.ID);
            }
            Useful = FormUseful.新增;
            Clear();
        }

        private void 新增岗位_ButtonCancelClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
