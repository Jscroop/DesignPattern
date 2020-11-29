using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            //都可以充电
            var usbLine = new UsbLine();
            usbLine.Charge();

            //对苹果充电线适配后进行充电
            var lightingLineAdapter = new UsbLightingLineAdapter();
            lightingLineAdapter.Charging();
        }
    }

    //目标抽象类
    public interface IChargingLine
    {
        void Charging();
    }

    //适配者类
    public class UsbLine
    {
        public void Charge()
        {
            Console.WriteLine("为设备充电!");
        }
    }

    //适配器类
    public class UsbLightingLineAdapter : UsbLine, IChargingLine
    {
        public void Charging()
        {
            Console.WriteLine("对苹果数据线进行适配");
            Charge();
        }
    }



}
