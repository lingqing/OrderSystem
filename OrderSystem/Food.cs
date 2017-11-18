using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
     public  class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public float FoodPrice { get; set; }
        public string CoverImage { get; set; }
    }
    public class FoodManager
    {
        public static List<Food> FoodCont = new List<Food>();
        public FoodManager()
        {
            FoodCont.Add(new Food { FoodId = 1, FoodName = "红烧肉", FoodPrice = 0.01f, CoverImage = "Assets/hong.jpg" });
            FoodCont.Add(new Food { FoodId = 2, FoodName = "干煸豆角", FoodPrice = 0.01f, CoverImage = "Assets/干煸豆角.jpg" });
            FoodCont.Add(new Food { FoodId = 3, FoodName = "宫保鸡丁", FoodPrice = 0.01f, CoverImage = "Assets/宫保鸡丁.jpg" });
            FoodCont.Add(new Food { FoodId = 4, FoodName = "拍黄瓜", FoodPrice = 0.01f, CoverImage = "Assets/拍黄瓜.jpg" });
            FoodCont.Add(new Food { FoodId = 5, FoodName = "酸辣土豆丝", FoodPrice = 0.01f, CoverImage = "Assets/酸辣土豆丝.jpg" });
            FoodCont.Add(new Food { FoodId = 6, FoodName = "西红柿炒鸡蛋", FoodPrice = 0.01f, CoverImage = "Assets/西红柿炒鸡蛋.jpg" });
            FoodCont.Add(new Food { FoodId = 7, FoodName = "小葱拌豆腐", FoodPrice = 0.01f, CoverImage = "Assets/小葱拌豆腐.jpg" });
            FoodCont.Add(new Food { FoodId = 8, FoodName = "鱼香肉丝", FoodPrice = 0.01f, CoverImage = "Assets/鱼香肉丝.jpg" });
        }
        
        public static List<Food> GetFoodStatic()
        {
            FoodCont.Clear();
            FoodCont.Add(new Food { FoodId = 1, FoodName = "红烧肉", FoodPrice = 0.01f, CoverImage = "Assets/hong.jpg" });
            FoodCont.Add(new Food { FoodId = 2, FoodName = "干煸豆角", FoodPrice = 0.01f, CoverImage = "Assets/干煸豆角.jpg" });
            FoodCont.Add(new Food { FoodId = 3, FoodName = "宫保鸡丁", FoodPrice = 0.01f, CoverImage = "Assets/宫保鸡丁.jpg" });
            FoodCont.Add(new Food { FoodId = 4, FoodName = "拍黄瓜", FoodPrice = 0.01f, CoverImage = "Assets/拍黄瓜.jpg" });
            FoodCont.Add(new Food { FoodId = 5, FoodName = "酸辣土豆丝", FoodPrice = 0.01f, CoverImage = "Assets/酸辣土豆丝.jpg" });
            FoodCont.Add(new Food { FoodId = 6, FoodName = "西红柿炒鸡蛋", FoodPrice = 0.01f, CoverImage = "Assets/西红柿炒鸡蛋.jpg" });
            FoodCont.Add(new Food { FoodId = 7, FoodName = "小葱拌豆腐", FoodPrice = 0.01f, CoverImage = "Assets/小葱拌豆腐.jpg" });
            FoodCont.Add(new Food { FoodId = 8, FoodName = "鱼香肉丝", FoodPrice = 0.01f, CoverImage = "Assets/鱼香肉丝.jpg" });
            return FoodCont;
        }        
    }
    public class OrderInfo
    {
        public string OrderName { get; set; }
        public float OrderPrice { get; set; }
        public List<int> OrderNum { set; get; }

        public bool HasRice;
        public bool HasSoup;
    }
}
