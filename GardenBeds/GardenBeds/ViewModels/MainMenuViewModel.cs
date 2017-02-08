using System.Collections.ObjectModel;
using GardenBeds.Models;
using GardenBeds.Services;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace GardenBeds.ViewModels
{
    public class MainMenuViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IGardenBedsService _gardenBedsService;
        private bool _loading = true;

        public MainMenuViewModel(INavigationService navigationService, IGardenBedsService gardenBedsService)
        {
            _navigationService = navigationService;
            _gardenBedsService = gardenBedsService;

            NavigateToDetailsCommand = new DelegateCommand<GardenBed>(NavigateToDetails);
            LoadData();
        }
        
        private async void LoadData()
        {
            var beds = await _gardenBedsService.GetGardenBeds();
            beds.ForEach(bed => GardenBeds.Add(bed));
            Loading = false;
        }

        public bool Loading
        {
            get { return _loading; }
            set { SetProperty(ref _loading, value); }
        }

        public ObservableCollection<GardenBed> GardenBeds { get; } = new ObservableCollection<GardenBed>();

        public DelegateCommand<GardenBed> NavigateToDetailsCommand { get; private set; }

        private void NavigateToDetails(GardenBed obj)
        {
            _navigationService.NavigateAsync($"Details/{obj.Id}");
        }
    }
}