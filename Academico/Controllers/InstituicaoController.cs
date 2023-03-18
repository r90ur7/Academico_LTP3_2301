using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Academico.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao
            {
                Id=1,
                Nome = "Hogwarts",
                Endereco = "Escócia"
            },
            new Instituicao
            {
                Id=2,
                Nome = "Mansão X",
                Endereco = "Nova Iorque"
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }
        public IActionResult Create()
        { return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao)
        {
            instituicao.Id = instituicoes.Select(i => i.Id).Max() + 1;
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long  id)
        {
            return View(instituicoes.Where(i => i.Id == id).First());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult  Edit(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i =>i.Id == instituicao.Id).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

    }
}
