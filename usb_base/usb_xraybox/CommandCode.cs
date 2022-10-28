using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usb_xraybox
{
    internal class CommandCode
    {
        public static  int CN_OVER_TIME_SET = 1000;        //设置超时时间及重发次数
        public static  int CN_DEVICE_DURATION = 1011;      //设置现场机采样时长
        public static  int CN_POLLUTANT_REAL_DATA = 2011;  //开始测试/上传测试数数
        public static  int CN_POLLUTANT_STOP = 2012;       //停止现场机测试
        public static  int CN_LOGIN_SYSTEM = 3011;         //登录系统
        public static  int CN_SELF_CHECK = 3012;           //仪器自检命令
        public static  int CN_SHUT_DOWN = 3014;            //仪器关机命令
        public static  int CN_QN_RTN = 9011;               //请求应答
        public static  int CN_EXE_RTN = 9012;              //执行结果
        public static  int CN_MESSAGE_RTN = 9013;          //通知应答
        public static  int CN_DATA_RTN = 9014;             //数据应答
    }
}
