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
                var property = Expression.Property(parameterExpression, "name");

                var tab = p.FilterNameMultiple.Split(',');
                var expression = Expression.Equal(property, Expression.Constant(tab[0]));

                BinaryExpression bin = expression;
                if(tab.Length > 1)
                {
                    foreach (var value in tab.Skip(1))
                    {
                        expression = Expression.Equal(property, Expression.Constant(value));
                        bin = Expression.Or(bin, expression);
                    }
                }

                var lambda = Expression.Lambda<Func<TModel, bool>>(bin, parameterExpression);
                return (IOrderedQueryable<TModel>)query.Where(lambda).AsQueryable();
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
            //Filtre pour rechercher un prix inférieur ou égal fonctionnel
            else if (!string.IsNullOrWhiteSpace(Convert.ToString(p.FilterInferiorPrice)))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterInferiorPrice);
                var property = Expression.Property(parameterExpression, "price");
                var expression = Expression.LessThanOrEqual(property, constant);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            //Filtre pour rechercher un prix supérieur ou égal fonctionnel
            else if (!string.IsNullOrWhiteSpace(Convert.ToString(p.FilterSuperiorPrice)))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterSuperiorPrice);
                var property = Expression.Property(parameterExpression, "price");
                var expression = Expression.GreaterThanOrEqual(property, constant);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            //Filtre pour rechercher une date fixe inférieure ou égale fonctionnelle
            else if (!string.IsNullOrWhiteSpace(Convert.ToString(p.FilterInferiorDate)))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterInferiorDate);
                var property = Expression.Property(parameterExpression, "createdAt");
                var expression = Expression.LessThanOrEqual(property, constant);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            //Filtre pour rechercher une date fixe supérieure ou égale fonctionnelle
            else if (!string.IsNullOrWhiteSpace(Convert.ToString(p.FilterSuperiorDate)))
            {
                var parameterExpression = Expression.Parameter(typeof(TModel), "x");
                var constant = Expression.Constant(p.FilterSuperiorDate);
                var property = Expression.Property(parameterExpression, "createdAt");
                var expression = Expression.GreaterThanOrEqual(property, constant);
                var lambda = Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);

                return (IOrderedQueryable<TModel>)query.Where(lambda);
            }
            else
                return (IOrderedQueryable<TModel>)query;

        }
    }
}
