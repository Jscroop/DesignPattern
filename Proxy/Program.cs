using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxyBuyer = new ProxyBuyer();
            var price = proxyBuyer.Buy("小明", "PS5");
            var proxyPrice = proxyBuyer.GetCheaperPrice(price);
            Console.WriteLine($"代理价格是{proxyPrice}");
            Console.ReadKey();
        }
    }

    //抽象主题
    public interface IBuyer
    {
        double Buy(string userName, string goodsName);
    }

    //真实主题
    public class Buyer : IBuyer
    {
        public double Price { get; set; }

        public double Buy(string userName, string goodsName)
        {
            Console.Write($"{userName}购买{goodsName}");
            Price = 8000;//模拟获得价格
            return Price;
        }
    }

    //代理主题-打九折
    public class ProxyBuyer : IBuyer
    {
        private readonly Buyer _buyer = new Buyer();

        public double Buy(string userName, string goodsName)
        {
            return _buyer.Buy(userName, goodsName);
        }

        public double GetCheaperPrice(double price)
        {
            return price * 0.9;
        }
    }


}
