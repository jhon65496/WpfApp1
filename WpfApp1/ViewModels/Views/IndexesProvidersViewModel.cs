using WpfApp1.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfApp1.Data;
using System.Diagnostics;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels.Views
{
    public class IndexesProvidersViewModel : BaseVM
    {
        ManagerIndexesViewModel managerIndexesViewModel;
        public DataContextApp DataContextApp;
        public IndexesProvidersViewModel(ManagerIndexesViewModel managerIndexesViewModel)
        {
            this.managerIndexesViewModel = managerIndexesViewModel;
            this.DataContextApp = this.managerIndexesViewModel.DataContextApp;

            LoadData();
        }


        public IndexesProvidersViewModel(DataContextApp DataContextApp)
        {
            this.DataContextApp = DataContextApp;

            LoadData();
        }


        private ObservableCollection<IndexProviderView> indexProvidersJoinView;

        public ObservableCollection<IndexProviderView> IndexProvidersJoinView
        {
            get { return indexProvidersJoinView; }
            set
            {
                indexProvidersJoinView = value;

                _IndexProvidersViewSource = new CollectionViewSource();
                _IndexProvidersViewSource.Source = value;
                _IndexProvidersViewSource.Filter += OnIndexProvidersFilter3;
                _IndexProvidersViewSource.View.Refresh(); // System.NullReferenceException: "Ссылка на объект не указывает на экземпляр объекта."

                RaisePropertyChanged(nameof(IndexProvidersJoinView));
            }
        }


        private IndexCalculation _IndexProviderFilter;

        public IndexCalculation IndexProviderFilter
        {
            get { return _IndexProviderFilter; }
            set
            {
                _IndexProviderFilter = value;

                if (IndexProviderFilter == null)
                {
                    Debug.WriteLine($"IndexesProvidersViewModel -- IndexProviderFilter.Name -- Null !!!!");
                    return;
                }
                Debug.WriteLine($"IndexesProvidersViewModel -- IndexProviderFilter.Name -- {IndexProviderFilter.Name}");

                _IndexProvidersViewSource.View.Refresh();
            }
        }


        private void OnIndexProvidersFilter3(object sender, FilterEventArgs e)
        {

            if (!(e.Item is IndexProviderView indexProviderView)) return;


            if (IndexProviderFilter == null) return;


            if (indexProviderView.IdIndex == IndexProviderFilter.Id)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        #region CollectionView
        private CollectionViewSource _IndexProvidersViewSource;

        public ICollectionView IndexProvidersView => _IndexProvidersViewSource?.View;
        #endregion

        #region SelectedIndexCalculation
        private IndexCalculation _selectedIndexCalculation;

        public IndexCalculation SelectedIndexCalculation
        {
            get { return _selectedIndexCalculation; }
            set
            {
                _selectedIndexCalculation = value;

                Debug.WriteLine($"IndexesProvidersViewModel -- _selectedIndexCalculation.Name -- {_selectedIndexCalculation.Name}");

                RaisePropertyChanged(nameof(SelectedIndexCalculation));
            }
        }
        #endregion

        #region Command TestCommand - Тестовая команда
        /// <summary>Тестовая команда</summary>
        private ICommand _TestCommand;

        /// <summary>Тестовая команда</summary>
        public ICommand TestCommand
        {
            get
            {
                if (_TestCommand == null)
                {
                    _TestCommand = new LambdaCommand(OnTestCommandExecuted, CanTestCommandExecute);
                }
                return _TestCommand;
            }
        }

        /// <summary>Проверка возможности выполнения - Тестовая команда</summary>
        private bool CanTestCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Тестовая команда</summary>
        private void OnTestCommandExecuted(object p)
        {
            //var value = _UserDialog.GetStringValue("Введите строку", "123", "Значение по умолчанию");
            //_UserDialog.ShowInformation($"Введено: {value}", "123");

            Debug.WriteLine("WpfApp1--OnTestCommandExecuted(object p)");
            // Output();
        }
        #endregion


        public void LoadData()
        {
            IndexProvidersJoinView = this.DataContextApp.IndexProvidersJoinView;

            Debug.WriteLine($"\n\n === === === IndexesProvidersViewModel === === ===");
            // Debug.WriteLine($"IndexesProvidersViewModel -- LoadData5() -- IndexProviders.Count          -- {IndexProviders.Count}");
            Debug.WriteLine($"IndexesProvidersViewModel -- LoadData5() -- indexProvidersJoinView.Count  -- {indexProvidersJoinView.Count}");
        }


        public ObservableCollection<IndexProviderView> GetIndexProvidersViewSource(IndexCalculation indexCalculation)
        {
            int id = indexCalculation.Id;

            var r = IndexProvidersJoinView.Where(x => x.IdIndex == id).ToList();

            var ips = new ObservableCollection<IndexProviderView>(r);

            // var ips1 = ips[0].
            return ips;

            //foreach (var item in r)
            //{
            //    Debug.WriteLine($"item.IdIndex -- {item.IdIndex} -- item.NameProvider -- {item.NameProvider}");
            //}
            // ObservableCollection<IndexProviderView> IndexProvidersJoinView
        }
    }
}
