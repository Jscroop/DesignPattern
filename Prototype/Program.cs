using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var computer = new Computer
            {
                MainBoard = "华硕Z490",
                Cpu = "i7-10700",
                Fan = "大霜塔",
                Ram = "芝奇幻光戟32G",
                Ssd = "三星Evo970",
                Electric = "酷冷至尊V1000",
                Case = "华硕太阳神"
            };

            //客户类创建新的对象
            for (int i = 0; i < 10; i++)
            {
                var gpu = $"用户{i}的Gpu";
                if (computer.Clone() is Computer cloneComputer)
                {
                    cloneComputer.Gpu = gpu;

                    ShowConf(cloneComputer);
                }
            }
        }

        private static void ShowConf(Computer cloneComputer)
        {
            Console.WriteLine($"主板:{cloneComputer.MainBoard},Cpu:{cloneComputer.Cpu},风扇:{cloneComputer.Fan},内存:{cloneComputer.Ram}，" +
                              $"固态:{cloneComputer.Ssd},电源:{cloneComputer.Electric},机箱:{cloneComputer.Case}，Gpu:{cloneComputer.Gpu}");
        }
    }

    public class Computer : ICloneable
    {
        //抽象原型
        public string MainBoard { get; set; }
        public string Cpu { get; set; }
        public string Fan { get; set; }
        public string Ram { get; set; }
        public string Ssd { get; set; }
        public string Electric { get; set; }
        public string Case { get; set; }
        public string Gpu { get; set; }

        //具体原型
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
