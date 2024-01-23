using Coastr.Model;

namespace Coastr.Data
{
    public class CoasterViewModel
    {
        public Venue Venue { get; set; }

        public IList<CoasterItemViewModel> Items { get; set; } = new List<CoasterItemViewModel>();

        public ObjectState State { get; set; } = ObjectState.MOVING;

        public Coaster Model { get; private set; }


        public CoasterViewModel()
        {
            // nothing special                
        }

        public CoasterViewModel(Coaster source)
        {
            if (source == null)
            {
                return;
            }
            Venue = source.Venue;
            State = source.State;
            Model = source;

            foreach (var item in source.Items)
            {
                Items.Add(new CoasterItemViewModel(item));
            }
        }
    }
}
