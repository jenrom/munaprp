using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class CriteriaExtensions
    {
        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left,
            Criteria<ItemToMatch> rigth)
        {
            return new OrCriteria<ItemToMatch>(left, rigth);     
        }

        public static Criteria<ItemToMatch> equal_to<ItemToMatch,PropertyType>(this PropertyAccessor<ItemToMatch,PropertyType> accessor, PropertyType value)
        {
            return new AnonymousCriteria<ItemToMatch>(x => accessor(x).Equals(value)); 
        }
    }
}