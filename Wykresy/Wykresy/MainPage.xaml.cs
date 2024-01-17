using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

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

        private void ChartAppearing(object sender, EventArgs e)
        {
            gridWykres.ColumnDefinitions.Clear();
            gridWykres.RowDefinitions.Clear();
            gridWykres.Children.Clear();

            for (int i = 0; i < DaneWykres.Count; i++) gridWykres.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridWykres.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridWykres.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Absolute) });
            gridWykres.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            if (DaneWykres.Count > 0)
            {
                double max = DaneWykres.Max(x => x.Value);
                for (int i = 0; i < DaneWykres.Count; i++)
                {
                    Label chartValue = new Label
                    {
                        Text = DaneWykres[i].Value.ToString(),
                        TextColor = Color.White,
                        HorizontalOptions = LayoutOptions.Center
                    };

                    Label title = new Label
                    {
                        Text = DaneWykres[i].Name,
                        HorizontalOptions = LayoutOptions.Center,
                        FontSize = 15
                    };

                    StackLayout wykres = new StackLayout
                    {
                        BackgroundColor = Colors[i],
                        HeightRequest = DaneWykres[i].Value / max * 700,
                        VerticalOptions = LayoutOptions.End,
                        Margin = new Thickness(15),
                        AnchorY = 1,
                        ScaleY = 0
                    };
                    wykres.Children.Add(chartValue);

                    gridWykres.Children.Add(wykres, i, 0);
                    gridWykres.Children.Add(title, i, 2);
                    wykres.ScaleYTo(1, 1500, Easing.SinInOut);
                }
            }
            labelWykres.Text = Title;

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditPage());
        }

    }
}
