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
            var buildingLevels = await ApiService.GetAllBuildingLevels();
            ConstructedBuilding c = new ConstructedBuilding();
            c.BuildingId = this.Buildings.Where(b => b.BuildingId == buildingId).FirstOrDefault().BuildingId;
            c.BuildingLevelId = buildingLevels.FirstOrDefault().BuildingLevelId;
            c.UserId = testguid;
            //c.User = await ApiService.GetUser(testguid);
            var result = await ApiService.CreateConstructedBuilding(c);
            var con = await SignalRExtension.GetSignalRConnection();
            await con.DoCombatLogicAsync(await GatherArmy());
        }

        private async Task<CombatMessage> GatherArmy()
        {
            var units = await ApiService.GetAllUnits();

            List<Unit> army1 = new List<Unit>();
            List<Unit> army2 = new List<Unit>();

            var peasant = units.Where(p => p.UnitName == "Peasant").First();
            var knight = units.Where(p => p.UnitName == "Knight").First();
            for (int i = 0; i < 10; i++)
            {
                army1.Add(peasant);
            }

            for (int i = 0; i < 5; i++)
            {
                army2.Add(knight);
            }
            CombatMessage message = new CombatMessage();
            message.Army1 = army1;
            message.Army2 = army2;
            return message;
        }
    }
}
