using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Diagnostics;
using Monitor.Map;

namespace Monitor.Classes
{
    class UDPClient
    {
        /// <summary>
        /// 用于UDP接收的网络服务
        /// </summary>
        private UdpClient udpcRecv;
        /// <summary>
        /// 线程：不断监听UDP报文
        /// </summary>
        private Thread thrRecv;
        /// <summary>
        /// 开关：在监听UDP报文阶段为true，否则为false
        /// </summary>
        private bool IsUdpcRecvStart = false;

        public DbAccessInfo mDbAcessInfo;

        public AlarmInfoSum mAlarmInfoSum;

        public UDPClient()
        {
            if(!IsUdpcRecvStart)//若未监听，开始监听
            {
                //IP地址和端口号
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8848);
                udpcRecv = new UdpClient(ip);
                thrRecv = new Thread(ReceiveMessage);
                thrRecv.Start();
                IsUdpcRecvStart = true;
                Debug.Print("UDP监听已经启动！");
            }
            else
            {
                thrRecv.Abort();
                udpcRecv.Close();
                IsUdpcRecvStart = false;
                Debug.Print("UDP监听已成功关闭！");
            }
        }

        private void ReceiveMessage(object obj)
        {
            IPEndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
            while(true)
            {
                try
                {
                    byte[] bytRecv = udpcRecv.Receive(ref remoteIp);
                    mDbAcessInfo.DbName = byteToString(bytRecv, 0, 16);
                    mDbAcessInfo.UserName = byteToString(bytRecv, 16, 16);
                    mDbAcessInfo.Password = byteToString(bytRecv, 32, 32);
                    mAlarmInfoSum.Alarmnum = byteToInt(bytRecv, 64, 4);
                   // mAlarmInfoSum.date
                    Debug.Print(mDbAcessInfo.DbName);
               
                }
                catch(Exception ex)
                {
                    MessageHelper.Info(ex.Message);
                }

            }
        }

        private string byteToString(byte[] byteArray,int start, int num)
        {
            byte[] mbyte= new byte[1024]; 
            Array.Copy(byteArray, start, mbyte, 0, num);
            string mString = Encoding.Unicode.GetString(mbyte, 0, mbyte.Length);
            return mString;
        }

        private int  byteToInt(byte[] byteArray, int start, int num)
        {
            byte[] mbyte = new byte[1024];
            Array.Copy(byteArray, start, mbyte, 0, num);
            int i = BitConverter.ToInt32(mbyte, 0);
            return i;
        }
    }
}
