using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Entities.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}