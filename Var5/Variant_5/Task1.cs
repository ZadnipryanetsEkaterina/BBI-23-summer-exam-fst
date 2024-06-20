using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

/*1.  В классе Task1 создайте структуру Rectangle,
представляющую собой прямоугольник с целочисленными полями
для длины и ширины прямоугольника и свойствами для чтения его сторон A, B.
В конструктор прямоугольника передавать 2 целых числа. 
Напишите методы Length() и Area() для расчета периметра и площади прямоугольника.
Напишите метод Compare для сравнения двух прямоугольников: какой из них больше по площади.
На вход передается второй прямоугольник для сравнения,
на выход: целое число (1 - больше текущий, -1 - переданный прямоугольник, 0 - прямоугольники равны).
Переопределите метод ToString() для вывода информации о прямоугольнике в формате: 
“a = 1, b = 2, p = 3, s = 4”, где a,b - длины сторон, p - периметр, s - площадь прямоугольника.
В классе Task1 создайте приватное поле для массива прямоугольников и свойство Rectangles для чтения этого массива.
Переопределите метод ToString() для вывода всех элементов массива Rectangles на консоль построчно.
Напишите метод Sorting() для сортировки массива Rectangles
по возрастанию периметра прямоугольников (чем выше скорость сортировки, тем больше баллов за выполнение).*/

namespace Variant_5
{
    public class Task1
    {
        public struct Rectangle
        {
            private int a;
            private int b;
            public int A => a;
            public int B => b;
            public Rectangle(int a, int b)
            {
                this.a = a >= 0 ? a : 0;
                this.b = b >= 0 ? b : 0;
            }
            public int Length()
            {
                return 2 * (a + b);
            }
            public int Area()
            {
                return a * b;
            }
            public int Compare(Rectangle other)
            {
                int thisArea = this.Area();
                int otherArea = other.Area();
                if (thisArea > otherArea)
                    return 1;
                else if (thisArea < otherArea)
                    return -1;
                else
                    return 0;
            }

            public override string ToString()
            {
                return $"a = {A}, b = {B}, p = {Length()}, s = {Area()}";
            }
        }
        private Rectangle[] rectangles;
        public Rectangle[] Rectangles
        {
            get { return rectangles; }
        }
        public Task1(Rectangle[] rectangles)
        {
            this.rectangles = rectangles;
        }
        public override string ToString()
        {
            string result = "";
            foreach (Rectangle rect in rectangles)
            {
                result += rect.ToString() + Environment.NewLine;
            }
            return result;
        }
        public void Sorting()
        {
            int n = rectangles.Length;
            int i = 1;
            while (i < n)
            {
                if (i == 0 || rectangles[i - 1].Length() <= rectangles[i].Length())
                {
                    i++;
                }
                else
                {
                    Rectangle temp = rectangles[i];
                    rectangles[i] = rectangles[i - 1];
                    rectangles[i - 1] = temp;
                    i--;
                }
            }
        }
    }
}
