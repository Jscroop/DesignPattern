using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee emp1 = new FullTimeEmployee("小王", 168);
            IEmployee emp2 = new FullTimeEmployee("小红", 168);
            IEmployee emp3 = new FullTimeEmployee("小明", 168);
            IEmployee emp4 = new PartTimeEmployee("王二", 120);
            IEmployee emp5 = new PartTimeEmployee("李四", 124);

            EmployeeList empList = new EmployeeList();
            empList.AddEmployee(emp1);
            empList.AddEmployee(emp2);
            empList.AddEmployee(emp3);
            empList.AddEmployee(emp4);
            empList.AddEmployee(emp5);

            Department dept = new HrDepartment();
            empList.Accept(dept);

            Console.ReadKey();
        }
    }

    //抽象元素-管理部门
    public interface IEmployee
    {
        void Process(Department dept);
    }

    //具体元素1-不同类型的员工
    public class FullTimeEmployee : IEmployee
    {
        public string Name { get; set; }
        public int WorkTime { get; set; }

        public FullTimeEmployee(string name, int workTime)
        {
            Name = name;
            WorkTime = workTime;
        }

        public void Process(Department dept)
        {
            dept.Visit(this);
        }
    }

    //具体元素类2-不同类型的员工
    public class PartTimeEmployee : IEmployee
    {
        public string Name { get; set; }
        public int WorkTime { get; set; }

        public PartTimeEmployee(string name, int workTime)
        {
            Name = name;
            WorkTime = workTime;
        }

        public void Process(Department dept)
        {
            dept.Visit(this);
        }
    }

    //抽象访问者
    public abstract class Department
    {
        //访问不同类型的具体元素
        public abstract void Visit(FullTimeEmployee employee);
        public abstract void Visit(PartTimeEmployee employee);
    }

    /// <summary>
    /// 具体访问者
    /// </summary>
    public class HrDepartment : Department
    {
        public override void Visit(PartTimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            Console.WriteLine($"临时员工 {employee.Name} 实际工作时间为：{workTime} 小时");
        }

        public override void Visit(FullTimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            Console.WriteLine($"正式员工 {employee.Name} 实际工作时间为：{workTime}小时");
        }
    }

    //对象结构
    public class EmployeeList
    {
        private readonly IList<IEmployee> _empList = new List<IEmployee>();

        public void AddEmployee(IEmployee emp)
        {
            _empList.Add(emp);
        }

        public void Accept(Department dept)
        {
            foreach (var emp in _empList)
            {
                emp.Process(dept);
            }
        }
    }


}
