using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MovieTelegramBot
{
    public abstract class MessageHandler
    {
        public BotManager BotManager { get; set; }

        public MessageHandler(BotManager manager)
        {
            BotManager = manager;
        }

        public abstract Task HandleMessage(Message message);

        public abstract Task EnterNewState(Message message);

    }
}
