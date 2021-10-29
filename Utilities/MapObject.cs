using System.Collections.Generic;
using AutoMapper;

namespace cookbookAPI.Utilities
{
    public static class MapObject
    {
        public static TDestination MapObj<TSource, TDestination>(TSource objToMap)
        {
            var config = new MapperConfiguration(cfg =>
                        cfg.CreateMap(typeof(TSource), typeof(TDestination)));

            var mapper = new Mapper(config);
            var mappedObj = mapper.Map<TSource, TDestination>(objToMap);

            return mappedObj;
        }

        public static List<TDestination> MapObjList<TSource,TDestination>(List<TSource> objList){
            var config = new MapperConfiguration(cfg =>
                        cfg.CreateMap(typeof(TSource), typeof(TDestination)));

            var mapper = new Mapper(config);
            
            List<TDestination> mappedObjList = mapper.Map<List<TSource>, List<TDestination>>(objList);

            return mappedObjList;
        }
        
    }
}


