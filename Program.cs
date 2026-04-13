using System;

class Program
{
    static void Main(string[] args)
    {
        Chatbot bot = new Chatbot();
        bot.Start();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}