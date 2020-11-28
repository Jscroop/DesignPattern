using System;

namespace Singleton
{
    class Program
    {
        static void Main()
        {
            var t1 = Singleton2.GetInstance();
            var t2 = Singleton2.GetInstance();
            var t3 = Singleton2.GetInstance();

            Console.WriteLine(t1.GetHashCode() + "~" + t2.GetHashCode() + "~" + t3.GetHashCode());
        }
    }

    //1.静态变量_饿汉式_使用Singleton时加载
    public class Singleton1
    {
        private static readonly Singleton1 Instance = new Singleton1();

        private Singleton1() { }

        public static Singleton1 GetInstance() => Instance;
    }

    //2、静态变量_懒汉式_调用GetInstance方法时加载
    public class Singleton2
    {
        private static Singleton2 _instance;

        private Singleton2() { }

        public static Singleton2 GetInstance() => _instance ??= new Singleton2();
    }

    //3、双空判断加锁_懒汉式
    public class Singleton3
    {
        private static Singleton3 _instance;

        private static readonly object Obj = new object();

        public static Singleton3 GetInstance()
        {
            if (_instance == null)
            {
                lock (Obj)
                {
                    _instance ??= new Singleton3();
                }
            }

            return _instance;
        }
    }

    //泛型单例
    public class GenericSingleton<T> where T : class, new()
    {
        private static T _instance;

        private static readonly object Obj = new object();

        public static T GetInstance()
        {
            if (_instance == null)
            {
                lock (Obj)
                {
                    _instance ??= Activator.CreateInstance(typeof(T), true) as T;
                }
            }

            return _instance;
        }
    }




}

