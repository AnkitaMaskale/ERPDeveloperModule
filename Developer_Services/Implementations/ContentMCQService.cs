using Developer_Services.Interfaces;
using DeveloperModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Implementations
{
    class ContentMCQService : IContentMCQc
    {
       
        SqlCommand cmd;
        SqlDataReader dr;
        public void AddContentMCQ(ContentMCQsModel m)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteContentMcqs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@ContentMCQ", m.ContentMcqName);
                cmd.Parameters.AddWithValue("@ContentId", m.ContentId);
                cmd.Parameters.AddWithValue("@Option1", m.Option1);
                cmd.Parameters.AddWithValue("@Option2", m.Option2);
                cmd.Parameters.AddWithValue("@Option3", m.Option3);
                cmd.Parameters.AddWithValue("@Option4", m.Option4);
                cmd.Parameters.AddWithValue("@CorrectOption", m.CorrectOption);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public void UpdateContentMCQs(ContentMCQsModel m)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteContentMcqs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@ContentMCQId", m.ContentMCQId);
                cmd.Parameters.AddWithValue("@ContentMCQ", m.ContentMcqName);
                cmd.Parameters.AddWithValue("@ContentId", m.ContentId);
                cmd.Parameters.AddWithValue("@Option1", m.Option1);
                cmd.Parameters.AddWithValue("@Option2", m.Option2);
                cmd.Parameters.AddWithValue("@Option3", m.Option3);
                cmd.Parameters.AddWithValue("@Option4", m.Option4);
                cmd.Parameters.AddWithValue("@CorrectOption", m.CorrectOption);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteContentMCQs(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteContentMcqs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@ContentMCQId", id);
                cmd.Parameters.AddWithValue("@Flag",1);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public List<ContentMCQsModel> GetAllContentMcq()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllcontentMcqs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentMCQId",0);
               dr = cmd.ExecuteReader();
                List<ContentMCQsModel> lst = new List<ContentMCQsModel>();

                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["ContentMCQId"]);
                    string mcq = dr["ContentMCQ"].ToString();
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string option1 = dr["Option1"].ToString();
                    string option2 = dr["Option2"].ToString();
                    string option3 = dr["Option3"].ToString();
                    string option4 = dr["Option4"].ToString();
                    string correctoption = dr["CorrectOption"].ToString();
                    string cname = dr["ContentName"].ToString();

                    ContentMCQsModel c = new ContentMCQsModel()
                    {
                        ContentMCQId = id,
                        ContentId = cid,
                        ContentMcqName = mcq,
                        ContentName = cname,
                        Option1 = option1,
                        Option2 = option2,
                        Option3=option3,
                        Option4=option4,
                        CorrectOption=correctoption
                    };
                    lst.Add(c);
                }
                return lst;
            }
        }

        public ContentMCQsModel GetContentMcqById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllcontentMcqs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentMCQId", id);
                dr = cmd.ExecuteReader();

                ContentMCQsModel c = new ContentMCQsModel();

                while (dr.Read())
                {
                    int mid = Convert.ToInt32(dr["ContentMCQId"]);
                    string mcq = dr["ContentMCQ"].ToString();
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string option1 = dr["Option1"].ToString();
                    string option2 = dr["Option2"].ToString();
                    string option3 = dr["Option3"].ToString();
                    string option4 = dr["Option4"].ToString();
                    string correctoption = dr["CorrectOption"].ToString();
                    string cname = dr["ContentName"].ToString();


                    c.ContentMCQId = mid;
                    c.ContentMcqName = mcq;
                    c.ContentId = cid;
                    c.Option1 = option1;
                    c.Option2 = option2;
                    c.Option3 = option3;
                    c.Option4 = option4;
                    c.CorrectOption = correctoption;
                    c.ContentName = cname;
                }
                return c;
            }
        }

        public List<ContentMCQsModel> GetContentWiseMCQ(string content)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchContentMCQsByContentName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentName", content);
                dr = cmd.ExecuteReader();
                List<ContentMCQsModel> lst = new List<ContentMCQsModel>();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ContentMCQId"]);
                    string mcq = dr["ContentMCQ"].ToString();
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string option1 = dr["Option1"].ToString();
                    string option2 = dr["Option2"].ToString();
                    string option3 = dr["Option3"].ToString();
                    string option4 = dr["Option4"].ToString();
                    string correctoption = dr["CorrectOption"].ToString();
                    string cname = dr["ContentName"].ToString();

                    ContentMCQsModel c = new ContentMCQsModel()
                    {
                        ContentMCQId = id,
                        ContentId = cid,
                        ContentMcqName = mcq,
                        ContentName = cname,
                        Option1 = option1,
                        Option2 = option2,
                        Option3 = option3,
                        Option4 = option4,
                        CorrectOption = correctoption
                    };
                    lst.Add(c);
                }
                return lst;
            }
        }
    }
}
