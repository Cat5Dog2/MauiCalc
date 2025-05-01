using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiCalc.ViewModel;

public class CalcViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private string _label = "0";

    public string Label
    {
        get => _label;
        set
        {
            _label = value;
            OnPropertyChanged();
        }
    }

    public ICommand BtnCommand { get; }
    public CalcViewModel()
    {
        BtnCommand = new Command<string>(
            (n) =>
            {
                this.Label = n;
            }
        );
    }

}
