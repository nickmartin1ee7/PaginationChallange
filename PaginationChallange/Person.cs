using System;
using CsvHelper.Configuration.Attributes;

namespace PaginationChallange
{
    public class Person
    {
        [Name("id")] public uint Id { get; set; }

        [Name("first_name")] public string FirstName { get; set; }

        [Name("last_name")] public string LastName { get; set; }

        [Name("birth_date")] public DateTime? BirthDate { get; set; }

        [Name("salary")] public string Salary { get; set; }

        public override string ToString()
        {
            return BirthDate is null
                ? $"{Id}, {FirstName} {LastName}; {Salary} per year"
                : $"{Id}, {FirstName} {LastName}, born {BirthDate}; {Salary} per year";
        }
    }
}