using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bot
{
    public class Meteo
    {

        public class CurrencyRates
        {
            //globalIdLocal: identificador do local
            public string idRegiao { get; set; }

            //local: nome do local: identificador do local
            public string idAreaAviso { get; set; }

            //idRegion: identificador região[1 "Continente", 2 "Arq. Madeira", 3 "Arq. Açores"]
            public string idConcelho { get; set; }

            //idCounty: Identificador do concelho(identificador definido no âmbito DICO)
            public string GlobalIdLocal{ get; set; }

            //idDistrict: Identificador do distrito(identificador definido no âmbito DICO)
            public string latitude { get; set; }

            //idWarningRegion: Identificador da área dos avisos
            public string idDistrito { get; set; }

            //latitude: latitude da coordenada geográfica(graus decimais)
            public string local { get; set; }

            //longitude: longitude da coordenada geográfica(graus decimais)
            public string longitude { get; set; }

        }

        public class IPMA
        {
            public string Owner { get; set; }
            public string Country { get; set; }

            public CurrencyRates Data = new CurrencyRates();
            //public string Data { get; set; }

            //globalIdLocal: identificador do local
            public string idRegiao { get; set; }

            //local: nome do local: identificador do local
            public string idAreaAviso { get; set; }

            //idRegion: identificador região[1 "Continente", 2 "Arq. Madeira", 3 "Arq. Açores"]
            public string idConcelho { get; set; }

            //idCounty: Identificador do concelho(identificador definido no âmbito DICO)
            public string GlobalIdLocal { get; set; }

            //idDistrict: Identificador do distrito(identificador definido no âmbito DICO)
            public string latitude { get; set; }

            //idWarningRegion: Identificador da área dos avisos
            public string idDistrito { get; set; }

            //latitude: latitude da coordenada geográfica(graus decimais)
            public string local { get; set; }

            //longitude: longitude da coordenada geográfica(graus decimais)
            public string longitude { get; set; }

        }

        private static T _download_serialized_json_data<T>(string url) where T : new()
        {

            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public void GetIdentificadores(string url)
        {
            //string apiURL = "https://api.ipma.pt/open-data/distrits-islands.json";

            var resp = _download_serialized_json_data<IPMA>(url);

            
            System.Console.ReadKey();
           // Meteo[] _meteo = new Meteo[];



        }


    }
}
