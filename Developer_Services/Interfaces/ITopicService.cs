using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface ITopicService
    {
        void AddTopic(TopicModel t);
        void UpdateTopic(TopicModel t);
        void DeleteTopic(int id);
        TopicModel GetTopicById(int id);
        List<TopicModel> GetAllTopics();

    }
}
