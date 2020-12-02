using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<ContactPerson>
            {
                new ContactPerson("张三","13xxxxxxxxx"),
                new ContactPerson("李四","18xxxxxxxxx"),
                new ContactPerson("王五","17xxxxxxxxx")
            };
            var mobile = new Mobile(list);
            mobile.DisplayPhoneBook();

            //备份通讯录
            var mementoManage = new MementoManage();
            string key = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            mementoManage.ContactMementoes.Add(DateTime.Now.ToString(CultureInfo.InvariantCulture), mobile.CreateMemento());
            Console.WriteLine($"==={key}：通讯录已备份===");

            //移除第一个联系人
            Console.WriteLine("----移除联系人----");
            mobile.GetPhoneBook().RemoveAt(0);
            mobile.DisplayPhoneBook();

            Thread.Sleep(2000);
            string key2 = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            mementoManage.ContactMementoes.Add(DateTime.Now.ToString(CultureInfo.InvariantCulture), mobile.CreateMemento());
            Console.WriteLine($"==={key2}：通讯录已备份===");

            //再移除一个联系人
            Console.WriteLine("----移除联系人----");
            mobile.GetPhoneBook().RemoveAt(0);
            mobile.DisplayPhoneBook();

            //恢复通讯录
            Console.WriteLine($"----恢复到最后一次通讯录备份：{mementoManage.ContactMementoes.LastOrDefault().Key}----");
            mobile.RestoreMemento(mementoManage.ContactMementoes.LastOrDefault().Value);

            mobile.DisplayPhoneBook();

            Console.ReadLine();
        }
    }

    //始发者
    public class ContactPerson
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public ContactPerson(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    //备忘录
    public class ContactMemento
    {
        private readonly List<ContactPerson> _backupContactPersons;

        public ContactMemento(List<ContactPerson> backupContactPersons)
        {
            _backupContactPersons = backupContactPersons;
        }
        public List<ContactPerson> GetMemento()
        {
            return _backupContactPersons;
        }
    }

    //管理者
    public class Mobile
    {
        private List<ContactPerson> _contactPersons;

        public Mobile(List<ContactPerson> contactPersons)
        {
            _contactPersons = contactPersons;
        }

        public List<ContactPerson> GetPhoneBook()
        {
            return _contactPersons;
        }

        public ContactMemento CreateMemento()
        {
            return new ContactMemento(new List<ContactPerson>(_contactPersons));
        }

        public void RestoreMemento(ContactMemento memento)
        {
            _contactPersons = memento.GetMemento();
        }

        public void DisplayPhoneBook()
        {
            Console.WriteLine($"共有{_contactPersons.Count}位联系人，联系人列表如下：");
            foreach (var contact in _contactPersons)
            {
                Console.WriteLine($"姓名：{contact.Name}，电话：{contact.PhoneNumber}");
            }
        }
    }

    //管理备忘录
    public class MementoManage
    {
        public Dictionary<string, ContactMemento> ContactMementoes { get; set; }
        public MementoManage()
        {
            ContactMementoes = new Dictionary<string, ContactMemento>();
        }
    }

}
