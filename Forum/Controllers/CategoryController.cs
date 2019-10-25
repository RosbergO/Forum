using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Forum.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.Controllers
{
    public class Category : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Posts()
        {
            return View();
        }

        public IActionResult ViewTest(int i)
        {
            List<TblPosts> postList = SelectWithDataSet(1);

            return View(postList);
        } 

        public List<TblPosts> SelectWithDataSet(int i)
        {
            List<TblPosts> postList = new List<TblPosts>();
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetPostsOnCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Category_ID", i));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //postList.Add(new TblPosts(int.Parse(rdr["Po_ID"].ToString()), rdr["Po_Name"].ToString(), rdr["Po_Content"].ToString(), Convert.ToDateTime(rdr["Po_Date"].ToString()), int.Parse(rdr["Po_Author"].ToString()), int.Parse(rdr["Po_Category"].ToString())));
                      postList.Add(new TblPosts(1, "Oscar", "HEj allihopA",DateTime.Now, 1, 1 ));    
                // Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
            return postList;
        }

        public void RunStoredProcParams(int i)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            // typically obtained from user
            // input, but we take a short cut
            int custId = i;

            try
            {
                // create and open a connection object
                conn = new
                    SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
                conn.Open();

                // 1. create a command object identifying
                // the stored procedure
                SqlCommand cmd = new SqlCommand(
                    "CustOrderHist", conn);

                // 2. set the command object so it knows
                // to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which
                // will be passed to the stored procedure
                cmd.Parameters.Add(
                    new SqlParameter("@CustomerID", custId));

                // execute the command
                rdr = cmd.ExecuteReader();

                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Console.WriteLine(
                        "Product: {0,-35} Total: {1,2}",
                        rdr["ProductName"],
                        rdr["Total"]);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
        }
    }

}

