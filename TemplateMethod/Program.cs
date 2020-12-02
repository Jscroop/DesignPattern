using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var hpComputer = new AssembleHpComputer();
            var dellComputer = new AssembleDellComputer();

            hpComputer.Assemble();
            dellComputer.Assemble();

            Console.ReadKey();
        }
    }

    //抽象类
    public abstract class AssembleComputer
    {
        public abstract void BuildMainFramePart();

        public abstract void BuildScreenPart();

        public abstract void BuildInputPart();
        public void Assemble()
        {
            BuildMainFramePart();
            BuildScreenPart();
            BuildInputPart();
        }
    }

    //具体子类1
    public class AssembleHpComputer : AssembleComputer
    {
        public override void BuildMainFramePart()
        {
            Console.WriteLine("组装HP电脑的主板");
        }

        public override void BuildScreenPart()
        {
            Console.WriteLine("组装HP电脑的显示器");
        }

        public override void BuildInputPart()
        {
            Console.WriteLine("组装HP电脑的键盘鼠标");
        }
    }

    //具体子类2
    public class AssembleDellComputer : AssembleComputer
    {
        public override void BuildMainFramePart()
        {
            Console.WriteLine("组装Dell电脑的主板");
        }

        public override void BuildScreenPart()
        {
            Console.WriteLine("组装Dell电脑的显示器");
        }

        public override void BuildInputPart()
        {
            Console.WriteLine("组装Dell电脑的键盘鼠标");
        }
    }
}
