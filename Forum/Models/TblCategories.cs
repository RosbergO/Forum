using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public partial class TblCategories
    {
        public TblCategories()
        {
            TblPosts = new HashSet<TblPosts>();
        }

        public int CaId { get; set; }
        public string CaName { get; set; }

        public ICollection<TblPosts> TblPosts { get; set; }

        public static string GetCategory(int i)
        {
            string output = "";
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetCategoryFromID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Category_ID", i));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output = rdr["Ca_Name"].ToString();
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
            return output;
        }

        internal static List<TblCategories> GetCategories()
        {
                List<TblCategories> output = new List<TblCategories>();
                SqlConnection conn = null;
                SqlDataReader rdr = null;

                try
                {
                    conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spGetCategories", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                    output.Add(new TblCategories()
                    {
                        CaName = rdr["Ca_Name"].ToString(), CaId = int.Parse(rdr["Ca_ID"].ToString())
                    });
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
                return output;
            }
            

        

        public static int InsertCategory(string category, out string errorMessage)
        {
            errorMessage = "";
            SqlConnection dbConnection = new SqlConnection { ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
            SqlCommand cmd = new SqlCommand("spCreateCategoryFromName", dbConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("name", SqlDbType.NVarChar, 20).Value = category;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = cmd.ExecuteNonQuery();
                if (i >= 1)
                    errorMessage = "";
                else
                {
                    errorMessage = "Could not create category.";
                }
                cmd.Dispose();
                return 1;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return 0;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public static int GetCategory(string category)
        {
            List<TblPosts> postList = new List<TblPosts>();
            int output = 0;
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@category", category));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output = int.Parse(rdr["Ca_ID"].ToString());
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
            return output;
        }
    }
}
