using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk.Modules.PRESENTATION.ViewModels
{
    public class Media
    {
        public int nextMediaIndex { get; set; }
        public int prevMediaIndex { get; set; }
        public Uri currMediaUri { get; set; }

        public Media(string media, int mediaCount, int mediaIndex)
        {
            nextMediaIndex = (mediaIndex + 1) % mediaCount;
            prevMediaIndex = (mediaIndex - 1 + mediaCount) % mediaCount;
            currMediaUri = new Uri(media, UriKind.Absolute);
        }
    }
}
