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
    class ProgramAnswerService : IProgramAnswersServices
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public void AddProgramAnswer(ProgramAnswersModel p)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString())) 
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteProgramsAnswers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@ProgramAnswer", p.ProgramAnswer);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@ProgramId", p.ProgramId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateProgramAnswer(ProgramAnswersModel p)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteProgramsAnswers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@ProgramAnswerId", p.ProgramAnswerId);
                cmd.Parameters.AddWithValue("@ProgramAnswer", p.ProgramAnswer);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@ProgramId", p.ProgramId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteProgramAnswer(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteProgramsAnswers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@ProgramAnswerId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<ProgramAnswersModel> GetAllProgramAnswers()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllProgramAnswers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProgramAnswerId", 0);
                dr = cmd.ExecuteReader();

                List<ProgramAnswersModel> lst = new List<ProgramAnswersModel>();

                while (dr.Read()) 
                {
                    int id = Convert.ToInt32(dr["ProgramAnswerId"]);
                    int pid = Convert.ToInt32(dr["ProgramId"]);
                    string panswer = dr["ProgramAnswer"].ToString();
                    string des = dr["Description"].ToString();
                    string pname = dr["ProgramName"].ToString();

                    ProgramAnswersModel p = new ProgramAnswersModel()
                    { 
                        ProgramAnswerId =id,
                        ProgramId=pid,
                        ProgramAnswer = panswer,
                        Description=des,
                        ProgramName =pname
                    };
                    lst.Add(p);
                }
                return lst;
            }
        }

        public ProgramAnswersModel GetProgramAnswersById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllProgramAnswers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProgramAnswerId", id);
                dr = cmd.ExecuteReader();

                ProgramAnswersModel p = new ProgramAnswersModel();

                while (dr.Read())
                {
                    int aid = Convert.ToInt32(dr["ProgramAnswerId"]);
                    int pid = Convert.ToInt32(dr["ProgramId"]);
                    string panswer = dr["ProgramAnswer"].ToString();
                    string des = dr["Description"].ToString();
                    string pname = dr["ProgramName"].ToString();

                    p.ProgramAnswerId = aid;
                    p.ProgramId = pid;
                    p.ProgramAnswer = panswer;
                    p.ProgramName = pname;
                    p.Description = des;

                }
                return p;
            }
        }

        public List<ProgramAnswersModel> GetProgramWiseAnswers(string program)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchProgramAnswersByProgram", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProgramName", program);
                dr = cmd.ExecuteReader();

                List<ProgramAnswersModel> lst = new List<ProgramAnswersModel>();

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ProgramAnswerId"]);
                    int pid = Convert.ToInt32(dr["ProgramId"]);
                    string panswer = dr["ProgramAnswer"].ToString();
                    string des = dr["Description"].ToString();
                    string pname = dr["ProgramName"].ToString();

                    ProgramAnswersModel p = new ProgramAnswersModel()
                    {
                        ProgramAnswerId = id,
                        ProgramId = pid,
                        ProgramAnswer = panswer,
                        Description = des,
                        ProgramName = pname
                    };
                    lst.Add(p);
                }
                return lst;
            }
        }
    }
}
