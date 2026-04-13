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
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("=====================================");
        Console.WriteLine("   CYBERSECURITY AWARENESS CHATBOT   ");
        Console.WriteLine("=====================================");
        Console.WriteLine();

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
        void Respond(string input)
        {
            input = input.ToLower();

            if (input.Contains("how are you"))
            {
                Console.WriteLine("I am functioning perfectly and ready to keep you safe online.");
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                Console.WriteLine("My purpose is to educate you about cybersecurity and keep you safe online.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Use strong passwords with uppercase letters, numbers, and symbols. Never share them.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Phishing is when attackers trick you into giving personal information through fake emails or messages.");
            }
            else if (input.Contains("safe browsing"))
            {
                Console.WriteLine("Always check website URLs, avoid suspicious links, and never download unknown files.");
            }
            else if (input.Contains("cyber attack"))
            {
                Console.WriteLine("A cyber attack is when hackers try to damage, steal, or access your data illegally.");
            }
            else
            {
                Console.WriteLine("I didn’t understand that. Try asking about passwords, phishing, or safe browsing.");
            }
        }

        Console.ResetColor();
    }
}