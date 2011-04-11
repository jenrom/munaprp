using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ReadonlySetOf<T> : IEnumerable<T>
    {
        IEnumerable<T> items;

        public ReadonlySetOf(IEnumerable<T> items)
        {
            this.items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}