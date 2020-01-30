using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry
{
    /// <remarks>
    /// These tests do not actually test anything, but rather show that the area can be calculated without knowing actual type of the shape
    /// </remarks>
    [TestClass]
    public class TestGenericShape
    {
        [TestMethod]
        public void TriangleArea()
        {
            var shape = new Triangle(3,4,5);
            double area = GetShapeArea(shape);
            Assert.AreEqual(6, area);
        }

        [TestMethod]
        public void CircleArea()
        {
            var shape = new Circle(1);
            double area = GetShapeArea(shape);
            Assert.AreEqual(Math.PI, area);
        }

        private static double GetShapeArea(Shape shape)
        {
            return shape.Area;
        }
    }
}
