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
        public static Ipma _ipma = new Ipma();

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

        public static void PrepareQuestionnairesFotos(MessageEventArgs e)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

        }

        public static void PrepareQuestionnairesVideos(MessageEventArgs e)
        {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                string data = _basedados.Verificar("select hashCode from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");

            if (data == null)
                {
                    _basedados.Inserir("insert into videos (hashCode, data,user) values ('" + e.Message.Video.FileUniqueId + "','" + sqlFormattedDate + "','" + e.Message.From + "')");
                    System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.From + " enviou um video. ");
                 }
                else
                {
                data = _basedados.Verificar("select data from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");
                string user = _basedados.Verificar("select user from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.From + " enviou um video que já existe. ");
                _respostas.Spam(e, data,user);
            }

            
        }

        public static void PrepareQuestionnaires(MessageEventArgs e)
        {

            if (e.Message.Text.First().ToString() == "/")
            {
                _respostas.Abuso(e);
            }

            if (e.Message.Text.ToLower().Contains("temperatura"))
            {
                
                Ipma.DadosTemperatura3Dias[] _temperaturas = new Ipma.DadosTemperatura3Dias[5];
                Ipma.DadosIdentificador[] _identificador = new Ipma.DadosIdentificador[30];

                string localidade = e.Message.Text.ToLower().Substring(11, e.Message.Text.ToLower().Length-11);
                localidade = localidade.Replace(" ", "");
                string resposta = "";

                _identificador = _ipma.GetDistritos();

                _temperaturas = _ipma.GetTemperatura(localidade, _identificador);

                resposta += "<b><i>" + localidade + "</i></b>" + ":" + Environment.NewLine;

                for (int i = 0; i < _temperaturas.Length; i++)
                {
                    resposta += _temperaturas[i].forecastDate + ":" + Environment.NewLine;
                    resposta += "**Probabilidade de chuva:** " + _temperaturas[i].precipitaProb + "%" + Environment.NewLine;
                    resposta += "**Max:** " + _temperaturas[i].tMax + "**Min:** " + _temperaturas[i].tMin + Environment.NewLine;
                }
                
                _respostas.Temperatura(e , resposta);

            }

            if (e.Message.Text.ToLower() == "quantas mensagens")
            {
                System.Console.WriteLine(e.Message.Chat.Id);
                _respostas.Noticias(e);
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

            if (e.Message.Text.ToLower() == "admins")
            {
                _respostas.Admins(e);
            }

            if (e.Message.Text.ToLower().Contains("melhor grupo"))
                bot.SendTextMessageAsync(e.Message.Chat.Id, "Pussylga com certeza!");
            

            if (e.Message.Text.ToString() != null)
{
                 DateTime myDateTime = DateTime.Now;
                 string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                _basedados.Inserir("INSERT INTO chat (idUser, conversa, data,user) VALUES ('" + e.Message.Chat.Id.ToString() + "','" + e.Message.Text + "','" + sqlFormattedDate + "','" + e.Message.From +"')");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.From +" enviou: " + e.Message.Text);
               
}


}
    }
}
