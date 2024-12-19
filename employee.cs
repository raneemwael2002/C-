using System.Reflection;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary1
{
    public class employee : IComparable
    {
        public int id; 
        public string name;
        public int _age;
        public int _target;
        securityLevel security;
        hireDate date;
        gender _gender;
        public float salary;

        public employee()
        {
            id = 0;
            name = "none";
            _age = 0;
            _target = 0;
            security = new securityLevel();
            salary = 0;
            date = new hireDate();
            _gender = gender.Female;


        }
        public employee(int _id, string _name, int age, int target, securityLevel _security, hireDate _date, gender gender, float _salary)
        {
            // Validation for ID
            if (_id <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.", nameof(_id));
            }
            id = _id;

            // Validation for name
            if (string.IsNullOrWhiteSpace(_name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(_name));
            }
            name = _name;

            // Validation for age
            if (age < 18 || age > 45)
            {
                throw new ArgumentOutOfRangeException(nameof(age), "Age must be between 18 and 45.");
            }
            _age = age;

            // Initialize other fields
            _target = target;
            security = _security;
            date = _date;
            _gender = gender;
            salary = _salary;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }

        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18 || value > 45)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Age must be between 18 and 45.");
                }
                _age = value;
            }
        }

        public int Target
        {
            get { return _target; }
            set
            {
                if (value < 300)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Target need to be +300 at least");
                }
                _target = value;
            }
        }

        public float Salary
        {
            get { return salary; }
            set
            {
                if (value < 6000.0 || value > 20000.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Salary is between 6k$ and 20k$");
                }
                salary = value;
            }
        }



        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            employee other = obj as employee;

            if (other == null)
            {
                throw new ArgumentException("Object is not an employee");
            }

            // Compare years first
            if (this.date.year != other.date.year)
            {
                return this.date.year.CompareTo(other.date.year);
            }

            // If years are the same, compare months
            if (this.date.month != other.date.month)
            {
                return this.date.month.CompareTo(other.date.month);
            }

            // If months are the same, compare days
            return this.date.day.CompareTo(other.date.day);
        }

        public override string ToString()
        {
            return $"{name} is {_age} years old, with id{id} , hring date is: {date.ToString()} works as{security} with salary {salary:C}and achived target of {_target} sale.";
        }


    }
}
