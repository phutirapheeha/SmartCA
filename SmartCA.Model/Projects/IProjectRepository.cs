using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.Model.Projects
{
    public interface IProjectRepository : IRepository<Project>
    {
        IList<Project> FindBy(IList<MarketSegment> seqments, bool completed);
        Project Findby(string projectNumber);
        IList<MarketSegment> FindAllMarketSegments();
        void SaveContact(ProjectContact contact);
    }
}
