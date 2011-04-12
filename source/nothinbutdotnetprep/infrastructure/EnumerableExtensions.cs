using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items,
                                                   IComparer<T> comparer)
        {
            var sorted = new List<T> (items);
            sorted.Sort(comparer);
            return sorted;
        }

        public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,
                                                                               Criteria<ItemToMatch> criteria)
        {
            return all_items_matching(items, criteria.matches);
        }

        static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,
                                                                        Condition<ItemToMatch> criteria)
        {
            foreach (var item_to_match in items)
            {
                if (criteria(item_to_match)) yield return item_to_match;
            }
        }
    }
}