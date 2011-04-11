using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure
{
    public static class EnumerableExtensions
    {
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