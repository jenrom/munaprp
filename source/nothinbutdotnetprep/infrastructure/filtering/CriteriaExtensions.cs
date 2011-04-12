namespace nothinbutdotnetprep.infrastructure.filtering
{
    public static class CriteriaExtensions
    {
        public static Criteria<ItemToMatch> and<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                             Criteria<ItemToMatch> rigth)
        {
            return new AndCriteria<ItemToMatch>(left, rigth);
        }

        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                            Criteria<ItemToMatch> rigth)
        {
            return new OrCriteria<ItemToMatch>(left, rigth);
        }
    }
}