using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface ITechnologyService
    {
        public void AddTechnology(TechnologyModel t);
        public void UpdateTechnology(TechnologyModel t);
        public void DeleteTechnology(int id);
        public TechnologyModel GetTechnologyById(int id);
        public List<TechnologyModel> GetAllTechnologies();
    
    }
}
