using Abio.Library.DatabaseModels;
using Abio.Library.Services;
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

    }
}
