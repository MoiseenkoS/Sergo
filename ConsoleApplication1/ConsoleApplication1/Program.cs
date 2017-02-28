using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace treangle
{
    class Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

    }
    class Edge
    {
        Point First;
        Point Second;

        public Edge(Point pointfirst, Point pointsecond)
        {
            First = pointfirst;
            Second = pointsecond;

        }
        public double length()
        {
            double length = Math.Sqrt(Math.Pow((Second.X - First.X), 2) + Math.Pow((Second.Y - First.Y), 2));
            return length;
        }
    }

    class Triangle
    {
        Point first;
        Point second;
        Point third;
        Edge side1;
        Edge side2;
        Edge side3;
        double perimeter;
        double area;


        public Triangle(Point pointfirst, Point pointsecond, Point pointthird)
        {
            side1 = new Edge(pointfirst, pointsecond);
            side2 = new Edge(pointfirst, pointthird);
            side3 = new Edge(pointsecond, pointthird);
        }



        public bool Check()
        {


            if ((side1.length() + side2.length() > side3.length()) || (side2.length() + side3.length() > side1.length()) || (side1.length() + side3.length() > side2.length()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public double Perimeter()
        {
            perimeter = side1.length() + side2.length() + side3.length();
            return perimeter;
        }


        public double Area()
        {

            double halfofperimeter = perimeter / 2;
            area = Math.Sqrt(halfofperimeter * (halfofperimeter - side1.length()) * (halfofperimeter - side2.length()) * (halfofperimeter * side3.length()));
            return area;

        }

        public bool CheckIsosceles()
        {
            if ((side1.length() == side2.length()) || (side1.length() == side3.length()) || (side2.length() == side3.length())) return true;
            else return false;
        }


        public bool CheckRight()
        {

            if ((side1.length() * side1.length() == side2.length() * side2.length() + side3.length() * side3.length())
                 || (side2.length() * side2.length() == side1.length() * side1.length() + side2.length() * side2.length())
                 || (side3.length() * side3.length() == side2.length() * side2.length() + side1.length() * side1.length())) return true;
            else return false;

        }

        public void dataTriangle(Triangle triangle)
        {
            Console.WriteLine("Сторона 1:{0}", triangle.side1.length());
            Console.WriteLine("Сторона 2:{0}", triangle.side2.length());
            Console.WriteLine("Сторона 3:{0}", triangle.side3.length());
            Console.WriteLine("Периметр :{0}", triangle.Perimeter());
            Console.WriteLine("Площадь :{0}", triangle.Area());
            Console.WriteLine("Прямоугольныq:{0}", triangle.CheckRight());
            Console.WriteLine("Равнобедренный:{0}", triangle.CheckIsosceles());


        }




    }

    class Program
    {
        static void Main(string[] args)
        {
            Point first = new Point(0, 0);
            Point second = new Point(2, 2);
            Point third = new Point(5, 4);
            Triangle triangle = new Triangle(first, second, third);

            if (triangle.Check())
            {
                Console.WriteLine("Треугольник сущствует");
                triangle.dataTriangle(triangle);
            }
            else Console.WriteLine("Треугольник несуществует!!!");
            Console.WriteLine();

            double totalarea = 0, totalperimeter = 0, averagearea = 0, averageperimeter = 0;
            int areacount = 0;
            int perimetercount = 0;


            Triangle[] triangles = new Triangle[20];
            for (int i = 0; i < triangles.Length; i++)
            {
                Random gen = new Random();
                double x1 = gen.Next(0, 20);
                double x2 = gen.Next(0, 20);
                double x3 = gen.Next(0, 20);
                double y1 = gen.Next(0, 20);
                double y2 = gen.Next(0, 20);
                double y3 = gen.Next(0, 20);
                Point mas1 = new Point(x1, y1);
                Point mas2 = new Point(x2, y2);
                Point mas3 = new Point(x3, y3);
                triangles[i] = new Triangle(mas1, mas2, mas3);
                if (triangles[i].Check())
                {
                    Console.WriteLine("Треугольник сущствует");

                }
                else Console.WriteLine("Треугольник не существует!!!");
                triangle.dataTriangle(triangles[i]);
                Console.WriteLine();
            }

            for (int i = 0; i < triangles.Length; i++)
            {
                if (triangles[i].CheckIsosceles())
                {
                    totalarea = totalarea + triangles[i].Area();
                    areacount++;
                }

                if (triangles[i].CheckRight())
                {
                    totalperimeter = totalperimeter + triangles[i].Perimeter();
                    perimetercount++;
                }

            }

            averagearea = totalarea / areacount;
            Console.WriteLine("Средняя площадь равнобедренных треугольников: " + averagearea);

            averageperimeter = totalperimeter / perimetercount;
            Console.WriteLine("Средний периметр прямоугольных треугольников: " + averageperimeter);
            Console.ReadKey();
        }


    }


}