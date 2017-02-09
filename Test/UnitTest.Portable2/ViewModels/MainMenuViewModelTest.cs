using System.Threading.Tasks;
using GardenBeds.Models;
using GardenBeds.Services;
using GardenBeds.ViewModels;
using NUnit.Framework;
using UnitTest.Portable2.Mocks;

namespace UnitTest.Portable2.ViewModels
{
    /// <summary>
    /// Summary description for MainMenuViewModelTest
    /// </summary>
    [TestFixture]
    public class MainMenuViewModelTest
    {
        private MainMenuViewModel _viewModel;
        private MockedNavigationService _navigationService;
        private IGardenBedService _service;

        [SetUp]
        public void Init()
        {
            _navigationService = new MockedNavigationService();
            _service = new GardenBedService();
        }

        [Test]
        public void Constructor_LoadsData_And_SetLoadingToFalse()
        {
            //Arrange
            var dataFromService = _service.GetGardenBeds().Result;
            //Act
            _viewModel = new MainMenuViewModel(_navigationService, _service);
            //Assert
            foreach (var gardenBed in dataFromService)
            {
                Assert.IsTrue(_viewModel.GardenBeds.Contains(gardenBed));
            }
        }

        [Test]
        public void NavigateToDetailsCommand_CallsNavigationService_WithExpectedArguments()
        {
            //Arrange
            var dataFromService = _service.GetGardenBeds().Result;
            _viewModel = new MainMenuViewModel(_navigationService, _service);
            //Act
            _viewModel.NavigateToDetailsCommand.Execute(dataFromService[0]);
            //Assert
            Assert.AreEqual($"Details/{dataFromService[0].Id}", _navigationService.LastName);
        }
    }
}
