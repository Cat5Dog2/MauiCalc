using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiCalc.Model;

namespace MauiCalc.ViewModel;

public class CalcViewModel : INotifyPropertyChanged
{
    // プロパティ変更通知
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    // 計算結果フィールド
    private string _label = "0";

    // 計算結果プロパティ
    public string Label
    {
        get => _label;
        set
        {
            _label = value;
            // 更新通知
            OnPropertyChanged();
        }
    }

    // 電卓クラスのインスタンス化
    readonly ClassCalc _calc = new();
    // ボタンが押された時のコマンド
    public ICommand BtnCommand { get; }

    public CalcViewModel()
    {
        BtnCommand = new Command<string>(
            (n) =>
            {
                // 現在の数値をプロパティに設定
                _calc.Display = this.Label;
                // パラメーターで処理分岐
                this.Label = n switch
                {
                    "C" => _calc.ClrKey(),
                    "." => _calc.DotKey(),
                    "/" => _calc.DivisionKey(),
                    "*" => _calc.MultiKey(),
                    "+" => _calc.PlusKey(),
                    "-" => _calc.MinusKey(),
                    "=" => _calc.EnterKey(),
                    // その他は数値キー
                    _ => _calc.NumKey(int.Parse(n)),
                };
            }
        );
    }

}
