using System;

public interface IFunction
{
    void SetCoefficientsFromInput();
    void PrintCoefficients();
    double Evaluate(double x0);
}

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

class FractionalFunction : IFunction
{
    protected double a1, a0, b1, b0;

    public FractionalFunction(double a1 = 0, double a0 = 0, double b1 = 0, double b0 = 0)
    {
        this.a1 = a1;
        this.a0 = a0;
        this.b1 = b1;
        this.b0 = b0;
    }

    public virtual void SetCoefficientsFromInput()
    {
        Console.WriteLine("Enter coefficients (a1, a0, b1, b0):");
        string[] coefficients = Console.ReadLine().Split();
        a1 = double.Parse(coefficients[0]);
        a0 = double.Parse(coefficients[1]);
        b1 = double.Parse(coefficients[2]);
        b0 = double.Parse(coefficients[3]);
    }

    public virtual void PrintCoefficients()
    {
        Console.WriteLine($"Numerator coefficients: a1 = {a1}, a0 = {a0}");
        Console.WriteLine($"Denominator coefficients: b1 = {b1}, b0 = {b0}");
    }

    public virtual double Evaluate(double x0)
    {
        double numerator = a1 * x0 + a0;
        double denominator = b1 * x0 + b0;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Division by zero occurred.");
        }
        return numerator / denominator;
    }
}

class FractionalQuadraticFunction : FractionalFunction
{
    private double a2, b2;

    public FractionalQuadraticFunction(double a2 = 0, double a1 = 0, double a0 = 0, double b2 = 0, double b1 = 0, double b0 = 0) : base(a1, a0, b1, b0)
    {
        this.a2 = a2;
        this.b2 = b2;
    }

    public override void SetCoefficientsFromInput()
    {
        base.SetCoefficientsFromInput();
        Console.WriteLine("Enter additional coefficients (a2, b2):");
        string[] additionalCoefficients = Console.ReadLine().Split();
        a2 = double.Parse(additionalCoefficients[0]);
        b2 = double.Parse(additionalCoefficients[1]);
    }

    public override void PrintCoefficients()
    {
        base.PrintCoefficients();
        Console.WriteLine($"Additional coefficients: a2 = {a2}, b2 = {b2}");
    }

    public override double Evaluate(double x0)
    {
        double linearPart = base.Evaluate(x0);
        double numerator = a2 * x0 * x0 + linearPart;
        double denominator = b2 * x0 * x0 + linearPart;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Division by zero occurred.");
        }
        return numerator / denominator;
    }
}

class FractionalFunctioN
{
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
}
