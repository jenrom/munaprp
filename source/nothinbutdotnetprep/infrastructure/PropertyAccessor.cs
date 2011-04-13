namespace nothinbutdotnetprep.infrastructure
{
    public delegate PropertyType PropertyAccessor<in ItemWithProperty, out PropertyType>(
        ItemWithProperty item_with_property);
}