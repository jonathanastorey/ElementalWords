// See https://aka.ms/new-console-template for more information

//var ew = new Kata.ElementalForms

using static Kata.ElementalWords;

var result = ElementalForms("hop");

foreach (var word in result)
{
    Console.WriteLine("<-Match Result Start->");
    foreach (var element in word)
    {
        Console.WriteLine(element);
    }
    Console.WriteLine("<-Match Result End->");
}
