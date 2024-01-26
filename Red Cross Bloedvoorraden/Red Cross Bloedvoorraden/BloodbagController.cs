using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Red_Cross_Bloedvoorraden.Data;
using Red_Cross_Bloedvoorraden.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

namespace Red_Cross_Bloedvoorraden.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloodbagController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public BloodbagController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllBloodbags")]
        public Response GetAll()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BloodbagAppCon").ToString());
            Response response = new Response();
            DataBase db = new DataBase();
            response = db.GetAllBloodbags(con);
            return response;

        }

        [HttpGet]
        [Route("GetBloodbagById/{id}")]
        public Response GetById(string id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BloodbagAppCon").ToString());
            Response response = new Response();
            DataBase db = new DataBase();
            response = db.GetBloodbagById(con, id);
            return response;

        }

        [HttpPost]
        [Route("AddBloodbag")]
        public Response Post(Bloedzakje bloodbag)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BloodbagAppCon").ToString());
            Response response = new Response();
            DataBase db = new DataBase();
            response = db.AddBloodbag(con, bloodbag);
            return response;

        }

    }
}