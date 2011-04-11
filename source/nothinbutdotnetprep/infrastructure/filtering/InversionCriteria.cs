using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class InversionCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        private Criteria<ItemToMatch> criteria;

        public InversionCriteria(Criteria<ItemToMatch> criteria)
        {
            this.criteria = criteria;
        }

        public bool matches(ItemToMatch item)
        {
            return !criteria.matches(item);
        }
    }
}
