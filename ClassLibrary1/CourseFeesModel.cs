using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModel
{
  public class CourseFeesModel
    {
        public int FeeId { get; set; }
        public int CourseId { get; set; }
        public float Fees { get; set; }
        public float GST { get; set; }
        public DateTime FeesChangeDate { get; set; }
        public string FeeMode { get; set; }
        public string CourseName { get; set; }

    }
}
