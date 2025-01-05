using System;

namespace assi_oop_02
{
    #region Q04 
    public enum SecurityPrivilege
    {
        Guest = 1,
        Developer = 2,
        Secretary = 3,
        DBA = 4
    }
    #endregion

    #region Q01 
    public class Employee
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private int SecurityLevel { get; set; }
        private decimal Salary { get; set; }
        private DateTime HireDate { get; set; }
        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set
            {
                if (value == "M" || value == "F")
                {
                    _gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Gender. Please use 'M' for Male or 'F' for Female.");
                }
            }
        }

        public SecurityPrivilege Privilege { get; set; }

        public Employee(int id, string name, int securityLevel, decimal salary, DateTime hireDate, string gender, SecurityPrivilege privilege)
        {
            ID = id;
            Name = name;
            SecurityLevel = securityLevel;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
            Privilege = privilege;
        }

        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Security Level: {SecurityLevel}");
            Console.WriteLine($"Salary: {Salary:C}");
            Console.WriteLine($"Hire Date: {HireDate:yyyy-MM-dd}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Privilege: {Privilege}");
        }

        public void UpdateSalary(decimal newSalary)
        {
            Salary = newSalary;
            Console.WriteLine($"Salary updated to: {Salary:C}");
        }

        public void Promote(int newSecurityLevel)
        {
            if (newSecurityLevel > SecurityLevel)
            {
                SecurityLevel = newSecurityLevel;
                Console.WriteLine($"{Name} has been promoted to Security Level {SecurityLevel}.");
            }
            else
            {
                Console.WriteLine("Invalid promotion. New security level must be higher than the current level.");
            }
        }
    }
    #endregion

    #region Q02 
    public class HiringDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public void DisplayHiringDate()
        {
            Console.WriteLine($"Hiring Date: {Day:D2}/{Month:D2}/{Year}");
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Q01 
                Employee emp = new Employee(1, "Sayed Mohamed", 3, 60000.00m, new DateTime(2020, 5, 1), "M", SecurityPrivilege.Developer);

                Console.WriteLine("Employee Details:");
                emp.DisplayEmployeeInfo();

                Console.WriteLine("\nUpdating Salary...");
                emp.UpdateSalary(55000.00m);

                Console.WriteLine("\nPromoting Employee...");
                emp.Promote(5);

                Console.WriteLine("\nFinal Employee Details:");
                emp.DisplayEmployeeInfo();
                #endregion

                #region Q02 
                HiringDate hireDate = new HiringDate(5, 5, 2020);

                Console.WriteLine("\nHiring Date Details:");
                hireDate.DisplayHiringDate();
                #endregion

                #region Q03 =
                Console.WriteLine("\nTesting invalid gender:");
                emp.Gender = "X";
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
