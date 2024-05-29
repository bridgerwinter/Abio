using Abio.Library.DatabaseModels;
using Abio.Library.Services;
using Abio.Test.Client.Business.Builder;
using Abio.Test.Client.Business.Hubs;
using Abio.Test.Client.UI.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Abio.Test.Client.UI.ViewModels;

public class HomePageViewModel : INotifyPropertyChanged
{
    #region init
    public HomePageViewModel()
    {
        InitializeAsync();
    }

    public async void InitializeAsync()
    {
        var units = await ApiService.GetAllHiredUnits();
        HiredUnits = new ObservableCollection<HiredUnit>(units);
    }
    #endregion
    #region Properties
    public SignalRConnection Connection { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public ObservableCollection<HiredUnit> HiredUnits
    {
        get
        {
            return _hiredUnits;
        }
        set
        {
            _hiredUnits = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<HiredUnit> _hiredUnits = new ObservableCollection<HiredUnit>();

    #endregion
    #region Commands
    public RelayCommand CreateUnitCommand => _createUnitCommand ??= new RelayCommand(CreateUnit);
    private RelayCommand _createUnitCommand;
    #endregion
    #region Methods
    private async void CreateUnit()
    {
        //await Shell.Current.GoToAsync("//HireUnit");
        //Window window = new Window(new HireUnitScreenView());
        //Application.Current.(window);
        //HiredUnitDefaultBuilder hiredUnitDefaultBuilder = new HiredUnitDefaultBuilder();
        //var unit = hiredUnitDefaultBuilder.Build();
        //await ApiService.CreateHiredUnit(unit);
        //await RefreshUnits();
    }

    public async Task RefreshUnits()
    {
        var units = await ApiService.GetAllHiredUnits();
        HiredUnits = new ObservableCollection<HiredUnit>(units);
    }
    #endregion
}