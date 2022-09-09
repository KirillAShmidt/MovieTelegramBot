using System;

namespace MovieTelegramBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bot = new BotManager();
            bot.InitializeBot();

            Console.ReadLine();
        }
    }
}
