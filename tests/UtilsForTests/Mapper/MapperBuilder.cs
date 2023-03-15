using AutoMapper;
using HairManager.Application.Utils.Automapper;
using UtilsForTests.HashIds;

namespace UtilsForTests.Mapper;
public class MapperBuilder
{
    public static IMapper Instancia()
    {
        var hashids = HashidsBuilder.Instance().Build();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutomapperConfiguration(hashids));
        });

        return configuration.CreateMapper();
    }
}
