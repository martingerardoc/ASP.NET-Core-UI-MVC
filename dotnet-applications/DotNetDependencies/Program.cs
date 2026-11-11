using Humanizer;

Console.WriteLine("Hello, World!");
Console.WriteLine("What is your name?");
string name = Console.ReadLine();   
Console.WriteLine("How old are you?");
int age = int.Parse(Console.ReadLine());    
Console.WriteLine("Nice to meet you, {0}! You are {1} years old.", name, age);

static void HumanizeQuantities()
{
    Console.WriteLine("case".ToQuantity(0));
    Console.WriteLine("case".ToQuantity(1));
    Console.WriteLine("case".ToQuantity(5));
}

static void HumanizeDates()
{
    Console.WriteLine(DateTime.UtcNow.AddHours(-24).Humanize());
    Console.WriteLine(DateTime.UtcNow.AddHours(-2).Humanize());
    Console.WriteLine(TimeSpan.FromDays(1).Humanize());
    Console.WriteLine(TimeSpan.FromDays(16).Humanize());
}
Console.WriteLine("Quantities:");
HumanizeQuantities();

Console.WriteLine("\nDate/Time Manipulation:");
HumanizeDates();