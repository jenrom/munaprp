using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class EmptyComparer<ItemToSort> : IComparer<ItemToSort>
    {
        public int Compare(ItemToSort x, ItemToSort y)
        {
            return 0;
        }
    }
}