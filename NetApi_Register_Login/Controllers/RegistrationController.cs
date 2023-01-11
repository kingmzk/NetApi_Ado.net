using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetApi_Register_Login.Models;
using System.Data;
using System.Data.SqlClient;

namespace NetApi_Register_Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {
              SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ToysCon").ToString()); 

                SqlCommand cmd = new SqlCommand("INSERT INTO Registration(USERNAME,PASSWORD,EMAIL,IsActive) VALUES('"+registration.USERNAME + "','" + registration.PASSWORD + "','" + registration.EMAIL + "','" + registration.IsActive +"')",con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                return "Data Inserted";
            }
            else
            {
                return "Error Occured";
            }


        }

        [HttpPost]
        [Route("login")]
        public string login(Registration registration)
        {


            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ToysCon").ToString());

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE  Email='" + registration.EMAIL + "' AND PASSWORD = '"+registration.PASSWORD + "' AND IsActive = 1",con);
             DataTable dt = new DataTable();
            da.Fill(dt);    
            if(dt.Rows.Count>0) 
            {
                return "Valid User"; 
            }
            else
            {
                return "Invalid User";
            }

       

        }


    }
}
