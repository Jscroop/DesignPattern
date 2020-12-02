using System;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Collection();
            var iterator = list.GetIterator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.GetCurrent());
                iterator.Next();
            }

            Console.ReadKey();
        }
    }

    //抽象迭代器
    public interface IIterator
    {
        bool MoveNext();
        object GetCurrent();
        void Next();
    }

    //抽象集合
    public interface ICollection
    {
        IIterator GetIterator();
    }

    //具体集合
    public class Collection : ICollection
    {
        private readonly string[] _collection;
        public Collection()
        {
            _collection = new[] { "A", "B", "C", "D" };
        }

        public IIterator GetIterator()
        {
            return new Iterator(this);
        }

        public int Length => _collection.Length;

        public string GetElement(int index)
        {
            return _collection[index];
        }
    }



    // 具体迭代器类
    public class Iterator : IIterator
    {
        private readonly Collection _list;
        private int _index;

        public Iterator(Collection list)
        {
            _list = list;
            _index = 0;
        }

        public bool MoveNext()
        {
            return _index < _list.Length;
        }

        public object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
        }
    }

}
