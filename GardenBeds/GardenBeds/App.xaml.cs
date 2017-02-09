using GardenBeds.Services;
using GardenBeds.ViewModels;
using GardenBeds.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;

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
            Container.RegisterTypeForNavigation<MainMenu, MainMenuViewModel>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
