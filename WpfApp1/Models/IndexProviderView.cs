using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class IndexProviderView
    {
        public int Id { get; set; }
        public int IdIndex { get; set; }
        public int IdProvider { get; set; }

        public int Sort { get; set; }

        public string NameProvider { get; set; }        
    }
}
