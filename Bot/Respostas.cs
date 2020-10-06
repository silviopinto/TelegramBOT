
// ********************************************************************
// ********************************************************************
// **********  https://github.com/silviopinto/TelegramBOT  ************
// ********************************************************************
// ********************************************************************

using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
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


        public async void Mensagens(MessageEventArgs e, string mensagens)
        {
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Olá " +e.Message.From.FirstName + " " + e.Message.From.LastName + " desde que existo, já enviaste " + mensagens +" mensagens",
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            replyToMessageId: e.Message.MessageId);
        }

        public async void Temperatura(MessageEventArgs e, string resposta)
        {
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: resposta,
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            replyToMessageId: e.Message.MessageId);
        }

        public async void BemVindo(MessageEventArgs e)
        {
            int quantidadeUsers = await bot.GetChatMembersCountAsync(e.Message.Chat.Id);
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Olá *" + e.Message.NewChatMembers[0].FirstName + " " + e.Message.NewChatMembers[0].LastName + "* sê bem vindo(a) ao "+e.Message.Chat.Title  + Environment.NewLine + "Se precisares da minha ajuda envia *!comandos*"
            +Environment.NewLine + "Atualmente somos *" + quantidadeUsers.ToString() +"* fornecedores de grelo",
            parseMode: ParseMode.Markdown,
            disableNotification: true);
        }

        public async void Convite(MessageEventArgs e)
        {
            string chatLink = await bot.ExportChatInviteLinkAsync(e.Message.Chat.Id);

            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Link para entrar no grupo: " + chatLink,
            parseMode: ParseMode.Markdown,
            disableNotification: true);
        }

        public async void Comandos(MessageEventArgs e)
        {
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat.Id,
            text: "Olá " + e.Message.From.FirstName + " " + e.Message.From.LastName +", os meus comandos são:"
            + Environment.NewLine +
            "*!admins* - Lista de admins"
            + Environment.NewLine +
            "*!euromilhoes* - Chave de euromilhões"
             + Environment.NewLine +
            "*!mensagens* - Quantidade de mensagens enviadas"
             + Environment.NewLine +
            "*!temperatura (distrito)* - Previsão para 5 dias"
             + Environment.NewLine +
            "*!noticias* - 5 ultimas noticias do JN"
             + Environment.NewLine +
            "*!horas* - Hora atual "
             + Environment.NewLine +
            "Mais tarde terei novos comandos",
            parseMode: ParseMode.Markdown,
            disableNotification: true);
        }

        public async void Adeus(MessageEventArgs e)
        {
            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "O " + e.Message.LeftChatMember.FirstName + " " + e.Message.LeftChatMember.LastName + " saiu do grupo porque viu a mulher num video",
            parseMode: ParseMode.Markdown,
            disableNotification: true);
        }

        public async void Abuso(MessageEventArgs e)
        {
            try {
                Message message = await bot.SendTextMessageAsync(
           chatId: e.Message.Chat,
           text: "Abusos *na pussylga* não serão tolerados, como consequencia poderás ser `banido` do grupo",
           parseMode: ParseMode.Markdown,
           disableNotification: true,
           replyToMessageId: e.Message.MessageId,
           replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Clica aqui para seres uma pessoa melhor", "https://www.decorfacil.com/como-fazer-croche/")));
                Console.WriteLine($"{message.From.FirstName} enviou mensagem {message.Text.ToLower()} " + $"para o chat {message.Chat.Title} às {message.Date}. " + $"Mensagem: {message.ReplyToMessage.MessageId} " +
    $"and has {message.Entities.Length} message entities.");
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException msg )
            {
                Console.WriteLine(e.Message.From + "  Bloqueou o BOT e não conseguiu ser notificado ");
            }
        }
            
        public async void Admins(MessageEventArgs e)
            {
                Message message = await bot.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: "Miguel" + Environment.NewLine + "Marco" + Environment.NewLine + "Sílvio" + Environment.NewLine + "2 Sarg 45º" + Environment.NewLine + "Migas" + Environment.NewLine + "Azevedo" + Environment.NewLine + "João Pincel" + Environment.NewLine + "Guerreiro" + Environment.NewLine + "J.Castanheiro" + Environment.NewLine + "Maluma" + Environment.NewLine + "Hello Kitty",
                parseMode: ParseMode.Markdown,
                disableNotification: true,
                replyToMessageId: e.Message.MessageId);
            }

        public async void Spam(MessageEventArgs e, string data, string user)
        {

            Message message = await bot.SendTextMessageAsync(
            chatId: e.Message.Chat,
            text: "Olá " + e.Message.From.FirstName +" "+ e.Message.From.LastName +" o video que tentaste enviar já foi enviado para o grupo em: " + data + " pelo utilizador " + user + " como tal, será apagado",
            parseMode: ParseMode.Markdown,
            disableNotification: true,
            //replyToMessageId: e.Message.MessageId,
            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Clica aqui para seres uma pessoa melhor", "https://www.decorfacil.com/como-fazer-croche/")));
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
                text: "Olá Grunho! Já vi que andas teso, aqui vai a chave. Numeros:Estrelas " + numero[0] + " - " + numero[1] + " - " + numero[2] + " - " + numero[3] + " - " + numero[4] + " : " + estrela[0] + " " + estrela[1],
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

            for (int i = 0; i < _noticias.Length; i++)
            {
                try
                {
                    Message message = await bot.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "*" + _noticias[i].Titulo + "*" + Environment.NewLine + _noticias[i].Noticia + Environment.NewLine + _noticias[i].Data.ToShortDateString() + "   " + _noticias[i].Data.ToShortTimeString() + Environment.NewLine + Environment.NewLine + _noticias[i].Link,
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
