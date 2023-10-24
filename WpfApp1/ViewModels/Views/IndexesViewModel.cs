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
    public class IndexesViewModel : BaseVM
    {   
        ManagerIndexesViewModel managerIndexesViewModel;
        
        DataContextApp DataContextApp;

        public IndexesViewModel(ManagerIndexesViewModel managerIndexesViewModel)
        {   

            this.managerIndexesViewModel = managerIndexesViewModel;
            this.DataContextApp = this.managerIndexesViewModel.DataContextApp;
                       

            // LoadData();
            Debug.WriteLine($"IndexesViewModel -- Конструктор -- IndexesViewModel(ManagerIndexesViewModel managerIndexesViewModel)");

            LoadDataTest2();
        }


        public IndexesViewModel(DataContextApp DataContextApp)
        {
            this.DataContextApp = DataContextApp;
                        
            LoadDataTest2();
        }




        private ObservableCollection<IndexCalculation> calculationIndexs;

        public ObservableCollection<IndexCalculation> СalculationIndexs
        {
            get { return calculationIndexs; }
            set 
            { 
                calculationIndexs = value;
                RaisePropertyChanged(nameof(СalculationIndexs));
            }
        }

        private IndexCalculation selectedIndexCalculation;

        public IndexCalculation SelectedIndexCalculation
        {
            get { return selectedIndexCalculation; }
            set 
            { 
                selectedIndexCalculation = value;


                if (selectedIndexCalculation == null) return;
                Debug.WriteLine($"--- --- --- --- --- --- --- --- ---");
                Debug.WriteLine($"IndexesViewModel--selectedIndexCalculation -- {selectedIndexCalculation.Name}");
                if (this.managerIndexesViewModel == null)
                {
                    Debug.WriteLine($"IndexesViewModel--selectedIndexCalculation -- managerIndexesViewModel = null\n");
                    return;
                }
             
                this.managerIndexesViewModel.SelectedIndexCalculation = selectedIndexCalculation;
                

                RaisePropertyChanged(nameof(SelectedIndexCalculation));
            }
        }

        
        public void LoadDataTest2()
        {
            СalculationIndexs = this.DataContextApp.СalculationIndexes;            

            Debug.WriteLine($"\n\n === === === IndexesViewModel === === === ");
            // Debug.WriteLine($"СalculationIndexs.Count -- {СalculationIndexs.Count}");
        }

        
    }
}
