using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var productA = SimpleFactory.GetProduct(ProductType.ProductA);
            productA?.Product();

            var productB = SimpleFactory.GetProduct(ProductType.ProductB);
            productB?.Product();

            var productC = SimpleFactory.GetProduct(ProductType.ProductC);
            productC?.Product();

            Console.ReadKey();
        }
    }

    //抽象产品
    public interface IProduct
    {
        void Product();
    }

    //具体产品
    public class ProductA : IProduct
    {
        public ProductA()
        {
            Console.WriteLine("开始生产产品A！");
        }

        public void Product()
        {
            Console.WriteLine("产品A生产成功！");
        }
    }

    //具体产品
    public class ProductB : IProduct
    {
        public ProductB()
        {
            Console.WriteLine("开始生产产品B！");
        }
        public void Product()
        {
            Console.WriteLine("产品B生产成功!");
        }
    }

    //具体产品
    public class ProductC : IProduct
    {
        public ProductC()
        {
            Console.WriteLine("开始生产产品C！");
        }

        public void Product()
        {
            Console.WriteLine("产品C生产成功!");
        }
    }

    //生产工厂
    public static class SimpleFactory
    {
        public static IProduct GetProduct(ProductType productType)
        {
            IProduct product = null;

            switch (productType)
            {
                case ProductType.ProductA:
                    product = new ProductA();
                    break;
                case ProductType.ProductB:
                    product = new ProductB();
                    break;
                case ProductType.ProductC:
                    product = new ProductC();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(product), product, "产品不存在，请确认!");
            }

            return product;
        }
    }

    public enum ProductType
    {
        ProductA,
        ProductB,
        ProductC
    }
}
