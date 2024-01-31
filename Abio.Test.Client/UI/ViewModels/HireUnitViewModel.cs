using Abio.Library.DatabaseModels;
using Abio.Test.Client.Business.Builder;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Abio.Test.Client.UI.ViewModels
{
    public class HireUnitViewModel
    {
        public HireUnitViewModel() {
            Initialize();
        } 

        public void Initialize()
        {
            HiredUnitDefaultBuilder hiredUnitDefaultBuilder = new HiredUnitDefaultBuilder();
            DefaultHiredUnit = hiredUnitDefaultBuilder.Build();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public RelayCommand GoBackCommand => _goBackCommand ??= new RelayCommand(GoBack);
        private RelayCommand _goBackCommand;

        public HiredUnit DefaultHiredUnit { get; set; }

        public void GoBack()
        {
            Shell.Current.GoToAsync("//Home");
        }
    }
}
