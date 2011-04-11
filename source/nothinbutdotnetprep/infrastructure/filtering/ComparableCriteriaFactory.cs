using System;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch,PropertyType> where PropertyType : IComparable<PropertyType>
    {
        public Criteria<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            throw new NotImplementedException();
        }
    }
}