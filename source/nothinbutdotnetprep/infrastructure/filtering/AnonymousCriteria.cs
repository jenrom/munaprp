namespace nothinbutdotnetprep.infrastructure.filtering
{
    public class AnonymousCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        readonly Condition<ItemToMatch> condition;

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