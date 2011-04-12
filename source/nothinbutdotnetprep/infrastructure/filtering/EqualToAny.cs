using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class EqualToAny<T> : Criteria<T>
    {
        IList<T> items;

        public EqualToAny(params T[] items)
        {
            this.items = new List<T>(items);
        }

        public bool matches(T item)
        {
            return items.Contains(item);
        }
    }
}