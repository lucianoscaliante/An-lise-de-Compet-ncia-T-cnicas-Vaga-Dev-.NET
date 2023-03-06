using Microsoft.AspNetCore.Mvc;
using Projeto_ControleALunos.Models;
using Projeto_ControleALunos.Repositorios.DisciplinasRepositorio;
using System.Collections.Generic;

namespace Projeto_ControleALunos.Controllers
{
    public class DisciplinasController : Controller
    {
        private readonly IDisciplinasRepositorios _disciplinasRepositorio;
        public DisciplinasController(IDisciplinasRepositorios disciplinasRepositorios) 
        {
            _disciplinasRepositorio = disciplinasRepositorios;
        }
        public IActionResult Index()
        {
            List<DisciplinasModel> disciplinas = _disciplinasRepositorio.ListarTodasDisciplinas();
            if (disciplinas == null)
            {
                return NotFound("Não foi possivel encontrar as disciplinas");
            }
            return View(disciplinas);
        }

        public IActionResult CadastrarDisciplinas()
        {
            return View();
        }

        public IActionResult EditarDisciplina(int id)
        {
            DisciplinasModel disciplina = _disciplinasRepositorio.ListarDisciplinaPorId(id);
            return View(disciplina);
            
        }
        public IActionResult ExcluirDisciplina(int id)
        {
            DisciplinasModel disciplina = _disciplinasRepositorio.ListarDisciplinaPorId(id);
            return View(disciplina);
        }
        public IActionResult Excluir(int id)
        {
            _disciplinasRepositorio.Excluir(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CadastrarDisciplinas(DisciplinasModel disciplina)
        {
            if (ModelState.IsValid)
            {
                _disciplinasRepositorio.AdicionarDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }

        [HttpPost]
        public IActionResult EditarDisciplina(DisciplinasModel disciplina)
        {
            if (ModelState.IsValid)
            {
                _disciplinasRepositorio.AtualizarDisciplina(disciplina);
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }
    }
}
