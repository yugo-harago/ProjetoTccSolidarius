using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data
{
    public static class DataExtensionMethods
    {
        public static T Find<T>(this IQueryable<T> query, int id) where T:IModel
        {
            return query.Where(w => w.Id == id).FirstOrDefault();
        }
    }
}
