using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Views.Views;
using WpfApp1.Data;


namespace WpfApp1.ViewModels.Views
{
    public class ManagerIndexesViewModel : BaseVM
    {
        
       
        IndexesViewModel indexesViewModel;
        ProvidersViewModel providersViewModel;

        IndexesProvidersViewModel indexesProvidersViewModel;

        public DataContextApp DataContextApp;

        //public ManagerIndexesViewModel()
        //{

        //}

        public ManagerIndexesViewModel(DataContextApp DataContextApp)
        {
            // appManager             
            this.DataContextApp = DataContextApp;

            // ViewModel
            this.indexesViewModel = new IndexesViewModel(this);
            IndexesView iView = new IndexesView();
            iView.DataContext = indexesViewModel;            
            IndexesView = this.indexesViewModel;
                        
            // providersViewModel
            this.providersViewModel = new ProvidersViewModel(this);
            ProvidersView pView = new ProvidersView();
            pView.DataContext = providersViewModel;            
            ProvidersView = this.providersViewModel;

            // indexesProvidersViewModel
            this.indexesProvidersViewModel = new IndexesProvidersViewModel(this);
            IndexesProvidersView ipView = new IndexesProvidersView();
            ipView.DataContext = indexesProvidersViewModel;
            IndexesProvidersView = this.indexesProvidersViewModel;
                       

        }

        private IndexCalculation selectedIndexCalculation;

        public IndexCalculation SelectedIndexCalculation
        {
            get { return selectedIndexCalculation; }
            set
            {
                selectedIndexCalculation = value;
                
                Debug.WriteLine($"ManagerIndexesViewModel--indexCalculation.Name -- {selectedIndexCalculation.Name}");
                
                if (indexesProvidersViewModel == null) return;

                // indexesProvidersViewModel.SelectedIndexCalculation = selectedIndexCalculation;
                this.indexesProvidersViewModel.SelectedIndexCalculation = selectedIndexCalculation;
                this.indexesProvidersViewModel.IndexProviderFilter = selectedIndexCalculation;

                var ips = this.indexesProvidersViewModel.GetIndexProvidersViewSource(selectedIndexCalculation);
                this.providersViewModel.LoadDataUnion(ips);

                RaisePropertyChanged(nameof(SelectedIndexCalculation));          
            }
        }



        /// <summary>
        /// View
        /// </summary>
        #region View
        // IndexesView
        private BaseVM indexesView;

        public BaseVM IndexesView
        {
            get { return indexesView; }
            set 
            { 
                indexesView = value;
                RaisePropertyChanged(nameof(IndexesView));            
            }
        }

        // ProvidersView
        private BaseVM providersView;

        public BaseVM ProvidersView
        {
            get { return providersView; }
            set
            { 
                providersView = value;
                RaisePropertyChanged(nameof(ProvidersView));
            }
        }

        // IndexesProvidersView
        private BaseVM indexesProvidersView;

        public BaseVM IndexesProvidersView
        {
            get { return indexesProvidersView; }
            set
            { 
                indexesProvidersView = value;
                RaisePropertyChanged(nameof(IndexesProvidersView));
            }
        }
        #endregion


    }
}
