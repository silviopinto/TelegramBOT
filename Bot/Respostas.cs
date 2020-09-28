using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace Bot
{
    public class Respostas
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient("1346767934:AAGFSN0XKPEN3bd5EY5PgJvh5v9m9NsRU2c");

        public async void Horas(MessageEventArgs e)
        {
            Get _get = new Get();

            Message message = await bot.SendStickerAsync(
             chatId: e.Message.Chat,
             sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp");

            message = await bot.SendTextMessageAsync(
             chatId: e.Message.Chat,
             text: _get.GetHoras());

            
        }

        public async void Ola(MessageEventArgs e)
        {
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat, 
            text: "Abusos *na pussylga* não serão tolerados, como consequencia poderás ser `banido` do grupo",
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            replyToMessageId: e.Message.MessageId,
            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Clica aqui para seres uma pessoa melhor", "https://pornhub.com" )));
            Console.WriteLine($"{message.From.FirstName} enviou mensagem {message.MessageId} " + $"para o chat {message.Chat.Id} às {message.Date}. " + $"Mensagem: {message.ReplyToMessage.MessageId} " +
$"and has {message.Entities.Length} message entities.");
        }

        public async void Abuso(MessageEventArgs e)
        {
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Abusos *na pussylga* não serão tolerados, como consequencia poderás ser `banido` do grupo",
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            replyToMessageId: e.Message.MessageId,
            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Clica aqui para seres uma pessoa melhor", "https://pornhub.com")));
            Console.WriteLine($"{message.From.FirstName} enviou mensagem {message.Text.ToLower()} " + $"para o chat {message.Chat.Title} às {message.Date}. " + $"Mensagem: {message.ReplyToMessage.MessageId} " +
$"and has {message.Entities.Length} message entities.");

            
        }

        public async void Spam(MessageEventArgs e, string result)
        {
           
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Olá Grunho! o video que tentaste enviar já foi enviado para a Pussylga em: "+result,
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            replyToMessageId: e.Message.MessageId,
            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Clica aqui para seres uma pessoa melhor", "https://pornhub.com")));
        }

        public async void EuroMilhoes(MessageEventArgs e)
        {
            try
            {

          
            int[] numero = new int[5];
            int[] estrela = new int[2];

            var rand = new Random();

            for (int i = 0; i <= 4; i++)
            {

                numero[i] = rand.Next(1, 50);
                    if (numero.Any(x => x == numero[i]))
                        numero[i] = rand.Next(1, 50);
                 
                }

            for (int i = 0; i <= 1; i++)
            {
                estrela[i] = rand.Next(1, 12);
                    if (estrela.Any(x => x == estrela[i]))
                        estrela[i] = rand.Next(1, 12);
                }

            Array.Sort(numero);
            Array.Sort(estrela);


            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Olá Grunho! Já vi que andas teso, aqui vai a chave. Numeros:Estrelas " + numero[0] + " - " + numero[1] + " - " + numero[2] + " - " + numero[3] + " - " + numero[4] + " : " + estrela[0] +" " + estrela[1],
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            replyToMessageId: e.Message.MessageId,
            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Clica aqui consultares as ultimas chaves", "https://www.jogossantacasa.pt/web/SCCartazResult/")));
            }
            catch (Exception msg)
            {
                System.Console.WriteLine(msg);
            }
            }


        public async void Noticias(MessageEventArgs e)
        {
            Get _get = new Get();
            Noticias[] _noticias = new Noticias[30];

            _noticias = await _get.GetNoticias();

            for(int i = 0; i < _noticias.Length; i++)
            {
                try { 
                Message message = await bot.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: "*" + _noticias[i].Titulo + "*" + Environment.NewLine + _noticias[i].Noticia + Environment.NewLine + _noticias[i].Data.ToShortDateString() +"   "+_noticias[i].Data.ToShortTimeString() + Environment.NewLine +Environment.NewLine + _noticias[i].Link,
                parseMode: ParseMode.Markdown);
                    //if ((message.From.FirstName != null) && (message.Date != null))
                    //{
                    //    Console.WriteLine($"{message.From.FirstName} enviou mensagem {message.MessageId} " + $"para o chat {message.Chat.Id} às {message.Date}. " + $"Mensagem: {message.ReplyToMessage.MessageId} " +
                    //    $"and has {message.Entities.Length} message entities.");
                    //}
                }
                catch (Exception msg)
                {
                    System.Console.WriteLine(msg);
                }
                 

            }


           
        }

    }
}
