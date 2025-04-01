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
    class TopicService : ITopicService
    {
        SqlCommand cmd;
        SqlDataReader dr;
        public void AddTopic(TopicModel t)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@TopicName", t.TopicName);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateTopic(TopicModel t)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@TopicId", t.TopicId);
                cmd.Parameters.AddWithValue("@TopicName", t.TopicName);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteTopic(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString())) 
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@TopicId",id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<TopicModel> GetAllTopics()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicId", 0);
               dr = cmd.ExecuteReader();

                List<TopicModel> lst = new List<TopicModel>();

                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["TopicId"]);
                    string name = dr["TopicName"].ToString();

                    TopicModel t = new TopicModel()
                    {
                        TopicId = id,
                        TopicName = name
                    };
                    lst.Add(t);
                }
                con.Close();
                return lst;
            }
        }

        public TopicModel GetTopicById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicId", id);
                dr = cmd.ExecuteReader();

                TopicModel t = new TopicModel();

                if (dr.Read())
                {
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string name = dr["TopicName"].ToString();

                    t.TopicId = tid;
                    t.TopicName = name;
                }
                con.Close();
                return t;
            }
        }

    }
}
