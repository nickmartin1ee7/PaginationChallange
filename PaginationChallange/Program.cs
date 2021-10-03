using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace PaginationChallange
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = ReadPeopleFromCsv("targets.csv");

            PaginatedMenu();
        }

        private static void PaginatedMenu()
        {
            throw new NotImplementedException();
        }

        private static List<Person> ReadPeopleFromCsv(string targetsCsv)
        {
            var people = new List<Person>();

            using TextFieldParser parser = new(targetsCsv);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            bool isHeader = true;
            
            while (!parser.EndOfData)
            {
                if (isHeader)
                {
                    _ = parser.ReadFields();
                    isHeader = false;
                    continue;
                }
                
                var fields = parser.ReadFields();

                var salary = fields[4]
                    .Replace("$", "")
                    .Replace(",", "");

                var birthDate = string.IsNullOrWhiteSpace(fields[3])
                    ? default
                    : DateTime.Parse(fields[3]);
                
                people.Add(new Person
                {
                    Id = uint.Parse(fields[0]),
                    FirstName = fields[1],
                    LastName = fields[2],
                    BirthDate = birthDate,
                    Salary = decimal.Parse(salary)
                });
            }

            return people;
        }
    }
}