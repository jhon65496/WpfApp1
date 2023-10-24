using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Views.Views
{
    /// <summary>
    /// Логика взаимодействия для IndexesView.xaml
    /// </summary>
    public partial class IndexesView : UserControl
    {
        public IndexesView()
        {
            InitializeComponent();
            var dataContext = this.DataContext;
            var itemsSource = this.MainDataGrid.ItemsSource;
            var isReadOnly = this.MainDataGrid.IsReadOnly;
        }
    }
}
