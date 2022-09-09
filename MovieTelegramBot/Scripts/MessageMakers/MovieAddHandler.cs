using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MovieTelegramBot.MessageMakers
{
    internal class MovieAddHandler : MessageHandler
    {
        public BotManager BotManager { get; private set; }

        private int _messageCounter = 0;

        private string _title;
        private int _year;
        private string _description;

        public MovieAddHandler(BotManager manager) : base(manager)
        {
            BotManager = manager;
        }

        public override void HandleMessage(Message message)
        {
            if (_messageCounter == 0)
            {
                _title = message.Text;
                BotManager.Client.SendTextMessageAsync(message.Chat, "Enter Year");
            }

            if (_messageCounter == 1)
            {
                _year = int.Parse(message.Text);
                BotManager.Client.SendTextMessageAsync(message.Chat, "Enter Movie Description");
            }

            if(_messageCounter == 2)
            {
                _description = message.Text;

                using(var context = new MovieContext())
                {
                    var movie = new Movie()
                    {
                        Title = _title,
                        Year = _year,
                        Description = _description
                    };

                    context.Movies.Add(movie);
                    context.SaveChanges();
                }

                BotManager.ChangeMessageHandler(new MainMessageHandler(BotManager));
                BotManager.Client.SendTextMessageAsync(message.Chat, "Movie Added");

                Console.WriteLine("added new Movie");
            }

            _messageCounter++;
        }

        public override void EnterNewState(Message message)
        {
            BotManager.Client.SendTextMessageAsync(message.Chat, "Enter Movie Title");
        }
    }
}
