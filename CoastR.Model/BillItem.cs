using Coastr.Model;

namespace CoastR.Model
{
    public class BillItem : AbstractPersistenceBase
    {
        public int Count { get; set; } = 0;

        public string Name { get; set; } = "";

        public decimal Price { get; set; } = decimal.Zero;

        public decimal Sum { get; set; } = decimal.Zero;
    }
}