using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Provider
    {
        public int Id { get; set; }

        public int Sort { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }
        
        public int Value { get; set; }
        
        public int CorrectionRegion { get; set; }
        
        public string Description { get; set; }
    }
}
