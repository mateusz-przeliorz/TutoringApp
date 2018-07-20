
namespace Tutoring.Core.Domain
{
    public class CourseDetails
    {
        
        public string Field { get; protected set; }
        public string Subject { get; set; }
        public string Level { get; protected set; }
        

        protected CourseDetails()
        {
        }

        protected CourseDetails(string field, string level, string subject)
        {
            Field = field;
            Level = level;
            Subject = subject;
        }

        public static CourseDetails Create(string field, string level, string subject)
        {
            return new CourseDetails(field, level, subject);
        }
    }
}