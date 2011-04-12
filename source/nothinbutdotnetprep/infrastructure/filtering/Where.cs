using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class Where<ItemToMatch>
    {
        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(new PropertyConditionCriteriaFactory<ItemToMatch, PropertyType>(accessor));
        }

        public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
            PropertyAccessor<ItemToMatch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(has_a(accessor), new PropertyConditionCriteriaFactory<ItemToMatch, PropertyType>(accessor));
        }
    }

    public class PropertyConditionCriteriaFactory<ItemToMatch, PropertyType> : IPropertyConditionCriteriaFactory<ItemToMatch, PropertyType>
    {
        private PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public PropertyConditionCriteriaFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToMatch> create_for(Condition<PropertyType> condition)
        {
            return new AnonymousCriteria<ItemToMatch>(x => condition.Invoke(accessor.Invoke(x)));
        }
    }
}