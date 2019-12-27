using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginMVC.Models;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        void ConnectionString()
        {
            con.ConnectionString = "host=db4free.net;database=demowest;uid=demowest;password=Damyant@580;";
        }
        public IActionResult Verify(Account acc)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from logintbl where username='"+acc.Name+"' and password='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }


            

            
        }
    }
}
