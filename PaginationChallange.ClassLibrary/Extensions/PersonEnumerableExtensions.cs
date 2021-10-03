using System;
using System.Collections.Generic;
using System.Linq;
using PaginationChallange.ClassLibrary.Models;

namespace PaginationChallange.Extensions
{
    public static class PersonEnumerableExtensions
    {
        public static IEnumerable<Person> OlderThan(this IEnumerable<Person> people, int ageLimit) =>
            people.Where(p => DateTime.Now.Date.Year - (p.BirthDate ?? DateTime.Now).Year >= ageLimit);

        public static IEnumerable<Person> SalaryAtLeast(this IEnumerable<Person> people, decimal minimumSalary) =>
            people.Where(p => decimal.Parse(p.Salary
                .Replace("$", "")
                .Replace(",", "")) >= minimumSalary);

        public static IEnumerable<Person> OrderByFullName(this IEnumerable<Person> people) =>
            people
                .OrderBy(p => p.LastName)
                .OrderBy(p => p.FirstName);
    }
}