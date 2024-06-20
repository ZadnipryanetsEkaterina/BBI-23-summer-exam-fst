using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

/*2. В класс Task2 скопируйте код из класса Task1.
Создайте в нём абстрактный класс Embrasure, наследующийся от Rectangle (тоже сделать абстрактным),
который представляет собой проем с названием, длиной, шириной, толщиной,
свойством для чтения толщины Thick и методом для расчета стоимости установки Cost(),
как произведение сторон * 10, который возвращает вещественное число.
Переопределите метод ToString() для вывода проемов на консоль  в формате: 
“Type = 1, p = 2, s = 3, price = 4”, где 1 - тип класса, 2 - периметр, 3 - площадь, 4 - цена.
От Embrasure сделайте наследников: Window и Door.
В классе окна добавьте поле количество слоев и свойство для их чтения Layers.
В классе двери добавьте поле материал и для его чтения (пластик/дерево/стекло) Material.
Переопределите метод Cost() с учетом дополнительных полей классов-наследников:
+ количество слоев / 0.3 и для материалов множители 1.25, 1.33, 1.5.
Толщину передавать в конструктор класса Embrasure, в конструктор класса Window
передавать дополнительно количество слоев, в конструктор класса Door - список названий материалов.
В классе Task2 создайте массив проемов и свойство Embrasures для его чтения.
Напишите метод Sorting() для сортировки проемов по увеличению стоимости.
Переопределите метод ToString() для вывода проемов на консоль. */

namespace Variant_5
{
    public class Task2
    {
        public abstract class Rectangle
        {
            protected int a;
            protected int b;

            public int A
            {
                get { return a; }
            }

            public int B
            {
                get { return b; }
            }

            public Rectangle(int a, int b)
            {
                this.a = a;
                this.b = b;
            }

            public int Length()
            {
                return 2 * (a + b);
            }

            public int Area()
            {
                return a * b;
            }

            public abstract override string ToString();
        }

        public abstract class Embrasure : Rectangle
        {
            protected double c;
            public string Name { get; protected set; }
            public double C => c;
            public Embrasure(int a, int b, double thickness) : base(a, b)
            {
                this.c = thickness;
                this.Name = this.GetType().Name;
            }

            public virtual double Cost()
            {
                return Area() * 10;
            }

            public override string ToString()
            {
                return $"Type = {Name}, p = {Length()}, s = {Area()}, price = {Cost():F2}";
            }
        }

        public class Window : Embrasure
        {
            public int Layers { get; private set; }

            public Window(int a, int b, double thickness, int layers) : base( a, b, thickness)
            {
                this.Layers = layers;
            }

            public override double Cost()
            {
                return base.Cost() + Layers / 0.3;
            }

            public override string ToString()
            {
                return base.ToString() + $", layers = {Layers}";
            }
        }

        public class Door : Embrasure
        {
            public string Material { get; private set; }

            public Door(int a, int b, double thickness, string material) : base( a, b, thickness)
            {
                this.Material = material;
            }

            public override double Cost()
            {
                double materialMultiplier = Material.ToLower() switch
                {
                    "plastic" => 1.25,
                    "wood" => 1.33,
                    "glass" => 1.5,
                    _ => 1.0
                };
                return base.Cost() * materialMultiplier;
            }

            public override string ToString()
            {
                return base.ToString() + $", material = {Material}";
            }
        }

        private Embrasure[] embrasures;

        public Embrasure[] Embrasures
        {
            get { return embrasures; }
        }

        public Task2(Embrasure[] embrasures)
        {
            this.embrasures = embrasures;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Embrasure embrasure in embrasures)
            {
                result += embrasure.ToString() + Environment.NewLine;
            }
            return result;
        }

        public void Sorting()
        {
            int i = 0;
            while (i < embrasures.Length)
            {
                if (i == 0 || embrasures[i - 1].Cost() <= embrasures[i].Cost())
                {
                    i++;
                }
                else
                {
                    var temp = embrasures[i];
                    embrasures[i] = embrasures[i - 1];
                    embrasures[i - 1] = temp;
                    i--;
                }
            }
        }
        //static void Main(string[] args)
        //{
        //    Embrasure[] embrasures = new Embrasure[]
        //    {
        //        new Window(6, 3, 5.6, 4 ),
        //        new Door(2, 2, 6, "plastic"),
        //        new Window( 5, 2, 0.3, 3),
        //        new Door(5, 4, 5, "plastic")
        //    };

        //    Task2 task = new Task2(embrasures);
        //    Console.WriteLine("До сортировки:");
        //    Console.WriteLine(task.ToString());

        //    task.Sorting();

        //    Console.WriteLine("После сортировки:");
        //    Console.WriteLine(task.ToString());
        //}
    }
}
