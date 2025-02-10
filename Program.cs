using System;


#region QUESTION_1

// Question 1: Shape Interfaces
interface IShape
{
    double Area { get; }
    void DisplayShapeInfo();
}

interface ICircle : IShape { }
interface IRectangle : IShape { }

class Circle : ICircle
{
    public double Radius { get; }
    public double Area => Math.PI * Radius * Radius;

    public Circle(double radius) => Radius = radius;
    public void DisplayShapeInfo() => Console.WriteLine($"Circle with radius {Radius}, Area: {Area}");
}

class Rectangle : IRectangle
{
    public double Width { get; }
    public double Height { get; }
    public double Area => Width * Height;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public void DisplayShapeInfo() => Console.WriteLine($"Rectangle {Width}x{Height}, Area: {Area}");
}

#endregion

//===============================================================================================================
#region QUESTION_2

// Question 2: Authentication Service

interface IAuthenticationService
{
    bool AuthenticateUser(string username, string password);
    bool AuthorizeUser(string username, string role);
}

class BasicAuthenticationService : IAuthenticationService
{
    private string storedUser = "admin";
    private string storedPass = "password";

    public bool AuthenticateUser(string username, string password) => username == storedUser && password == storedPass;
    public bool AuthorizeUser(string username, string role) => username == storedUser && role == "admin";
}

#endregion

//===============================================================================================================

#region QUESTION_3

// Question 3: Notification Service

interface INotificationService
{
    void SendNotification(string recipient, string message);
}

class EmailNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message) => Console.WriteLine($"Email to {recipient}: {message}");
}

class SmsNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message) => Console.WriteLine($"SMS to {recipient}: {message}");
}

class PushNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message) => Console.WriteLine($"Push Notification to {recipient}: {message}");
}
#endregion

//===============================================================================================================

#region Frist_Project
class Point3D : ICloneable, IComparable<Point3D>
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    // Constructor chaining
    public Point3D() : this(0, 0, 0) { }
    public Point3D(int x) : this(x, 0, 0) { }
    public Point3D(int x, int y) : this(x, y, 0) { }
    public Point3D(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    // Override ToString()
    public override string ToString()
    {
        return $"Point Coordinates: ({X}, {Y}, {Z})";
    }

    // Override Equals and == Operator
    public override bool Equals(object obj)
    {
        if (obj is Point3D other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    public static bool operator ==(Point3D p1, Point3D p2)
    {
        return Equals(p1, p2);
    }

    public static bool operator !=(Point3D p1, Point3D p2)
    {
        return !(p1 == p2);
    }

    // Implement ICloneable
    public object Clone()
    {
        return new Point3D(X, Y, Z);
    }

    // Implement IComparable for sorting
    public int CompareTo(Point3D other)
    {
        if (X != other.X) return X.CompareTo(other.X);
        return Y.CompareTo(other.Y);
    }
}

#endregion

//===============================================================================================================

#region Second Project: Math Operations
static class Maths
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static double Divide(int a, int b) => b != 0 ? (double)a / b : throw new DivideByZeroException();
}
#endregion

//===============================================================================================================
#region Third Project: E-commerce Discount System

abstract class Discount
{
    public string Name { get; protected set; } // عشان اللي بيورثوا بس  هما اللي يقدروا يدخلوا الاسم بتاع الخصم 
    public abstract decimal CalculateDiscount(decimal price, int quantity);
}
class PercentageDiscount : Discount
{
    private readonly decimal percentage;

    public PercentageDiscount(decimal percentage)
    {
        this.percentage = percentage;
        Name = "Percentage Discount";
    }

    public override decimal CalculateDiscount(decimal price, int quantity)
    {
        return price * quantity * (percentage / 100);
    }
}
class FlatDiscount : Discount
{
    private decimal FlatAmount;
    public FlatDiscount(decimal amount) => FlatAmount = amount;
    public override decimal CalculateDiscount(decimal price, int quantity) => FlatAmount * Math.Min(quantity, 1);
}
class BuyOneGetOneDiscount : Discount
{
    public override decimal CalculateDiscount(decimal price, int quantity) => (price / 2) * (quantity / 2);
}

#endregion

//===============================================================================================================
class Program
{
    static Point3D ReadPoint(string pointName)
    {
        int x, y, z;
        Console.WriteLine($"Enter coordinates for {pointName} (X, Y, Z):");
        x = ReadInt("X");
        y = ReadInt("Y");
        z = ReadInt("Z");
        return new Point3D(x, y, z);
    }
    static int ReadInt(string coordName)
    {
        int value;
        while (true)
        {
            Console.Write($"Enter {coordName}: ");
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
    static void Main()
    {
        #region TESTING_QUESTION_1
        IShape circle = new Circle(5);
        circle.DisplayShapeInfo();
        IShape rectangle = new Rectangle(4, 6);
        rectangle.DisplayShapeInfo();
        #endregion

        #region TESTING_QUESTION_2

        IAuthenticationService authService = new BasicAuthenticationService();
        Console.WriteLine(authService.AuthenticateUser("admin", "password"));
        Console.WriteLine(authService.AuthorizeUser("admin", "admin"));

        #endregion

        #region TESTING_QUESTION_3

        INotificationService Email_Service = new EmailNotificationService();
        Email_Service.SendNotification("user@example.com", "Welcome!");
        INotificationService Sms_Service = new SmsNotificationService();
        Sms_Service.SendNotification("user@example.com", "Welcome!");
        INotificationService Push_Service = new PushNotificationService();
        Push_Service.SendNotification("user@example.com", "Welcome!");

        #endregion

        #region Testing_First_Project
        // Test Constructor and ToString()
        Point3D P = new Point3D(10, 10, 10);
        Console.WriteLine(P.ToString());

        // Read input from user
        Point3D P1 = ReadPoint("P1");
        Point3D P2 = ReadPoint("P2");

        // Test == Operator
        Console.WriteLine(P1 == P2 ? "P1 and P2 are equal" : "P1 and P2 are not equal");

        // Create and sort an array of points
        Point3D[] points =
        {
            new Point3D(5, 2, 3),
            new Point3D(2, 1, 4),
            new Point3D(3, 5, 1),
            new Point3D(1, 3, 2)
        };

        Array.Sort(points);
        Console.WriteLine("Sorted Points:");
        foreach (var point in points)
        {
            Console.WriteLine(point);
        }

        // Test Cloning
        Point3D clone = (Point3D)P1.Clone();
        Console.WriteLine($"Cloned P1: {clone}");
        #endregion

        #region Testing_Second_Project

        Console.WriteLine(Maths.Add(10, 5));
        Console.WriteLine(Maths.Subtract(10, 5));
        Console.WriteLine(Maths.Multiply(10, 5));
        Console.WriteLine(Maths.Divide(10, 5));

        #endregion

        #region Testing_Third_Project
        decimal price = 100;
        int quantity = 3;

        Discount percentageDiscount = new PercentageDiscount(10);
        Discount flatDiscount = new FlatDiscount(50);
        Discount bogoDiscount = new BuyOneGetOneDiscount();

        Console.WriteLine($"{percentageDiscount.Name}: ${percentageDiscount.CalculateDiscount(price, quantity)}");
        Console.WriteLine($"{flatDiscount.Name}: ${flatDiscount.CalculateDiscount(price, quantity)}");
        Console.WriteLine($"{bogoDiscount.Name}: ${bogoDiscount.CalculateDiscount(price, quantity)}");

        #endregion
    }
}
