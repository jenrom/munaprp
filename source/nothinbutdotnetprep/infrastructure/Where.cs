using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure
{
    public static class Where<ItemToMatch> 
    {
        public static CriteriaBuilder<ItemToMatch> has_a(Func<ItemToMatch, object> valueSelector)
        {
            return new CriteriaBuilder<ItemToMatch>(valueSelector);
        }
    }

    public class CriteriaBuilder<ItemToMatch>
    {
        private readonly Func<ItemToMatch, object> valueSelector;

        public CriteriaBuilder(Func<ItemToMatch, object> valueSelector)
        {
            this.valueSelector = valueSelector;
        }

        public Criteria<ItemToMatch> equal_to(object valueToMatch)
        {
            return new EqualToCriteria<ItemToMatch>(valueSelector, valueToMatch);
        }
    }

    public class EqualToCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        private readonly Func<ItemToMatch, object> valueSelector;
        private readonly object valueToMatch;

        public EqualToCriteria(Func<ItemToMatch, object> valueSelector, object valueToMatch)
        {
            this.valueSelector = valueSelector;
            this.valueToMatch = valueToMatch;
        }

        public bool matches(ItemToMatch item)
        {
            return valueSelector(item).Equals(valueToMatch);
        }
    }
}
