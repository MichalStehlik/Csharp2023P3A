using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS01EFC.Models
{
    internal class ArtistMovie
    {
        [ForeignKey("ArtistId")]
        public Artist? Artist { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }
        public int MovieId { get; set; }
    }
}
