using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS01EFC.Models
{
    internal class Artist
    {
        public int ArtistId { get; set; }
        public string? FirstName { get; set; }
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? WebAddress { get; set; }
        public Gender Gender { get; set; } = Gender.Unknown;
        public ICollection<Movie>? Movies { get; set; }
    }
}
