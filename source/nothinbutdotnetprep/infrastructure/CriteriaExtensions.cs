namespace nothinbutdotnetprep.infrastructure
{
    public static class CriteriaExtensions
    {
        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left,
            Criteria<ItemToMatch> rigth)
        {
            return new OrCriteria<ItemToMatch>(left, rigth);     
        }
    }
}