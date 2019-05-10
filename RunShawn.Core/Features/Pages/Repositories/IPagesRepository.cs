using RunShawn.Core.Base;
using RunShawn.Core.Features.Pages.Model;
using System.Collections.Generic;

namespace RunShawn.Core.Features.Pages.Repositories
{
    public interface IPagesRepository : IBaseRepository<Page>
    {
        List<PageListView> GetAllInfo(bool onlyActive = false);
        Page GetBySlug(string urlSlug);
        int GetCountByUrlSlug(string urlSlug, long? exceptId = null);
    }
}