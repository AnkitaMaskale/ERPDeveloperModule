using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface IProgramService
    {
        public void AddProgram(ProgramsModel p);
        public void UpdateProgram(ProgramsModel p);
        public void DeleteProgram(int id);
        public ProgramsModel GetProgramById(int id);
        public List<ProgramsModel> GetAllPrograms();
        ProgramsModel GetContentWiseProgram(string content);
    }
}
