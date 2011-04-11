using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class Where<ItemToMatch>
    {
        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(accessor);
        }

        public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(accessor);
        }
    }
}