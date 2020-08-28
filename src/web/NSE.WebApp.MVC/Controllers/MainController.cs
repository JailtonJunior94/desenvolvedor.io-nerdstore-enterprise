using System.Linq;
using NSE.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult response)
        {
            if (response != null && response.Errors.Mensagens.Any()) return true;
            return false;
        }
    }
}
