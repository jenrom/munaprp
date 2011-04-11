using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        private readonly PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToMatch> greater_than(PropertyType start)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).CompareTo(start) >= 0);
        }

        public Criteria<ItemToMatch> less_than(PropertyType end)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).CompareTo(end) <= 0);
        }

        public Criteria<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return new AndCriteria<ItemToMatch>(greater_than(start), less_than(end));
        }
    }
}