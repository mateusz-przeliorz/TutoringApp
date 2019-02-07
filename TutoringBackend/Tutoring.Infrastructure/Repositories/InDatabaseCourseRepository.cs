using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    public class InDatabaseCourseRepository : ICourseRepository
    {
        public Task<Course> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
