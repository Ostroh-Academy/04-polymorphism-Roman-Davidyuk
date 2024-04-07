


# Порівняння роботи програми з оверайдом і без нього при виклику методів з батьківського класу:

| Функціонал            | Без оверайду                                 | З оверайдом                                  |
|-----------------------|----------------------------------------------|---------------------------------------------|
| Встановлення коефіцієнтів | Викликається метод `SetCoefficients` батьківського класу | Викликається метод `SetCoefficients` батьківського класу |
| Виведення коефіцієнтів  | Викликається метод `PrintCoefficients` батьківського класу | Викликається метод `PrintCoefficients` який був переписаний |
| Оцінка функції         | Викликається метод `Evaluate` батьківського класу | Викликається метод `Evaluate` який був переписаний |

### У випадку використання методів з батьківського класу без оверайду, вони виконуються без змін, оскільки клас-спадкоємець не перевизначає їх функціональність. У випадку оверайду, методи виконуються зі змінами, відповідно до перевизначеної функціональності у класі-спадкоємці.

---

## Пририклад роботи з оверайдом:
![image](https://github.com/Roman-Davidyuk/04-polymorphism-Roman-Davidyuk/assets/145706234/8d80e429-f706-4e22-a878-254d8316bc25)

## Приклад без оверайду:
![image](https://github.com/Roman-Davidyuk/04-polymorphism-Roman-Davidyuk/assets/145706234/ca62df21-bd91-427d-abd7-b6c0f5b8a709)

# Імплементація фабричного методу в програм
---

<ol>
  <li>
    Перший крок створити інтерфейс IFunction.
    
  ```C#
  public interface IFunction
  {
      void SetCoefficients(double[] coefficients);
      void PrintCoefficients();
      double Evaluate(double x0);
  }
  ```

  </li>
  <li>
      Другий крок створити фабричний метод у класі FunctionFactory, який буде створювати об'єкти різних типів функцій в залежності від вхідних даних.
    
```C#
  public static class FunctionFactory
  {
      public static IFunction CreateFunction(int choice)
      {
          if (choice == 1)
          {
              return new FractionalFunction();
          }
          else if (choice == 2)
          {
              return new FractionalQuadraticFunction();
          }
          else
          {
              throw new ArgumentException("Invalid choice.");
          }
      }
  }
```
    
  </li>
</ol>

пілся цого програма Main буде мати такий вигляд

```C#
static void Main(string[] args)
{
      Console.WriteLine("Which type of function do you want to create?");
      Console.WriteLine("Enter 1 for FractionalFunction");
      Console.WriteLine("Enter 2 for FractionalQuadraticFunction");
      int choice = int.Parse(Console.ReadLine());

      IFunction function = FunctionFactory.CreateFunction(choice);
      function.SetCoefficientsFromInput();

      Console.WriteLine("\nFunction created:");
      function.PrintCoefficients();
      Console.WriteLine("Enter x0 to evaluate the function:");
      double x0 = double.Parse(Console.ReadLine());
      Console.WriteLine($"Value at x = {x0}: " + function.Evaluate(x0));

}
```
[Оновлена програма з використанням фабричного методу](https://github.com/Roman-Davidyuk/04-polymorphism-Roman-Davidyuk/blob/main/FractionalFunction.cs)
## Використання фабричного методу в цьому випадку дозволяє спростити процес створення та розширення функціональності програми.
