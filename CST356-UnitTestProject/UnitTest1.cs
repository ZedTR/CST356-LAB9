using System;
using NUnit.Framework;
using FakeItEasy;
using CST356_lab3.repository;
using CST356_lab3.Services;
using CST356_lab3.Data.Entities;

namespace CST356_UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        private IClasses _Iclasses;
        [SetUp]
        public void SetUp()
        {
            _Iclasses = A.Fake<IClasses>();
        }
        //Test that the class start date always less than the end date
        [Test]
        public void ShouldHaveLogicalTime()
        {
            //Arrange
            A.CallTo(() => _Iclasses.GetClass(A<int>.Ignored)).Returns(new Classes {
                EndDate = DateTime.Now
            });

            //ACT
            var service = new Service(_Iclasses);
            var clsvm = service.GetClass(1);

            //Assert
            Assert.IsTrue(clsvm.EndDate > clsvm.StartDate);
        }
        //Test the class period is not more than 65 days
        [Test]
        public void ShouldBeNoMoreThan()
        {
            //Arrange
            A.CallTo(() => _Iclasses.GetClass(A<int>.Ignored)).Returns(new Classes
            {
                Delta = 65
            });

            //ACT
            var service = new Service(_Iclasses);
            var clsvm = service.GetClass(1);
            var delta = service.CheckClassDelta(clsvm);

            //Assert
            Assert.IsTrue(clsvm.Delta >= delta);
        }

    }
}
