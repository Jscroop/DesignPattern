using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new Facade();
            facade.FileEncrypt("xxx", "zzz");

            Console.ReadKey();
        }
    }

    //子系统A
    public class SystemA
    {
        public void GetFile(string filePath)
        {
            Console.WriteLine($"通过{filePath}获取到文件...");
        }
    }

    //子系统B
    public class SystemB
    {
        public void FileEncrypt(string fileName)
        {
            Console.WriteLine($"{fileName}加密成功...");
        }
    }

    //外观角色
    public class Facade
    {
        private readonly SystemA _systemA;
        private readonly SystemB _systemB;

        public Facade()
        {
            _systemA = new SystemA();
            _systemB = new SystemB();
        }

        public void FileEncrypt(string filePath, string fileName)
        {
            _systemA.GetFile(filePath);
            _systemB.FileEncrypt(fileName);
        }
    }

}
