namespace nothinbutdotnetprep.infrastructure.filtering
{
    public interface Criteria<in ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }
}