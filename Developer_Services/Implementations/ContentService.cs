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
    class ContentService : IContentsService
    {

        SqlCommand cmd;
        SqlDataReader dr;

        public void AddContent(ContentsModel t)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteContents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@TopicId", t.TopicId);
                cmd.Parameters.AddWithValue("@ContentName", t.ContentName);
                cmd.Parameters.AddWithValue("@VideoUrl", t.VideoUrl);
                cmd.Parameters.AddWithValue("@PPT", t.PPT);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateContent(ContentsModel t)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteContents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@ContentId", t.ContentId);
                cmd.Parameters.AddWithValue("@TopicId", t.TopicId);
                cmd.Parameters.AddWithValue("@ContentName", t.ContentName);
                cmd.Parameters.AddWithValue("@VideoUrl", t.VideoUrl);
                cmd.Parameters.AddWithValue("@PPT", t.PPT);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteContent(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteContents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@ContentId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<ContentsModel> GetAllContents()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllContents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", 0);
                dr = cmd.ExecuteReader();

                List<ContentsModel> lst = new List<ContentsModel>();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ContentId"]);
                    string name = dr["ContentName"].ToString();
                    string vdo = dr["VideoUrl"].ToString();
                    string ppt = dr["PPT"].ToString();
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string tname = dr["TopicName"].ToString();

                    ContentsModel c = new ContentsModel()
                    {
                        ContentId = id,
                        ContentName = name,
                        VideoUrl = vdo,
                        PPT = ppt,
                        TopicId = tid,
                        TopicName = tname
                    };
                    lst.Add(c);
                }
                con.Close();
                return lst;
            }
        }

        public ContentsModel GetContentById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllContents", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentId", id);
                dr = cmd.ExecuteReader();

                ContentsModel c = new ContentsModel();
                if (dr.Read())
                {
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string name = dr["ContentName"].ToString();
                    string vdo = dr["VideoUrl"].ToString();
                    string ppt = dr["PPT"].ToString();
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string tname = dr["TopicName"].ToString();

                    c.ContentId = cid;
                    c.ContentName = name;
                    c.VideoUrl = vdo;
                    c.PPT = ppt;
                    c.TopicId = tid;
                    c.TopicName = tname;
                }
                con.Close();
                return c;
            }

        }

        public ContentsModel GetTopicWiseContent(string topic)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchContentsByTopicName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicName", topic);
                dr = cmd.ExecuteReader();

                ContentsModel c = new ContentsModel();

                if (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ContentId"]);
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string tname = dr["TopicName"].ToString();
                    string cname = dr["ContentName"].ToString();
                    string vdo = dr["VideoUrl"].ToString();
                    string ppt = dr["PPT"].ToString();

                    c.ContentId = id;
                    c.ContentName = cname;
                    c.TopicId = tid;
                    c.TopicName = tname;
                    c.VideoUrl = vdo;
                    c.PPT = ppt;
                   
                }
                con.Close();
                return c;
            }
        }

       
    }
}
