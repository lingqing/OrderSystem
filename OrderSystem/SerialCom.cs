using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace OrderSystem
{
    public class SerialCom
    {
        public const string COM_NUM = "COM3";
        static SerialPort serialPort;
        private DispatcherTimer timer3 = new DispatcherTimer();
        private bool timeOut = false;
        public bool isOpened { get; set; }
        private int timerParameter;
        private int times;

        // 声明回掉
        public delegate void ComOver();
        private ComOver mOver = null;
        public SerialCom()
        {
            serialPort = new SerialPort();
            isOpened = false;
            serialPort.PortName = COM_NUM;
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.Even;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;                 
        }
        public void SendBytes(byte[] bytes)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();                    
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }                
            }
            serialPort.Open();
            serialPort.Write(bytes, 0, bytes.Length);
        }

        public byte[] ReceiveBytes(int sec)
        {
            serialPort.ReadTimeout = 1000 * sec;
            try
            {
                int n = serialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
                byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据  
                //received_count += n;//增加接收计数  
                serialPort.Read(buf, 0, n);//读取缓冲数据  
                                           //因为要访问ui资源，所以需要使用invoke方式同步ui
                return buf;
                //Dispatcher.Invoke(interfaceUpdateHandle, new string[] { Encoding.ASCII.GetString(buf) });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                //处理超时错误
            }
            return new byte[0];
        }
       
        public void WaitResp(byte b)
        {
            for (int i = 0; i < 5; i++)
            {
                byte[] bytes = ReceiveBytes(2);
                foreach (var item in bytes)
                {
                    if (item == (byte)b)
                    {                       
                        break;
                    }
                    else continue;
                }
                Thread.Sleep(2000);
            }            
        }
        public void WaitRespAndClose(byte b)
        {
            WaitResp(b);
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
            mOver();
        }
        public void CloseCom()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }  
        
        public void SetComOverCallBack(ComOver over)
        {
            mOver = over;
        }     
    }


}
