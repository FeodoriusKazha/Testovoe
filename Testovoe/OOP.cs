interface IShape
{
  double GetArea();
  double GetPerimeter();
  bool IsValid();
}

abstract class Shape : IShape
{
  public abstract double GetArea();
  public abstract double GetPerimeter();
  public abstract bool IsValid();

  public void DisplayInfo()
  {
    if (IsValid())
    {
      Console.WriteLine($"Периметр: {GetPerimeter():F2}");
      Console.WriteLine($"Площадь: {GetArea():F2}");
    }
  }
}

class Square : Shape
{
  public double Side { get; }

  public Square(double side) => Side = side;

  public override double GetArea() => Side * Side;
  public override double GetPerimeter() => 4 * Side;
  public override bool IsValid() => Side > 0;
}

class Rectangle : Shape
{
  public double Width { get; }
  public double Height { get; }

  public Rectangle(double width, double height)
  {
    Width = width;
    Height = height;
  }

  public override double GetArea() => Width * Height;
  public override double GetPerimeter() => 2 * (Width + Height);
  public override bool IsValid() => Width > 0 && Height > 0;
}

class Circle : Shape
{
  public double Radius { get; }

  public Circle(double radius) => Radius = radius;

  public override double GetArea() => Math.PI * Radius * Radius;
  public override double GetPerimeter() => 2 * Math.PI * Radius;
  public override bool IsValid() => Radius > 0;
}

class Rhombus : Shape
{
  public double Side { get; }
  public double Angle { get; }

  public Rhombus(double side, double angle)
  {
    Side = side;
    Angle = angle;
  }

  public override double GetArea() => Side * Side * Math.Sin(Angle * Math.PI / 180);
  public override double GetPerimeter() => 4 * Side;
  public override bool IsValid() => Side > 0 && Angle > 0 && Angle < 180;
}

class OOP
{
  public static void FigureProgram()
  {
    bool running = true;

    while (running)
    {
      Console.Clear();
      Console.WriteLine("===================");
      Console.WriteLine(" Выберите фигуру:");
      Console.WriteLine("===================");
      Console.WriteLine("1. Квадрат");
      Console.WriteLine("2. Прямоугольник");
      Console.WriteLine("3. Круг");
      Console.WriteLine("4. Ромб");
      Console.WriteLine("5. Выход");
      string choice = Readline.TryReadline<string>("Выберите пункт меню: ");
      Console.Clear();

      IShape shape = choice switch
      {
        "1" => new Square(ReadDouble("Введите длину стороны квадрата: ")),
        "2" => new Rectangle(ReadDouble("Введите ширину прямоугольника: "), ReadDouble("Введите высоту прямоугольника: ")),
        "3" => new Circle(ReadDouble("Введите радиус круга: ")),
        "4" => new Rhombus(ReadDouble("Введите длину стороны ромба: "), ReadDouble("Введите угол ромба в градусах: ")),
        "5" => ExitProgram(ref running),
        _ => null
      };
      (shape as Shape)?.DisplayInfo();

      Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
      Console.ReadKey();
    }
  }
  static double ReadDouble(string message)
  {
    double value = 0;
    Console.Write(message);
    while (!double.TryParse(Console.ReadLine(), out value) || value <= 0)
    {
      Console.Write("Ошибка! Введите положительное число: ");
    }
    return value;
  }
  static IShape? ExitProgram(ref bool running)
  {
    running = false;
    Console.WriteLine("Выход из программы.");
    return null;
  }
}
