using Microsoft.Practices.Unity;
using Prism.Unity;

namespace GardenBeds.UWP
{
    public sealed partial class MainPage: IPlatformInitializer
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new GardenBeds.App(this));
        }

        public void RegisterTypes(IUnityContainer container)
        {
        }
    }
}
