using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Entities.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}