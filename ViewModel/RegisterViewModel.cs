using System.ComponentModel;
using System.Runtime.CompilerServices;
using tic_tac_toe.Services;

namespace tic_tac_toe.ViewModel;

public class RegisterViewModel : INotifyPropertyChanged
{
    public readonly AuthService AuthService;
    public event PropertyChangedEventHandler PropertyChanged;
    
    private string _email;
    public string Email 
    { 
        get => _email; 
        set
        {
            if (_email != value)
            {
                _email = value;
                OnPropertyChanged();
            }
        }
    }
    
    private string _password;
    public string Password 
    { 
        get => _password; 
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }

    public RegisterViewModel()
    {
        AuthService = new AuthService();
    }
    
    

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}