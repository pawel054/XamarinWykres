using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wykresy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EditPage()
        {
            InitializeComponent();
            for (int i = 0; i < MainPage.DaneWykres.Count; i++)
            {
                (gridDane.Children[i] as Entry).Text = MainPage.DaneWykres[i].Name;
                (gridDane.Children[i+7] as Entry).Text = MainPage.DaneWykres[i].Value.ToString();
            }

            entryTitle.Text = MainPage.Tytul;
        }

        private void BtnClicked(object sender, EventArgs e)
        {
            MainPage.DaneWykres = new List<DaneWykres>();

            for (int i = 0; i < 7; i++)
            {
                if (!string.IsNullOrWhiteSpace((gridDane.Children[i] as Entry).Text) && !string.IsNullOrWhiteSpace((gridDane.Children[i+7] as Entry).Text)) 
                    MainPage.DaneWykres.Add(new DaneWykres((gridDane.Children[i] as Entry).Text, double.Parse((gridDane.Children[i+7] as Entry).Text)));
            }

            if (string.IsNullOrWhiteSpace(entryTitle.Text))
                DisplayAlert("Alert", "Podano zły tytuł!", "OK");
            else
            {
                MainPage.Tytul = entryTitle.Text;
                Navigation.PopAsync();
            }
        }
    }
}