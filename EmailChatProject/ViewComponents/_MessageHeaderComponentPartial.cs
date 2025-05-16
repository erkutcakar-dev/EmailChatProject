using Microsoft.AspNetCore.Mvc;

namespace EmailChatProject.ViewComponents
{
    public class _MessageHeaderComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke ()
        {
            return View();
        }
    }
}
