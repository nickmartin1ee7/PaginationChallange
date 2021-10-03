using System;
using System.Linq;
using PaginationChallange.ClassLibrary.Managers;
using PaginationChallange.ClassLibrary.Models;
using PaginationChallange.Extensions;

namespace PaginationChallange
{
    internal static class Program
    {
        public static void Main()
        {
            const int AGE_LIMIT = 18;
            const decimal MIN_SALARY = 2000m;
            
            Console.Write("Filter to MVPs? (y/n) ");
            var shouldFilter = Console.ReadLine().Trim().ToLower() == "y";
            
            Person[] people;

            if (shouldFilter)
            {
                people = CsvDataManager.Read<Person>("targets.csv")
                    .OlderThan(AGE_LIMIT)
                    .SalaryAtLeast(MIN_SALARY)
                    .OrderByFullName()
                    .ToArray();
            }
            else
            {
                people = CsvDataManager.Read<Person>("targets.csv")
                    .ToArray();
            }

            new PaginatedMenu<Person>(10, people).Show();
        }
    }
}