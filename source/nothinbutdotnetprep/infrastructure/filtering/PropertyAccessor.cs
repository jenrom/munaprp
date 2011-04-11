namespace nothinbutdotnetprep.infrastructure.filtering
{
    public delegate PropertyType PropertyAccessor<in ItemWithProperty, out PropertyType>(
        ItemWithProperty item_with_property);
}