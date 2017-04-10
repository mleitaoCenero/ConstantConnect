using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Helpers
{
    public static class ListExtensions
    {
        public static void RemoveRange<T>(this List<T> source, IEnumerable<T> rangeToRemove)
        {
            if (rangeToRemove == null | !rangeToRemove.Any())
                return;

            foreach (var item in rangeToRemove)
            {
                source.Remove(item);
            }
        }

        public static bool In<T>(this T source, params T[] list)
        {
            return list.Contains(source);
        }
    }
}
