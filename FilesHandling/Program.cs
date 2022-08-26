using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesHandling
{
    class Program
    {
        private static readonly string path = @"C:\Users\cgatsakos\MyFiles\Babis.txt";
        /*
         * Expected output is the following table :
         *  #   DATE            NAME       AGE
         *  1   20/08/2022      Babis      25 
         */
        static void Main(string[] args)
        {
            try
            {
                int counter = 0;
                List<Customer> customers = new List<Customer>();
                IEnumerable lines = File.ReadLines(path);
                foreach (string line in lines)
                {
                    Customer customer = new Customer();
                    counter++;
                    if (line.Trim().All(char.IsDigit))
                    {
                        int year = int.Parse(line.Trim().Substring(0, 4));
                        int month = int.Parse(line.Trim().Substring(4, 2));
                        int day = int.Parse(line.Trim().Substring(6, 2));
                        customer.Date = DateTime.Parse($"{day}/{month}/{year}");
                        Console.WriteLine(counter + ": " + customer.Date.ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        string[] keyValue = line.Trim().Split("\t");
                        if (keyValue[0].Equals("NAME"))
                        {
                            customer.Name = keyValue[1];
                           Console.WriteLine(counter + ": " + customer.Name);
                        }
                        else
                        {
                            customer.Age = int.Parse(keyValue[2]);
                            Console.WriteLine(counter + ": " + customer.Age);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("File does not exist");
            }


        }
    }
}
