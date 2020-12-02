using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Mediator();
            var buyer = new Buyer(mediator);
            var seller = new Seller(mediator);

            mediator.Buyer = buyer;
            mediator.Seller = seller;
            var buyerRequirement = mediator.GetBuyerRequirement();
            var sellerRequirement = mediator.GetSellerRequirement();

            Console.WriteLine($"现有一买家，要求为:{buyerRequirement}，现有一卖家，条件为:{sellerRequirement}");

            Console.ReadKey();
        }
    }

    //抽象同事
    public abstract class Role
    {
        protected AbstractMediator Mediator;

        protected Role(AbstractMediator mediator)
        {
            Mediator = mediator;
        }
    }

    //具体同事类1
    public class Seller : Role
    {
        private static readonly string Requirement = "90平学区房，售价200W";

        public Seller(AbstractMediator mediator) : base(mediator)
        {
        }

        public string GetRequirement()
        {
            return Requirement;
        }
    }

    //具体同事类2
    public class Buyer : Role
    {
        private static readonly string Requirement = "学区房，售价200W左右";

        public Buyer(AbstractMediator mediator) : base(mediator)
        {
        }

        public string GetRequirement()
        {
            return Requirement;
        }
    }


    //抽象中介
    public abstract class AbstractMediator
    {
        public Buyer Buyer { get; set; }
        public Seller Seller { get; set; }

        public abstract string GetBuyerRequirement();

        public abstract string GetSellerRequirement();
    }

    //具体中介
    public class Mediator : AbstractMediator
    {
        public override string GetBuyerRequirement()
        {
            return Buyer.GetRequirement();
        }

        public override string GetSellerRequirement()
        {
            return Seller.GetRequirement();
        }
    }
}
