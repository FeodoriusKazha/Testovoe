using System.Text.RegularExpressions;
internal class Readline
{
  public static T TryReadline<T>(string message)
  {
    Console.WriteLine(message);
    while (true)
    {
      string input = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine($"Ошибка! Введите корректное значение типа {typeof(T).Name}.");
        continue;
      }
      try
      {
        T value = (T)Convert.ChangeType(input, typeof(T));
        if (typeof(T) == typeof(char) && input.Length != 1)
          throw new FormatException();
        return value;
      }
      catch
      {
        Console.WriteLine($"Ошибка! Введите корректное значение типа {typeof(T).Name}.");
      }
    }
  }
  public static string TryReadPhoneNumber(string message)
  {
    Console.WriteLine(message);
    while (true)
    {
      string input = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Ошибка! Введите номер телефона.");
        continue;
      }

      if (!Regex.IsMatch(input, @"^[\d\+\-]+$"))
      {
        Console.WriteLine("Ошибка! Номер должен содержать только цифры, '+' и '-'.");
        continue;
      }

      return input;
    }
  }
}


