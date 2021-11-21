using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 纺织贸易管理系统.其他窗体
{
   public  class Update
    {
        public Boolean CheckUpdate()
        {
            XDocument document = XDocument.Load(Application.StartupPath +"\\Version.xml");
            XElement root = document.Root;
            XElement updater = root.Element("Updater");
            XElement ver = updater.Element("MainVersion");
            Version localVer = Version.Parse(ver.Value);
            Version ServerVer = GetServerVer(updater .Element("UpdateUrl").Value );
            if(ServerVer >localVer )
            { return true; }
            else
            {
                return false;
            }
        }
        private Version GetServerVer(string ServerUrl)
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
    }
}
