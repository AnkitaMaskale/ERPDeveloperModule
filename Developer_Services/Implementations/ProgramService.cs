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
    class ProgramService : IProgramService
    {
      
        SqlCommand cmd;
        SqlDataReader dr;

        public void AddProgram(ProgramsModel p)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString())) 
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeletePrograms", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@ProgramName", p.ProgramName);
                cmd.Parameters.AddWithValue("@ContentId", p.ContentId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateProgram(ProgramsModel p)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeletePrograms", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@ProgramId", p.ProgramId);
                cmd.Parameters.AddWithValue("@ProgramName", p.ProgramName);
                cmd.Parameters.AddWithValue("@ContentId", p.ContentId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteProgram(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeletePrograms", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@ProgramId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<ProgramsModel> GetAllPrograms()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllPrograms", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProgramId", 0);
               dr = cmd.ExecuteReader();

                List<ProgramsModel> lst = new List<ProgramsModel>();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ProgramId"]);
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string pname = dr["ProgramName"].ToString();
                    string cname = dr["ContentName"].ToString();

                    ProgramsModel p = new ProgramsModel() 
                    {
                        ProgramId = id,
                        ProgramName = pname,
                        ContentId = cid,
                        ContentName = cname
                    };
                    lst.Add(p);
                }
                return lst;
            }
        }

        public ProgramsModel GetProgramById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllPrograms", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProgramId", id);
                dr = cmd.ExecuteReader();

                ProgramsModel p = new ProgramsModel();

                if (dr.Read())
                {
                    int pid = Convert.ToInt32(dr["ProgramId"]);
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string pname = dr["ProgramName"].ToString();
                    string cname = dr["ContentName"].ToString();

                    p.ProgramId = pid;
                    p.ProgramName = pname;
                    p.ContentId = cid;
                    p.ContentName = pname;

                }
                return p;
            }
        }

        public ProgramsModel GetContentWiseProgram(string content)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchProgramsByContentName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentName", content);
                dr = cmd.ExecuteReader();

                ProgramsModel p = new ProgramsModel();

                if (dr.Read())
                {
                    int pid = Convert.ToInt32(dr["ProgramId"]);
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string pname = dr["ProgramName"].ToString();
                    string cname = dr["ContentName"].ToString();

                    p.ProgramId = pid;
                    p.ProgramName = pname;
                    p.ContentId = cid;
                    p.ContentName = pname;

                }
                return p;
            }
        }
    }
}
