using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1;
using WpfApp1.ViewModels;

namespace WpfApp1.Models
{
    internal class MainMenuItemMainWindow
    {
        public int Id { get; set; }

        public int Sort { get; set; }

        public string Name { get; set; }
        
        public string Alias { get; set; }

        public string Description { get; set; }

        public UserControl Control { get; set; }
    }
}
