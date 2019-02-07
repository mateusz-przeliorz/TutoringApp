using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;

namespace Tutoring.Core.Repositories
{
    public interface ICourseDetailsRepository : IRepository
    {
        Task<Course> GetAsync(Guid id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
    }
}
