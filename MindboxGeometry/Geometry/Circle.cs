using System;

namespace Geometry
{
    /// <summary>Represents a Circle.</summary>
    public sealed class Circle : Shape
    {
        /// <summary>
        /// Radius of the Circle.
        /// </summary>
        public readonly double Radius;

        private double? area;
        public override double Area
        {
            get
            {
                if (area == null)
                {
                    area = Math.PI * Math.Pow(Radius, 2);
                }
                return area.Value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Geometry.Circle" /> class.
        /// </summary>
        /// <param name="radius">Radius of the Circle.</param>
        public Circle(double radius)
        {
            ParamGuard.CheckNotNegative(radius, nameof(radius));

            Radius = radius;
        }
    }
}
