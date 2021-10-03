using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;

namespace PaginationChallange
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {
            List<Person> people = await ReadPeopleFromCsvAsync("targets.csv");

            PaginatedMenu();
        }

        private static void PaginatedMenu()
        {
            throw new NotImplementedException();
        }

        private static async Task<List<Person>> ReadPeopleFromCsvAsync(string targetCsvFile)
        {
            using var sr = new StreamReader(targetCsvFile);
            using var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture);

            var people = csvReader.GetRecords<Person>().ToList();

            return people;
        }
    }
}