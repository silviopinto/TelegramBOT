using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot;
 using Telegram.Bot.Types;
 using Telegram.Bot.Types.Enums;
 using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Specialized;

namespace Bot
{
    class Program
    {
        /// <summary>  
        /// Declare Telegrambot object  
        /// </summary>  
        private static readonly TelegramBotClient bot = new TelegramBotClient("1346767934:AAGFSN0XKPEN3bd5EY5PgJvh5v9m9NsRU2c");

        public static Respostas _respostas = new Respostas();
        public static BaseDados _basedados = new BaseDados();

        static void Main(string[] args)
        {

            bot.OnMessage += Csharpcornerbotmessage;
            bot.StartReceiving();
            
            Console.ReadLine();
            bot.StopReceiving();

        }

        /// <summary>  
        /// Handle bot webhook  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        private static void Csharpcornerbotmessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                PrepareQuestionnaires(e);
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Video)
                PrepareQuestionnairesVideos(e);
        }
        public static void PrepareQuestionnairesVideos(MessageEventArgs e)
        {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                string resultado = _basedados.Verificar("select hashCode from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");

                if (resultado == null)
                {
                    _basedados.Inserir("insert into videos (hashCode, data) values ('" + e.Message.Video.FileUniqueId + "','" + sqlFormattedDate + "')");
                }
                else
                {
                resultado = _basedados.Verificar("select data from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");
                  _respostas.Spam(e, resultado);
            }

            
        }

        public static void PrepareQuestionnaires(MessageEventArgs e)
        {

            if (e.Message.Text.First().ToString() == "/")
            {
                _respostas.Abuso(e);
                
                
            }

            if (e.Message.Text.ToLower() == "noticias")
            {
                System.Console.WriteLine(e.Message.Chat.Id);
                _respostas.Noticias(e);
            }

            if (e.Message.Text.ToLower() == "horas")
            {
                _respostas.Horas(e);
            }

            if (e.Message.Text.ToLower() == "euromilhoes") {
                _respostas.EuroMilhoes(e);
            
            }

            if (e.Message.Text.ToLower().Contains("melhor grupo"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Pussylga com certeza!");
            
            if (e.Message.Text.ToLower().Contains("csharpcorner logo?"))
            {
                bot.SendStickerAsync(e.Message.Chat.Id, "https://csharpcorner-mindcrackerinc.netdna-ssl.com/App_Themes/CSharp/Images/SiteLogo.png");
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Anything else?");
            }
            if (e.Message.Text.ToLower().Contains("list of featured"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Give me your profile link ?");
            if (e.Message.Text.ToLower().Contains("here it is"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, Environment.NewLine + "https://www.c-sharpcorner.com/article/getting-started-with-ionic-framework-angular-and-net-core-3/" + Environment.NewLine + Environment.NewLine +
                    "https://www.c-sharpcorner.com/article/getting-started-with-ember-js-and-net-core-3/" + Environment.NewLine + Environment.NewLine +
                    "https://www.c-sharpcorner.com/article/getting-started-with-vue-js-and-net-core-32/");


            

         

            if (e.Message.Text.ToString() != null)
{
                 DateTime myDateTime = DateTime.Now;
                 string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                _basedados.Inserir("INSERT INTO chat (idUser, conversa, data) VALUES ('" + e.Message.Chat.Id.ToString() + "','" + e.Message.Text + "','" + sqlFormattedDate + "')");
                System.Console.WriteLine(e.Message.Chat.Id.ToString());
                System.Console.WriteLine(e.Message.Text);
}


}
    }
}
