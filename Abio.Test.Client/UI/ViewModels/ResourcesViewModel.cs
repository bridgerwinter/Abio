using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abio.Test.Client.UI.ViewModels
{
    public class ResourcesViewModel : INotifyPropertyChanged
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

        public ResourcesViewModel()
        {
            InitializeAsync();
        }
        public async void InitializeAsync()
        {
            StartCounterAsync();
        }
        public async void StartCounterAsync()
        {
            IDispatcherTimer timer;
            timer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += (s, e) =>
            {
                IncrementResource();
            };
            timer.Start();
        }

        public bool Stop = false;
        public void IncrementResource()
        {
            GatherableGold += 1;
            GatherableWheat += 1;
            GatherableWood += 1;
        }
        public RelayCommand GatherWheatCommand => _gatherWheatCommand ??= new RelayCommand(GatherWheatAsync);
        private RelayCommand _gatherWheatCommand;

        public RelayCommand GatherWoodCommand => _gatherWoodCommand ??= new RelayCommand(GatherWoodAsync);
        private RelayCommand _gatherWoodCommand;

        public RelayCommand GatherGoldCommand => _gatherGoldCommand ??= new RelayCommand(GatherGoldAsync);
        private RelayCommand _gatherGoldCommand;
        

        public BigInteger GatherableWheat
        {
            get
            {
                return _gatherableWheat;
            }
            set
            {
                _gatherableWheat = value;
                OnPropertyChanged();
            }
        }
        private BigInteger _gatherableWheat;

        public BigInteger GatherableWood
        {
            get
            {
                return _gatherableWood;
            }
            set
            {
                _gatherableWood = value;
                OnPropertyChanged();
            }
        }
        private BigInteger _gatherableWood;

        public BigInteger GatherableGold
        {
            get
            {
                return _gatherableGold;
            }
            set
            {
                _gatherableGold = value;
                OnPropertyChanged();
            }
        }
        private BigInteger _gatherableGold;

        public BigInteger TotalWheat
        {
            get
            {
                return _totalWheat;
            }
            set
            {
                _totalWheat = value;
                OnPropertyChanged();
            }
        }
        private BigInteger _totalWheat;
        public BigInteger TotalWood
        {
            get
            {
                return _totalWood;
            }
            set
            {
                _totalWood = value;
                OnPropertyChanged();
            }
        }
        private BigInteger _totalWood;

        public BigInteger TotalGold
        {
            get
            {
                return _totalGold;
            }
            set
            {
                _totalGold = value;
                OnPropertyChanged();
            }
        }
        private BigInteger _totalGold;


        //Rename to food. 
        private async void GatherWheatAsync()
        {
            TotalWheat = TotalWheat + GatherableWood;
            GatherableWheat = 0;
        }

        private async void GatherWoodAsync()
        {
            TotalWood = TotalWood + GatherableWood;
            GatherableWood = 0;
        }
        private async void GatherGoldAsync()
        {
            TotalGold = TotalGold + GatherableGold;
            GatherableGold = 0;
        }

    }

}
