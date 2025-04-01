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
    class CourseTopicService : ICourseTopicService
    {

        SqlCommand cmd;
        SqlDataReader dr;

        public void AddCourseTopic(CourseTopicsModel c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteCourseTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@CourseTopicName", c.CourseTopicName);
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@TopicId", c.TopicId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateCourseTopic(CourseTopicsModel c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteCourseTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@CourseTopicId", c.CourseTopicId);
                cmd.Parameters.AddWithValue("@CourseTopicName", c.CourseTopicName);
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@TopicId", c.TopicId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteCourseTopic(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteCourseTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@CourseTopicId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<CourseTopicsModel> GetAllCourseTopics()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllCourseTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseTopicId", 0);
                dr = cmd.ExecuteReader();

                List<CourseTopicsModel> lst = new List<CourseTopicsModel>();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["CourseTopicId"]);
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string name = dr["CourseTopicName"].ToString();
                    string cname = dr["CourseName"].ToString();
                    string tname = dr["TopicName"].ToString();

                    CourseTopicsModel cm = new CourseTopicsModel()
                    {
                        CourseTopicId = id,
                        CourseTopicName = name,
                        CourseId = cid,
                        TopicId = tid,
                        CourseName = cname,
                        TopicName = tname
                    };
                    lst.Add(cm);
                }
                con.Close();
                return lst;

            }
        }

        public CourseTopicsModel GetCourseTopicById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllCourseTopics", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseTopicId", id);
                dr = cmd.ExecuteReader();

                CourseTopicsModel cm = new CourseTopicsModel();
                if (dr.Read())
                {
                    int cmid = Convert.ToInt32(dr["CourseTopicId"]);
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string name = dr["CourseTopicName"].ToString();
                    string cname = dr["CourseName"].ToString();
                    string tname = dr["TopicName"].ToString();

                    cm.CourseTopicId = cmid;
                    cm.CourseId = cid;
                    cm.TopicId = tid;
                    cm.CourseName = cname;
                    cm.CourseTopicName = name;
                    cm.TopicName = tname;
                }
                con.Close();
                return cm;
            }
        }

        public List<CourseTopicsModel> GetCourseWiseCourseTopic(string course)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchCourseTopicsByCourseName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseName", course);
                dr = cmd.ExecuteReader();

                List<CourseTopicsModel> lst = new List<CourseTopicsModel>();
                
                while (dr.Read())
                {
                    int cmid = Convert.ToInt32(dr["CourseTopicId"]);
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string name = dr["CourseTopicName"].ToString();
                    string cname = dr["CourseName"].ToString();

                    CourseTopicsModel cm = new CourseTopicsModel()
                    {
                        CourseTopicId = cmid,
                        CourseTopicName = name,
                        CourseId=cid,
                        TopicId=tid,
                        CourseName = cname
                    };
                    lst.Add(cm);
                }
                con.Close();
                return lst;
            }
        }

        public List<CourseTopicsModel> GetTopicWiseCourseTopics(string topic)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchCourseTopicsByTopicName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TopicName", topic);
                dr = cmd.ExecuteReader();

                List<CourseTopicsModel> lst = new List<CourseTopicsModel>();

                while (dr.Read())
                {
                    int cmid = Convert.ToInt32(dr["CourseTopicId"]);
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    int tid = Convert.ToInt32(dr["TopicId"]);
                    string name = dr["CourseTopicName"].ToString();
                    string tname = dr["TopicName"].ToString();

                    CourseTopicsModel cm = new CourseTopicsModel()
                    {
                        CourseTopicId = cmid,
                        CourseTopicName = name,
                        CourseId = cid,
                        TopicId = tid,
                        TopicName = tname
                    };
                    lst.Add(cm);
                }
                con.Close();
                return lst;
            }
        }
    }
}
