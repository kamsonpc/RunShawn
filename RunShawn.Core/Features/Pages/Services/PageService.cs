using RunShawn.Core.Features.Pages.Model;
using RunShawn.Core.Features.Pages.Repositories;
using RunShawn.Core.Helpers.Strings;

namespace RunShawn.Core.Features.Pages.Services
{
    public class PageService : IPagesService
    {
        #region Dependencies

        private readonly IPagesRepository _pagesRepository;
        public PageService(IPagesRepository pagesRepository)
        {
            _pagesRepository = pagesRepository;
        }
        #endregion

        #region Create()

        public Page Create(Page page, string userId)
        {
            page.UrlSlug = GenerateUrlSlug(page.Title);
            return _pagesRepository.Create(page, userId);
        }

        #endregion Create()

        #region Update()
        public Page Update(Page page, string userId)
        {
            page.UrlSlug = GenerateUrlSlug(page.Title, page.Id);
            return _pagesRepository.Update(page, userId);
        }
        #endregion

        #region GenerateUrlSlug()

        private string GenerateUrlSlug(string title, long? pageId = null)
        {
            string urlSlug = title.ToUrlSlug();

            var pagesCount = _pagesRepository.GetCountByUrlSlug(urlSlug, pageId);
            if (pagesCount > 0)
            {
                return $"{urlSlug}-{pagesCount + 1}";
            }
            return urlSlug;
        }

        #endregion GenerateUrlSlug()
    }
}
