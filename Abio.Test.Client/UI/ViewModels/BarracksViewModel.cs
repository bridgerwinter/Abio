using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.UI.ViewModels
{
    public class BarracksViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public BarracksViewModel()
        {
            InitializeAsync();
        }  
        public async void InitializeAsync()
        {
            var units = await ApiService.GetAllUnits();
            this.AllUnits = new ObservableCollection<Unit>(units);
        }

        public RelayCommand<int> HireUnitCommand => _hireUnitCommand ??= new RelayCommand<int>(HireUnitAsync);
        private RelayCommand<int> _hireUnitCommand;


        public ObservableCollection<Unit> AllUnits
        {
            get
            {
                return _allUnits;
            }
            set
            {
                _allUnits = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Unit> _allUnits = new ObservableCollection<Unit>();

        //Generate Helper during initialization? Like how we pass in the interfaces at work. 
        //To do update all ApiServices that get a specific value with a "/"
        // Refresh Army List
        private async void HireUnitAsync(int unitId)
        {
            await Business.ApiHelper.HireUnitHelper.HireUnitAsync(unitId);
        }

    }
}
