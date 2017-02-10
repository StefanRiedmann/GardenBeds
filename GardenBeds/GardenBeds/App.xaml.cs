using GardenBeds.Logger;
using GardenBeds.Services;
using GardenBeds.ViewModels;
using GardenBeds.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace GardenBeds
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainMenu");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType(typeof (IGardenBedService), typeof (GardenBedService), null,
                new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainMenu, MainMenuViewModel>();
            Container.RegisterTypeForNavigation<Detail, DetailViewModel>();
        }

        protected override void OnStart()
        {
            Logger = new PrismLogger();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
