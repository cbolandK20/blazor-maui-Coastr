using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coastr.Model
{
    public class CoasterItem : AbstractPersistenceBase
    {
        virtual public MenuItem? MenuItem { get; set; } = null;
        public int Count { get; set; } = 0;

        public int? Index { get; set; } = null;

        virtual public Coaster? Coaster { get; set; }

        [NotMapped]
        public decimal? Price { 
            get
            {
                return Count * MenuItem?.Price;
            } 
        }
    }
}
