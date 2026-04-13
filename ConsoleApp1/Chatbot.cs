using System;
using System.IO;
using System.Media;

class Chatbot
{
    string userName;

    ConsoleColor titleColor = ConsoleColor.Magenta;
    ConsoleColor accentColor = ConsoleColor.DarkMagenta;
    ConsoleColor textColor = ConsoleColor.White;
    ConsoleColor highlight = ConsoleColor.Cyan;

    public void Start()
    {
        ShowAsciiArt();
        ShowHeader();
        PlayVoiceGreeting();
        AskUserName();
        ChatLoop();
    }

    void ShowAsciiArt()
    {
        Console.ForegroundColor = accentColor;

        Console.WriteLine(@"
   ____      _                              _             
  / ___| ___| |__   ___ _ __ ___   ___  ___| |_ ___  _ __ 
 | |  _ / _ \ '_ \ / _ \ '_ ` _ \ / _ \/ __| __/ _ \ '__|
 | |_| |  __/ |_) |  __/ | | | | |  __/\__ \ ||  __/ |   
  \____|\___|_.__/ \___|_| |_| |_|\___||___/\__\___|_|   
                                                          
     CYBERSECURITY AWARENESS CHATBOT
        ");

        Console.ResetColor();
        Console.WriteLine();
    }

    void ShowHeader()
    {
        Console.Clear();

        Console.ForegroundColor = titleColor;

        Console.WriteLine("==============================================");
        Console.WriteLine("        CYBERSECURITY CHATBOT                ");
        Console.WriteLine("==============================================");

        Console.ForegroundColor = highlight;
        Console.WriteLine("      SAFE ONLINE LIVING - CYBERSECURITY BOT");
        Console.WriteLine("==============================================\n");

        Console.ResetColor();
    }

    void PlayVoiceGreeting()
    {
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

            if (File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
            else
            {
                Console.WriteLine("Voice file missing in project folder.");
            }
        }
        catch
        {
            Console.WriteLine("Error playing voice file.");
        }
    }

    void AskUserName()
    {
        Console.ForegroundColor = highlight;
        Console.Write("Enter your name: ");
        Console.ResetColor();

        userName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userName))
            userName = "User";

        Console.ForegroundColor = textColor;
        Console.WriteLine("Hello " + userName + ", welcome!\n");
        Console.ResetColor();
    }

    void ChatLoop()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n----------------------------------------------");
            Console.ResetColor();

            Console.ForegroundColor = highlight;
            Console.WriteLine("Ask me something (or type exit)");
            Console.ResetColor();

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid question.");
                continue;
            }

            if (input.ToLower() == "exit")
            {
                Console.WriteLine("Stay safe online " + userName + "!");
                break;
            }

            Respond(input);
        }
    }

    void Respond(string input)
    {
        input = input.ToLower();

        Console.ForegroundColor = textColor;

        if (input.Contains("how are you"))
        {
            Console.WriteLine("I am working safely and ready to help you!");
        }
        else if (input.Contains("purpose"))
        {
            Console.WriteLine("I help you learn cybersecurity safety.");
        }
        else if (input.Contains("password"))
        {
            Console.WriteLine("Use strong passwords with uppercase, numbers and symbols.");
        }
        else if (input.Contains("phishing"))
        {
            Console.WriteLine("Phishing is fake messages trying to steal your personal information.");
        }
        else
        {
            Console.WriteLine("I didn’t understand that. Try asking about passwords or phishing.");
        }

        Console.ResetColor();
    }
}