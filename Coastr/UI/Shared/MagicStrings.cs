using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coastr.UI.Shared
{
    public class MagicStrings
    {
        public static readonly string SECTION_APP_HEADER_TEXT = "AppHeaderText";

        public static readonly string SECTION_APP_HEADER_BUTTON = "AppHeaderButton";

        public const string URL_VENUE_EDIT = "editVenue";
        public const string URL_VENUE_EDIT_FULL = "/"+ URL_VENUE_EDIT + "/{VenueId:int}";

    }
}
