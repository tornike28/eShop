using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Utility
{
    public abstract class AutoMapperExtensions
    {
        public static TDestination MapObject<Tsource, TDestination>(Tsource value)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Tsource, TDestination>(); });
            IMapper imapper = config.CreateMapper();
            return (TDestination)imapper.Map<Tsource, TDestination>(value);
        }

        public static List<TDestination> MapList<Tsource, TDestination>(List<Tsource> source)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Tsource, TDestination>(); });
            IMapper imapper = config.CreateMapper();
            return imapper.Map<List<TDestination>>(source);
        }
    }
}
