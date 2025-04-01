using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface IContentsService
    {
        void AddContent(ContentsModel t);
        void UpdateContent(ContentsModel t);
        void DeleteContent(int id);
        ContentsModel GetContentById(int id);
        List<ContentsModel> GetAllContents();
       ContentsModel GetTopicWiseContent(string topic);
    }
}
