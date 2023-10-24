using WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp1.Data;
using System.Diagnostics;

namespace WpfApp1.ViewModels.Views
{
    public class ProvidersViewModel : BaseVM
    {
        ManagerIndexesViewModel managerIndexesViewModel;

        DataContextApp dс;

        public ProvidersViewModel(ManagerIndexesViewModel managerIndexesViewModel)
        {
            this.managerIndexesViewModel = managerIndexesViewModel;
            this.dс = this.managerIndexesViewModel.DataContextApp;
            
            LoadDataTest();
        }

        public ProvidersViewModel(DataContextApp dс)
        {
            this.dс = dс;

            LoadDataTest();
        }

        

        private ObservableCollection<Provider> providers;

        public ObservableCollection<Provider> Providers
        {
            get { return providers; }
            set 
            { 
                providers = value;
                RaisePropertyChanged(nameof(Providers));
            }
        }

        private ObservableCollection<Provider> providersView;

        public ObservableCollection<Provider> ProvidersView
        {
            get { return providersView; }
            set
            {
                providersView = value;
                RaisePropertyChanged(nameof(ProvidersView));
            }
        }


        public void LoadDataTest()
        {
            Providers = dс.Providers;
            ProvidersView = Providers;            

            Debug.WriteLine($"\n\n=== === === ProvidersViewModel.LoadDataTest() === === ===");
            // Debug.WriteLine($"Providers.Count -- {Providers.Count}");
        }

      

        public void LoadDataUnion(ObservableCollection<IndexProviderView> indexProviderView)
        {   
            ProvidersView = new ObservableCollection<Provider>(Providers
                                .Where(p => !indexProviderView
                                .Select(rp => rp.IdProvider).Contains(p.Id)));

            Debug.WriteLine($"\n\n=== === === ProvidersViewModel.LoadDataUnion(...) === ===");
            // Debug.WriteLine($"ProvidersView.Count -- {ProvidersView.Count}");
            // Debug.WriteLine($"Providers.Count -- {Providers.Count}");

            //foreach (var item in ProvidersView)
            //{
            //    Debug.WriteLine($"item.Id: {item.Id} | item.Name: {item.Name}");
            //}
        }
       
    }
}
