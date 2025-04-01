using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface IProgramAnswersServices
    {
        public void AddProgramAnswer(ProgramAnswersModel p);
        public void UpdateProgramAnswer(ProgramAnswersModel p);
        public void DeleteProgramAnswer(int id);
        public ProgramAnswersModel GetProgramAnswersById(int id);
        public List<ProgramAnswersModel> GetAllProgramAnswers();
        List<ProgramAnswersModel> GetProgramWiseAnswers(string program);
    }
}
