using System;
using System.Linq;
using GardenBeds.Models;
using GardenBeds.Views;
using NUnit.Framework;
using Xamarin.Forms;

namespace UnitTest.Portable.Views
{
    [TestFixture]
    public class ConvertersTest
    {
        [Test]
        public void NegateBooleanConverter_ReturnsInvertedBool()
        {
            var converter = new NegateBooleanConverter();
            Assert.AreEqual(true, converter.Convert(false, null, null, null));
        }

        [Test]
        public void SizeToTextConverter_ReturnsExpectedString_IfPassingInt()
        {
            var converter = new SizeToTextConverter();
            Assert.AreEqual("5 square metres", converter.Convert(5, null, null, null));
            Assert.AreEqual("unknown size", converter.Convert("dd", null, null, null));
        }

        [Test]
        public void PlantToStringConverter_ReturnsExptectedName()
        {
            var converter = new PlantToStringConverter();
            var values = Enum.GetValues(typeof(Plants)).Cast<Plants>();
            foreach (var plant in values)
            {
                Assert.AreEqual(plant.ToString(), converter.Convert(plant, null, null, null));
            }
            Assert.AreEqual("unknown plant", converter.Convert("dd", null, null, null));
        }

        [Test]
        public void PlantToImageConverter_ReturnsImageSource_ForEveryPlant()
        {
            var converter = new PlantToImageConverter();
            var values = Enum.GetValues(typeof(Plants)).Cast<Plants>();
            foreach (var plant in values)
            {
                var imgSource = converter.Convert(plant, null, null, null) as ImageSource;
                Assert.NotNull(imgSource);
                Assert.AreNotSame(PlantToImageConverter.DefaultImageSource, imgSource);
            }
            Assert.AreSame(PlantToImageConverter.DefaultImageSource, converter.Convert("dd", null, null, null));
        }

    }
}