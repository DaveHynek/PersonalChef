namespace PersonalChef.Api.Mappers
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
