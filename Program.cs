using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 老師練習題
{
    //計算員工薪水
    internal class Program
    {
        static void Main(string[] args)
        {  //抽象類別不能new () ;所以不能寫new Engineer
            Employee employee = new Engineer() { Name = "Alan", Age = "18", MonthlySalary = 22000 };
            Employee sales = new Sales() { Name = "Kristy", Age = "26", MonthlySalary = 32000 };
            Employee salesManager = new SalesManger() { Name = "Becky", Age = "30", MonthlySalary = 38000 };

            decimal employeePay = employee.CalPay();
            decimal salesPay = sales.CalPay();
            decimal salesManagerPay = salesManager.CalPay();

            Console.WriteLine($"Employee pay: {employee.CalPay().ToString()}");
            Console.WriteLine($"Sales pay: {sales.CalPay()}");
            Console.WriteLine($"SalesManager pay: {salesManager.CalPay()}");
        }
    }
    abstract class Employee //抽象abstract 必需定義class
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public decimal MonthlySalary { get; set; }

        public virtual decimal CalOverTimePay(decimal hours)
        {
            return hours * 160;
        }

        public virtual decimal CalBonus(int yearsOfServices)
        {
            return yearsOfServices * 1000;
        }

        public abstract decimal CalPay(); //宣告抽象方法,但不能實作
        
    }
    class Engineer : Employee
    {
        public override decimal CalOverTimePay(decimal hours)
        {
            return hours * 160;
        }
        public override decimal CalBonus(int yearsOfServices)
        {
            if (yearsOfServices <= 2)
            {
                return yearsOfServices * 1000;
            }
            else
            {
                return yearsOfServices * 5000;
            }
        }

        public override decimal CalPay()
        {
            decimal overtimePay = CalOverTimePay(3);
            decimal bonus = CalBonus(2);
            decimal totalPay = MonthlySalary + overtimePay + bonus;

            return totalPay;
            //return MonthlySalary + CalBonus(2) + CalOverTimePay(3);
        }
    }

    class Sales : Employee
    {
        public override decimal CalOverTimePay(decimal hours)
        {
            return hours * 150;
        }
        public override decimal CalBonus(int yearsOfServices)
        {
            if (yearsOfServices > 3)
            {
                return yearsOfServices * 6000;
            }
            else
            {
                return yearsOfServices * 2000;
            }
        }
        public virtual decimal ManBonus(int membersOfSales)
        {
            return membersOfSales * 200;
        }

        public override decimal CalPay()
        {
            decimal overtimePay = CalOverTimePay(5);
            decimal bonus = CalBonus(2);
            decimal totalPay = MonthlySalary + overtimePay + bonus;

            return totalPay;
            //return MonthlySalary + CalOverTimePay(5) + CalBonus(5);
        }
    }
    class SalesManger : Sales
    {
        public override decimal CalOverTimePay(decimal hours)
        {
            return hours * 150;
        }
        public override decimal CalBonus(int yearsOfServices)
        {
            if (yearsOfServices > 3)
            {
                return yearsOfServices * 6000;
            }
            else
            {
                return yearsOfServices * 2000;
            }
        }
        public override decimal ManBonus(int membersOfSales)
        {
            return base.ManBonus(membersOfSales);
        }
        public override decimal CalPay()
        {
            return MonthlySalary + CalOverTimePay(5) + CalBonus(5) + ManBonus(3);
        }
    }
}

