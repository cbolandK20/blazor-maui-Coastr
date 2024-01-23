using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Coastr.Model
{
    public class Menu : AbstractPersistenceBase
    {
        virtual public IList<MenuItem> Items { get; set; } = new List<MenuItem>();

        [JsonIgnore]
        virtual public Venue Venue { get; set; } = null!;
    }
}
