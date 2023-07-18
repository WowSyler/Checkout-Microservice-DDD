using AutoMapper;

namespace Checkout.Application.Mapping;

public static class InitAutoMapperConfig
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CustomMapping>();
        });

        return config.CreateMapper();
    });

    public static IMapper Mapper => Lazy.Value;
    
    //var destination = mapper.Map<Source, Destination>(source);
}