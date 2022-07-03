using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 纺织贸易管理系统.其他窗体
{
   public static class UpdateService
    {
        public static Boolean CheckUpdate()
        {
            XDocument document = XDocument.Load(Application.StartupPath +"\\Version.xml");
            XElement root = document.Root;
            XElement updater = root.Element("Updater");
            XElement ver = updater.Element("MainVersion");
            Version localVer = Version.Parse(ver.Value);
            User.version = localVer;
            Version ServerVer = GetServerVer(updater .Element("UpdateUrl").Value );
            if(ServerVer >localVer )
            { return true; }
            else
            {
                return false;
            }
        }
        private static Version GetServerVer(string ServerUrl)
        { 
            Version serverVersion=new Version ();
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ServerUrl + "/Version.xml");
                request.Credentials = new NetworkCredential("Administrator", "Kc123456");
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());//中文文件名
                                                                                     //XDocument document = XDocument.Load(url );
                                                                                     //XElement root = document.Root;
                                                                                     //XElement updater = root.Element("Updater");
                                                                                     //XElement ver = updater.Element("MainVersion");
                                                                                     //textBox1.Text = ver.Value;  

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!line.Contains("<DIR>"))
                    {
                        string msg = line.Trim();
                        if (msg.Contains("MainVersion"))
                        {
                            string value = msg.Split('>')[1];
                            value = value.Split('<')[0];
                            serverVersion = Version.Parse(value);
                            return serverVersion;
                        }
                    }
                    try
                    {
                        line = reader.ReadLine();
                    }
                    catch
                    {
                        reader.Close();
                        response.Close();
                        return serverVersion;
                    }
                }
            }
            catch
            { }
            return serverVersion;
            }
        public static  void IsNeedUpdate(Form form)
        {
            var check = CheckUpdate();
            if (check == true)
            {
                if (Sunny.UI.UIMessageDialog .ShowAskDialog (form, "系统提示", "有新的更新！启用更新将会关闭程序。请做好保存"))
                {
                    Process.Start(Application.StartupPath + "\\Updater.exe");
                    Process cur = Process.GetCurrentProcess();
                    KillProcess(cur.ProcessName);
                    Process.GetCurrentProcess().Kill();
                    Application.ExitThread();
                }
            }
        }
        public static void KillProcess(string strProcessesByName)//关闭线程
        {
            foreach (Process p in Process.GetProcesses())//GetProcessesByName(strProcessesByName))
            {
                if (p.ProcessName.ToUpper().Contains(strProcessesByName))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                    catch (Win32Exception e)
                    {
                        MessageBox.Show(e.Message.ToString());   // process was terminating or can't be terminated - deal with it
                    }
                    catch (InvalidOperationException e)
                    {
                        MessageBox.Show(e.Message.ToString()); // process has already exited - might be able to let this one go
                    }
                }
            }
        }
    }
}
