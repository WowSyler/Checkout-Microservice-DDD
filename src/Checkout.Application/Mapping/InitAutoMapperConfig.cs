using AutoMapper;

namespace Checkout.Application.Mapping;

public static class InitAutoMapperConfig
{
    public static IMapper Mapper;
    public static void InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg => {
            //cfg.CreateMap<Class, ClassDTO>();
        });
        
        Mapper = config.CreateMapper();
    }
}