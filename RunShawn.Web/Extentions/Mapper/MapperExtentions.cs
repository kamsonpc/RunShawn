using AutoMapper;
using System;
using System.Linq.Expressions;

namespace RunShawn.Web.Extentions
{
    public static class MapperExtentions
    {
        #region MapTo()
        /// <summary>
        /// Map shortcut.
        /// </summary>
        public static TDest MapTo<TDest>(this object src)
        {
            return (TDest)AutoMapper.Mapper.Map(src, src.GetType(), typeof(TDest));
        }
        #endregion

        #region Ignore
        /// <summary>
        /// Maps properties as ignored.
        /// </summary>
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());

            return map;
        }
        #endregion

        #region MapProperty
        /// <summary>
        /// Sets mapping from source property to destination property. Convenient extension method. 
        /// </summary>
        public static IMappingExpression<TSource, TDestination> MapProperty<TSource, TDestination, TProperty>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TSource, TProperty>> sourceMember,
            Expression<Func<TDestination, object>> targetMember)
        {
            map.ForMember(targetMember, opt => opt.MapFrom(sourceMember));

            return map;
        }
        #endregion
    }
}