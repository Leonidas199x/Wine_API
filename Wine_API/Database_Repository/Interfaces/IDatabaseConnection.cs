using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Database_Repository.Interfaces
{
    internal interface IDatabaseConnection
    {
        SqlConnection OpenSqlConnection();
       
    }
}
