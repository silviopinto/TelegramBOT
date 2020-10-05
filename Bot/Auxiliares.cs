using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace Bot
{
    public class Auxiliares 
    {
        public async Task<int> NumeroMembrosChat(TelegramBotClient e, MessageEventArgs msg)
        {

            int total = await e.GetChatMembersCountAsync(msg.Message.Chat.Id);

            return total;
        }

        public async void ApagarMensagem(TelegramBotClient e, MessageEventArgs msg)
        {
            await e.DeleteMessageAsync(msg.Message.Chat.Id, msg.Message.MessageId);

        }

        public void ratata()
        {

        }




    }
}
