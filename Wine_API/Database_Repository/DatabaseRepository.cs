using System;
using System.Collections.Generic;
using System.Text;
using Database_Models;
using System.Data.SqlClient;
using System.Data;

namespace Database_Repository
{
    public class DatabaseRepository
    {
        DatabaseConnection DatabaseConnect = new DatabaseConnection();

        public List<Models.Country> GetCountries()
        {
            var countriesList = new List<Models.Country>();

            using (var conn = DatabaseConnect.OpenSqlConnection())
            using (var command = new SqlCommand("spGetAllCountries", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    var countryModel = new Models.Country();
                    countryModel.CountryId = Int32.Parse(reader["CountryID"].ToString());
                    countryModel.CountryName = reader["CountryName"].ToString();

                    countriesList.Add(countryModel);
                }
            }

            return countriesList;
        }
    }
}
