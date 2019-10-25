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
   

        public IActionResult Posts(int id)
        {
            
            List<TblPosts> postList = SelectWithDataSet(id);
            ViewBag.postList = postList;

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
                    postList.Add(new TblPosts(int.Parse(rdr["Po_ID"].ToString()), rdr["Po_Name"].ToString(), rdr["Po_Content"].ToString(), Convert.ToDateTime(rdr["Po_Date"].ToString()), 1, int.Parse(rdr["Po_Category"].ToString())));
                    //postList.Add(new TblPosts(int.Parse(rdr["Po_ID"].ToString()), rdr["Po_Name"].ToString(), rdr["Po_Content"].ToString(), Convert.ToDateTime(rdr["Po_Date"].ToString()), int.Parse(rdr["Po_Author"].ToString()), int.Parse(rdr["Po_Category"].ToString())));
                    //postList.Add(new TblPosts(1, "Oscar", "HEj allihopA",DateTime.Now, 1, 1 ));    
                    // Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
                }
                cmd.Dispose();
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
    }

}

