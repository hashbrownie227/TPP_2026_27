using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

class Polynomial
{
    private List<double> _coefs; //
    public IReadOnlyList<double> Coefs => _coefs; //()

    //
    public Polynomial(IEnumerable<double> coefs)
    {
        _coefs = coefs.ToList();
    }

    // P(x)
    public double Evaluate(double x)
    {
        double result = 0;
        for (int i = _coefs.Count - 1; i >= 0; i--)
        {
            result = result * x + _coefs[i]; //
        }
        return result;
    }

    //
    public double this[int i]
    {
        get => _coefs[i];
        set=> _coefs[i] = value;
    }

    //ToString()
    public override string ToString()
    {
        var terms = new List<string>();
        for (int i = 0; i < _coefs.Count; i++)
        {
            double c = _coefs[i];
            if (i==0) terms.Add($"{c}");
            else if (i==1) terms.Add($"{c}x");
            else terms.Add($"{c}x^{i}");
        }
        return "P(x) = " + string.Join(" + ", terms);
    }
    public void PrintCoefs()
    {
        for(int i = 0; i < _coefs.Count; i++)
        {
            Console.Write($"{_coefs[i]} ");
        }
        Console.WriteLine();
    }

    public Polynomial Add(Polynomial other)
    {
        var res = new List<double>();
        if (this._coefs.Count > other._coefs.Count)
        {
            for (int i = 0; i < other._coefs.Count; i++)
            {
                double num = this._coefs[i] + other._coefs[i];
                res.Add(num);
            }
            for (int i = other._coefs.Count; i < this._coefs.Count; i++)
            {
                res.Add(this._coefs[i]);
            }
        }
        else
        {
            for (int i = 0; i < this._coefs.Count; i++)
            {
                double num = other._coefs[i] + this._coefs[i];
                res.Add(num);
            }
            for (int i = this._coefs.Count; i < other._coefs.Count; i++)
            {
                res.Add(other._coefs[i]);
            }
        }
        
        Polynomial NewPol = new Polynomial(res);
        return NewPol;
    }
}

class Program
{
    static void Main()
    {
        var p = new Polynomial(new double[] {1, 2, 3});
        Console.WriteLine(p);
        Console.WriteLine("P(2) = " + p.Evaluate(2));
        p.PrintCoefs();
        var p2 = new Polynomial(new double[] {66, 65, 64, 67});
        Console.WriteLine(p2);
        Console.WriteLine("Складываем");
        Console.WriteLine(p.Add(p2));
    }
}