using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Geometry
{
    [TestClass]
    public class TestTriangle
    {
        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(0, 1, 1)]
        [DataRow(1, 2, 3)]
        [DataRow(double.MaxValue, double.MaxValue, double.MaxValue)]
        [DataRow(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
        public void CreateWithValidSides(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
        }

        [DataTestMethod]
        [DataRow(-1, 0, 0)]
        [DataRow(0, -1, 0)]
        [DataRow(0, 0, -1)]
        [DataRow(double.NegativeInfinity, 0, 0)]
        [DataRow(0, double.NegativeInfinity, 0)]
        [DataRow(0, 0, double.NegativeInfinity)]
        public void CreateWithInvalidSides(double sideA, double sideB, double sideC)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                var triangle = new Triangle(sideA, sideB, sideC);
            });
        }

        [DataTestMethod]
        [DataRow(1, 2, 4)]
        [DataRow(4, 1, 2)]
        [DataRow(2, 4, 1)]
        [DataRow(2, double.PositiveInfinity, 1)]
        public void SumOfTwoSidesMustBeGreaterThanThirdSide(double sideA, double sideB, double sideC)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                var triangle = new Triangle(sideA, sideB, sideC);
            });
        }

        [DataTestMethod]
        [DataRow(0, 0, 0, 0)]
        [DataRow(3, 4, 5, 6)]
        [DataRow(double.MaxValue, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [DataRow(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity)]
        public void GetArea(double sideA, double sideB, double sideC, double expectedArea)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            Assert.AreEqual(expectedArea, triangle.Area);
        }

        [DataTestMethod]
        [DataRow(1, 1, 1, false)]
        [DataRow(3, 4, 5, true)]
        public void IsRight(double sideA, double sideB, double sideC, bool expectedIsRight)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            Assert.AreEqual(expectedIsRight, triangle.IsRight);
        }

        [TestMethod]
        public void IsRightDoesntLosePrecision()
        {
            double sideA = 11;
            double sideB = 17;
            double sideC = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            var triangle = new Triangle(sideA, sideB, sideC);

            Assert.AreEqual(true, triangle.IsRight);
        }
    }
}
