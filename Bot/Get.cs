// ********************************************************************
// ********************************************************************
// **********  https://github.com/silviopinto/TelegramBOT  ************
// ********************************************************************
// ********************************************************************

using Microsoft.Toolkit.Parsers.Rss;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bot
{
    public class Get
    {
        public static Respostas _resposta = new Respostas();

        string url = "http://feeds.jn.pt/JN-Ultimas";


        public void GetMeteo()
        {


        }

        public string GetHoras()
        {
            int horas = Int32.Parse(DateTime.Now.ToShortTimeString().Substring(0, 2));
            string tempo = DateTime.Now.ToShortTimeString();
            string mensagem = "";

            if (horas >= 6 && horas < 13)
            {
                mensagem += "Bom dia! São ";
            }
            else if (horas >= 13 && horas < 19)
            {
                mensagem += "Boa Tarde! São ";
            }
            else
            {
                mensagem += "Boa Noite! São ";
            }

            mensagem += tempo;
            Console.WriteLine(mensagem);

            return mensagem;
        }


        public async Task<Noticias[]> GetNoticias()
        {
            Noticias[] _noticias = new Noticias[6];

            for (int i = 0; i < _noticias.Length; i++)
            {
                _noticias[i] = new Noticias();
            }

            //urlNoticias[0] = "http://feeds.jn.pt/JN-Ultimas";
            int contador = 0;

            string feed = null;

            using (var client = new HttpClient())
            {
                try
                {
                    feed = await client.GetStringAsync(url);
                }
                catch { }
            }

            if (feed != null)
            {
                var parser = new RssParser();
                var rss = parser.Parse(feed);
                try
                {
                    foreach (var element in rss.Select((value, i) => new { i, value }))
                    {
                        _noticias[element.i].Link = element.value.FeedUrl;
                        _noticias[element.i].Titulo = element.value.Title;
                        _noticias[element.i].Data = element.value.PublishDate;
                        int index = element.value.Content.IndexOf("<img");
                        if (index > 0)
                        {
                            _noticias[element.i].Noticia = element.value.Content.Substring(0, index);
                        }

                        contador++;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("6 Noticias enviadas");
                    System.Console.WriteLine(e);

                }

            }
            return _noticias;
        }
    }
}
