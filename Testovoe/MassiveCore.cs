internal class MassiveCore
{
  static public int[,] CreateMassive()
  {
    int size = Readline.TryReadline<int>("Введите размер массива: ");
    int[,] array = new int[size, size];
    Random rand = new Random();

    for (int i = 0; i < size; i++)
    {
      for (int j = 0; j < size; j++)
      {
        array[i, j] = rand.Next(1, 10);
      }
    }

    Console.WriteLine("Сгенерированный массив:");

    for (int i = 0; i < size; i++)
    {
      for (int j = 0; j < size; j++)
      {
        Console.Write(array[i, j].ToString() + ", ");
      }
      Console.WriteLine();
    }

    return array;
  }
  public static void SumOfDiagonal(int[,] array)
  {
    int primarySum = 0;
    int secondarySum = 0;
    int size = array.GetLength(0);

    for (int i = 0; i < size; i++)
    {
      primarySum += array[i, i];
      secondarySum += array[i, size - i - 1];
    }

    Console.WriteLine($"Сумма главной диагонали: {primarySum}");
    Console.WriteLine($"Сумма побочной диагонали: {secondarySum}");
    Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
    Console.ReadKey();
  }

  public static void SumOfMultiple3(int[,] array)
  {
    int sum = 0;

    foreach (int num in array)
    {
      if (num % 3 == 0)
      {
        sum += num;
      }
    }

    Console.WriteLine($"Сумма чисел, кратных 3: {sum}");
  }
}





