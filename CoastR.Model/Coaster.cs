using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coastr.Model
{    
    public class Coaster : AbstractPersistenceBase
    {                
        virtual public Venue? Venue { get; set; }

        virtual public IList<CoasterItem> Items { get; set; } = new List<CoasterItem>();

    }
}
