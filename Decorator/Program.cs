using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            //毛坯房装修
            var withoutDecoratorHouse = new WithoutDecoratorHouse();
            var decoratorHouse = new ModelHouse(withoutDecoratorHouse);
            decoratorHouse.ShowMsg();

            Console.ReadKey();
        }
    }

    //抽象构建
    public abstract class AbstractHouse
    {
        public abstract void ShowMsg();
    }

    //具体构建
    public class WithoutDecoratorHouse : AbstractHouse
    {
        public override void ShowMsg()
        {
            Console.WriteLine("当前为毛坯房...");
        }
    }

    //抽象装饰
    public class DecoratorHouse : AbstractHouse
    {
        private readonly AbstractHouse _house;

        public DecoratorHouse(AbstractHouse house)
        {
            _house = house;
        }
        public override void ShowMsg()
        {
            _house.ShowMsg();
        }
    }

    //具体装饰
    public class ModelHouse : DecoratorHouse
    {
        public ModelHouse(AbstractHouse house) : base(house)
        {
        }

        private void AddDecorator()
        {
            Console.WriteLine("添加部分装饰...当前为新房！");
        }

        public override void ShowMsg()
        {
            base.ShowMsg();
            AddDecorator();
        }
    }

}
