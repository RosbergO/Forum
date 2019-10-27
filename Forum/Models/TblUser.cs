using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblPosts = new HashSet<TblPosts>();
        }

        public int UsId { get; set; }
        public string UsName { get; set; }
        public string UsHash { get; set; }
        public string UsSalt { get; set; }
        public string UsEmail { get; set; }

        public ICollection<TblPosts> TblPosts { get; set; }

        public static TblUser GetUserFromID(int i)
        {
            TblUser output = new TblUser();
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetUserFromID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@User_ID", i));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output = new TblUser() { UsId = int.Parse(rdr["Us_ID"].ToString()), UsName = rdr["Us_Name"].ToString(), UsEmail = rdr["Us_Email"].ToString() };
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
