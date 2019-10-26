using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Models
{
    public partial class TblPosts
    {
        

        public int PoId { get; set; }
        public string PoName { get; set; }
        public string PoContent { get; set; }
        public DateTime PoDate { get; set; }
        public int PoAuthor { get; set; }
        public int PoCategory { get; set; }
        public TblPosts(int PoID, string PoName, string PoContent, DateTime PoDate, int PoAuthor, int PoCategory)
        {
            this.PoId = PoID;
            this.PoName = PoName;
            this.PoContent = PoContent;
            this.PoDate = PoDate;
            this.PoAuthor = PoAuthor;
            this.PoCategory = PoCategory;
            TblComments = new HashSet<TblComments>();
        }
        public TblUser PoAuthorNavigation { get; set; }
        public TblCategories PoCategoryNavigation { get; set; }
        public ICollection<TblComments> TblComments { get; set; }

        public static int InsertPost(TblPosts postDetails, out string errorMessage)
        {
            errorMessage = "";

            SqlConnection dbConnection = new SqlConnection();
            dbConnection.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sqlString = @"INSERT INTO [Tbl_Posts] ([Po_Author], [Po_Category], [Po_Name], [Po_Content], [Po_Date]) 
VALUES(@author, @category, @name, @content, @date)";
            SqlCommand dbcommand = new SqlCommand(sqlString, dbConnection);

            dbcommand.Parameters.Add("author", SqlDbType.Int).Value = postDetails.PoAuthor;
            dbcommand.Parameters.Add("category", SqlDbType.Int).Value = postDetails.PoCategory;
            dbcommand.Parameters.Add("name", SqlDbType.NVarChar, 20).Value = postDetails.PoName;
            dbcommand.Parameters.Add("content", SqlDbType.NVarChar, 1000).Value = postDetails.PoContent;
            dbcommand.Parameters.Add("date", SqlDbType.Date).Value = postDetails.PoDate;

            try
            {
                dbConnection.Open();
                int i = 0;
                i = dbcommand.ExecuteNonQuery();
                if (i >= 1)
                    errorMessage = "";
                else
                {
                    errorMessage = "Could not create post.";
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

        public static List<TblPosts> GetPostsFromCategory(int i)
        {
            List<TblPosts> postList = new List<TblPosts>();
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MonsterPlan;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetPostsFromCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Category_ID", i));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    postList.Add(new TblPosts(int.Parse(rdr["Po_ID"].ToString()), rdr["Po_Name"].ToString(), rdr["Po_Content"].ToString(), Convert.ToDateTime(rdr["Po_Date"].ToString()), 1, int.Parse(rdr["Po_Category"].ToString())));
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
