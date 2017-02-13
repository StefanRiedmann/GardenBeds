using System.Threading.Tasks;
using GardenBeds.Models;
using GardenBeds.Services;
using GardenBeds.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Navigation;

namespace UnitTest.Portable.ViewModels
{
    [TestFixture]
    public class DetailViewModelTest
    {
        private DetailViewModel _viewModel;
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
        public void OnNavigatedTo_SetsGardenBedToNull_WhenIdMissing()
        {
            //Arrange
            _viewModel = new DetailViewModel(_navMock.Object, _serviceMock.Object);
            _viewModel.GardenBed = new GardenBed();
            //Act
            _viewModel.OnNavigatedTo(new NavigationParameters());
            //Verify
            Assert.IsNull(_viewModel.GardenBed);
        }

        [Test]
        public void OnNavigatedTo_SetsGardenBedToNull_WhenIdWrongFormat()
        {
            //Arrange
            _viewModel = new DetailViewModel(_navMock.Object, _serviceMock.Object);
            _viewModel.GardenBed = new GardenBed();
            //Act
            _viewModel.OnNavigatedTo(new NavigationParameters {["id"] = new object()});
            //Verify
            Assert.IsNull(_viewModel.GardenBed);
        }

        [Test]
        public void OnNavigatedTo_LoadsGardenBed_WithGivenId()
        {
            //Arrange
            var testData = new GardenBed {Id = 5};
            _serviceMock
                .Setup(s => s.GetGardenBed(It.Is<int>(x => x == 5)))
                .Returns(Task.Factory.StartNew(() => testData))
                .Verifiable();
            _viewModel = new DetailViewModel(_navMock.Object, _serviceMock.Object);
            //Act
            _viewModel.OnNavigatedTo(new NavigationParameters { ["id"] = "5" });
            //Verify
            Assert.AreSame(testData, _viewModel.GardenBed);
        }

        [Test]
        public void OnNavigatedTo_SetsLoadingToFalse_WhenReady()
        {
            //Arrange
            _viewModel = new DetailViewModel(_navMock.Object, _serviceMock.Object) {Loading = true};
            //Act
            _viewModel.OnNavigatedTo(new NavigationParameters { ["id"] = new object() });
            //Verify
            Assert.IsFalse(_viewModel.Loading);
        }

        [Test]
        public void NavigateBackCommand_CallsNavigationService()
        {
            //Arrange
            _navMock
                .Setup(n => n.GoBackAsync(null, null, true))
                .Returns(Task.Factory.StartNew(() => true))
                .Verifiable();
            _viewModel = new DetailViewModel(_navMock.Object, _serviceMock.Object) { Loading = true };
            //Act
            _viewModel.NavigateBackCommand.Execute();
            //Verify
            _navMock.Verify();
        }

    }
}