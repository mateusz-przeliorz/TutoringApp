using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoring.Core.Domain
{
    public class Details
    {
        public string Title { get; protected set; }
        public int Size { get; protected set; }
        public string Field { get; protected set; }
        public string Level { get; protected set; }
        public string Description { get; protected set; }
        public string City { get; protected set; }

        protected Details()
        {
        }

        protected Details(string title, int size, string field, string level, string description, string city)
        {
            Title = title;
            Size = size;
            Field = field;
            Level = level;
            Description = description;
            City = city;
        }

        public static Details Create(string title, int size, string field, string level, string description, string city)
        {
            return new Details(title, size, field, level, description, city);
        }
    }
}