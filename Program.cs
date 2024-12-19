using System.Reflection;
using ClassLibrary1;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Day2_Task
{
    internal class Program
    {


        static void Main(string[] args)
        {
            employee[] employees = new employee[10];
            int employeeCount = 0;

            hireDate hireDate1 = new hireDate(2024, 12, 18);
            securityLevel security1=securityLevel.hr;
            employee emp1 = new employee(1,"Mona",25 ,500,security1, hireDate1,gender.Female,6500);
            employees[employeeCount++] = emp1;

            hireDate hireDate2 = new hireDate(2020, 10, 6);
            securityLevel security2 = securityLevel.admin;
            employee emp2 = new employee(1, "Alo", 30, 400, security2, hireDate2, gender.Male, 10000);
            employees[employeeCount++] = emp2;

            while (true)
            {
                Console.WriteLine("\nGood Morning, Please enter a choice: ");
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. Display all employees");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    employee newEmp = CreateEmployeeFromUserInput(employees);
                    employees[employeeCount++] = newEmp;
                    Console.WriteLine("Employee added successfully :)");
                }
                else if (choice == "2")
                {
                    //DisplayAllEmployees(employees, employeeCount);
                    Array.Sort(employees);

                    // Display sorted employees
                    Console.WriteLine("Employees sorted by hire date (oldest first):");
                    foreach (var emp in employees)
                    {
                        Console.WriteLine(emp);
                    }

                }
                else if (choice == "3")
                {
                    Console.WriteLine("Thanks for using our program, BYE!");
                    break;
                }
                
                
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }

        static employee CreateEmployeeFromUserInput(employee[] emp)
        {
            gender gender;
            securityLevel security;
            bool validInput = false;
            bool validInput2 = false;
            bool valid=true;
            int id;

            //Console.Write("Enter employee ID: ");
            //int id = int.Parse(Console.ReadLine());

            do
            {
                Console.Write("Enter employee ID: ");
                if (int.TryParse(Console.ReadLine(), out id)) // Validate input is a number
                {
                    valid = true;
                    foreach (var e in emp)
                    {
                        if (e != null && e.id == id) // Check if the ID exists in the array
                        {
                            Console.WriteLine("This ID already exists. Please enter a new ID.");
                            valid = false; // ID is not unique
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric ID.");
                    valid = false;
                }
            } while (!valid);


            Console.Write("Enter employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter employee age: ");
            int age = int.Parse(Console.ReadLine());
            while (age < 18 || age > 45)
            {
                Console.Write("Age should be between 18 and 45, Enter employee age: ");
                 age = int.Parse(Console.ReadLine());

            }

            Console.Write("Enter target: ");
            int target = int.Parse(Console.ReadLine());
            while (target < 300)
            {
                Console.Write("Target should be +300, Enter target again: ");
                target = int.Parse(Console.ReadLine());

            }

            //Console.Write("Enter Security Level, (hr), (admin),(officer): ");
            //securityLevel security = (securityLevel)Enum.Parse(typeof(securityLevel), Console.ReadLine(), true);

            do
            {
                Console.Write("Enter Security Level (hr, admin, officer): ");
                string input = Console.ReadLine();

                // Try to parse the input to a securityLevel enum
                if (Enum.TryParse(input, true, out security) && Enum.IsDefined(typeof(securityLevel), security))
                {
                    validInput = true; // Exit the loop if input is valid
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a valid security level (hr, admin, officer).");
                }
            } while (!validInput);

            Console.Write("Enter hire year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter hire month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter hire day: ");
            int day = int.Parse(Console.ReadLine());
            
            Console.Write("Enter employee salary: ");
            int salary = int.Parse(Console.ReadLine());
            while (salary < 6000 || salary>20000)
            {
                Console.Write("Salary should be beween 6k and 20k, enter valid number:");
                salary = int.Parse(Console.ReadLine());

            }

            //Console.Write("Enter gender (Male/Female): ");
            //gender gender = (gender)Enum.Parse(typeof(gender), Console.ReadLine(), true);

            do
            {
                Console.Write("Enter Gender (Male, Female): ");
               string input = Console.ReadLine();

                // Try to parse the input to a Gender enum
                if (Enum.TryParse(input, true, out gender) && Enum.IsDefined(typeof(gender), gender))
                {
                    validInput2 = true; // Exit the loop if input is valid
                }
                else
                {
                    Console.WriteLine("Invalid option. Please enter a valid gender (Male, Female, ).");
                    
                }
            } while (!validInput2);


            hireDate hireDate = new hireDate(year, month, day);
            return new employee(id, name,age,target,security,hireDate,gender,salary);
        }

        static void DisplayAllEmployees(employee[] employees, int count)
        {
            if (count == 0)
            {
                Console.WriteLine("No employees to display.");
                return;
            }

            Console.WriteLine("\nHere are all of our Employees ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(employees[i].ToString());
            }
        }



    }
}
