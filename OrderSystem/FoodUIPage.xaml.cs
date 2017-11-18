using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// FoodUIPage.xaml 的交互逻辑
    /// </summary>
    public partial class FoodUIPage : Page
    {
        private ObservableCollection<Food> OrderedFoods = new ObservableCollection<Food>();
        private List<Food> MyFoods;
        Frame mFrame = MainWindow.Current.MidFrame;
        private Food soupFood = FoodManager.FoodCont.Find(f =>
        {
            return (f.FoodId == 1);
        });

        public FoodUIPage()
        {            
            InitializeComponent();
            //OrderedFoods.Add(new Food { FoodId = 1, FoodName = "红烧肉", FoodPrice = 0.01f, CoverImage = "Assets/红烧肉.jpg" });
            //OrderedFoods.Add(new Food { FoodId = 2, FoodName = "干煸豆角", FoodPrice = 0.01f, CoverImage = "Assets/干煸豆角.jpg" });
            //OrderedFoods.Add(new Food { FoodId = 3, FoodName = "宫保鸡丁", FoodPrice = 0.01f, CoverImage = "Assets/宫保鸡丁.jpg" });
            //OrderedFoods.Add(new Food { FoodId = 4, FoodName = "拍黄瓜", FoodPrice = 0.01f, CoverImage = "Assets/拍黄瓜.jpg" });
            listView.ItemsSource = OrderedFoods;
            FoodManager.GetFoodStatic();
            MyFoods = FoodManager.FoodCont;

            // 初始化 食物源
            //Image imgCtl = (Image) Food1.Children.OfType<Image>();
            Uri uri = new Uri("http://andyhacker.cn/orderm/images/红烧肉.jpg");
            BitmapImage img = new BitmapImage(uri);
            FoodImage1.Source = img;
            FoodName1.Text = MyFoods[0].FoodName;
            FoodPrice1.Text = MyFoods[0].FoodPrice.ToString() + "元";

            uri = new Uri("http://andyhacker.cn/orderm/images/干煸豆角.jpg");
            img = new BitmapImage(uri);
            FoodImage2.Source = img;
            FoodName2.Text = MyFoods[1].FoodName;
            FoodPrice2.Text = MyFoods[1].FoodPrice.ToString() + "元";

            uri = new Uri("http://andyhacker.cn/orderm/images/"+ MyFoods[2].FoodName + ".jpg");
            img = new BitmapImage(uri);
            FoodImage3.Source = img;
            FoodName3.Text = MyFoods[2].FoodName;
            FoodPrice3.Text = MyFoods[2].FoodPrice.ToString() + "元";

            uri = new Uri("http://andyhacker.cn/orderm/images/" + MyFoods[3].FoodName + ".jpg");
            img = new BitmapImage(uri);
            FoodImage4.Source = img;
            FoodName4.Text = MyFoods[3].FoodName;
            FoodPrice4.Text = MyFoods[3].FoodPrice.ToString() + "元";

            uri = new Uri("http://andyhacker.cn/orderm/images/" + MyFoods[4].FoodName + ".jpg");
            img = new BitmapImage(uri);
            FoodImage5.Source = img;
            FoodName5.Text = MyFoods[4].FoodName;
            FoodPrice5.Text = MyFoods[4].FoodPrice.ToString() + "元";

            uri = new Uri("http://andyhacker.cn/orderm/images/" + MyFoods[5].FoodName + ".jpg");
            img = new BitmapImage(uri);
            FoodImage6.Source = img;
            FoodName6.Text = MyFoods[5].FoodName;
            FoodPrice6.Text = MyFoods[5].FoodPrice.ToString() + "元";

            uri = new Uri("http://andyhacker.cn/orderm/images/" + MyFoods[6].FoodName + ".jpg");
            img = new BitmapImage(uri);
            FoodImage7.Source = img;
            FoodName7.Text = MyFoods[6].FoodName;
            FoodPrice7.Text = MyFoods[6].FoodPrice.ToString() + "元";

            uri = new Uri("http://andyhacker.cn/orderm/images/" + MyFoods[7].FoodName + ".jpg");
            img = new BitmapImage(uri);
            FoodImage8.Source = img;
            FoodName8.Text = MyFoods[7].FoodName;
            FoodPrice8.Text = MyFoods[7].FoodPrice.ToString() + "元";
        }

        private void OrderFoodBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OrderedFoods.Count > 3)
            {
                MessageBox.Show("抱歉，您选择了超过三个菜");               
                return;
            }
            if (OrderedFoods.Count < 1)
            {
                MessageBox.Show("请至少选择一个菜");
                return;
                //MessageDialog message = new MessageDialog("请至少选择一个菜");
                //await message.ShowAsync();
                //return;
            }

            OrderInfo orderinfo = new OrderInfo();
            if (OrderedFoods.Count > 0)
            {
                float price = 0.0f;
                List<int> num = new List<int>();
                foreach (var food in OrderedFoods)
                {
                    price += food.FoodPrice;
                    num.Add(food.FoodId);
                }
                num.Sort();
                orderinfo.OrderPrice = price;
                orderinfo.OrderName = OrderedFoods[0].FoodName;
                orderinfo.OrderNum = num;
            }
            orderinfo.HasSoup = (bool)OrderedFoods.Contains(soupFood);
            orderinfo.HasRice = (bool)RiceChoose.IsChecked;

            MainWindow.orderInfo = orderinfo;
            PayWayPage page = new PayWayPage();
            
            PayWayPage payPage = new PayWayPage();
            mFrame.Content = payPage;
        }

        private void FoodCheckBox1_Click(object sender, RoutedEventArgs e)
        {
            int num = 1;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
            var price = 0.0f;
            foreach (Food f in OrderedFoods)
            {
                price += f.FoodPrice;
            }
            TextSumPrice.Text = price.ToString();
        }

        private void FoodCheckBox2_Click(object sender, RoutedEventArgs e)
        {
            int num = 2;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
            var price = 0.0f;
            foreach (Food f in OrderedFoods)
            {
                price += f.FoodPrice;
            }
            TextSumPrice.Text = price.ToString();
        }

        private void FoodCheckBox3_Click(object sender, RoutedEventArgs e)
        {
            int num = 3;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
            var price = 0.0f;
            foreach (Food f in OrderedFoods)
            {
                price += f.FoodPrice;
            }
            TextSumPrice.Text = price.ToString();
        }

        private void FoodCheckBox4_Click(object sender, RoutedEventArgs e)
        {
            int num = 4;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
            var price = 0.0f;
            foreach (Food f in OrderedFoods)
            {
                price += f.FoodPrice;
            }
            TextSumPrice.Text = price.ToString();
        }

        private void FoodCheckBox5_Click(object sender, RoutedEventArgs e)
        {
            int num = 5;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
            var price = 0.0f;
            foreach (Food f in OrderedFoods)
            {
                price += f.FoodPrice;
            }
            TextSumPrice.Text = price.ToString();
        }

        private void FoodCheckBox6_Click(object sender, RoutedEventArgs e)
        {
            int num = 6;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
            var price = 0.0f;
            foreach (Food f in OrderedFoods)
            {
                price += f.FoodPrice;
            }
            TextSumPrice.Text = price.ToString();
        }

        private void FoodCheckBox7_Click(object sender, RoutedEventArgs e)
        {
            int num = 7;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
            var price = 0.0f;
            foreach (Food f in OrderedFoods)
            {
                price += f.FoodPrice;
            }
            TextSumPrice.Text = price.ToString();
        }

        private void FoodCheckBox8_Click(object sender, RoutedEventArgs e)
        {
            int num = 8;
            CheckBox box = sender as CheckBox;
            Food food = FoodManager.FoodCont.Find(f =>
            {
                return (f.FoodId == num);
            });
            if ((bool)box.IsChecked)
            {
                if (!OrderedFoods.Contains(food))
                {
                    OrderedFoods.Add(food);
                }
            }
            else
            {
                if (OrderedFoods.Contains(food))
                {
                    OrderedFoods.Remove(food);
                }
            }
             var price = 0.0f;
            foreach(Food f in OrderedFoods)
            {
                price += f.FoodPrice;                
            }
            TextSumPrice.Text = price.ToString();
        }

        private void RiceChoose_Click(object sender, RoutedEventArgs e)
        {
            if((bool)RiceChoose.IsChecked)
            {
                RiceChoose.Content = "米饭一份";
            }
            else
            {
                RiceChoose.Content = "不要米饭";
            }
        }
    }
}
