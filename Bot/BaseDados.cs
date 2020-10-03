using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Bot
{
    public class BaseDados
    {

        public async void Inserir(string query)
        {
            try
            {

                string cs = @"server=localhost;userid=root;password=;database=bot";

                MySqlConnection con = new MySqlConnection(cs);

                con.Open();

                var cmd = new MySqlCommand(query, con);

                var result =  await cmd.ExecuteNonQueryAsync();

                Console.WriteLine("Novo registo feito na base de dados");

                con.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }

        public async Task<string> Verificar(string query)
        {
            try
            {

                string cs = @"server=localhost;userid=root;password=;database=bot";

                MySqlConnection con = new MySqlConnection(cs);

                con.Open();

                var cmd = new MySqlCommand(query, con);

                var result = await cmd.ExecuteScalarAsync();

                if (result != null)
                {
                    // Console.WriteLine($"Numero de novos registos: {result}");
                    return result.ToString();
                }

                con.Close();

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return null;
        }

    }
}
