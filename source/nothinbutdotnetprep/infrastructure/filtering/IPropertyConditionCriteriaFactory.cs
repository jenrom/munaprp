namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface IPropertyConditionCriteriaFactory<ItemToMatch,PropertyType>
    {
        Criteria<ItemToMatch> create_for(Condition<PropertyType> condition);
    }
}