using Microsoft.AspNetCore.Mvc;

namespace EmailChatProject.ViewComponents
{
    public class _MessageScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke ()
        {

            return View();
        }
    }
}
