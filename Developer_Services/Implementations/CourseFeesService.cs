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
    class CourseFeesService : ICourseFeesService
    {
        SqlCommand cmd;
        SqlDataReader dr;
        //public CourseFeesService()
        //{
        //    con = new SqlConnection(@"Server=DESKTOP-P1V523F; Database=ERP_ProjectDB; Trusted_Connection=True; TrustServerCertificate=True");
        //}
        public void AddCourseFee(CourseFeesModel c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeletecourseFees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@Fees", c.Fees);
                cmd.Parameters.AddWithValue("@GST", c.GST);
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@FeesChangeDate", c.FeesChangeDate);
                cmd.Parameters.AddWithValue("@FeeMode", c.FeeMode);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateCourseFee(CourseFeesModel c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeletecourseFees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@Fees", c.Fees);
                cmd.Parameters.AddWithValue("@GST", c.GST);
                cmd.Parameters.AddWithValue("@CourseId", c.CourseId);
                cmd.Parameters.AddWithValue("@FeesChangeDate", c.FeesChangeDate);
                cmd.Parameters.AddWithValue("@FeeMode", c.FeeMode);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteCourseFee(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeletecourseFees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@FeeId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<CourseFeesModel> GetAllCourseFees()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllFees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeeId", 0);
                dr = cmd.ExecuteReader();

                List<CourseFeesModel> lst = new List<CourseFeesModel>();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["FeeId"]);
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    float fees = (float)Convert.ToDouble(dr["Fees"]);
                    float gst = (float)Convert.ToDouble(dr["GST"]);
                    DateTime changedate = Convert.ToDateTime(dr["FeesChangeDate"]);
                    string feemode = dr["FeeMode"].ToString();
                    string cname = dr["CourseName"].ToString();

                    CourseFeesModel c = new CourseFeesModel()
                    {
                        FeeId = id,
                        CourseId = cid,
                        Fees = fees,
                        GST = gst,
                        FeesChangeDate = changedate,
                        FeeMode = feemode,
                        CourseName=cname
                    };
                    lst.Add(c);
                }
                return lst;
            }
        }

        public CourseFeesModel GetCourseFeeById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllFees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeeId", id);
                dr = cmd.ExecuteReader();

                CourseFeesModel cm = new CourseFeesModel();

                if (dr.Read())
                {
                    int fid = Convert.ToInt32(dr["FeeId"]);
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    float fees = (float)Convert.ToDouble(dr["Fees"]);
                    float gst = (float)Convert.ToDouble(dr["GST"]);
                    DateTime changedate = Convert.ToDateTime(dr["FeesChangeDate"]);
                    string feemode = dr["FeeMode"].ToString();
                    string cname = dr["CourseName"].ToString();

                    cm.FeeId = fid;
                    cm.CourseId = cid;
                    cm.Fees = fees;
                    cm.GST = gst;
                    cm.FeesChangeDate = changedate;
                    cm.FeeMode = feemode;
                    cm.CourseName = cname;
                }
                con.Close();
                return cm;
            }
        }

        public CourseFeesModel GetCourseWiseFee(string course)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchCourseFeeByCourseName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourseName", course);
                dr = cmd.ExecuteReader();

                CourseFeesModel cm = new CourseFeesModel();

                if (dr.Read())
                {
                    int fid = Convert.ToInt32(dr["FeeId"]);
                    int cid = Convert.ToInt32(dr["CourseId"]);
                    float fees = (float)Convert.ToDouble(dr["Fees"]);
                    float gst = (float)Convert.ToDouble(dr["GST"]);
                    DateTime changedate = Convert.ToDateTime(dr["FeesChangeDate"]);
                    string feemode = dr["FeeMode"].ToString();
                    string cname = dr["CourseName"].ToString();

                    cm.FeeId = fid;
                    cm.CourseId = cid;
                    cm.Fees = fees;
                    cm.GST = gst;
                    cm.FeesChangeDate = changedate;
                    cm.FeeMode = feemode;
                    cm.CourseName = cname;
                }
                con.Close();
                return cm;
            }
        }
    }
}
