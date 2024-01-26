using Microsoft.Extensions.Configuration;
using Red_Cross_Bloedvoorraden.Models;
using System.Data.SqlClient;
using System.Data;

namespace Red_Cross_Bloedvoorraden.Data
{
    public interface DataContext
    {
        Response AddBloodbag(SqlConnection connection, Bloedzakje bloodbag);
        Response GetAllBloodbags(SqlConnection connection);
        Response GetBloodbagById(SqlConnection connection, string id);
    }
}
