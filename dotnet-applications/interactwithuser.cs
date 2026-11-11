// Ask for the user's name
Console.WriteLine("What is your name?");
string name = Console.ReadLine();
// Ask for the user's age
Console.WriteLine("How old are you?");
int age = int.Parse(Console.ReadLine());

 // Display a personalized message that includes both pieces of information
 Console.WriteLine($"Nice to meet you, {name}! You are {age} years old.");