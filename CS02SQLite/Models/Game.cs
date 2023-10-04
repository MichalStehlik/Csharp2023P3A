using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS02SQLite.Models
{
    internal class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<Development> Developments { get; set; }
    }
}
