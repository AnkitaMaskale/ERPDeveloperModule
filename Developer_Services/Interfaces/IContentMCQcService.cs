using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface IContentMCQc
    {
        public void AddContentMCQ(ContentMCQsModel mcq);
        public void UpdateContentMCQs(ContentMCQsModel mcq);
        public void DeleteContentMCQs(int id);
        public ContentMCQsModel GetContentMcqById(int id);
        public List<ContentMCQsModel> GetAllContentMcq();
        List<ContentMCQsModel> GetContentWiseMCQ(string content);
    }
}
