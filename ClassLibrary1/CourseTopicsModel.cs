using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModel
{
    class CourseTopicsModel
    {
        public int CourseTopicId { get; set; }
        public string CourseTopicName { get; set; }
        public int TopicId { get; set; }
        public int CourseId { get; set; }
        public string TopicName { get; set; }
        public string CourseName { get; set; }
    }
}
