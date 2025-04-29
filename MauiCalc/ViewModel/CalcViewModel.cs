using System;

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

}
