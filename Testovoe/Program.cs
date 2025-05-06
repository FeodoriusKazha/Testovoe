using System;
using System.Text;

namespace Testovoe
{
  class Program
  {
    static void Main()
    {
      Console.OutputEncoding = Encoding.UTF8;
      while (true)
      {
        Console.Clear();
        Console.WriteLine("========================");
        Console.WriteLine(" Консольное приложение");
        Console.WriteLine("========================");
        Console.WriteLine("1. Массивы. Получение суммы чисел главной диагонали.");
        Console.WriteLine("2. Массивы. Нахождение суммы чисел кратных 3.");
        Console.WriteLine("3. Рекурсивные алгоритмы. Нахождения числа из последовательности Фибоначчи.");
        Console.WriteLine("4. Рекурсивные алгоритмы. Возведения числа в целую степень.");
        Console.WriteLine("5. Хеширование данных. Справочник контактов.");
        Console.WriteLine("6. ООП. Квадрат, прямоугольник, круг и ромб.");
        Console.WriteLine("7. Выход");
        string input = Readline.TryReadline<string>("Выберите пункт меню: ");
        Console.Clear();

        switch (input)
        {
          case "1":
            MassiveCore.SumOfDiagonal(MassiveCore.CreateMassive());
            break;
          case "2":
            MassiveCore.SumOfMultiple3(MassiveCore.CreateMassive());
            break;
          case "3":
            RecursiveFunction.Fibonachi();
            break;
          case "4":
            RecursiveFunction.Degree();
            break;
          case "5":
            HeshProgram.HeshMenu();
            break;
          case "6":
            OOP.FigureProgram();
            break;
          case "7":
            Console.WriteLine("Выход...");
            return;
          default:
            Console.WriteLine("Неверный выбор, попробуйте снова.");
            Console.ReadKey();
            break;
        }
      }
    }
  }
}