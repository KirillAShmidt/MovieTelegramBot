using System;
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

        public abstract void HandleMessage(Message message);

        public abstract void EnterNewState(Message message);

    }
}
