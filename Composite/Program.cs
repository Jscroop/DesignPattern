using System;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var department1 = new Department("软件部");
            var department2 = new Department("项目部");

            var employee1 = new Employee("员工A");
            var employee2 = new Employee("员工B");
            var employee3 = new Employee("员工C");
            var employee4 = new Employee("员工D");

            department1.Add(employee1);
            department1.Add(employee2);

            department2.Add(employee3);
            department2.Add(employee4);

            department1.ShowMsg();
            department2.ShowMsg();

            Console.ReadKey();
        }
    }


    //根节点
    public abstract class Organization
    {
        public abstract void Add(Organization org);
        public abstract void Remove(Organization org);
        public abstract Organization GetChild(int index);
        public abstract void ShowMsg();
    }

    //树枝节点
    public class Department : Organization
    {
        private readonly string _name;

        public Department(string name)
        {
            _name = name;
        }

        private readonly IList<Organization> _organizationList = new List<Organization>();

        public override void Add(Organization org)
        {
            _organizationList.Add(org);
        }

        public override void Remove(Organization org)
        {
            _organizationList.Remove(org);
        }

        public override Organization GetChild(int index)
        {
            return _organizationList[index];
        }

        public override void ShowMsg()
        {
            Console.WriteLine($"部门名称：{_name}");

            foreach (var organization in _organizationList)
            {
                organization.ShowMsg();
            }

            Console.WriteLine("----------------");
        }
    }

    //叶子节点
    public class Employee : Organization
    {
        private readonly string _name;

        public Employee(string name)
        {
            _name = name;
        }

        public override void Add(Organization org)
        {
            Console.WriteLine("叶子节点不支持添加节点！");
        }

        public override void Remove(Organization org)
        {
            Console.WriteLine("叶子节点不支持移出节点！");
        }

        public override Organization GetChild(int index)
        {
            Console.WriteLine("叶子节点不支持查询子节点！");
            return null;
        }

        public override void ShowMsg()
        {
            Console.WriteLine($"员工名称：{_name}");
        }
    }
}
