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
    class InterviewQuestionService : IInterviewQuestionsService
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public void AddInterviewQuestion(InterviewQuestionsModel m)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString())) {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteInterviewQuestions", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "INSERT");
                cmd.Parameters.AddWithValue("@QuestionName", m.QuestionName);
                cmd.Parameters.AddWithValue("@ContentId", m.ContentId);
                cmd.Parameters.AddWithValue("@CorrectAnswer", m.CorrectAnswer);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public void UpdateInterviewQuestion(InterviewQuestionsModel m)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString())) 
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteInterviewQuestions", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "UPDATE");
                cmd.Parameters.AddWithValue("@QuestionId", m.QuestionId);
                cmd.Parameters.AddWithValue("@QuestionName", m.QuestionName);
                cmd.Parameters.AddWithValue("@ContentId", m.ContentId);
                cmd.Parameters.AddWithValue("@CorrectAnswer", m.CorrectAnswer);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteInterviewQuestion(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_InsertUpdateDeleteInterviewQuestions", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", "DELETE");
                cmd.Parameters.AddWithValue("@QuestionId", id);
                cmd.Parameters.AddWithValue("@Flag", 1);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<InterviewQuestionsModel> GetAllInterviewQuestions()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllcontentInterviewQuestions", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QuestionId", 0);
                dr = cmd.ExecuteReader();

                List<InterviewQuestionsModel> lst = new List<InterviewQuestionsModel>();

                while (dr.Read()) {
                    int id = Convert.ToInt32(dr["QuestionId"]);
                    string question = dr["QuestionName"].ToString();
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string ans = dr["CorrectAnswer"].ToString();
                    string cname = dr["ContentName"].ToString();

                    InterviewQuestionsModel m = new InterviewQuestionsModel()
                    {
                        QuestionId = id,
                        QuestionName = question,
                        ContentId = cid,
                        CorrectAnswer = ans,
                        ContentName = cname
                    };
                    lst.Add(m);
                }
                return lst;
            }
        }

        public InterviewQuestionsModel GetInterviewQuestionById(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchAllcontentInterviewQuestions", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@QuestionId", id);
                dr = cmd.ExecuteReader();

                InterviewQuestionsModel m = new InterviewQuestionsModel();
                if (dr.Read())
                {
                    int qid = Convert.ToInt32(dr["QuestionId"]);
                    string question = dr["QuestionName"].ToString();
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string ans = dr["CorrectAnswer"].ToString();
                    string cname = dr["ContentName"].ToString();

                    m.QuestionId = qid;
                    m.QuestionName = question;
                    m.ContentId = cid;
                    m.CorrectAnswer = ans;
                    m.ContentName = cname;
                }
                return m;
            }
        }

        public List<InterviewQuestionsModel> GetContentWiseInterviewQuestions(string content)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                cmd = new SqlCommand("usp_FetchInterviewQuestionsByContentName", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContentName", content);
                dr = cmd.ExecuteReader();

                List<InterviewQuestionsModel> lst = new List<InterviewQuestionsModel>();

                while (dr.Read())
                {
                    int qid = Convert.ToInt32(dr["QuestionId"]);
                    string question = dr["QuestionName"].ToString();
                    int cid = Convert.ToInt32(dr["ContentId"]);
                    string ans = dr["CorrectAnswer"].ToString();
                    string cname = dr["ContentName"].ToString();

                    InterviewQuestionsModel m = new InterviewQuestionsModel()
                    {
                        QuestionId = qid,
                        QuestionName = question,
                        ContentId = cid,
                        CorrectAnswer = ans,
                        ContentName = cname
                    };
                    lst.Add(m);
                }
                return lst;
            }
        }
    }
}
