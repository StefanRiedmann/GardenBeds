using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardenBeds.Models;
using GardenBeds.ViewModels;
using Xamarin.Forms;

namespace GardenBeds.Views
{
    public partial class MainMenu : ContentPage
    {
        private MainMenuViewModel ViewModel => BindingContext as MainMenuViewModel;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var b = e.SelectedItem as GardenBed;
            if (b != null)
                ViewModel?.NavigateToDetailsCommand.Execute(b);
        }
    }
}
