using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.ViewModels.Views;

namespace WpfApp1.ViewModels
{
    internal class MainWindowViewModel : BaseVM
    {
        AppManager appManager;
        
        public MainWindowViewModel(AppManager appManager)
        {
            this.appManager = appManager;
            
            LoadItemMainMenu();
        }

        //public MainWindowViewModel() : this(new AppManager())
        //{

        //}


        #region Title
        private string title = "App `WpfApp1`. Prop title";
        
        public string Title 
        {
            get { return title; }
            set { title = value; }
        }
        #endregion

        #region mainMenuItems        
        private ObservableCollection<MainMenuItemMainWindow> mainMenuItems;

        public ObservableCollection<MainMenuItemMainWindow> MainMenuItems
        {
            get { return mainMenuItems; }
            set
            {
                mainMenuItems = value;
                RaisePropertyChanged(nameof(MainMenuItemMainWindow));
            }
        }
        #endregion

        #region SelectedItem
        private MainMenuItemMainWindow selectedMainMenuItem;

        public MainMenuItemMainWindow SelectedMainMenuItem
        {
            get { return selectedMainMenuItem; }
            set 
            {                 
                selectedMainMenuItem = value;
                Debug.WriteLine($"MainWindowViewModel -- selectedMainMenuItem.Alias -- {selectedMainMenuItem.Alias}");

                TitleDetail = selectedMainMenuItem.Name;
                appManager.SwitchView(selectedMainMenuItem.Alias);

                RaisePropertyChanged(nameof(CurrentView));
            }
        }
        #endregion


        private BaseVM currentView;
        public BaseVM CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                RaisePropertyChanged(nameof(CurrentView));
            }
        }

        #region TitleDetail
        private string titleDetail = "TitleDetail";

        public string TitleDetail
        {
            get { return titleDetail; }
            set 
            { 
                titleDetail = value;
                Debug.WriteLine($"titleDetail -- {titleDetail}");
                RaisePropertyChanged(nameof(TitleDetail));
            }
        }
        #endregion

        //private object currentView;
        //public object CurrentView
        //{
        //    get { return currentView; }
        //    set
        //    {
        //        currentView = value;
        //        RaisePropertyChanged(nameof(CurrentView));
        //    }
        //}



        public void LoadItemMainMenu()
        {
            mainMenuItems = new ObservableCollection<MainMenuItemMainWindow>()
            {
                new MainMenuItemMainWindow(){ Name = "Управление коэффициентами", Alias ="ManagerIndexes" },
                new MainMenuItemMainWindow(){ Name = "Коэффициенты", Alias ="Indexes"  },
                new MainMenuItemMainWindow(){ Name = "Поставщки", Alias ="Provider"  }
            };
            
            // appManager.TestProp = "MainWindowViewModel - выполнен метод LoadItemenu";
        }

    }
}
