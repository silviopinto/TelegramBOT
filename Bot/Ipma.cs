using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections;
using System.Collections.Generic;


namespace Bot
{
    public class Ipma
    {

        public class DadosIdentificador
        {
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

        public class DadosTemperatura3Dias
        {

            public string precipitaProb { get; set; }
            public string tMin { get; set; }
            public string tMax { get; set; }
            public string predWindDir { get; set; }
            public string idWeatherType { get; set; }
            public string classWindSpeed { get; set; }
            public string longitude { get; set; }
            public string forecastDate { get; set; }
            public string latitude { get; set; }
        }



        public class RootObject
        {
            public List<DadosIdentificador> Data { get; set; }
        }

        public class RootObject2
        {
            public List<DadosTemperatura3Dias> Data { get; set; }
        }


        public Ipma.DadosIdentificador[] GetDistritos()
        {
            Ipma.DadosIdentificador[] _objectoDistritos = new Ipma.DadosIdentificador[30];

            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString("https://api.ipma.pt/open-data/distrits-islands.json");
                }
                catch (Exception)
                { }

                var result = JsonConvert.DeserializeObject<RootObject>(json_data);

                var idRegiao = result.Data.Select(p => p.idRegiao).ToList();
                var idAreaAviso = result.Data.Select(p => p.idAreaAviso).ToList();
                var idConcelho = result.Data.Select(p => p.idConcelho).ToList();
                var GlobalIdLocal = result.Data.Select(p => p.GlobalIdLocal).ToList();
                var latitude = result.Data.Select(p => p.latitude).ToList();
                var idDistrito = result.Data.Select(p => p.idDistrito).ToList();
                var local = result.Data.Select(p => p.local).ToList();
                var longitude = result.Data.Select(p => p.longitude).ToList();


                foreach (var element in idRegiao.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i] = new Ipma.DadosIdentificador();
                    _objectoDistritos[element.i].idRegiao = element.value;

                }

                foreach (var element in idAreaAviso.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i].idAreaAviso = element.value;
                }


                foreach (var element in idConcelho.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i].idConcelho = element.value;
                }


                foreach (var element in GlobalIdLocal.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i].GlobalIdLocal = element.value;
                }

                foreach (var element in latitude.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i].latitude = element.value;
                }


                foreach (var element in idDistrito.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i].idDistrito = element.value;
                }

                foreach (var element in local.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i].local = element.value;
                }

                foreach (var element in longitude.Select((value, i) => new { i, value }))
                {
                    _objectoDistritos[element.i].longitude = element.value;
                }

                return _objectoDistritos;
            }
        }

        public Ipma.DadosTemperatura3Dias[] GetTemperatura(string local, Ipma.DadosIdentificador[] objectoDistritos)
        {
            Ipma.DadosTemperatura3Dias[] _objectoTemperaturas = new Ipma.DadosTemperatura3Dias[5];

            string globalIdLocal = "";

            for (int i = 0; i < objectoDistritos.Length-1; i++)
            {
                if (local == objectoDistritos[i].local || local == objectoDistritos[i].local.ToLower())
                {
                    globalIdLocal = objectoDistritos[i].GlobalIdLocal;
                }
            }


            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    System.Console.WriteLine("A obter: http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/" + globalIdLocal + ".json");
                    json_data = w.DownloadString("http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/" + globalIdLocal + ".json");

                }
                catch (Exception)
                {
                    System.Console.WriteLine("Ocorreu um erro a tentar obter o JSON do IPMA");
                }

                try
                {
                    var result = JsonConvert.DeserializeObject<RootObject2>(json_data);

                    var precipitaProb = result.Data.Select(p => p.precipitaProb).ToList();
                    var tMin = result.Data.Select(p => p.tMin).ToList();
                    var tMax = result.Data.Select(p => p.tMax).ToList();
                    var predWindDir = result.Data.Select(p => p.predWindDir).ToList();
                    var idWeatherType = result.Data.Select(p => p.idWeatherType).ToList();
                    var classWindSpeed = result.Data.Select(p => p.classWindSpeed).ToList();
                    var longitude = result.Data.Select(p => p.longitude).ToList();
                    var forecastDate = result.Data.Select(p => p.forecastDate).ToList();
                    var latitude = result.Data.Select(p => p.latitude).ToList();

                    foreach (var element in precipitaProb.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i] = new Ipma.DadosTemperatura3Dias();
                        _objectoTemperaturas[element.i].precipitaProb = element.value;

                    }

                    foreach (var element in tMin.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].tMin = element.value;
                    }

                    foreach (var element in tMax.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].tMax = element.value;
                    }
                    foreach (var element in tMin.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].tMin = element.value;
                    }

                    foreach (var element in predWindDir.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].predWindDir = element.value;
                    }
                    foreach (var element in idWeatherType.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].idWeatherType = element.value;
                    }
                    foreach (var element in classWindSpeed.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].classWindSpeed = element.value;
                    }
                    foreach (var element in longitude.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].longitude = element.value;
                    }
                    foreach (var element in forecastDate.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].forecastDate = element.value;
                    }
                    foreach (var element in latitude.Select((value, i) => new { i, value }))
                    {
                        _objectoTemperaturas[element.i].latitude = element.value;
                    }
                }
                catch (NullReferenceException)
                {
                    System.Console.WriteLine("Ocorreu um erro #15");
                }
                }
            

            return _objectoTemperaturas;
        }

        public string ObtemID(string distrito)
        {
            Ipma.DadosIdentificador[] _objectoDistritos = new Ipma.DadosIdentificador[30];
            string id = "";
            _objectoDistritos = GetDistritos();

            for (int i = 0; i < _objectoDistritos.Length - 1; i++)
            {
                if (distrito == _objectoDistritos[i].local)
                {
                    id = _objectoDistritos[i].GlobalIdLocal;
                }
            }

            return id;
        }
    }
}
