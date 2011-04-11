namespace nothinbutdotnetprep.infrastructure
{
    public interface Criteria<in ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}