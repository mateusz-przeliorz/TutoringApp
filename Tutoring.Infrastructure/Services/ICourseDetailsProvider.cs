using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Core.Domain;
using Tutoring.Infrastructure.Dtos;

namespace Tutoring.Infrastructure.Services
{
    public interface ICourseDetailsProvider : IService
    {
        Task<IEnumerable<CourseDetailsDto>> BrowseAsync();
        Task<CourseDetails> GetAsync(string subject, string field, string level);
    }
}
