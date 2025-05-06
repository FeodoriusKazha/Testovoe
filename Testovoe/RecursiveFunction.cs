internal class RecursiveFunction
{
  public static void Fibonachi()
  {
    int numberFi = 1;
    int number = Readline.TryReadline<int>("Введите номер числа в последовательности Фибоначчи: ");

    try
    {
      checked
      {
        for (int i = 1; i < number; i++)
        {
          if (numberFi > int.MaxValue / 2)
          {
            Console.WriteLine("Ошибка: Число превышает допустимый диапазон int.");
            Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
            return;
          }
          numberFi += numberFi;
        }
      }
    }
    catch (OverflowException)
    {
      Console.WriteLine("Ошибка: Число вышло за пределы int.");
      Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
      Console.ReadKey();
      return;
    }

    Console.WriteLine($"{number}-ое число в последовательности: {numberFi}");
    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
    Console.ReadKey();
  }

  public static void Degree()
  {
    int number = Readline.TryReadline<int>("Введите число возводимое в степень: ");
    int degree = Readline.TryReadline<int>("Введите степень: ");
    int raisedNumber = number;

    try
    {
      checked
      {
        for (int i = 1; i < degree; i++)
        {
          if (raisedNumber > int.MaxValue / number)
          {
            Console.WriteLine("Ошибка: Результат вышел за пределы int.");
            Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
            return;
          }
          raisedNumber *= number;
        }
      }
    }
    catch (OverflowException)
    {
      Console.WriteLine("Ошибка: Число вышло за пределы int.");
      Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
      Console.ReadKey();
      return;
    }

    Console.WriteLine($"Число возведённое в степень: {raisedNumber}");
    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
    Console.ReadKey();
  }
}