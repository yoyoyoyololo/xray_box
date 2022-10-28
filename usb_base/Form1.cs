using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
//using System.Threading;
using Command;
using System.Text.RegularExpressions;
using Matching;
using CRC;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.IO.Ports;

namespace usb_xraybox
{

    public partial class Form1 : Form
    {
        //声明变量
        String cmd = "cmd.exe";
        Process p = new Process();
        //int TSleep = 3000;
        int LinkFlag = 0;
        Match1 Match = new Match1();
        CRC16 crc = new CRC16();
        string crc16;

        public Form1()
        {
             Control.CheckForIllegalCrossThreadCalls = false;//关闭检查非法的跨线操作
            InitializeComponent();
            listen();
            
            OpenSerialPort();
            
            if (LinkFlag == 1)
            {
                Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(100);
                        ReceiveData();
                        //int receiveLength = clientSocket.Receive(result);
                        //String andStr = Encoding.UTF8.GetString(result, 0, receiveLength);
                        //Console.WriteLine("接收服务器消息：{0}", andStr);
                        //textBox4.Text = andStr;
                    }
                });
            }
        }


        private void OpenSerialPort()
        {
            try
            {
                serialPort1.PortName = "COM13";
                serialPort1.BaudRate = 115200;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.Open();
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            }
            catch
            {
                MessageBox.Show("串口打开失败","提示");
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)      //串口接收数据事件
        {
            if (serialPort1.IsOpen)
            {
                int count = serialPort1.BytesToRead;
                byte[] dataReceive = new byte[count];
                serialPort1.Read(dataReceive, 0, count);     //串口接收
                //textBox5.AppendText(dataReceive.ToString());
                MessageBox.Show("串口打开成功", "提示");
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }






        //启用adb
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

        public void listen()
        {
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
        }

        //socket连接
        public int Link()
        {
            try
            {
                //(new IPEndPoint(ip, 12580)); //配置服务器IP与端口  
                EndPoint point = new IPEndPoint(ip, 12580);
                clientSocket.Connect(point);
                //Socket ts = clientSocket.Accept();
                Console.WriteLine("连接服务器成功");
                LinkFlag = 1;
                textBox4.Text = "ok";
                //ts.BeginReceive(result, 0, result.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
                //Console.ReadKey();
                return LinkFlag;
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                textBox4.Text = "false";
                return 0;
            }
        }


        //send发送数据
        public void SendData(int i)
        {
            try
            {
                //string data = CommandCode.DATA(i).Substring(6, CommandCode.DATA(i).Length - 6);
                //crc16 = crc.CRC(data);
                string sendMessage = CommandCode.DATA(i);
                clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));
                Console.WriteLine("向服务器发送消息：{0}" + sendMessage);
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

        //Receive接收
        public void ReceiveData()
        {
            try
            {

                Regex shujubao = new Regex("(QN.+&&)");
                Regex crc_16 = new Regex("&&(\\w{4})$");
                //同步接收
                int receiveLength = clientSocket.Receive(result);
                //异步接收
                //clientSocket.BeginReceive(result, 0, result.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
                String andStr = Encoding.UTF8.GetString(result, 0, receiveLength);
                //Match.Match_Data(andStr);
                //接收信号的crc校验
                Match SAMPLE = shujubao.Match(andStr);
                crc16 = crc.CRC(SAMPLE.Groups[1].Value);
                //Console.WriteLine(SAMPLE.Groups[1].Value);
                //Console.WriteLine(crc16);
                Match CRC_16 = crc_16.Match(andStr);
                //Console.WriteLine(CRC_16.Groups[1].Value);
                if (CRC_16.Groups[1].Value != crc16)
                {
                    string str = CommandCode.ExeRtn(8);
                    clientSocket.Send(Encoding.UTF8.GetBytes(str));
                }


                Regex yuansu = new Regex("(\\d{1,3})-content");
                MatchCollection YUANSU = yuansu.Matches(SAMPLE.Groups[1].Value);
                //Console.WriteLine(YUANSU[0].Value);
                Regex content = new Regex("-content=(\\d{1,2}.\\d{1,2})");
                MatchCollection CONTENT = content.Matches(SAMPLE.Groups[1].Value);
                //Console.WriteLine(CONTENT[0].Value);
                Regex digit1 = new Regex("(\\d{1,3})");
                Regex digit2 = new Regex("(\\d{1,2}.\\d{1,2})");
                Console.WriteLine(digit2.Match(CONTENT[0].Value).Groups[1].Value);
                Regex error = new Regex("-Error=(\\d{1,2}.\\d{1,2})");
                MatchCollection ERROR = error.Matches(SAMPLE.Groups[1].Value);
                for (int i = 0; i < YUANSU.Count; i++)
                {
                    Console.WriteLine("{0}元素的含量为：{1}，误差为：{2}", digit1.Match(YUANSU[i].Value).Groups[1].Value, digit2.Match(CONTENT[i].Value).Groups[1].Value,0);
                }

                //Console.WriteLine("接收服务器消息：{0}", andStr);
                //string Tistr = andStr.Substring(andStr.IndexOf("22-content=") + 11, 5);
                //float Ticont = Convert.ToSingle(Tistr);
                //if ((Ticont > 1) && (Ticont < 32))
                //{ textBox1.Text = "属于钨钴钛合金"; }
                //textBox4.Text = Tistr;
            }
            catch
            {
                if (clientSocket != null && clientSocket.Connected)
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
                else
                { textBox4.Text = "unconnected444"; }
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


        //打开设备
        private void open_device_button_Click(object sender, EventArgs e)
        {
            //获取手机型号
           
            String phonModel = " shell getprop ro.product.model";
            textBox2.Text = executeAdb(phonModel);
            //ReceiveData(); 

            //String exAdb = "  devices";

            //通过clientSocket发送数据  
            SendData(1);//仪器登录
            //ReceiveData();

        }

        //测试字符串匹配
        private void button9_Click(object sender, EventArgs e)
        {
            string str = "1422-content=22.12";
            string Tistr = str.Substring(str.IndexOf("22-content=") + 11, 5);
            float Ticont = Convert.ToSingle(Tistr);
            if ((Ticont > 1)&&(Ticont<32))
            { textBox1.Text = "属于钨钴钛合金"; }
            //string str = "ABCD-123456EF";
            //string mystr = str.Substring(str.IndexOf("-") + 1, str.Length - str.IndexOf("-") * 2);
            //textBox1.Text = mystr;
        }

        private void self_check_button_Click(object sender, EventArgs e)
        {
            SendData(4);
            //port_DataSend(11);            
            //ReceiveData();
        }

        private void start_check_button_Click(object sender, EventArgs e)
        {
            SendData(5);
            //ReceiveData();
        }

        private void stop_check_button_Click(object sender, EventArgs e)
        {
            SendData(6);
            //ReceiveData();
        }

        private void shut_button_Click(object sender, EventArgs e)
        {
            SendData(8);
            //ReceiveData();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

    }
}

/*  Control.CheckForIllegalCrossThreadCalls = false;
  Thread thread = new Thread(ReceiveData);
  thread.IsBackground = true;
  thread.Start();*/
//异步编程
//if (LinkFlag == 1)
//{
//Task.Run(async () =>
//{
//    while (true)
//    {
//        await Task.Delay(100);
//        ReceiveData();
//        int receiveLength = clientSocket.Receive(result);
//        String andStr = Encoding.UTF8.GetString(result, 0, receiveLength);
//        Console.WriteLine("接收服务器消息：{0}", andStr);
//        textBox4.Text = andStr;
//    }
//});
//}

////static byte[] buffer = new byte[8];
//static void ReceiveCallback(IAsyncResult res)
//{
//    Socket ts = (Socket)res.AsyncState;
//    ts.EndReceive(res);
//    res.AsyncWaitHandle.Close();
//    //Console.WriteLine("收到消息：{0}", Encoding.ASCII.GetString(result));

//    //清空数据，重新开始异步接收
//    result = new byte[result.Length];
//    ts.BeginReceive(result, 0, result.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), ts);
//}