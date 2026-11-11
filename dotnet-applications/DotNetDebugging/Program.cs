using System;
using System.Diagnostics;
using System.IO;

int result = Fibonacci(5);
Console.WriteLine(result);



static int Fibonacci(int n)
{
    Debug.WriteLine($"Entering {nameof(Fibonacci)} method");
    Debug.WriteLine($"We are looking for the {n}th number");
    int n1 = 0;
    int n2 = 1;
    int sum;

    for (int i = 2; i <= n; i++)
    {
        sum = n1 + n2;
        n1 = n2;
        n2 = sum;
        Debug.WriteLineIf(sum == 1, $"sum is 1, n1 is {n1}, n2 is {n2}");
    }

    return n == 0 ? n1 : n2;
}

Console.WriteLine("This message is readable by the end user.");
Trace.WriteLine("This is a trace message when tracing the app.");
Debug.WriteLine("This is a debug message just for developers.");

Debug.Write("Debug - ");
Debug.WriteLine("This is a full line.");
Debug.WriteLine("This is another full line.");


// 1. List all directories inside stores
Console.WriteLine("=== Store Directories ===");

IEnumerable<string> listOfDirectories =
    Directory.EnumerateDirectories("stores");

foreach (var dir in listOfDirectories)
{
    Console.WriteLine(dir);
}

// 2. List all files inside stores
Console.WriteLine("\n=== Files in stores ===");

IEnumerable<string> files =
    Directory.EnumerateFiles("stores");

foreach (var file in files)
{
    Console.WriteLine(file);
}

// 3. Find all .txt files in stores and its subdirectories
Console.WriteLine("\n=== All TXT files ===");

IEnumerable<string> allFilesInAllFolders =
    Directory.EnumerateFiles(
        "stores",
        "*.txt",
        SearchOption.AllDirectories
    );

foreach (var file in allFilesInAllFolders)
{
    Console.WriteLine(file);
}