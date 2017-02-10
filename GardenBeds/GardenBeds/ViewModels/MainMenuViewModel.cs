using System;
using System.Collections.ObjectModel;
using GardenBeds.Models;
using GardenBeds.Services;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace GardenBeds.ViewModels
{
    public class MainMenuViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IGardenBedService _gardenBedService;
        private bool _loading = true;

        public MainMenuViewModel(INavigationService navigationService, IGardenBedService gardenBedService)
        {
            _navigationService = navigationService;
            _gardenBedService = gardenBedService;

            NavigateToDetailsCommand = new DelegateCommand<GardenBed>(NavigateToDetails);
            LoadData();
        }
        
        private async void LoadData()
        {
            var beds = await _gardenBedService.GetGardenBeds();
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
            _navigationService.NavigateAsync($"Detail?id={obj.Id}");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}