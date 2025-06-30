using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Models/Risk.cs
namespace EMAR.Models
{
    public class Risk
    {
        public int Id { get; set; }
        public int BolgeId { get; set; }
        public int RiskSira { get; set; }
        public string Baslik { get; set; }
    }
}

