using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InMemoryCourseRepository : ICourseRepository
    {
        private static ISet<Course> _courses = new HashSet<Course>();
        

        public async Task CreateAsync(Course course)
        {
            _courses.Add(course);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await Task.FromResult(_courses);
        }

        public async Task UpdateAsync(Course course)
        {
            await Task.CompletedTask;
        }

        public async Task<Course> GetAsync(Guid id)
        {
            return await Task.FromResult(_courses.SingleOrDefault(x => x.Id == id));
        }
    }
}
