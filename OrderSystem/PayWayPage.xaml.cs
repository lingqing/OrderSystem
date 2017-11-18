using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OrderSystem
{
    /// <summary>
    /// PayWayPage.xaml 的交互逻辑
    /// </summary>
    public partial class PayWayPage : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private DispatcherTimer timer2 = new DispatcherTimer();
        //private DispatcherTimer timer3 = new DispatcherTimer();
        private bool mComOvered = false;
        Frame mFrame = MainWindow.Current.MidFrame;
        private string outTradeNo;
        private string wxQueryUrl = "http://andyhacker.cn/orderm/wxpay/orderquery.php?out_trade_no=";
        private string alQueryUrl = "http://andyhacker.cn/orderm/alpay/f2fpay/orderquery.php?out_trade_no=";
        private OrderInfo orderinfo = MainWindow.orderInfo;
        private static int comTimes = 0;
        public PayWayPage()
        {
            InitializeComponent();
            outTradeNo = "188" + DateTime.Now.ToFileTimeUtc().ToString();
            wxQueryUrl += outTradeNo;
            alQueryUrl += outTradeNo;
            SubTitleTxt.Text = "共需支付" + orderinfo.OrderPrice.ToString() + "元";
        }
        
        private void PayGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (mFrame.CanGoBack)
            {
                timer.Stop();
                timer2.Stop();
                mFrame.GoBack();
            }
        }

        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            ComWithOrderMac();
        }

        private async void AliPayBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://andyhacker.cn/orderm/alpay/alpayfromclient.php"; //post的地址  
            var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"outTradeNo", outTradeNo },
                        {"orderLabel", orderinfo.OrderName},
                        {"sumPrice", orderinfo.OrderPrice.ToString()},
                    });
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            timer.Stop();
            PayTitleTxt.Text = "支付宝扫码";
            var brush = this.Resources["AlColor"] as SolidColorBrush;
            PayImgCont.Background = brush;
            using (var http = new HttpClient(handler))
            {
                //await异步等待回应
                try
                {
                    HttpResponseMessage response = await http.PostAsync(url, content);
                    if (response.StatusCode.GetHashCode() == 200)
                    {
                        //OnRestRequestEvent(
                        //new RestEventArgs
                        //{
                        //    StatuCode = stateCode,
                        //    ExceptionInfo = "",
                        //    sContentInfo = response.Content.ReadAsStringAsync().Result,
                        //});
                        string qrUrl = response.Content.ReadAsStringAsync().Result;

                        Uri uri = new Uri("http://andyhacker.cn/orderm/wxpay/qrcode.php?data=" + qrUrl);
                        BitmapImage img = new BitmapImage(uri);
                        QrCodeImg.Source = img;
                        timer.Interval = new TimeSpan(0, 0, 2);
                        timer.Tick -= WxUpdatePayResult;
                        timer.Tick += AliUpdatePayResult;
                        timer.Start();
                        ResultTxt.Text = "请扫码支付";
                    }
                    else
                    {
                        ResultTxt.Text = "else" + response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (Exception errr)
                {
                    ResultTxt.Text = "error" + errr.Message;
                }
            }
        }

        private async void AliUpdatePayResult(object sender, object e)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var http = new HttpClient(handler))
            {
                HttpResponseMessage response = await http.GetAsync(alQueryUrl);
                if (response.StatusCode.GetHashCode() == 200)
                {
                    string respStr = response.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(respStr);
                    if (jo["alipay_trade_query_response"]["code"].ToString() != "10000")
                    {
                        ResultTxt.Text = "请扫码";
                    }
                    else
                    {
                        var payState = jo["alipay_trade_query_response"]["trade_status"].ToString();
                        if (payState == "TRADE_SUCCESS")
                        {
                            timer.Stop();
                            //ResultTxt.Text = "支付成功";
                            //Uri uri = new Uri("http://andyhacker.cn/orderm/wxpay/paysucceed.png");
                            //BitmapImage img = new BitmapImage(uri);
                            //QrCodeImg.Source = img;
                            ComWithOrderMac();
                            //mFrame.Navigate(typeof(FoodUIPage));
                        }
                        else
                            ResultTxt.Text = "等待支付";
                    }
                }
                else
                {
                    ResultTxt.Text = "else" + response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        private async void WxUpdatePayResult(object sender, object e)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (var http = new HttpClient(handler))
            {
                HttpResponseMessage response = await http.GetAsync(wxQueryUrl);
                if (response.StatusCode.GetHashCode() == 200)
                {
                    string respStr = response.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(respStr);
                    string payState = jo["trade_state"].ToString();
                    if (payState == "NOTPAY")
                    {
                        ResultTxt.Text = "请扫码支付";
                    }
                    else if (payState == "SUCCESS")
                    {
                        timer.Stop();
                        //ResultTxt.Text = "支付成功";
                        //Uri uri = new Uri("http://andyhacker.cn/orderm/wxpay/paysucceed.png");
                        //BitmapImage img = new BitmapImage(uri);
                        //QrCodeImg.Source = img;
                        ComWithOrderMac();
                        //mFrame.Navigate(typeof(FoodUIPage));
                    }
                }
                else
                {
                    ResultTxt.Text = "else" + response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        private async void WxPayBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://andyhacker.cn/orderm/wxpay/wxpayfromclient.php"; //post的地址    
            var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"outTradeNo", outTradeNo },
                        {"orderLabel", orderinfo.OrderName},
                        {"sumPrice", orderinfo.OrderPrice.ToString()},
                    });
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            timer.Stop();
            PayTitleTxt.Text = "微信扫码";
            var brush = this.Resources["WxColor"] as SolidColorBrush;
            PayImgCont.Background = brush;

            using (var http = new HttpClient(handler))
            {
                try
                {
                    HttpResponseMessage response = await http.PostAsync(url, content);
                    if (response.StatusCode.GetHashCode() == 200)
                    {
                        var qrUrl = response.Content.ReadAsStringAsync().Result;
                        Uri uri = new Uri("http://andyhacker.cn/orderm/wxpay/qrcode.php?data=" + qrUrl);
                        BitmapImage img = new BitmapImage(uri);
                        QrCodeImg.Source = img;
                        timer.Interval = new TimeSpan(0, 0, 2);
                        timer.Tick -= AliUpdatePayResult;
                        timer.Tick += WxUpdatePayResult;
                        timer.Start();
                        ResultTxt.Text = "请扫码支付";
                    }
                    else
                    {
                        ResultTxt.Text = "else" + response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (Exception errr)
                {
                    ResultTxt.Text = "error" + errr.Message;
                }
            }
        }

        private void ComWithOrderMac()
        {
            ResultTxt.Text = "支付成功,正在出菜...";
            Uri uri = new Uri("http://andyhacker.cn/orderm/wxpay/paysucceed.png");
            BitmapImage img = new BitmapImage(uri);
            QrCodeImg.Source = img;

            byte[] comBytes = new byte[4];
            comBytes[0] = orderinfo.HasRice ? (byte)1 : (byte)0;
            //comBytes[1] = orderinfo.HasSoup ? (byte)1 : (byte)0;
            //if (comTimes++ >= 1)
            //{
            //    comBytes[5] = (byte)1;
            //    comTimes = 0;
            //}
            //else comBytes[5] = (byte)0;

            List<int> nums = orderinfo.OrderNum;
            nums.Sort();
            switch (nums.Count)
            {
                case 1:
                    comBytes[3] = (byte)nums[0];
                    break;
                case 2:
                    comBytes[2] = (byte)(nums[0]);
                    comBytes[3] = (byte)(nums[1] - nums[0]);
                    break;
                case 3:
                    comBytes[1] = (byte)(nums[0]);
                    comBytes[2] = (byte)(nums[1] - nums[0]);
                    comBytes[3] = (byte)(nums[2] - nums[1]);
                    break;

                default:
                    break;
            }
            //if (nums.Count >= 3) comBytes[1] = (byte)(nums[0]);
            //if (nums.Count >= 2) comBytes[2] = (byte)(nums[1] - nums[0]);
            //if (nums.Count >= 1) comBytes[3] = (byte)(nums[2] - nums[1]);

            MainWindow.com.SetComOverCallBack(ComOver);

            MainWindow.com.SendBytes(comBytes);
            Task.Factory.StartNew(()=>
            {
                MainWindow.com.WaitResp((byte)13);
                MainWindow.com.WaitRespAndClose((byte)13);
            });

            timer2.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += PageGoBack;
            timer2.Start();
            //SerialCom.SetComOverCallBack(ComOver);
            //SerialCom.ReadResp(1);
            //SerialCom.ReadResp(2);
        }
        public bool WaitResp(byte b)
        {
            for (int i = 0; i < 5; i++)
            {
                byte[] bytes = MainWindow.com.ReceiveBytes(2);
                foreach (var item in bytes)
                {
                    if (item == (byte)b)
                    {
                        return true;
                    }
                    else continue;
                }
            }
            return false;
        }

        public void ComOver()
        {
            //FoodUIPage foodPage = new FoodUIPage();
            //mFrame.Content = foodPage;
            //PayGoBack_Click(null, null);
            mComOvered = true;
        }

        public void PageGoBack(object sender, object e)
        {
            if (mComOvered)
            {
                PayGoBack_Click(null, null);
                mComOvered = false;
            }            
        }
    }
}
