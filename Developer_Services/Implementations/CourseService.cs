using ClassLibrary1;
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
    class CourseService :ICourseService
    {
 
        SqlCommand cmd;
        SqlDataReader dr;

        public void AddCourse(CoursesModel c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteRestoreCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@CourseName", c.CourseName);
                cmd.Parameters.AddWithValue("@CourseCode", c.CourseCode);
                cmd.Parameters.AddWithValue("@TechnologyId", c.TechnologyId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateCourse(CoursesModel c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteRestoreCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@CourseName", c.CourseName);
                cmd.Parameters.AddWithValue("@CourseCode", c.CourseCode);
                cmd.Parameters.AddWithValue("@TechnologyId", c.TechnologyId);
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteCourse(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteRestoreCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@CourseId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<CoursesModel> GetAllCourses()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseId", 0);
                dr = cmd.ExecuteReader();

                List<CoursesModel> lst = new List<CoursesModel>();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["CourseId"]);
                    string name = dr["CourseName"].ToString();
                    string code = dr["CourseCode"].ToString();
                    int tid = Convert.ToInt32(dr["TechnologyId"]);
                    string tech = dr["TechnologyName"].ToString();

                    CoursesModel c = new CoursesModel()
                    {
                        CourseId = id,
                        CourseName = name,
                        CourseCode = code,
                        TechnologyId = tid,
                        TechnologyName = tech
                    };
                    lst.Add(c);
                }
                con.Close();
                return lst;
            }
        }

        public CoursesModel GetCourseById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllCourses", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseId", id);
                dr = cmd.ExecuteReader();

                CoursesModel c = new CoursesModel();
                if (dr.Read())
                {
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    string name = dr["CourseName"].ToString();
                    string code = dr["CourseCode"].ToString();
                    int tid = Convert.ToInt32(dr["TechnologyId"]);
                    string tname = dr["TechnologyName"].ToString();

                    c.CourseId = cid;
                    c.CourseName = name;
                    c.CourseCode = code;
                    c.TechnologyId = tid;
                    c.TechnologyName = tname;
                }
                con.Close();
                return c;
            }
        }

        public List<CoursesModel> GetTechnologyWiseCourses(string technology)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchCoursesByTechnologyName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TechnologyName", technology);
                dr = cmd.ExecuteReader();

                List<CoursesModel> lst = new List<CoursesModel>();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["CourseId"]);
                    string name = dr["CourseName"].ToString();
                    string code = dr["CourseCode"].ToString();
                    int tid = Convert.ToInt32(dr["TechnologyId"]);
                    string tech = dr["TechnologyName"].ToString();

                    CoursesModel c = new CoursesModel()
                    {
                        CourseId = id,
                        CourseName = name,
                        CourseCode = code,
                        TechnologyId = tid,
                       TechnologyName = tech                                                                                                                                                                                                                                                                                    
                    };
                    lst.Add(c);
                }
                con.Close();
                return lst;
            }
        }
    }
}
