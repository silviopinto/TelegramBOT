namespace Bot
{
    public class Noticias
    {

        public string Titulo { get; set; }
        public string Noticia { get; set; }
        public System.DateTime Data { get; set; }
        public string Link { get; set; }


        public Noticias(string titulo, string noticia, System.DateTime data, string link)
        {
            Titulo = titulo;
            Noticia = noticia;
            Data = data;
            Link = link;
        }

        public Noticias() { }
    }
}
