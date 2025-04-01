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
    class TechnologyService : ITechnologyService
    {
        SqlCommand cmd;
        SqlDataReader dr;
        public void AddTechnology(TechnologyModel t)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString())) {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteRestoreTechnologies", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@TechnologyName", t.TechnologyName);
                int cnt = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateTechnology(TechnologyModel t)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteRestoreTechnologies", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@TechnologyId", t.TechnologyId);
                cmd.Parameters.AddWithValue("@TechnologyName", t.TechnologyName);
                int cnt = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteTechnology(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteRestoreTechnologies", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@TechnologyId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                int cnt = cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<TechnologyModel> GetAllTechnologies()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllTechnologis", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TechnologyId", 0);
              dr = cmd.ExecuteReader();
                List<TechnologyModel> lst = new List<TechnologyModel>();

                while (dr.Read()) 
                {
                    int id = Convert.ToInt32(dr["TechnologyId"]);
                    string tname = dr["TechnologyName"].ToString();

                    TechnologyModel t = new TechnologyModel()
                    { 
                        TechnologyId = id,
                        TechnologyName = tname
                    };
                    lst.Add(t);
                }
                return lst;
            }
        }

        public TechnologyModel GetTechnologyById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllTechnologis", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TechnologyId", id);
                dr = cmd.ExecuteReader();

                TechnologyModel t = new TechnologyModel();

                while (dr.Read())
                {
                    int tid = Convert.ToInt32(dr["TechnologyId"]);
                    string tname = dr["TechnologyName"].ToString();

                    t.TechnologyId = tid;
                    t.TechnologyName = tname;
                }
                return t;
            }
        }
    }
}
