using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public partial class TblComments
    {
        public TblComments()
        {
        }

        public int CoId { get; set; }
        public string CoContent { get; set; }
        public DateTime CoDate { get; set; }
        public int CoAuthor { get; set; }
        public int CoPost { get; set; }

        public TblPosts CoPostNavigation { get; set; }


        public static List<TblComments> GetCommentsFromID(int id)
        {
            List<TblComments> output = new List<TblComments>();
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetComments", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Post_ID", id));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["Co_Content"].ToString());
                    output.Add(new TblComments() { CoAuthor = int.Parse(rdr["Co_Author"].ToString()), CoContent = rdr["Co_Content"].ToString(), CoDate = Convert.ToDateTime(rdr["Co_Date"].ToString()), CoPost = int.Parse(rdr["Co_Post"].ToString()), CoId = int.Parse(rdr["Co_ID"].ToString()) }); ;//CoAuthor = int.Parse(rdr["Co_Author"].ToString()), CoPost = int.Parse(rdr["Co_Post"].ToString()), CoContent = rdr["Co_Content"].ToString(), CoDate = Convert.ToDateTime(rdr["Co_Date"].ToString()) });
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

        internal static int InsertComment(TblComments comment, out string message)
        {
                message = "";

                SqlConnection dbConnection = new SqlConnection { ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" };
                string sqlString = @"INSERT INTO [Tbl_Comments] ([Co_Author], [Co_Post], [Co_Content], [Co_Date])
VALUES(@author, @post, @content, @date);";
                SqlCommand dbcommand = new SqlCommand(sqlString, dbConnection);

                dbcommand.Parameters.Add("author", SqlDbType.Int).Value = comment.CoAuthor;
                dbcommand.Parameters.Add("post", SqlDbType.Int).Value = comment.CoPost;
                dbcommand.Parameters.Add("content", SqlDbType.NVarChar, 1000).Value = comment.CoContent;
                dbcommand.Parameters.Add("date", SqlDbType.DateTime).Value = DateTime.Now;

                try
                {
                    dbConnection.Open();
                    int i = 0;
                    i = dbcommand.ExecuteNonQuery();
                    if (i >= 1)
                        message = "";
                    else
                    {
                        message = "Could not create comment.";
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    message = e.Message;
                    return 0;
                }
                finally
                {
                    dbConnection.Close();
                }
            
        }
    }
}
