using System;
using System.Collections;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            // 获取享元工厂
            var shoesFactory = ShoesFactory.GetInstance();

            var blackShoes1 = shoesFactory.GetShoes("black");
            var blackShoes2 = shoesFactory.GetShoes("black");
            Console.WriteLine($"两双黑鞋是否相同：{ReferenceEquals(blackShoes1, blackShoes2)}");

            var whiteShoes1 = shoesFactory.GetShoes("white");
            var whiteShoes2 = shoesFactory.GetShoes("white");
            Console.WriteLine($"两双白鞋是否相同：{ReferenceEquals(whiteShoes1, whiteShoes2)}");

            Console.ReadKey();
        }
    }

    //抽象享元
    public abstract class Shoes
    {
        public abstract string GetColor();
    }

    //具体享元1
    public class BlackShoes : Shoes
    {
        public override string GetColor()
        {
            return "黑色";
        }
    }

    //具体享元2
    public class WhiteShoes : Shoes
    {
        public override string GetColor()
        {
            return "白色";
        }
    }

    //享元工厂
    public class ShoesFactory
    {
        //单例实现享元
        private static ShoesFactory _instance;

        public static ShoesFactory GetInstance() => _instance ??= new ShoesFactory();

        //存储享元对象充当享元池
        private static Hashtable _ht;
        private ShoesFactory()
        {
            _ht = new Hashtable();
            Shoes blackShoes = new BlackShoes();
            _ht.Add("black", blackShoes);
            Shoes whiteShoes = new WhiteShoes();
            _ht.Add("white", whiteShoes);
        }

        public Shoes GetShoes(string color)
        {
            Shoes shoes = _ht[color] as Shoes;
            return shoes;
        }

    }



}
