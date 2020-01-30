using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometry
{
    /// <summary>Represents a Triangle.</summary>
    public sealed class Triangle : Shape
    {
        /// <summary>
        /// Side A of the Triangle.
        /// </summary>
        public readonly double SideA;
        /// <summary>
        /// Side B of the Triangle.
        /// </summary>
        public readonly double SideB;
        /// <summary>
        /// Side C of the Triangle.
        /// </summary>
        public readonly double SideC;

        private readonly SortedSet<double> orderedSides;

        private bool? isRight;
        /// <summary>
        /// Returns a value indicating whether the Triangle is right.
        /// </summary>
        public bool IsRight
        {
            get
            {
                if (!isRight.HasValue)
                    isRight = Math.Pow(orderedSides.ElementAt(0), 2) + Math.Pow(orderedSides.ElementAt(1), 2) ==
                              Math.Pow(orderedSides.ElementAt(2), 2);
                return isRight.Value;
            }
        }

        private double? area;
        public override double Area
        {
            get
            {
                if (area == null)
                {
                    if (double.IsPositiveInfinity(orderedSides.ElementAt(2)))
                    {
                        area = double.PositiveInfinity;
                    }
                    else
                    {
                        double s = (SideA + SideB + SideC) / 2;
                        area = Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
                    }
                }
                return area.Value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Geometry.Triangle" /> class.
        /// </summary>
        /// <param name=""></param>
        /// <param name="sideA">Side A of the Triangle.</param>
        /// <param name="sideB">Side B of the Triangle.</param>
        /// <param name="sideC">Side C of the Triangle.</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            ParamGuard.CheckNotNegative(sideA, nameof(sideA));
            ParamGuard.CheckNotNegative(sideB, nameof(sideB));
            ParamGuard.CheckNotNegative(sideC, nameof(sideC));

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            orderedSides = new SortedSet<double>(new DuplicateKeyComparer<double>()) { SideA, SideB, SideC };

            CheckInequality(sideA, sideB, sideC);
        }

        private void CheckInequality(double sideA, double sideB, double sideC)
        {
            if (orderedSides.ElementAt(0) + orderedSides.ElementAt(1) < orderedSides.ElementAt(2))
                throw new ArgumentException("The sum of any two sides must be greater than or equal to the third side");
        }
    }
}
