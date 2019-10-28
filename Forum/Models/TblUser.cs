using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblPosts = new HashSet<TblPosts>();
        }

        public int UsId { get; set; }
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string UsName { get; set; }
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        public string UsHash { get; set; }
        public string UsSalt { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Please provide valid email id")]
        public string UsEmail { get; set; }
        public Boolean UsVerified { get; set; }
        public DateTime UsDate { get; set; }
        public string UsVerificationToken { get; set; }

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
        public static TblUser GetUserFromName(string name)
        {
            TblUser output = new TblUser();
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetUserFromName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@User_Name", name));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output = new TblUser() { UsId = int.Parse(rdr["Us_ID"].ToString()), UsName = rdr["Us_Name"].ToString(), UsEmail = rdr["Us_Email"].ToString(), UsSalt = rdr["Us_Salt"].ToString(), UsHash = rdr["Us_Hash"].ToString() };
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

        public static TblUser GetUserFromToken(string token)
        {
            TblUser output = new TblUser();
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetUserFromToken", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@token", token));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output = new TblUser() { UsId = int.Parse(rdr["Us_ID"].ToString()), UsName = rdr["Us_Name"].ToString(), UsEmail = rdr["Us_Email"].ToString(), UsSalt = rdr["Us_Salt"].ToString(), UsHash = rdr["Us_Hash"].ToString(), UsVerificationToken = rdr["Us_Verification_Token"].ToString() };
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
        internal static int Insert(TblUser user, out string errorMessage)
        {
            errorMessage = "";

            SqlConnection dbConnection = new SqlConnection { ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
            string sqlString = @"spInsertUser";
            SqlCommand dbcommand = new SqlCommand(sqlString, dbConnection);
            dbcommand.CommandType = CommandType.StoredProcedure;

            dbcommand.Parameters.Add("name", SqlDbType.NVarChar, 20).Value = user.UsName;
            dbcommand.Parameters.Add("hash", SqlDbType.NVarChar, 128).Value = user.UsHash;
            dbcommand.Parameters.Add("salt", SqlDbType.NVarChar, 128).Value = user.UsSalt;
            dbcommand.Parameters.Add("email", SqlDbType.NVarChar, 40).Value = user.UsEmail;
            dbcommand.Parameters.Add("token", SqlDbType.NVarChar, 64).Value = user.UsVerificationToken;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbcommand.ExecuteNonQuery();
                if (i >= 1)
                    errorMessage = "";
                else
                {
                    errorMessage = "Could not create User.";
                }

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

        public static int VerifyUser(TblUser user, out string errorMessage)
        {
            errorMessage = "";

            SqlConnection dbConnection = new SqlConnection { ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
            string sqlString = @"spVerifyUser";
            SqlCommand dbcommand = new SqlCommand(sqlString, dbConnection);
            dbcommand.CommandType = CommandType.StoredProcedure;

            dbcommand.Parameters.Add("id", SqlDbType.Int).Value = user.UsId;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbcommand.ExecuteNonQuery();
                if (i >= 1)
                    errorMessage = "";
                else
                {
                    errorMessage = "Could not create User.";
                }

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
    }
}
