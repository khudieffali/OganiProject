using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class CategoryExtension
    {
        public static IEnumerable<Category> GetHierArchy(this IEnumerable<Category> categories,Category parentCategory)
        {
            if(parentCategory.ParentId != null)
            {
                yield return parentCategory;
            }
            foreach (var item in categories.Where(x=>x.ParentId==parentCategory.Id && x.DeletedBy==null).SelectMany(c=>categories.GetHierArchy(c)))
            {
                yield return item;
            }
        }
    }
}
