using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.filtering;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        PropertyAccessor<ItemToSort, PropertyType> accessor;
        IComparer<PropertyType> real_comparer;

        public PropertyComparer(PropertyAccessor<ItemToSort, PropertyType> accessor,
                                IComparer<PropertyType> real_comparer)
        {
            this.accessor = accessor;
            this.real_comparer = real_comparer;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return real_comparer.Compare(accessor(x), accessor(y));
        }
    }
}