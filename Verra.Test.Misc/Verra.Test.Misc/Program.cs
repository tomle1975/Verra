// See https://aka.ms/new-console-template for more information

using System.Text;

Console.WriteLine("Hello, World!");
Console.WriteLine(Reverse("Today is sunny and Tom is taking a live coding test."));

static string Reverse(string input)
{
    var start = DateTime.Now;

    if (string.IsNullOrEmpty(input) || input.Length == 1) return input;

    var stringBuilder = new StringBuilder();
    for (var i = input.Length - 1; i >= 0; i--) stringBuilder.Append(input[i]);

    Console.WriteLine(DateTime.Now - start);

    return stringBuilder.ToString();
}