using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAR.Models
{
    public class RaporTuru
    {
        public int Id { get; set; }
        public string Kod { get; set; }

        public override string ToString() => Kod;
    }
}


