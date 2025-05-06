internal class RecursiveFunction
{
  public static void Fibonachi()
  {
    int numberFi = 1;
    int number = Readline.TryReadline<int>("Введите номер числа в последовательности Фибоначи: ");
    for (int i = 1; i < number; i++)
    {
      numberFi += numberFi;
    }
    Console.WriteLine($"{number}-ое число в последовательности:  {numberFi}");
    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
    Console.ReadKey();
  }

  public static void Degree()
  {
    int number = Readline.TryReadline<int>("Введите число возводимое в степень: ");
    int degree = Readline.TryReadline<int>("Введите степень: ");
    int raisedNumber = number;
    for (int i = 1; i < degree; i++)
    {
      raisedNumber *= number;
    }
    Console.WriteLine($"Число возведённое в степень:  {raisedNumber}");
    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
    Console.ReadKey();
  }
}