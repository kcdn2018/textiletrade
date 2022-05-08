using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Config
{
    public partial class 设置数据库 : Form
    {
        private string Environmen = string.Empty;
        private SqlConnection sqlConnection = new SqlConnection ();
        private List <LinkInfo > Linkinfos = InitLinkInfos.GetLinkInfos();
        private DataTable alllinks = new DataTable();
        public 设置数据库()
        {
            InitializeComponent();
            progressBar1.Maximum = 10;
            progressBar1.Step = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string Connectstring= $"server={txtIP.Text},{TXTPORT.Text };uid={TXTUSER.Text };pwd={TXTPASSWORD.Text };database={TXTDBNAME.Text }";
            progressBar1.Maximum = sqlConnection.ConnectionTimeout-1;
            label7.Text = "正在连接";
            timer1.Start();
            try
            {
                //this.Invoke (new MethodInvoker (()=> { sqlConnection.Open(); }) );
                Task.Factory.StartNew(new Action(() =>
                {
                    sqlConnection = new SqlConnection(Connectstring);
                    sqlConnection.Open();
                }));
            }
            catch
            {
                label7.Text = "连接失败";
            }
            //this.Invoke(new Action(() =>
            //{
            //    try
            //    {
            //        sqlConnection.Open();
            //        label7.Text = "连接成功";
            //        //timer1.Stop();
            //        //progressBar1.Value = 0;
            //    }
            //    catch
            //    {
            //        label7.Text = "连接失败";
            //        //timer1.Stop();
            //        //progressBar1.Value = 0;
            //    }
            //}));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;
            if (sqlConnection.State == ConnectionState.Open)
            {
                label7.Text = "连接成功";
                progressBar1.Value = 0;
                timer1.Stop();
            }
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                label7.Text = "连接失败";
                progressBar1.Value = 0;
                timer1.Stop();
            }
        }

        private void 设置数据库_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("server=192.168.0.109;uid=sa;pwd=Kc123456;database=UserDB"))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from DBTable",conn);
                sqlDataAdapter.Fill(alllinks);
                Linkinfos =InitLinkInfos.DataTableToDataList<LinkInfo>(alllinks);
                comboBox2.DataSource = Linkinfos.Select (x=>x.CompanyName ).ToList () ;
                Environmen = comboBox1.Text;
                var dt = GetSqlite();
                //return $"server={dt.Rows[0]["server"]},{};uid={};pwd={};database={}";
                if (dt.Rows.Count > 0)
                {
                    txtIP.Text = dt.Rows[0]["server"].ToString();
                    TXTDBNAME.Text = dt.Rows[0]["database"].ToString();
                    TXTPASSWORD.Text = dt.Rows[0]["PWD"].ToString();
                    TXTPORT.Text = dt.Rows[0]["port"].ToString();
                    TXTUSER.Text = dt.Rows[0]["username"].ToString();
                }
            }
        } 
        public  SQLiteConnection CreatSqlite()
            {
                SQLiteConnection sqlconn = new SQLiteConnection();
                SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
                connstr.DataSource = System.Environment.CurrentDirectory + "\\Config.db";
                sqlconn.ConnectionString = connstr.ToString();
                sqlconn.Open();
                return sqlconn;
            }
        private  DataTable GetSqlite()
        {
            var sqliteconn = CreatSqlite();
            SQLiteDataAdapter dp = new SQLiteDataAdapter($"select * from linkinfo where Environment='{Environmen}'", sqliteconn);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            return dt;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Environmen = comboBox1.Text;
            var dt = GetSqlite();
            //return $"server={dt.Rows[0]["server"]},{};uid={};pwd={};database={}";
            if (dt.Rows.Count > 0)
            {
                txtIP.Text = dt.Rows[0]["server"].ToString();
                TXTDBNAME.Text = dt.Rows[0]["database"].ToString();
                TXTPASSWORD.Text = dt.Rows[0]["PWD"].ToString();
                TXTPORT.Text = dt.Rows[0]["port"].ToString();
                TXTUSER.Text = dt.Rows[0]["username"].ToString();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            Environmen = comboBox1.Text;
            var dt = GetSqlite();
            //return $"server={dt.Rows[0]["server"]},{};uid={};pwd={};database={}";
            if (dt.Rows.Count > 0)
            {
                txtIP.Text = dt.Rows[0]["server"].ToString();
                TXTDBNAME.Text = dt.Rows[0]["database"].ToString();
                TXTPASSWORD.Text = dt.Rows[0]["PWD"].ToString();
                TXTPORT.Text = dt.Rows[0]["port"].ToString();
                TXTUSER.Text = dt.Rows[0]["username"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sqliteconn = CreatSqlite();
            string UpdateString = $"Update linkinfo set server='{txtIP.Text }',database='{TXTDBNAME.Text }',pwd='{TXTPASSWORD.Text }',port='{TXTPORT.Text }',username='{TXTUSER.Text }' where Environment='{Environmen}'";
            SQLiteCommand command = new SQLiteCommand(UpdateString, sqliteconn);
            command.ExecuteNonQuery();
            MessageBox.Show("保存成功！",this.Name ,MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty (comboBox2.Text ))
            {
                var link = Linkinfos.FirstOrDefault(x => x.CompanyName == comboBox2.Text);
                txtIP.Text = link.ServerName ;
                TXTDBNAME.Text = link.DbName;
                TXTPASSWORD.Text = link.PWD;
                TXTPORT.Text = link.Port;
                TXTUSER.Text = link.UID;
            }
        }

        private void 设置数据库_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

    }
}
