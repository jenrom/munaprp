using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        readonly PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return this.CreateFactory().equal_to(value);
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return this.CreateFactory().equal_to_any(values);
        }

        public Criteria<ItemToMatch> not_equal_to(PropertyType value)
        {
            return this.CreateFactory().not_equal_to(value);
        }

        private CriteriaFactory<ItemToMatch, PropertyType> CreateFactory()
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(this.accessor);
        }

        public Criteria<ItemToMatch> greater_than_or_equal_to(PropertyType start)
        {
            return Where<ItemToMatch>.has_a(accessor).equal_to(start).or(greater_than(start));
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