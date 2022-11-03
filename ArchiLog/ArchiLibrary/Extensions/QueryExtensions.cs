using ArchiLibrary.Models;
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
            else
                return (IOrderedQueryable<TModel>)query;

        }
    }
}
