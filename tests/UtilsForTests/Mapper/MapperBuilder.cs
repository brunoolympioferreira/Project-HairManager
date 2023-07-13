using AutoMapper;
using HairManager.Application.Utils.Automapper;

namespace UtilsForTests.Mapper;
public class MapperBuilder
{
    public static IMapper Instancia()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutomapperConfiguration());
        });

        return configuration.CreateMapper();
    }
}
