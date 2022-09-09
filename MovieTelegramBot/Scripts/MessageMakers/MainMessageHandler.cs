using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MovieTelegramBot.MessageMakers
{
    internal class MainMessageHandler : MessageHandler
    {
        public BotManager BotManager { get; private set; }

        public MainMessageHandler(BotManager manager) : base(manager)
        {
            BotManager = manager;
        }

        public override void HandleMessage(Message message)
        {
            Console.WriteLine($"Id: {message.Chat.Id} | UserName: {message.Chat.Username} | Message: {message.Text}");

            if (message.Text == "Find By Tag")
            {
                BotManager.ChangeMessageHandler(new MovieFindHandler(BotManager));
            }

            if (message.Text == "Add Movie")
            {
                BotManager.ChangeMessageHandler(new MovieAddHandler(BotManager));
            }

            if(message.Text == "Start")
            {
                BotManager.ChangeMessageHandler(new MainMessageHandler(BotManager));
            }
        }

        public override void EnterNewState(Message message)
        {
            var rmu = new ReplyKeyboardMarkup(new KeyboardButton[]
            {
                new KeyboardButton("Find By Tag"),
                new KeyboardButton("Add Movie")
            })
            {
                ResizeKeyboard = true
            };

            BotManager.Client.SendTextMessageAsync(message.Chat.Id, "Choose Option", replyMarkup: rmu);
        }
    }
}
