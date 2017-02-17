using GardenBeds.Services;
using NUnit.Framework;

namespace UnitTest.Portable.Services
{
    [TestFixture]
    public class GardenBedServiceTest
    {
        private GardenBedService _service;

        [SetUp]
        public void Init()
        {
            //usually this service test would use a mocked backend (e.g. an httpclient)
            //in this case, the fixture comes with embedded test data, so we can just run it
            _service = new GardenBedService();
        }

        [Test]
        public void Constructor_LoadsDemoData()
        {
            var items = _service.GetGardenBeds().Result;
            Assert.IsNotNull(items);
            Assert.AreEqual(4, items.Count);
        }

        [Test]
        public void GetGardenBed_ReturnsExpectedItem()
        {
            var item = _service.GetGardenBed(1).Result;
            Assert.IsNotNull(item);
            Assert.AreEqual(1, item.Id);
        }

        [Test]
        public void GetGardenBed_ReturnsNull_WhenIdDoesntExist()
        {
            var item = _service.GetGardenBed(11).Result;
            Assert.IsNull(item);
        }
    }
}
