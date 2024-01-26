using Red_Cross_Bloedvoorraden.Models;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Red_Cross_Bloedvoorraden.Data
{
    public class DataBase : DataContext
    {
        public Response AddBloodbag(SqlConnection connection, Bloedzakje bloodbag)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Bloedvoorraden(Bloedzakje_ID, Bloedgroep, Volume, Verzamelingsdatum, Vervaldatum) VALUES('" + bloodbag.Bloedzakje_ID + "','" + bloodbag.Bloedgroep + "','" + bloodbag.Volume + "','" + bloodbag.Verzamelingsdatum.ToString("yyyy-MM-dd") + "','" + bloodbag.Vervaldatum.ToString("yyyy-MM-dd") + "');", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data added";
                response.Bloedzakje = bloodbag;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Unable to add data";
                response.Bloedzakje = null;
            }

            return response;
        }

        public Response GetAllBloodbags(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Bloedvoorraden;", connection);
            DataTable dt = new DataTable();
            List<Bloedzakje> bloodbagList = new List<Bloedzakje>();
            da.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Bloedzakje bloodbag = new Bloedzakje();
                    bloodbag.Bloedzakje_ID = Convert.ToString(dt.Rows[i]["Bloedzakje_ID"]);
                    bloodbag.Bloedgroep = Convert.ToString(dt.Rows[i]["Bloedgroep"]);
                    bloodbag.Volume = Convert.ToInt32(dt.Rows[i]["Volume"]);
                    bloodbag.Verzamelingsdatum = Convert.ToDateTime(dt.Rows[i]["Verzamelingsdatum"]);
                    bloodbag.Vervaldatum = Convert.ToDateTime(dt.Rows[i]["Vervaldatum"]);
                    bloodbagList.Add(bloodbag);
                }
            }

            if(bloodbagList.Count> 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.bloodbagList = bloodbagList;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.bloodbagList = null;
            }

            return response;
        }

        public Response GetBloodbagById(SqlConnection connection, string id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Bloedvoorraden WHERE Bloedzakje_ID = '" + id + "';", connection);
            DataTable dt = new DataTable();
            Bloedzakje bloodbagList = new Bloedzakje();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Bloedzakje bloodbag = new Bloedzakje();
                bloodbag.Bloedzakje_ID = Convert.ToString(dt.Rows[0]["Bloedzakje_ID"]);
                bloodbag.Bloedgroep = Convert.ToString(dt.Rows[0]["Bloedgroep"]);
                bloodbag.Volume = Convert.ToInt32(dt.Rows[0]["Volume"]);
                bloodbag.Verzamelingsdatum = Convert.ToDateTime(dt.Rows[0]["Verzamelingsdatum"]);
                bloodbag.Vervaldatum = Convert.ToDateTime(dt.Rows[0]["Vervaldatum"]);

                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Bloedzakje = bloodbag;
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Bloedzakje = null;
            }

            return response;
        }

    }
}
