using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Exercicio_Fixacao_Lambda___Delegate.Entities;

namespace Exercicio_Fixacao_Lambda___Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            List<Employee> list = new List<Employee>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        string email = line[1];
                        double salary = double.Parse(line[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salary));
                    }

                }
                Console.Write("Enter Salary: ");
                int filter = int.Parse(Console.ReadLine());
                var fil = list.Where(e => e.Salary > filter).OrderBy(e => e.Name).Select(e => e.Email);
                foreach (string name in fil)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
                var sum = list.Where(e => e.Name[0]=='M').Select(e => e.Salary).DefaultIfEmpty(0.0).Sum();
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine();



            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
