using Coastr.Model;

namespace CoastR.Model
{
    public class Bill : AbstractPersistenceBase
    {
        public decimal Sum { get; set; } = decimal.Zero;
        public string VenueName { get; set; } = "";

        public GeoPosition? VenueLocation { get; set; } = null;

        public virtual IList<BillItem> Items { get; set; } = new List<BillItem>();
    }
}
