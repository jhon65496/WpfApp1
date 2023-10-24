using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;



namespace WpfApp1.Data
{
    public class DataContextApp
    {
        public DataContextApp()
        {
            GenerateDataСalculationIndex();
            GenerateDataProviders();            
            GenerateDataIndexProvider3();
        }


        private ObservableCollection<IndexCalculation> calculationIndexes;

        public ObservableCollection<IndexCalculation> СalculationIndexes
        {
            get { return calculationIndexes; }
            set { calculationIndexes = value; }
        }


        private ObservableCollection<Provider> providers;

        public ObservableCollection<Provider> Providers
        {
            get { return providers; }
            set { providers = value; }
        }


        private ObservableCollection<IndexProvider> indexProviders;

        public ObservableCollection<IndexProvider> IndexProviders
        {
            get { return indexProviders; }
            set { indexProviders = value; }
        }

        private ObservableCollection<IndexProviderView> indexProvidersJoinView;

        public ObservableCollection<IndexProviderView> IndexProvidersJoinView
        {
            get { return indexProvidersJoinView; }
            set { indexProvidersJoinView = value; }
        }

        

        // ---- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        public void GenerateDataСalculationIndex()
        {
            var calculationIndexes = new ObservableCollection<IndexCalculation>();
            for (int i = 1; i < 11; i++)
            {
                var indexCalculation = new IndexCalculation()
                {
                    Id = i,
                    Name = $"NameIndex-{i}",
                    Description = $"DescriptionIndex-{i}"
                };
                calculationIndexes.Add(indexCalculation);
            }

            СalculationIndexes = calculationIndexes;
        }


        public void GenerateDataProviders()
        {
            Providers = new ObservableCollection<Provider>();
            for (int i = 1; i < 101; i++)
            {
                var provider = new Provider()
                {
                    Id = i,
                    Name = $"NameProvider-{i}",
                    Description = $"DescriptionProvider-{i}"
                };
                Providers.Add(provider);
            }
        }


        public void GenerateDataIndexProvider3()
        {
            IndexProviders = new ObservableCollection<IndexProvider>();

            int idIndexProvider = 1;
            int indexCurrentProvider = 1;

            for (int ii = 3; ii < 11; ii++)     // Index
            {
                int step = 10;
                int indexFirstProvider = indexCurrentProvider;
                int indeLastProvider = indexFirstProvider + step;

                for (int ip = indexFirstProvider; ip < indeLastProvider; ip++) // Provider
                {
                    // idIndexProvider         
                    var indexProveder = new IndexProvider()
                    {
                        Id = idIndexProvider,
                        IdIndex = ii,
                        IdProvider = ip
                    };
                    IndexProviders.Add(indexProveder);
                    idIndexProvider++;
                }
                indexCurrentProvider = indeLastProvider++;
            }
           
            CreateView2();//
        }

        public void CreateView2()
        {
            var IndexProviderViews = IndexProviders.Join(Providers,
                 ip => ip.IdProvider, p => p.Id,
                (ip, p) => new IndexProviderView
                {
                    Id = ip.Id,
                    IdIndex = ip.IdIndex,
                    IdProvider = ip.IdProvider,                   

                    NameProvider = p.Name
                }).ToList();

            IndexProvidersJoinView = new ObservableCollection<IndexProviderView>(IndexProviderViews);
        }
    }
}
