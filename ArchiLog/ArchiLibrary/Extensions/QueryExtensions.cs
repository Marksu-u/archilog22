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
            //condition pour la fonction ascendante fonctionnelle
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
            //condition pour la fonction descendante fonctionnelle
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
            //condition pour la fonction recherche fonctionnelle
            else if (!string.IsNullOrWhiteSpace(p.Search))
            {
                var obj = Expression.Parameter(typeof(TModel), "obj");
                var objProperty = Expression.PropertyOrField(obj, "name");
                var contains = Expression.Call(objProperty, "Contains", null, Expression.Constant(p.Search, typeof(string)));
                var lambda = Expression.Lambda<Func<TModel, bool>>(contains, obj);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            //Filtre pour rechercher une valeur fixe fonctionnelle
            else if (!string.IsNullOrWhiteSpace(p.FilterNameFixe))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterNameFixe);
                var property = Expression.Property(parameterExpression, "name");
                var expression = Expression.Equal(property, constant);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            //Filtre pour rechercher une valeur multiple NON FONCTIONNELLE
            else if (!string.IsNullOrWhiteSpace(p.FilterNameMultiple))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterNameMultiple);
                var property = Expression.Property(parameterExpression, "name");
                var expression = Expression.Equal(property, constant);

                Expression property2 = parameterExpression;
                foreach (var nameCar in "name".Split('.'))
                {
                    property2 = Expression.PropertyOrField(property2, nameCar);
                }
                var expression2 = Expression.Equal(property2, constant);
                expression = Expression.Or(expression, expression2);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);
                var compiledLambda = lambda.Compile();
                return (IOrderedQueryable<TModel>)query.Where(compiledLambda).ToList();
            }
            //Filtre pour rechercher un nombre fixe fonctionnelle
            else if (!string.IsNullOrWhiteSpace(Convert.ToString(p.FilterPriceFixe)))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterPriceFixe);
                var property = Expression.Property(parameterExpression, "price");
                var expression = Expression.Equal(property, constant);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            //Filtre pour rechercher une date fixe fonctionnelle
            else if (!string.IsNullOrWhiteSpace(Convert.ToString(p.FilterDateFixe)))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterDateFixe);
                var property = Expression.Property(parameterExpression, "createdAt");
                var expression = Expression.Equal(property, constant);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            else
                return (IOrderedQueryable<TModel>)query;

        }
    }
}
