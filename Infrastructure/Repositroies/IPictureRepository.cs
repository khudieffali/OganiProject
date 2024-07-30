using Infrastructure.Commons.Abstracts;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositroies
{
    public interface IPictureRepository : IRepository<Picture>
    {
        Task DeleteRange(List<Picture> pictureList);
        void HardDeleteRange(List<Picture> existingDeletedImages);

    }
}
