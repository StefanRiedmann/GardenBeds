using System.Reflection;
using Android.App;
using Android.OS;
using UnitTest.Portable2.Services;
using Xamarin.Android.NUnitLite;

namespace UnitTest.Android
{
    [Activity(Label = "UnitTest.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : TestSuiteActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            AddTest(Assembly.GetExecutingAssembly());
            //not recognised. probably nunitlite is needed in that assembly. 
            //that needs nunit.3.6.0, but that's incompatible with running in VisualStudio
            AddTest(typeof(GardenBedServiceTest).Assembly);
            base.OnCreate(bundle);
        }
    }
}

