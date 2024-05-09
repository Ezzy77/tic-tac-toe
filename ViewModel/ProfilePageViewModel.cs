using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace tic_tac_toe.ViewModel;

public class ProfilePageViewModel : INotifyPropertyChanged
{
    public string DeviceModel => DeviceInfo.Model;
    public string DeviceManufacturer => DeviceInfo.Manufacturer;
    public string DeviceName => DeviceInfo.Name;
    public string DeviceVersion => DeviceInfo.VersionString;
    public string DevicePlatform => DeviceInfo.Platform.ToString();
    public string DeviceIdiom => DeviceInfo.Idiom.ToString();

    public double BatteryLevel => Battery.ChargeLevel;

    public string NetworkAccess => Connectivity.NetworkAccess.ToString();

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}