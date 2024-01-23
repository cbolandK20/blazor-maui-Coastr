

using Coastr.Model;

namespace Coastr.Data
{
    public class CoasterItemViewModel
    {
        public CoasterItemViewModelType Type { get; set; }

        public Coastr.Model.MenuItem MenuItem { get; set; } = null;

        public int Count { get; set; } = 0;

        public int Index { get; set; } = 0;

        public CoasterItem Model { get; private set; }

        public CoasterItemViewModel()
        {
            // nothing special
        }

        public CoasterItemViewModel(CoasterItem source)
        {
            Type = CoasterItemViewModelType.CONTENT;
            Count = source.Count;
            Index = source.Index.Value;
            MenuItem = source.MenuItem;

            Model = source;
        }

    }

    public enum CoasterItemViewModelType
    {
        COMMAND,
        CONTENT,
        OTHER
    }
}
