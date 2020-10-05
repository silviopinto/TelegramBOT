
// ********************************************************************
// ********************************************************************
// **********  https://github.com/silviopinto/TelegramBOT  ************
// ********************************************************************
// ********************************************************************


using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Bot
{
    public class Program
    {
        /// <summary>  
        /// Declare Telegrambot object  
        /// </summary>  
        private static readonly TelegramBotClient bot = new TelegramBotClient("1346767934:AAGFSN0XKPEN3bd5EY5PgJvh5v9m9NsRU2c");

        public static Respostas _respostas = new Respostas();
        public static BaseDados _basedados = new BaseDados();
        public static Ipma _ipma = new Ipma();
        public static Auxiliares _auxiliares = new Auxiliares();
        public static Get _get = new Get();

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
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.ChatMembersAdded)
                PrepararNovoMembro(e);
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.ChatMemberLeft)
                PrepararSaidaMembro(e);
            else if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
                PrepararFotos(e);
            

        }

        public static void PrepararFotos(MessageEventArgs e)
        {

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");


        }


        public async static void PrepararSaidaMembro(MessageEventArgs e)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string data = await _basedados.Verificar("select nome from membros where nome ='" + e.Message.LeftChatMember + "'");

            if (data == null)
            {
                _basedados.Inserir("insert into membros (nome, dataEntrada, dataSaida) values ('" + e.Message.LeftChatMember + "','" + sqlFormattedDate + "','" + sqlFormattedDate + "')");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.LeftChatMember + " saiu do grupo. ");
                _respostas.Adeus(e);
            }
            else
            {
                _basedados.Inserir("update membros set dataSaida = '" + sqlFormattedDate + "' where nome = '" + e.Message.LeftChatMember + "')");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.LeftChatMember + " saiu do grupo. ");
                _respostas.Adeus(e);
            }

        }

        public async static void PrepararNovoMembro(MessageEventArgs e)
        {
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string data = await _basedados.Verificar("select nome from membros where nome ='" + e.Message.NewChatMembers[0].ToString() +"'");

            // e.Message.NewChatMembers[0].FirstName.ToString() + " " + e.Message.NewChatMembers[0].LastName.ToString() + " (" + e.Message.NewChatMembers[0].

            if (data == null)
            {
                _basedados.Inserir("insert into membros (nome, dataEntrada) values ('" + e.Message.NewChatMembers[0].ToString() + "','" + sqlFormattedDate +"')");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.NewChatMembers[0].ToString() + " entrou no grupo. ");
                _respostas.BemVindo(e);
            }
            else
            {
                _basedados.Inserir("insert into membros (nome, dataEntrada) values ('" + e.Message.NewChatMembers[0].ToString() + "','" + sqlFormattedDate + "')");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.NewChatMembers[0].ToString() + " reentrou no grupo. ");
                _respostas.BemVindo(e);
            }

        }


        public async static void PrepareQuestionnairesVideos(MessageEventArgs e)
        {

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string data = await _basedados.Verificar("select hashCode from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");

            if (data == null)
            {
                _basedados.Inserir("insert into videos (hashCode, data,user) values ('" + e.Message.Video.FileUniqueId + "','" + sqlFormattedDate + "','" + e.Message.From + "')");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.From + " enviou um video. ");
            }
            else
            {
                
                data = await _basedados.Verificar("select data from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");
                string user = await _basedados.Verificar("select user from videos where hashCode='" + e.Message.Video.FileUniqueId + "'");
                _respostas.Spam(e, data, user);
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.From + " enviou um video que já existe. ");
                _basedados.Inserir("insert into avisos (nome,tipoAviso,data) values ('"+ e.Message.From + "','Video Repetido','" + sqlFormattedDate+ "')");
                await bot.DeleteMessageAsync(e.Message.Chat.Id, e.Message.MessageId);
                System.Console.WriteLine("A Mensagem foi apagada");
            }

        }

        public async static void PrepareQuestionnaires(MessageEventArgs e)
        {

            if (e.Message.Text.First().ToString() == "/")
            {
                _respostas.Abuso(e);
            }


            if (e.Message.Text.ToLower().Contains("!temperatura"))
            {
                try
                {
                    Ipma.DadosTemperatura3Dias[] _temperaturas = new Ipma.DadosTemperatura3Dias[5];
                    Ipma.DadosIdentificador[] _identificador = new Ipma.DadosIdentificador[30];

                    string localidade = e.Message.Text.ToLower().Substring(12, e.Message.Text.ToLower().Length - 12);
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

                    _respostas.Temperatura(e, resposta);
                }
                catch (Exception)
                { }
            }

            if (e.Message.Text.ToLower() == "!mensagens")
            {
                string resposta = await _get.getMensagens(e);

                System.Console.WriteLine(e.Message.From.FirstName +" " + e.Message.From.LastName +" solicitou o numero de mensagens, o resultado foi: " + resposta);
                _respostas.Mensagens(e, resposta);
            }

            if (e.Message.Text.ToLower() == "!noticias")
            {
                System.Console.WriteLine(e.Message.Chat.Id);
                _respostas.Noticias(e);
            }

            if (e.Message.Text.ToLower() == "!horas")
            {
                _respostas.Horas(e);
            }

            if (e.Message.Text.ToLower() == "!euromilhoes")
            {
                _respostas.EuroMilhoes(e);
            }

            if (e.Message.Text.ToLower() == "!admins")
            {
                _respostas.Admins(e);
            }

            if (e.Message.Text.ToLower() == "!comandos")
            {
                _respostas.Comandos(e);
                System.Console.WriteLine("O User " + e.Message.From.FirstName + " " + e.Message.From.LastName + " solicitou a lista de comandos.");
            }

            if (e.Message.Text.ToLower().Contains("melhor grupo"))
                await bot.SendTextMessageAsync(e.Message.Chat.Id, "Pussylga com certeza!");


            if (e.Message.Text.ToString() != null)
            {
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                _basedados.Inserir("INSERT INTO chat (idUser, conversa, data,user) VALUES ('" + e.Message.Chat.Id.ToString() + "','" + e.Message.Text + "','" + sqlFormattedDate + "','" + e.Message.From + "')");
                System.Console.WriteLine(sqlFormattedDate + " : " + e.Message.From + " enviou: " + e.Message.Text);

            }


        }
    }
}
