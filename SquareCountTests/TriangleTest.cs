using NUnit.Framework;
using SquareCount;
using System;

namespace SquareCountTest
{
    public class TriangleTest
    {

        [TestCase(1e-11,1,1)]
        [TestCase(1, 1e-11, 1)]
        [TestCase(1, 1, 1e-11)]
        [TestCase(1e-11, 1e-11, 1e-11)]
        public void Triangle_1eminus11_ArgumentExceptionExpected(double a, double b, double c)
        {
            Assert.That(() => new Triangle(a, b, c),
                Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Для длины стороны меньше 1e-10 обработка не предусмотрена."));
        }

        [TestCase(20, 4, 3)]
        [TestCase(6, 20, 5)]
        [TestCase(7, 8, 20)]
        public void Triangle_oneSideMoreThenOthersSum_ArgumentExceptionExpected(double a, double b, double c)
        {
            Assert.That(() => new Triangle(a, b, c),
                Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Треугольник не существует т.к. одна из сторон больше или равна сумме двух других."));
        }

        [Test]
        public void GetSquare_345_6Expected()
        {
            double expected = 6;
            var triangle = new Triangle(3, 4, 5);

            var actual = triangle.GetSquare();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1.78e+307, 1.78e+307, 1.78e+307)]
        public void GetSquare_OverflowExceptionExpected(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);

            Assert.That(() => triangle.GetSquare(),
                Throws.TypeOf<OverflowException>()
                .With.Message.EqualTo("Невозможно посчитать т.к. введено слишком большое значение сторон."));
        }

        [TestCase(5, 4, 3, ExpectedResult = true)]
        [TestCase(3, 3, 3, ExpectedResult = false)]
        [TestCase(3, 4, 5.000000001, ExpectedResult = false)]
        public bool IsOrthogonalTest(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);

            return triangle.IsOrthogonal();
        }
    }
}
