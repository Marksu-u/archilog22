using ArchiLibrary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchiLibrary.Extensions
{
    public static class QueryExtensions
    {

        public static IOrderedQueryable<TModel> Sort<TModel>(this IQueryable<TModel> query, Params p)
        {
            //condition pour la fonction ascendante
            if (!string.IsNullOrWhiteSpace(p.Asc))
            {
                string champ = p.Asc;

                //créer lambda
                var parameter = Expression.Parameter(typeof(TModel), "x");
                var property = Expression.Property(parameter, champ/*"Name"*/);

                var o = Expression.Convert(property, typeof(object));
                var lambda = Expression.Lambda<Func<TModel, object>>(o, parameter);

                //utilisation lambda
                return query.OrderBy(lambda);

            } 
            //condition pour la fonction descendante
            else if (!string.IsNullOrWhiteSpace(p.Desc))
            {
                string champ = p.Desc;

                //créer lambda
                var parameter = Expression.Parameter(typeof(TModel), "x");
                var property = Expression.Property(parameter, champ/*"Name"*/);

                var o = Expression.Convert(property, typeof(object));
                var lambda = Expression.Lambda<Func<TModel, object>>(o, parameter);

                //utilisation lambda
                return query.OrderByDescending(lambda);

            } 
            //condition pour la fonction recherche
            else if(!string.IsNullOrWhiteSpace(p.Search))
            {
                var obj = Expression.Parameter(typeof(TModel), "obj");
                var objProperty = Expression.PropertyOrField(obj, "name");
                var contains = Expression.Call(objProperty, "Contains", null, Expression.Constant(p.Search, typeof(string)));
                var lambda = Expression.Lambda<Func<TModel, bool>>(contains, obj);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            else
                return (IOrderedQueryable<TModel>)query;

        }
    }
}
