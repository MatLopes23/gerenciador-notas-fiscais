using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Gerenciador_de_Notas_Fiscais.Controllers
{
    public class NotaFiscalController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/ 
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }

}
