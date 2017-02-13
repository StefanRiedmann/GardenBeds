using System.Collections.Generic;
using System.Threading.Tasks;
using GardenBeds.Models;
using GardenBeds.Services;
using GardenBeds.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Navigation;

namespace UnitTest.Portable.ViewModels
{
    /// <summary>
    /// Summary description for MainMenuViewModelTest
    /// </summary>
    [TestFixture]
    public class MainMenuViewModelTest
    {
        private MainMenuViewModel _viewModel;
        private Mock<INavigationService> _navMock;
        private Mock<IGardenBedService> _serviceMock;

        [SetUp]
        public void Init()
        {
            _navMock = new Mock<INavigationService>();
            _serviceMock = new Mock<IGardenBedService>();
        }

        [TearDown]
        public void VerifyAll()
        {
            //to make sure all the Setup's of the Mocks were really called like expected,
            //and that the test doesn't success by chance.
            _navMock.Verify();
            _serviceMock.Verify();
        }

        [Test]
        public void Constructor_LoadsData()
        {
            //Arrange
            var testData = new List<GardenBed>(new[]
            {
                new GardenBed {Id = 1, Name = "test"},
                new GardenBed {Id = 2, Name = "test2"}
            });
            _serviceMock
                .Setup(s => s.GetGardenBeds())
                .Returns(Task.Factory.StartNew(() => testData))
                .Verifiable();
            //Act
            _viewModel = new MainMenuViewModel(_navMock.Object, _serviceMock.Object);
            //Assert
            testData.ForEach(d => Assert.IsTrue(_viewModel.GardenBeds.Contains(d)));
        }

        [Test]
        public void NavigateToDetailsCommand_CallsNavigationService_WithExpectedArguments()
        {
            //Arrange
            var testData = new GardenBed {Id = 7, Name = "test"};
            _navMock
                .Setup(n => n.NavigateAsync(It.Is<string>(uri => uri.Equals("Details/7")), null, null, true))
                .Returns(Task.Factory.StartNew(() => { }))
                .Verifiable();
            //Act
            _viewModel = new MainMenuViewModel(_navMock.Object, _serviceMock.Object);
            _viewModel.NavigateToDetailsCommand.Execute(testData);
            //Assert
            _navMock.Verify(); //also happens in cleanup, but well... 
        }

        [Test]
        public void LoadData_SetsLoadingToFalse_WhenReady()
        {
            //Arrange
            _serviceMock
                .Setup(s => s.GetGardenBeds())
                .Returns(Task.Factory.StartNew(() => new List<GardenBed>()))
                .Verifiable();
            _viewModel.Loading = true;
            //Act
            _viewModel = new MainMenuViewModel(_navMock.Object, _serviceMock.Object);
            //Assert
            Assert.IsFalse(_viewModel.Loading);
        }
    }
}
