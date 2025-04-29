using System;
using System.Windows.Input;

namespace MauiCalc.ViewModel;

public class CalcViewModel
{
    private string _label = "0";

    public string Label
    {
        get => _label;
        set
        {
            _label = value;
        }
    }

    public ICommand BtnCommand { get; }
    public CalcViewModel()
    {
        BtnCommand = new Command<string>(
            (n) =>
            {
            }
        );
    }

}
