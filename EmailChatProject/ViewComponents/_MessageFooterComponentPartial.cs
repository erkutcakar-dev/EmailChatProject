using Microsoft.AspNetCore.Mvc;

namespace EmailChatProject.ViewComponents
{
    public class _MessageFooterComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke ()
        {

            return View();
        }
    }
}
