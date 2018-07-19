using System.Threading.Tasks;

namespace Tutoring.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}
