using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.UI.ViewModels
{
    public class ResourceInventoryViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        readonly Guid testguid = Guid.Parse("77754478-B688-42FB-BD4C-26E3831F1E2B");

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ResourceInventoryViewModel() {
            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            //this.Test = "Binding Correctly";

            var resources = await ApiService.GetAllResources();
            var playerResources = await ApiService.GetAllResourceInventorys();
            foreach (var item in playerResources)
            {
                item.Resource = resources.Where(p => p.ResourceId == item.ResourceId).FirstOrDefault();
            }
            this.PlayerResources = playerResources;

        }

       // public string Test = "can bind correctly";

        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                OnPropertyChanged();
            }
        }
        private string _test = string.Empty;
        public List<ResourceInventory> PlayerResources
        {
            get
            {
                return _playerResources;
            }
            set
            {
                _playerResources = value;
                OnPropertyChanged();
            }
        }
        private List<ResourceInventory> _playerResources = new List<ResourceInventory>();

    }
}
