using PaginationChallange.ClassLibrary.Managers;
using PaginationChallange.ClassLibrary.Models;

namespace PaginationChallange
{
    internal static class Program
    {
        public static void Main()
        {
            var people = CsvDataManager.Read<Person>("targets.csv");

            new PaginatedMenu<Person>(10, people).Show();
        }
    }
}