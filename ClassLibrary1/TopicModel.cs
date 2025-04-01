using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModel
{
    public class TopicModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int CourseId { get; set; }
        public int CourseTopicId { get; set; }
        public string CourseTopicName { get; set; }
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public string VideoUrl { get; set; }
        public string PPT { get; set; }
    }
}
