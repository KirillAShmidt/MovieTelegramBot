using MovieTelegramBot.MessageMakers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace MovieTelegramBot
{
    public class BotManager
    {
        public TelegramBotClient Client { get; private set; }
        private MessageHandler CurrentMessageHandler { get; set; }

        private Message _message;

        public void InitializeBot()
        {
            Client = new TelegramBotClient(DataContainer.TOKEN);
            Client.StartReceiving(UpdateHandler, ErrorHandler, new ReceiverOptions());

            CurrentMessageHandler = new MainMessageHandler(this);
        }

        private Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
        {
            if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                _message = update.Message;

                CurrentMessageHandler.HandleMessage(_message);
            }
        }

        public void ChangeMessageHandler(MessageHandler messageHandler)
        {
            CurrentMessageHandler = messageHandler;
            CurrentMessageHandler.EnterNewState(_message);
        }
    }
}
