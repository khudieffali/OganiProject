using Infrastructure.Commons.Abstracts;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositroies
{
    public interface IBlogToTagRepository:IRepository<BlogToTag>
    {
        void DeleteRange(List<BlogToTag> tags);
    }
}
