using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.Models;
using WpfApp1.ViewModels;
using WpfApp1.ViewModels.Views;
using WpfApp1.Views;
using WpfApp1.Views.Views;

namespace WpfApp1
{
    public class AppManager
    {
        MainWindowViewModel mainWindowViewModel;
        
        public IndexesViewModel indexesViewModel;
        public ProvidersViewModel providersViewModel;
        public IndexesProvidersViewModel indexesProvidersViewModel;
        
        public ManagerIndexesViewModel managerIndexesViewModel;
        // public ManagerIndexesViewModel2 ManagerIndexesViewModel2;

        DataContextApp DataContextApp;
        public AppManager()
        {
            mainWindowViewModel = new MainWindowViewModel(this);
            MainWindow mainWindow =new MainWindow();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();

            // managerIndexesViewModel = new ManagerIndexesViewModel();

            DataContextApp = new DataContextApp();
        }


        private string testProp;

        public string TestProp
        {
            get { return testProp; }
            set 
            { 
                testProp = value;
                Debug.WriteLine("*** **** **** *** *** *** *** ***");
                Debug.WriteLine("AppManager -- TestProp - работает");
                Debug.WriteLine($"AppManager получил соощение в свойство TestProp -- {TestProp}");
            }
        }


        public void SwitchView(string nameView)
        {
            switch (nameView)
            {
                case "ManagerIndexes":
                    ManagerIndexesViewModel ManagerIndexesViewModel = new ManagerIndexesViewModel(DataContextApp);
                    

                    mainWindowViewModel.CurrentView = ManagerIndexesViewModel;
                    
                    break;

                case "Indexes":
                    IndexesViewModel indexesViewModel = new IndexesViewModel(DataContextApp);
                    

                    mainWindowViewModel.CurrentView = indexesViewModel;
                    break;

                case "Provider":
                    ProvidersViewModel providersViewModel = new ProvidersViewModel(DataContextApp);
                    mainWindowViewModel.CurrentView = providersViewModel;
                    break;
               
                // default: Debug.WriteLine(" ");
            }


        }

    }
}
