using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class EFCrudController : Controller
    {
        private readonly MeuDbContext _context;

        public EFCrudController(MeuDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Rafael",
                DataNascimento = DateTime.Now,
                Email = "rafael@hotmail.com"
            };

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            var aluno2 = _context.Alunos.Find(aluno.Id);
            var aluno3 = _context.Alunos.FirstOrDefault(a => a.Email == "rafael@hotmail.com");
            var aluno4 = _context.Alunos.Where(a => a.Nome == "Rafael");

            aluno.Nome = "João";

            _context.Alunos.Update(aluno);
            _context.SaveChanges();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return View("_Layout");
        }
    }
}