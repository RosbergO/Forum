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
    }
}
