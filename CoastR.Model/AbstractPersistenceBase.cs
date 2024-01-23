using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Coastr.Model
{
    public abstract class AbstractPersistenceBase
    {
        [Key]
        public int? Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;

        public ObjectState State { get; set; } = ObjectState.MOVING;

    }
}
