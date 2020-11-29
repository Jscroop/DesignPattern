using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var carBuilder = new CarBuilder();
            var director = new Director(carBuilder);
            director.Construct();
            Console.ReadKey();
        }
    }

    //产品角色
    public class Product
    {
        public string Name { get; set; } = "xx汽车";
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string PartC { get; set; }
    }

    //抽象建造者
    public abstract class Builder
    {
        protected Product Product = new Product();

        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();

        public Product GetResult()
        {
            return Product;
        }
    }

    //具体构建者
    public class CarBuilder : Builder
    {
        public override void BuildPartA()
        {
            Console.WriteLine("PartA已构建！");
        }

        public override void BuildPartB()
        {
            Console.WriteLine("PartB已构建！");
        }

        public override void BuildPartC()
        {
            Console.WriteLine("PartC已构建！");
        }
    }

    //指挥者
    public class Director
    {
        private readonly Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();

            var product = _builder.GetResult();
            Console.WriteLine($"成功生产出一个{product.Name}");
        }
    }



}
