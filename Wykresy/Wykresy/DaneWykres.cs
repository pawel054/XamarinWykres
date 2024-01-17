using System;
using System.Collections.Generic;
using System.Text;

namespace Wykresy
{
    public class DaneWykres
    {
        public string Name {  get; set; }
        public double Value {  get; set; }

        public DaneWykres(){}
        public DaneWykres(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
