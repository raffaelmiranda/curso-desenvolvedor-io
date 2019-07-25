using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MinhaDemoMvc.Models;

namespace MinhaDemoMvc.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        //Sobrecarga de rotas
        [Route("")]
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id:int}/{categoria:guid}")] //Passando parametros com constraint
        public IActionResult Index(int id, Guid categoria)
        {
            var filme = new Filme
            {
                Titulo = "oi",
                DataLancamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000
            };

            //return RedirectToAction("Privacy", filme);
            return View();
        }

        [Route("sobre")]
        public IActionResult About(string id, string categoria)
        {
            ViewData["Message"] = "Your application description page.";

            
            return View();
        }

        [Route("retorna-json")]
        public IActionResult RetornaJson()
        {
            return Json("{'nome':'Rafael'}");
        }

        [Route("retorna-content")]
        public IActionResult RetornaContent()
        {
            return Content("Qualquer coisa");
        }

        [Route("retorna-arquivo")]
        public IActionResult RetornaArquivo()
        {
            var fileBytes = System.IO.File.ReadAllBytes(@"c:\arquivo.txt");
            var fileName = "arquivo.txt";
            return File(fileBytes,System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [Route("contato")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("privacidade")]
        [Route("politica-privacidade")]
        public IActionResult Privacy(Filme filme)
        {
            if (ModelState.IsValid)
            {

            }

            foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
