﻿using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace PaginationChallange
{
    public static class CsvDataManager
    {
        public static T[] Read<T>(string targetCsvFile) where T : class
        {
            using var sr = new StreamReader(targetCsvFile);
            using var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture);

            var collection = csvReader.GetRecords<T>()
                .ToArray();

            return collection;
        }
    }
}