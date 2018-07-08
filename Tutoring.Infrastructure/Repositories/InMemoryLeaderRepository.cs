using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutoring.Core.Domain;
using Tutoring.Core.Repositories;

namespace Tutoring.Infrastructure.Repositories
{
    class InMemoryLeaderRepository : ILeaderRepository
    {
        private static ISet<Leader> _leaders = new HashSet<Leader>();

        public void Add(Leader driver)
        {
            _leaders.Add(driver);
        }

        public Leader Get(Guid userId)
        {   
           return _leaders.SingleOrDefault(x => x.UserId == userId);
        }
        public IEnumerable<Leader> GetAll()
        {
            return _leaders;
        }

        public void Update(Leader driver)
        {

        }
    }
}
