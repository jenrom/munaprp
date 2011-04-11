namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class NegatingCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        Criteria<ItemToMatch> criteria;

        public NegatingCriteria(Criteria<ItemToMatch> criteria)
        {
            this.criteria = criteria;
        }

        public bool matches(ItemToMatch item)
        {
            return !criteria.matches(item);
        }
    }
}