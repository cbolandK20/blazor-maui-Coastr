using CoastR.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coastr.Model
{
    public class Venue : AbstractPersistenceBase
    {
        public string Name { get; set; } = "";
        virtual public GeoPosition? Location { get; set; }
        virtual public Menu? Menu { get; set; } = new Menu();
    }
}
