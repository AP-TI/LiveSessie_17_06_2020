using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Deel4Oefening1.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public List<Speler> GetSpelers(string naam, DateTime geboorteDatum)
        {
            string url = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            List<Speler> spelers = new List<Speler>();
            using (SqlConnection conn = new SqlConnection(url))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Spelers WHERE Naam LIKE @Naam AND Geb_Datum = @Geboortedatum", conn);
                cmd.Parameters.AddWithValue("Naam", $"%{naam}%");
                cmd.Parameters.AddWithValue("Geboortedatum", geboorteDatum);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    spelers.Add(new Speler
                    {
                        SpelersNr = reader.GetInt32(0),
                        Naam = reader.GetString(1),
                        Voorletters = reader.GetString(2),
                        Geb_Datum = reader.GetDateTime(3),
                        Geslacht = 'V',
                        Jaartoe = int.Parse(reader.GetValue(5).ToString()),
                        Straat = reader.GetString(6),
                        HuisNr = reader.GetString(7),
                        Postcode = reader.GetString(8),
                        Plaats = reader.GetString(9),
                        Telefoon = reader.GetString(10),
                        BondsNr = reader.GetValue(11).ToString(),
                    });

                    /*
                        spelers.Add(new Speler
                    {
                        SpelersNr = Convert.ToInt32(reader["SpelersNr"]),
                        Naam = reader["Naam"].ToString(),
                        Voorletters = reader["Voorletters"].ToString(),
                        Geb_Datum = Convert.ToDateTime(reader["Geb_Datum"]),
                        Geslacht = Convert.ToChar(reader["Geslacht"]),
                        Jaartoe = Convert.ToInt32(reader["Jaartoe"]),
                        Straat = reader["Straat"].ToString(),
                        HuisNr = reader["HuisNr"].ToString(),
                        Postcode = reader["Postcode"].ToString(),
                        Plaats = reader["Plaats"].ToString(),
                        Telefoon = reader["Telefoon"].ToString(),
                        BondsNr = reader["Bondsnr"].ToString()
                    });
                    */
                }
            }
            return spelers;
        }
    }
}
