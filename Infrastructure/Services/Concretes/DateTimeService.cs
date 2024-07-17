using Infrastructure.Services.Abstarcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Concretes
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime { get => DateTime.Now; }
    }
    public partial class UtcDateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime { get => DateTime.UtcNow; }
    }
}
