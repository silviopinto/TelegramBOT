using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace Bot
{
    public class BaseDados
    {

        public void Inserir(string query)
        {
            try
            {

            string cs = @"server=localhost;userid=root;password=;database=bot";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            var cmd = new MySqlCommand(query, con);

           
               var result = cmd.ExecuteNonQuery().ToString();
            Console.WriteLine($"Numero de novos registos: {result}");
                con.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }

        public string Verificar(string query)
        {
            try
            {

                string cs = @"server=localhost;userid=root;password=;database=bot";

                MySqlConnection con = new MySqlConnection(cs);

                con.Open();

                var cmd = new MySqlCommand(query, con);

                var result = cmd.ExecuteScalar();

                if (result != null) { 
                Console.WriteLine($"Numero de novos registos: {result}");
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
