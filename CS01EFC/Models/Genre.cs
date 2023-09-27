using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS01EFC.Models
{
    internal class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Movie>? Movies { get; set; }
    }
}
