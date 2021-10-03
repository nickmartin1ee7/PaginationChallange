using System;
using static System.Console;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using PaginationChallange.Extensions;

namespace PaginationChallange
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var people = ReadPeopleFromCsv("targets.csv");
            PaginatedMenu(people);
        }

        private static void PaginatedMenu(Person[] people)
        {
            const int PAGE_LIMIT = 10;
            int currentIndex = 0;

            void PrintPeople(Direction direction)
            {
                var section = new Range(currentIndex, currentIndex + PAGE_LIMIT);

                switch (direction)
                {
                    case Direction.Forwards:
                        if (people.ValidRange(currentIndex + PAGE_LIMIT, currentIndex + PAGE_LIMIT * 2))
                        {
                            section = new Range(currentIndex + PAGE_LIMIT, currentIndex + PAGE_LIMIT * 2);
                            currentIndex += PAGE_LIMIT;
                        }
                        else if (people.ValidRange(currentIndex + PAGE_LIMIT, people.Length))
                        {
                            section = new Range(currentIndex + PAGE_LIMIT, people.Length);
                            currentIndex += PAGE_LIMIT;
                        }
                        break;
                    case Direction.Backwards:
                        if (people.ValidRange(currentIndex - PAGE_LIMIT, currentIndex))
                        {
                            section = new Range(currentIndex - PAGE_LIMIT, currentIndex);
                            currentIndex -= PAGE_LIMIT;
                        }
                        else
                        {
                            section = new Range(0, PAGE_LIMIT);
                            currentIndex = 0;
                        }
                        break;
                }

                var pagePeople = people[section];

                foreach (var person in pagePeople)
                {
                    WriteLine(person);
                }
            }

            PrintPeople(Direction.None);
            WriteLine();
            WriteLine("[Right] arrow to go to next page, [Left] arrow to go back, or [Enter] to exit...");

            while (true)
            {
                var inputConsoleKey = ReadKey();

                Clear();
                
                switch (inputConsoleKey.Key)
                {
                    case ConsoleKey.Enter:
                        return;
                    case ConsoleKey.RightArrow:
                        PrintPeople(Direction.Forwards);
                        break;
                    case ConsoleKey.LeftArrow:
                        PrintPeople(Direction.Backwards);
                        break;
                    default:
                        PrintPeople(Direction.None);
                        break;
                }
                WriteLine();
                WriteLine("[Right] arrow to go to next page, [Left] arrow to go back, or [Enter] to exit...");
            }
        }

        private static Person[] ReadPeopleFromCsv(string targetCsvFile)
        {
            using var sr = new StreamReader(targetCsvFile);
            using var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture);

            var people = csvReader.GetRecords<Person>()
                .ToArray();

            return people;
        }
        
        private enum Direction
        {
            None,
            Forwards,
            Backwards
        }
    }
}