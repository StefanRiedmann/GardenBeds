using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GardenBeds.ViewModels;
using Xamarin.Forms;

namespace GardenBeds.Views
{
    public partial class Detail : ContentPage
    {
        public DetailViewModel ViewModel => BindingContext as DetailViewModel;

        public Detail()
        {
            InitializeComponent();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            ViewModel?.NavigateBackCommand.Execute();
        }
    }
}
