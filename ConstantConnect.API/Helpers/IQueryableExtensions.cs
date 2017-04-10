using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;

namespace ConstantConnect.API.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sort)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (sort == null)
                return source;

            var listSort = sort.Split(',');

            string completeSortExpression = "";
            foreach (var option in listSort)
            {
                if (option.StartsWith("-"))
                    completeSortExpression = completeSortExpression + option.Remove(0, 1) + " descending,";
                else
                    completeSortExpression = completeSortExpression + option + ",";
            }

            if (!string.IsNullOrWhiteSpace(completeSortExpression))
                source = source.OrderBy(completeSortExpression.Remove(completeSortExpression.Count() - 1));

            return source;
        }
    }
}