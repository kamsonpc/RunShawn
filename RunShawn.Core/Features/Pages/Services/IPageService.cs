using RunShawn.Core.Features.Pages.Model;

namespace RunShawn.Core.Features.Pages.Services
{
    public interface IPagesService
    {
        Page Create(Page page, string userId);
        Page Update(Page page, string userId);

    }
}