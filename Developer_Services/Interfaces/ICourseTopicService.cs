using ClassLibrary1;
using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface ICourseTopicService
    {
      public  void AddCourseTopic(CourseTopicsModel c);
      public  void UpdateCourseTopic(CourseTopicsModel c);
        void DeleteCourseTopic(int id);
        CourseTopicsModel GetCourseTopicById(int id);
        List<CourseTopicsModel> GetAllCourseTopics();
        List<CourseTopicsModel> GetCourseWiseCourseTopic(string course);
        List<CourseTopicsModel> GetTopicWiseCourseTopics(string topic);
    }
}
