using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factoryA = new FactoryA();
            var productA = factoryA.CreateProduct();
            productA.ShowName();

            IFactory factoryB = new FactoryB();
            var productB = factoryB.CreateProduct();
            productB.ShowName();

            Console.ReadKey();
        }
    }

    //抽象产品
    public interface IProduct
    {
        void ShowName();
    }

    //具体产品
    public class ProductA : IProduct
    {
        public void ShowName()
        {
            Console.WriteLine("我是产品A");
        }
    }

    public class ProductB : IProduct
    {
        public void ShowName()
        {
            Console.WriteLine("我是产品B");
        }
    }


    //抽象工厂
    public interface IFactory
    {
        IProduct CreateProduct();
    }

    //具体工厂
    public class FactoryA : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductA();
        }
    }

    public class FactoryB : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductB();
        }
    }


}
