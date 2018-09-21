
using System;

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
            SetField(field);
            SetLevel(level);
            SetSubject(subject);
        }

       

        public static CourseDetails Create(string field, string level, string subject)
        {
            return new CourseDetails(field, level, subject);
        }

        private void SetField(string field)
        {
            if(string.IsNullOrWhiteSpace(field))
            {
                throw new Exception("Please provide valid data.");
            }

            if (field.Length > 50)
            {
                throw new Exception("Description length can not be greater than 50 marks.");
            }

            if (Field == field)
            {
                return;
            }

            Field = field;
        }

        private void SetLevel(string level)
        {
            if (string.IsNullOrWhiteSpace(level))
            {
                throw new Exception("Please provide valid data.");
            }

            if (level.Length > 50)
            {
                throw new Exception("Description length can not be greater than 50 marks.");
            }

            if (Level == level)
            {
                return;
            }

            Level = level;
        }

        private void SetSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new Exception("Please provide valid data.");
            }

            if (subject.Length > 50)
            {
                throw new Exception("Description length can not be greater than 50 marks.");
            }

            if (Subject == subject)
            {
                return;
            }

            Subject = subject;
        }
    }
}