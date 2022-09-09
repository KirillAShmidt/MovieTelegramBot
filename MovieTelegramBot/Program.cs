using System;

namespace MovieTelegramBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*using(var context = new MovieContext())
            {
                var movie = new Movie()
                {
                    Title = "Interstellar",
                    Year = 2014,
                    Description = "movie about space"
                };

                context.Movies.Add(movie);
                context.SaveChanges();

                var movie1 = context.Movies.Find(1);

                //Console.WriteLine($"id: {movie1.Id} | Title: {movie1.Title}");
                Console.ReadLine();*/

            var bot = new BotManager();

            bot.InitializeBot();


            Console.ReadLine();
        }
    }
}
