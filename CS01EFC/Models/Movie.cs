using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS01EFC.Models
{
    internal class Movie
    {
        public int MovieId { get; set; }
        // public int Id { get; set; }
        //[Key]
        //public int KeyToMovie { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public float? Duration { get; set; }
        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }
        public int GenreId { get; set; }
        public ICollection<Artist>? Artists { get; set; }
    }
}
