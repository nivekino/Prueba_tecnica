using Microsoft.AspNetCore.Mvc;

namespace Prueba_tecnica_01.Extensions
{
    public enum notificationType
    {
        Success,
        Error,
        Info
    }

    public class BaseController : Controller
    {
        public void basicNotification(string msj, notificationType type , string title="")
        {
            TempData["notification"] = $"Swal.fire( '{title}', '{msj}', '{type.ToString().ToLower()}')";
        }
    }
}
