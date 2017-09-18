using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void DelegateOfSumMethod(int num1, int num2);
   
    class Program
    {
        static void Main(string[] args)
        {
            DelegateOfSumMethod d = new DelegateOfSumMethod(SumOfNumbers);
            d(5, 15);
            Console.ReadKey();

            //Employee regarding statements
            List<Employee> list = new List<Employee>();
            list.Add(new Employee(){Id = 101 , name="Rohith" , salary = 10000 , exp = 12  });
            list.Add(new Employee() { Id = 102, name = "Kumar", salary = 3000, exp = 2 });
            list.Add(new Employee() { Id = 103, name = "Nitya", salary = 4000, exp = 5 });
            list.Add(new Employee() { Id = 104, name = "Ram", salary = 3800, exp = 4 });
            list.Add(new Employee() { Id = 105, name = "Priyanka", salary = 8000, exp = 6 });

            PromoteDelegate pe = new PromoteDelegate(Promote);
            PromoteDelegate p2 = new PromoteDelegate(PromoteSalary);
            pe += p2; //multicaste delegate
            Employee.promoteEmployee(list, pe);
            Console.ReadKey();
        }

        public static bool Promote(Employee emp)
        {
            if (emp.exp >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool PromoteSalary(Employee emp)
        {
            if(emp.salary>=5000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SumOfNumbers(int a, int b)
        {
            int result = 0;
            result = a + b;
            Console.WriteLine("The Sum of the numbers is: " + result);
            
        }
    }

    public delegate bool PromoteDelegate(Employee emp);
    public class Employee
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int exp{ get; set; }

        public static void promoteEmployee(List<Employee> emplist , PromoteDelegate isPromotable)
        {
            foreach(Employee employee  in emplist)
            {
                if (isPromotable(employee))
                {
                    Console.WriteLine("Promote the employee with Id:" + employee.Id + " and Name:" + employee.name);
                } 
            }
        }
    }
}
