using System;
using System.Collections.Generic;
using System.Linq;
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

namespace OrderSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    ///     
    public partial class MainWindow : Window
    {
        public static MainWindow Current;
        public static OrderInfo orderInfo = new OrderInfo();
        public static SerialCom com = new SerialCom();
        //public static FoodUIPage foodPage = new FoodUIPage();
        //public static PayWayPage payPage = new PayWayPage();
        public MainWindow()
        {            
            InitializeComponent();
            Current = this;
            FoodUIPage foodPage = new FoodUIPage();
            MidFrame.Content = foodPage;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (com.isOpened)
            {
                com.CloseCom();
            }
            base.OnClosed(e);
        }
    }
}
