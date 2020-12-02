using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var mt = new MovieTicket();
            var originalPrice = 60.0;

            mt.Price = originalPrice;
            Console.WriteLine($"原始票价：{originalPrice}");

            var student = new StudentDiscount();
            var studentPrice = student.Calculate(originalPrice);
            Console.WriteLine($"学生票价：{studentPrice}");

            var vip = new VipDiscount();
            var vipPrice = vip.Calculate(originalPrice);
            Console.WriteLine($"VIP票价：{vipPrice}");

            var child = new ChildrenDiscount();
            var childPrice = child.Calculate(originalPrice);
            Console.WriteLine($"儿童票价：{childPrice}");

            Console.ReadKey();
        }
    }

    //抽象策略类
    public interface IDiscount
    {
        double Calculate(double price);
    }

    //具体策略类1
    public class StudentDiscount : IDiscount
    {
        public double Calculate(double price)
        {
            return price * 0.8;
        }
    }

    //具体策略类2
    public class VipDiscount : IDiscount
    {
        public double Calculate(double price)
        {
            return price * 0.5;
        }
    }

    //具体策略类3
    public class ChildrenDiscount : IDiscount
    {
        public double Calculate(double price)
        {
            return price - 10;
        }
    }

    //环境类
    public class MovieTicket
    {
        private double _price;
        private IDiscount _discount;

        public double Price
        {
            get => _discount.Calculate(_price);
            set => _price = value;
        }

        public IDiscount Discount
        {
            set => _discount = value;
        }
    }
}
