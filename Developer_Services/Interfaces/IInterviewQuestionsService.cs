using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface IInterviewQuestionsService
    {
        public void AddInterviewQuestion(InterviewQuestionsModel m);
        public void UpdateInterviewQuestion(InterviewQuestionsModel m);
        public void DeleteInterviewQuestion(int id);
        public InterviewQuestionsModel GetInterviewQuestionById(int id);
        public List<InterviewQuestionsModel> GetAllInterviewQuestions();
        List<InterviewQuestionsModel> GetContentWiseInterviewQuestions( string content);
    }
}
