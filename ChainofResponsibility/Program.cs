using System;

namespace ChainofResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseRequest request = new PurchaseRequest(20000, "xxxx0001");
            AbstractHandler jack = new President("Jack", null);
            AbstractHandler andy = new Director("Andy", jack);
            andy.ProcessRequest(request);

            Console.ReadKey();
        }
    }

    //请求类-模拟采购物品
    public class PurchaseRequest
    {
        // 采购金额
        public double Price { get; set; }
        // 采购单编号
        public string PurchaseNo { get; set; }

        public PurchaseRequest(double price, string purchaseNo)
        {
            Price = price;
            PurchaseNo = purchaseNo;
        }
    }

    //抽象处理者
    public abstract class AbstractHandler
    {
        public string Name { get; set; }//当前处理者

        public AbstractHandler NextHandler { get; set; }//后续处理者

        protected AbstractHandler(string name, AbstractHandler nextHandler)
        {
            Name = name;
            NextHandler = nextHandler;
        }

        public abstract void ProcessRequest(PurchaseRequest request);
    }

    //具体处理者1
    public class Director : AbstractHandler
    {
        public Director(string name, AbstractHandler nextHandler) : base(name, nextHandler)
        {
        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            Console.WriteLine($"经理 {Name} 审批采购单：{request.PurchaseNo}，金额：{request.Price} 元");

            if (request.Price > 10000)
            {
                NextHandler.ProcessRequest(request);
            }
        }
    }

    //具体处理者2
    public class President : AbstractHandler
    {
        public President(string name, AbstractHandler nextHandler) : base(name, nextHandler)
        {
        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            Console.WriteLine($"总经理 {Name} 审批采购单：{request.PurchaseNo}，金额：{request.Price} 元");
        }
    }
}
