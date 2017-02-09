using System;
using NUnit.Framework;


namespace UnitTest.Android
{
    [TestFixture]
    public class TestsSample
    {

        [SetUp]
        public void Setup() { }


        [TearDown]
        public void Tear() { }

        [Test]
        [Ignore("not implemented yet")]
        public void MainActivity_RegisterTypes_RegistersLogger()
        {
            Assert.True(false);
        }
    }
}