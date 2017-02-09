using System;
using System.Threading.Tasks;
using Prism.Navigation;

namespace UnitTest.Portable2.Mocks
{
    /// <summary>
    /// Until we find a real good PCL Mocking Library... 
    /// </summary>
    public class MockedNavigationService : INavigationService
    {
        public Uri LastUri;
        public string LastName;

        public Task<bool> GoBackAsync(NavigationParameters parameters = null, bool? useModalNavigation = null, bool animated = true)
        {
            return Task.Factory.StartNew(() => true);
        }

        public Task NavigateAsync(Uri uri, NavigationParameters parameters = null, bool? useModalNavigation = null,
            bool animated = true)
        {
            LastUri = uri;
            return Task.Factory.StartNew(() => { });
        }

        public Task NavigateAsync(string name, NavigationParameters parameters = null, bool? useModalNavigation = null,
            bool animated = true)
        {
            LastName = name;
            return Task.Factory.StartNew(() => { });
        }
    }
}