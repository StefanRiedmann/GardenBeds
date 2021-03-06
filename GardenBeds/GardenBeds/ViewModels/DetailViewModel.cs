﻿using GardenBeds.Services;
using Prism.Mvvm;
using Prism.Navigation;
using GardenBeds.Models;
using Prism.Commands;

namespace GardenBeds.ViewModels
{
    public class DetailViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IGardenBedService _gardenBedService;
        private bool _loading = true;
        private GardenBed _gardenBed = new GardenBed();

        public DetailViewModel(INavigationService navigationService, IGardenBedService gardenBedService)
        {
            _navigationService = navigationService;
            _gardenBedService = gardenBedService;
        }
        
        public bool Loading
        {
            get { return _loading; }
            set { SetProperty(ref _loading, value); }
        }

        public GardenBed GardenBed
        {
            get { return _gardenBed; }
            set { SetProperty(ref _gardenBed, value); }
        }

        public DelegateCommand NavigateBackCommand => new DelegateCommand(GoBack);

        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            Loading = true;
            int id;
            if (parameters.ContainsKey("id") && int.TryParse(parameters["id"] as string, out id))
            {
                GardenBed = await _gardenBedService.GetGardenBed(id);
            }
            else
            {
                GardenBed = null;
            }
            Loading = false;
        }
    }
}
