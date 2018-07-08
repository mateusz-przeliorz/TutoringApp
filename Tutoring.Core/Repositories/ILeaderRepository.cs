using System;
using System.Collections.Generic;
using System.Text;
using Tutoring.Core.Domain;

namespace Tutoring.Core.Repositories
{
    public interface ILeaderRepository
    {
        Leader Get(Guid userId);
        IEnumerable<Leader> GetAll();
        void Add(Leader leader);
        void Update(Leader leader);
    }
}
