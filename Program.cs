using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {

            Department department = new Department
            {
                DepartmentName = "Human Resources",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Kettie" },
                    new Employee { EmployeeName = "Mary" },
                    new Employee { EmployeeName = "Tom" }
                }
            };

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("department.bin", FileMode.Create))
            {
                formatter.Serialize(stream, department);
            }

            using (FileStream stream = new FileStream("department.bin", FileMode.Open))
            {
                Department deserializedDepartment = (Department)formatter.Deserialize(stream);

                Console.WriteLine($"Department Name: {deserializedDepartment.DepartmentName}");
                foreach (Employee employee in deserializedDepartment.Employees)
                {
                    Console.WriteLine($"Employee Name: {employee.EmployeeName}");
                }
            }
        }
    }

    [Serializable]
    public class Employee
    {
        public string EmployeeName { get; set; }
    }

    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}