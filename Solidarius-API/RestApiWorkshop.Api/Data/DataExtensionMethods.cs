using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Data
{
    public static class DataExtensionMethods
    {
        public static IModel Find(this IQueryable<IModel> query, int id)
        {
            return query.Where(w => w.Id == id).FirstOrDefault();
        }
    }
}
