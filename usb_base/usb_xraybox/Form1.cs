using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using static usb_xraybox.CommandCode;
using System.Drawing;


namespace usb_xraybox
{
    public partial class Form1 : Form
    {
        //声明变量
        String cmd = "cmd.exe";
        Process p = new Process();
        //int TSleep = 3000;

        public Form1()
        {
            InitializeComponent();
        }

        private string executeAdb(string adb)
        {
            p.StartInfo = new System.Diagnostics.ProcessStartInfo();
            p.StartInfo.FileName =  cmd;//设定程序名 
            p.StartInfo.Arguments = "/c adb"+adb;
            p.StartInfo.UseShellExecute = false; //关闭shell的使用 
            p.StartInfo.RedirectStandardInput = true; //重定向标准输入 
            p.StartInfo.RedirectStandardOutput = true; //重定向标准输出 
            p.StartInfo.RedirectStandardError = true; //重定向错误输出 
            p.StartInfo.CreateNoWindow = true;//设置不显示窗口 
            p.Start();
            String restr = "";
            restr = p.StandardOutput.ReadToEnd();
            p.Close();
            return restr;

        }
       

        private static byte[] result = new byte[1024];

        //Socket clientSocket,socket = null;
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static IPAddress ip = IPAddress.Parse("127.0.0.1");
       
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //发送数据
        private void button1_Click_1(object sender, EventArgs e)
        {
            //通过 clientSocket 发送数据  
            try
            {
                string sendMessage = textBox1.Text;
                clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));
                Console.WriteLine("向服务器发送消息：{0}" + sendMessage);

                int receiveLength = clientSocket.Receive(result);
                String andStr = Encoding.UTF8.GetString(result, 0, receiveLength);
                Console.WriteLine("接收服务器消息：{0}", andStr);
                string Tistr = andStr.Substring(andStr.IndexOf("22-content=") + 11, 5);
                float Ticont = Convert.ToSingle(Tistr);
                if ((Ticont > 1) && (Ticont < 32))
                { textBox1.Text = "属于钨钴钛合金"; }
                textBox4.Text = Tistr;
            }
            catch
            {
                if (clientSocket != null && clientSocket.Connected)
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
                else
                { textBox4.Text = "unconnected"; }


            }
            Console.WriteLine("发送完毕，按回车键退出");
            Console.ReadLine();
        }
        //结束同步
        private void button2_Clink_Click(object sender, EventArgs e)
        {
            String exAdb = " shell am broadcast -a NotifyServiceStop";
            executeAdb(exAdb);

        }

        private void Link()
        {
            try
            {
                //(new IPEndPoint(ip, 12580)); //配置服务器IP与端口  
                EndPoint point = new IPEndPoint(ip, 12580);
                clientSocket.Connect(point);
                Console.WriteLine("连接服务器成功");
                textBox4.Text = "ok";
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                textBox4.Text = "false";
                return;

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //获取手机型号
            String phonModel = " shell getprop ro.product.model";
            textBox2.Text = executeAdb(phonModel);

            //String exAdb = "  devices";
            String adb_rstr = "";
            String exAdb = null;
            //端口
            exAdb = " forward tcp:12580 tcp:10086";
            adb_rstr = executeAdb(exAdb);
            //转换结果
            exAdb = " forward --list";
            adb_rstr = executeAdb(exAdb);
            //发送开启手机服务监听广播
            exAdb = " shell am broadcast -a NotifyServiceStart";
            adb_rstr = executeAdb(exAdb);

            //作为客户端链接
            //ip.AddressFamily
            Link();
            //通过clientSocket接收数据  

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "1422-content=22.12";
            string Tistr = str.Substring(str.IndexOf("22-content=")+11,5);
            float Ticont = Convert.ToSingle(Tistr);
            if ((Ticont > 1)&&(Ticont<32))
            { textBox1.Text = "属于钨钴钛合金"; }
            //string str = "ABCD-123456EF";
            //string mystr = str.Substring(str.IndexOf("-") + 1, str.Length - str.IndexOf("-") * 2);
            //textBox1.Text = mystr;
        }




    }
}
