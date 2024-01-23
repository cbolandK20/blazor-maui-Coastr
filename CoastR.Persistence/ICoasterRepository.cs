using Coastr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coastr.Persistence
{
    public interface ICoasterRepository : IRepository<Coaster>
    {
        public Task<Coaster?> GetLatest();
    }
}
