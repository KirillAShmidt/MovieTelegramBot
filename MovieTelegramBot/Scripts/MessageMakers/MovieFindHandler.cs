using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MovieTelegramBot.MessageMakers
{
    internal class MovieFindHandler : MessageHandler
    {
        public BotManager BotManager { get; private set; }

        public MovieFindHandler(BotManager manager) : base(manager)
        {
            BotManager = manager;
        }

        public override void HandleMessage(Message message)
        {
            using(var context = new MovieContext())
            {
                var movie = context.Movies.Find(int.Parse(message.Text));

                if (movie != null)
                    BotManager.Client.SendTextMessageAsync(message.Chat, $"id: {movie.Id} | Title: {movie.Title} | Year: {movie.Year} | Description {movie.Description}");
                else
                    BotManager.Client.SendTextMessageAsync(message.Chat, $"Movie with id '{message.Text}' does not exist.");
            }

            BotManager.ChangeMessageHandler(new MainMessageHandler(BotManager));
        }

        public override void EnterNewState(Message message)
        {
            BotManager.Client.SendTextMessageAsync(message.Chat, "Enter Movie ID");
        }
    }
}
