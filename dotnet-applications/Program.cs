Console.WriteLine("Hello World!"); 
Console.WriteLine("Line 1 \nline 2"); // \n = new line
Console.WriteLine("Name: \tAlex");  // \t = tab space
Console.WriteLine("Path: C:\\Users"); // \\ = backslash
Console.WriteLine("She said, \"Hi!\""); // \" = double quote

// Console.Write()- no line break
Console.Write("Hello ");    
Console.Write(" ");
Console.Write("World!");
// output: Hello World!

// Console.WriteLine()- adds a line break
Console.WriteLine("Hello");
Console.WriteLine("World!");
//output:
// Hello
// World!  

Console.WriteLine("Hello", "World!"); // output: Hello World!

//Accept User Input in C# 
Console.WriteLine("What is your favorite color?"); // Prompts the user for input
string favoriteColor = Console.ReadLine(); // Accepts user input and stores it in the variable favoriteColor
Console.WriteLine("Your favorite color is: " + favoriteColor); // Displays the user input
Console.WriteLine($"Your favorite color is: {favoriteColor}"); // Displays the user input using string interpolation
Console.WriteLine("Your favorite color is: {0}", favoriteColor); // Displays the user input using string formatting
Console.WriteLine("oh, I love " + favoriteColor + " too!"); // Concatenation
// Manipulate streings in C#
string name = "Alex";   
Console.WriteLine(name.ToUpper()); // Output: ALEX
Console.WriteLine(name.ToLower()); // Output: alex
Console.WriteLine(name.Replace("A", "E")); // Output: Elex
Console.WriteLine(name.Length); // Output: 4

//Concatenation (+)
Console.WriteLine("Hello " + name); // Output: Hello Alex

//string interpolation ($)
Console.WriteLine($"Hello {name}"); // Output: Hello Alex

