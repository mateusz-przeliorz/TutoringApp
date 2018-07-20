using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface ICourseService : IService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> GetAsync(Guid id);
        Task CreateAsync(Guid courseId, string name, int size, string city, string description,
            string field, string level, string subject);
        Task SetCourseDetailsAsync(Guid courseId, string field, string level, string subject);
    }
}
