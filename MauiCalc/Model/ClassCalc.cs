using System;

namespace MauiCalc.Model;

public class ClassCalc
{
    // デリゲートのインスタンス化
    private Func<Decimal, Decimal> _deleCalc = d => d;

    //計算対象値
    private Decimal _operand = 0;
    // 計算ボタンが押されたか？
    private bool _cmdKey = false;
    // 現在表示されている数値
    public string Display { get; set; } = "";

    public ClassCalc()
    {
        ClrKey();
    }

    // 計算ボタンが押された時の処理
    string CmdKeyMethod(Func<Decimal, Decimal> p)
    {
        decimal dtmp = 0;

        try
        {
            // 現在表示されている数値をパラメーターとして計算処理
            dtmp = _deleCalc(decimal.Parse(Display));
        }
        catch
        {
            // 例外時は0
        }

        // 計算ボタン押下フラグ
        _cmdKey = true;
        // 次回の計算処理を設定
        _deleCalc = p;
        
        return string.Format("{0:0.##########}", dtmp);
    }

    // 「+」ボタン
    public string PlusKey()
    {
        return CmdKeyMethod((d) => _operand += d);
    }
    // 「-」ボタン
    public string MinusKey()
    {
        return CmdKeyMethod((d) => _operand -= d);
    }
    // 「*」ボタン
    public string MultiKey()
    {
        return CmdKeyMethod((d) => _operand *= d );
    }
    // 「/」ボタン
    public string DivisionKey()
    {
        return CmdKeyMethod((d) => _operand /= d);
    }
    // 「=」ボタン
    public string EnterKey()
    {
        return CmdKeyMethod((d) => _operand = d);
    }
    // 「C」クリアボタン
    public string ClrKey()
    {
        _operand = 0;
        // 代入処理を初期設定に
        _deleCalc = (d) => _operand = d;
        return "0";
    }
    // 数字ボタン
    public string NumKey(int n)
    {
        if (_cmdKey == true)
        {
            // 計算ボタンフラグ
            _cmdKey = false;
            // 数値表示の置き換え
            Display = n.ToString();
        }
        // 0かつ小数点が無い
        else if (decimal.Parse(Display) == 0 && !Display.Contains("."))
        {
            // 数値表示の置き換え
            Display = n.ToString();
        }
        // 数値の長さが10未満
        else if (Display.Length < 10)
        {
            // 数値を追加し表示を置き換え
            Display += n.ToString();
        }
        return Display;
    }
    // 「.」ボタン
    public string DotKey()
    {
        // 計算ボタンが押されたか
        if (_cmdKey == true)
        {
            //計算ボタンフラグ
            _cmdKey = false;
            //0と小数点に置き換え
            Display = "0.";
        }
        else
        {
            // 小数点が無く、数値の長さが10未満
            if(!Display.Contains(".") && Display.Length <10)
            {
                // 数値に小数点を追加する
                Display += ".";
            }
        }
        return Display;
    }
}
