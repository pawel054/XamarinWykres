using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wykresy
{
    public partial class MainPage : TabbedPage
    {
        public static List<DaneWykres> DaneWykres { get; set; }
        public static string Tytul = "Przykadowy wykres";
        private Brush[] Brushes = { Brush.Red, Brush.Blue, Brush.Orange, Brush.Green, Brush.Yellow, Brush.Pink };
        private Color[] Colors = { Color.Red, Color.Blue, Color.Orange, Color.Green, Color.Yellow, Color.Pink };
        public MainPage()
        {
            InitializeComponent();

            DaneWykres = new List<DaneWykres>
            {
                new DaneWykres("Seria 1", 10),
                new DaneWykres("Seria 2", 25),
                new DaneWykres("Seria 3", 5),
                new DaneWykres("Seria 4", 90),
            };
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditPage());
        }

    }
}
