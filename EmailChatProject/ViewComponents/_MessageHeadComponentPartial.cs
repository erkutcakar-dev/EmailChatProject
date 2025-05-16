using Microsoft.AspNetCore.Mvc;

namespace EmailChatProject.ViewComponents
{
    public class _MessageHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke ()
        {
            return View();

        }
    }
}
