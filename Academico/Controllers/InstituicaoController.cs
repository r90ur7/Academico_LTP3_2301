using Academico.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
