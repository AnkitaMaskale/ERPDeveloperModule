using ClassLibrary1;
using DeveloperModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface ICourseFeesService
    {
        void AddCourseFee(CourseFeesModel c);
        void UpdateCourseFee(CourseFeesModel c);
        void DeleteCourseFee(int id);
        CourseFeesModel GetCourseFeeById(int id);
        List<CourseFeesModel> GetAllCourseFees();
        CourseFeesModel GetCourseWiseFee(string course);
    }
}
