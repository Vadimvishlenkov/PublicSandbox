using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry
{
    [TestClass]
    public class TestCircle
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(double.MaxValue)]
        [DataRow(double.PositiveInfinity)]
        public void CreateWithValidSides(double radius)
        {
            var circle = new Circle(radius);
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(double.NegativeInfinity)]
        public void CreateWithInvalidSides(double radius)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var circle = new Circle(radius);
            });
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(1, Math.PI)]
        [DataRow(5, 78.539816339744830961566084581988)]
        [DataRow(double.MaxValue, double.PositiveInfinity)]
        [DataRow(double.PositiveInfinity, double.PositiveInfinity)]
        public void GetArea(double radius, double expectedArea)
        {
            var circle = new Circle(radius);
            Assert.AreEqual(expectedArea, circle.Area);
        }
    }
}
