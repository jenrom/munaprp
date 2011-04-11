using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaBuilder<ItemToMatch, PropertyType>
    {
        PropertyAccessor<ItemToMatch, PropertyType> accessor;

        public CriteriaBuilder(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return new AnonymousCriteria<ItemToMatch>(x => new List<PropertyType>(values).Contains(this.accessor(x)));
        }
    }
}