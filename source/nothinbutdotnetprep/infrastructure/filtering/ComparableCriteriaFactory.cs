using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        private readonly PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToMatch> greater_than_or_equal_to(PropertyType start)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).CompareTo(start) >= 0);
        }

        public Criteria<ItemToMatch> less_than_or_equal_to(PropertyType end)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).CompareTo(end) <= 0);
        }

        public Criteria<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return greater_than_or_equal_to(start).and(less_than_or_equal_to(end));
        }

        public Criteria<ItemToMatch> greater_than(PropertyType value)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).CompareTo(value) > 0);
        }
    }
}