using Abio.Library.Actions;
using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using Abio.Test.Client.Business;
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
    public class PlayerBuildingsViewModel : INotifyPropertyChanged
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

        public PlayerBuildingsViewModel()
        {
            InitializeAsync();
        }
        public async void InitializeAsync()
        {
            var buildings = await ApiService.GetAllBuildings();
            this.Buildings = new ObservableCollection<Building>(buildings);
        }


        public RelayCommand<int> ConstructBuildingCommand => _constructBuildingCommand ??= new RelayCommand<int>(ConstructBuildingAsync);
        private RelayCommand<int> _constructBuildingCommand;


        public ObservableCollection<Building> Buildings
        {
            get
            {
                return _buildings;
            }
            set
            {
                _buildings = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Building> _buildings = new ObservableCollection<Building>();
        readonly Guid testguid = Guid.Parse("77754478-B688-42FB-BD4C-26E3831F1E2B");

        //Generate Helper during initialization? Like how we pass in the interfaces at work. 
        //To do update all ApiServices that get a specific value with a "/"
        // Refresh Army List
        private async void ConstructBuildingAsync(int buildingId)
        {
            // Find Better way to deposit resource id into database. 
            var buildingLevels = await ApiService.GetAllBuildingLevels();
            ConstructedBuilding c = new ConstructedBuilding();
            c.BuildingId = this.Buildings.Where(b => b.BuildingId == buildingId).FirstOrDefault().BuildingId;
            c.BuildingLevelId = buildingLevels.FirstOrDefault().BuildingLevelId;
            c.UserId = testguid;
            var con = await SignalRExtension.GetSignalRConnection();
            await con.CreateConstructedBuilding(c);
        }
    }
}
