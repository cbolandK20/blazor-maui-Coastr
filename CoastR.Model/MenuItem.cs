using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Coastr.Model
{
    public class MenuItem : AbstractPersistenceBase
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }

        [JsonIgnore]
        virtual public Coastr.Model.Menu? Menu { get; set; }
    }
}
