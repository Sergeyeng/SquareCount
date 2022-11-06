using NUnit.Framework;
using SquareCount;
using System;

namespace Tests
{
    public class CircleTest
    {

        [Test]
        public void Circle_1eminus11_ArgumentExceptionExpected()
        {
            double rad = 1e-11;
            Assert.That(() => new Circle(rad),
                Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Для радиуса круга меньше 1e-10 обработка не предусмотрена."));
        }

        [Test]
        public void GetSquare_5_25PiExpected()
        {
            double rad = 5;
            double expected = 25 * Math.PI;
            var circle = new Circle(rad);

            var actual = circle.GetSquare();    

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSquare_1e200_OverflowExceptionExpected()
        {
            double rad = 1e+200;
            var circle = new Circle(rad);

            Assert.That(() => circle.GetSquare(),
                Throws.TypeOf<OverflowException>()
                .With.Message.EqualTo("Невозможно посчитать т.к. введено слишком большое значение радиуса."));
        }
    }
}