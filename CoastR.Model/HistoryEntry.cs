using Coastr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoastR.Model
{
    public class HistoryEntry : AbstractPersistenceBase
    {
        public string Venue { get; set; } = "";
        public decimal Price { get; set; } = 0;
        public byte[]? Content { get; set; } = null;
        public virtual GeoPosition? Position { get; set; } = null;
    }
}
