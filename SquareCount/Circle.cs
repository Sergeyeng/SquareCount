using System;

namespace SquareCount
{
    public class Circle : IFigure
    {

        public double Radius { get; }

        public double GetSquare()
        {
            double square = Math.PI * Math.Pow(Radius, 2);
            if (double.IsInfinity(square))
                throw new OverflowException("Невозможно посчитать т.к. введено слишком большое значение радиуса.");
            return square;
        }

        public Circle(double radius)
        {
            if (radius < Constant.minLength)
                throw new ArgumentException("Для радиуса круга меньше 1e-10 обработка не предусмотрена.");
            Radius = radius;
        }
    }
}