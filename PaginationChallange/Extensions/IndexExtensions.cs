using System.Collections;

namespace PaginationChallange.Extensions
{
    public static class IndexExtensions
    {
        public static bool ValidRange(this ICollection collection, int start, int end) => end <= collection.Count && start >= 0 && start < collection.Count;
    }
}