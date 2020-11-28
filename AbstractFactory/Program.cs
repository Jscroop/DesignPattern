using System;
using System.Threading;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var bmwFactory = new BmwFactory();
            var bmwBus = bmwFactory.CreateBus();
            bmwBus.Product();
            var bmwCar = bmwFactory.CreateCar();
            bmwCar.Product();

            var audiFactory = new AudiFactory();
            var audiBus = audiFactory.CreateBus();
            audiBus.Product();
            var audiCar = audiFactory.CreateCar();
            audiCar.Product();
            Console.ReadKey();
        }
    }

    //抽象产品1
    public interface ICar
    {
        void Product();
    }
    //抽象产品2
    public interface IBus
    {
        void Product();
    }

    //抽象工厂
    public interface IAbstractFactory
    {
        ICar CreateCar();
        IBus CreateBus();
    }

    //具体产品1
    public class BmwCar : ICar
    {
        public void Product()
        {
            Console.WriteLine("生产出了一辆宝马轿车");
        }
    }
    //具体产品2
    public class BmwBus : IBus
    {
        public void Product()
        {
            Console.WriteLine("生产出了一辆宝马公交");
        }
    }
    //具体产品1
    public class AudiCar : ICar
    {
        public void Product()
        {
            Console.WriteLine("生产出了一辆奥迪轿车");
        }
    }
    //具体产品2
    public class AudiBus : IBus
    {
        public void Product()
        {
            Console.WriteLine("生产出了一辆奥迪公交");
        }
    }

    //具体工厂1
    public class BmwFactory : IAbstractFactory
    {
        public IBus CreateBus()
        {
            return new BmwBus();
        }

        public ICar CreateCar()
        {
            return new BmwCar();
        }
    }
    //具体工厂2
    public class AudiFactory : IAbstractFactory
    {
        public IBus CreateBus()
        {
            return new AudiBus();
        }

        public ICar CreateCar()
        {
            return new AudiCar();
        }
    }

}
