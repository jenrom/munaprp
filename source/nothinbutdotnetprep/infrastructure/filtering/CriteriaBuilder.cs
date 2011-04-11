namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class CriteriaBuilder<ItemToMatch, PropertyType>
    {
        private readonly PropertyAccessor<ItemToMatch, PropertyType> accessor;

        private CriteriaBuilder(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public static CriteriaBuilder<ItemToMatch, PropertyType> Create(PropertyAccessor<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaBuilder<ItemToMatch, PropertyType>(accessor);
        }

        public Criteria<ItemToMatch> equal_to(PropertyType value)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).Equals(value));
        }
    }
}