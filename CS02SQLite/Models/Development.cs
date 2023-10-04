using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS02SQLite.Models
{
    internal class Development
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
