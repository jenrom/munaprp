namespace nothinbutdotnetprep.infrastructure
{
    public class AnonymousCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        Condition<ItemToMatch> condition;

        public AnonymousCriteria(Condition<ItemToMatch> condition)
        {
            this.condition = condition;
        }

        public bool matches(ItemToMatch item)
        {
            return condition(item);
        }
    }
}