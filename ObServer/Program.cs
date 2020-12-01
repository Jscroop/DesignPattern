using System;
using System.Collections.Generic;

namespace ObServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var observer1 = new Observer("王师傅");
            var observer2 = new Observer("李师傅");
            var observer3 = new Observer("钱师傅");
            var target = new Target("北京路", "上海路");
            
            target.Join(observer1);
            target.Join(observer2);
            target.Join(observer3);

            target.NotifyObserver();

            Console.ReadKey();
        }
    }

    //抽象观察者
    public interface IObserver
    {
        public string Name { get; set; }
        void TryGetOrder();//尝试获取订单
    }

    //具体观察者-滴滴司机
    public class Observer : IObserver
    {
        public string Name { get; set; }

        public Observer(string name)
        {
            Name = name;
        }

        public void TryGetOrder()
        {
            Console.WriteLine($"{Name}尝试获取订单...");
        }
    }

    //抽象目标
    public abstract class AbstractTarget
    {
        protected IList<IObserver> ObserverList = new List<IObserver>();//观察者集合

        public void Join(IObserver observer)
        {
            ObserverList.Add(observer);
        }

        public abstract void NotifyObserver();
    }

    //具体目标-订单
    public class Target : AbstractTarget
    {
        public Target(string startPlace, string endPlace)
        {
            Console.WriteLine($"来新单啦,从{startPlace}到{endPlace}");
        }

        public override void NotifyObserver()
        {
            foreach (var observer in ObserverList)
            {
                observer.TryGetOrder();
            }
        }
    }

}
