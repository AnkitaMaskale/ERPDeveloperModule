using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Services.Interfaces
{
    interface ICourseService
    {
        void AddCourse(CoursesModel c);
        void UpdateCourse(CoursesModel c);
        void DeleteCourse(int id);
        CoursesModel GetCourseById(int id);
        List<CoursesModel> GetAllCourses();
        List<CoursesModel> GetTechnologyWiseCourses(string technology);
    }
}
