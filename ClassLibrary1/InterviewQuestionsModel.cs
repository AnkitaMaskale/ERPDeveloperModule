using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModel
{
   public  class InterviewQuestionsModel
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public int ContentId { get; set; }
        public string CorrectAnswer{ get; set; }

        public string ContentName { get; set; }
    }
}
