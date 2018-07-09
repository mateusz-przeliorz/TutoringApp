using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;

namespace Tutoring.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> GetAsync(Guid id);
        Task<IEnumerable<Course>> GetAllAsync();
        Task CreateAsync(Course course);
        Task UpdateAsync(Course course);
    }
}
