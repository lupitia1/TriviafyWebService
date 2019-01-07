using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PlaylistSelected
    {
        public PlaylistSelected(PlaylistsReceived o)
        {
            this.id = o.playlists.items[0].id;
            this.name = o.playlists.items[0].name;
            this.message = o.message;
            this.tracksNumber = o.playlists.items[0].tracks.total;

        }
        public string id { get; set; }
        public string name { get; set; }
        public string message { get; set; }
        public int tracksNumber { get; set; }


    }
}
