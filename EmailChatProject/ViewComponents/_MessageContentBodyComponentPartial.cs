using Microsoft.AspNetCore.Mvc;

namespace EmailChatProject.ViewComponents
{
    public class _MessageContentBodyComponentPartial: ViewComponent
    {
      public IViewComponentResult Invoke ()
        {


            return View();
        }
    }
}
