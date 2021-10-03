using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace PaginationChallange.ClassLibrary.Managers
{
    public static class CsvDataManager
    {
        public static IEnumerable<T> Read<T>(string targetCsvFile) where T : class
        {
            using var sr = new StreamReader(targetCsvFile);
            using var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture);

            var collection = csvReader.GetRecords<T>()
                .ToArray(); // Stream gets disposed

            return collection;
        }
    }
}