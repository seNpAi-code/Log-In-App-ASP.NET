using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogInApp.Models;
using System.Data.SqlClient;

namespace LogInApp.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=LAPTOP-SUT349NN; database=LoginDB; integrated security = SSPI;";
        }
        [HttpPost]

        public ActionResult Verify(Account acc)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings[@"ConnectionString1"].ConnectionString;
            
            
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Users where UserName='"+acc.UserName+"' and password='"+acc.Password+"'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return View("Home");
            }
            else
            {
                con.Close();
                return View("Error");
            }

            
            
        }
    }
}