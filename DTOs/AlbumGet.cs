using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DTOs
{
    public class AlbumGet
    {
        public int IdAlbum { get; set;}
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Tracks> Tracks { get; set; }
    }

    public class Tracks {
        
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
    }
}