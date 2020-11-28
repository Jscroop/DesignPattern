using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFactory.Create(Product.ProductA);
            SimpleFactory.Create(Product.ProductB);
            SimpleFactory.Create(Product.ProductC);
            Console.ReadKey();
        }
    }

    public static class SimpleFactory
    {
        public static void Create(Product product)
        {
            switch (product)
            {
                case Product.ProductA:
                    Console.WriteLine("产品A生产成功！");
                    break;
                case Product.ProductB:
                    Console.WriteLine("产品B生产成功!");
                    break;
                case Product.ProductC:
                    Console.WriteLine("产品C生产成功!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(product), product, "产品不存在，请确认!");
            }
        }
    }

    public enum Product
    {
        ProductA,
        ProductB,
        ProductC
    }
}
