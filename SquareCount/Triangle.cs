using System;

namespace SquareCount
{
    public class Triangle : IFigure
    {
        public double LengthA { get; }
        public double LengthB { get; }
        public double LengthC { get; }

        public double GetSquare()
        {
            double halfPerimeter = (LengthA + LengthB + LengthC) / 2;
            double square = Math.Sqrt(halfPerimeter
                * (halfPerimeter - LengthA)
                * (halfPerimeter - LengthB)
                * (halfPerimeter - LengthC)
                );
            if (double.IsInfinity(square))
                throw new OverflowException("Невозможно посчитать т.к. введено слишком большое значение сторон.");
            return square;
        }

        public Triangle(double lengthA, double lengthB, double lengthC)
        {
            if (lengthA < Constant.minLength
                || lengthB < Constant.minLength
                || lengthC < Constant.minLength) 
            throw new ArgumentException("Для длины стороны меньше 1e-10 обработка не предусмотрена."); 
            else if (lengthA + lengthB <= lengthC
                || lengthA + lengthC <= lengthB
                || lengthB + lengthC <= lengthA)
                throw new ArgumentException("Треугольник не существует т.к. одна из сторон больше или равна сумме двух других.");

            LengthA = lengthA;
            LengthB = lengthB;
            LengthC = lengthC;
        }

        public bool IsOrthogonal() 
        {
            double hypotenuse = Math.Max(LengthA, Math.Max(LengthB, LengthC));
            double minSide = Math.Min(LengthA, Math.Min(LengthB, LengthC));
            double middleSide = LengthA + LengthB + LengthC - hypotenuse - minSide;
            return Math.Pow(hypotenuse, 2) == Math.Pow(minSide, 2) + Math.Pow(middleSide, 2);
        }
    }
}
