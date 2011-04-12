namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class AndCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        readonly Criteria<ItemToMatch> left_side;
        readonly Criteria<ItemToMatch> right_side;

        public AndCriteria(Criteria<ItemToMatch> left_side, Criteria<ItemToMatch> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public bool matches(ItemToMatch item)
        {
            return left_side.matches(item) && right_side.matches(item);
        }
    }
}