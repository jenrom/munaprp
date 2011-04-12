namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface ICreateSpecifications<ItemToMatch, PropertyType>
    {
        Criteria<ItemToMatch> equal_to(PropertyType value);
        Criteria<ItemToMatch> equal_to_any(params PropertyType[] values);
        Criteria<ItemToMatch> not_equal_to(PropertyType value);
    }
}