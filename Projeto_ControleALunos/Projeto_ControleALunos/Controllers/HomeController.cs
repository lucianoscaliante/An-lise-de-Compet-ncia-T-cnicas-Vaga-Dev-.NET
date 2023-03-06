using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_ControleALunos.Models;
using Projeto_ControleALunos.Repositorios.AlunosRepositorio;
using Projeto_ControleALunos.Repositorios.DisciplinasRepositorio;
using Projeto_ControleALunos.Repositorios.RepositorioMatricula;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace Projeto_ControleALunos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDisciplinasRepositorios _disciplinasRepositorio;
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IAlunosRepositorio _alunosRepositorio;
        public HomeController(IDisciplinasRepositorios disciplinasRepositorios, IMatriculaRepositorio matriculaRepositorio, IAlunosRepositorio alunosRepositorio)
        {
            _disciplinasRepositorio = disciplinasRepositorios;
            _matriculaRepositorio = matriculaRepositorio;
            _alunosRepositorio = alunosRepositorio;
        }

        public IActionResult Index()
        {   

            return View();
        }

        public IActionResult MatricularALuno()
        {
            var disciplinas = _disciplinasRepositorio.ListarTodasDisciplinas();
            var viewModel = new MatriculasModel { Disciplinas = disciplinas };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SalvarAlunoMatricula(AlunosModel aluno)
        {
            AlunosModel alunos = _alunosRepositorio.ListarAlunoPorId(aluno.Id);
            if (alunos != aluno)
            {
                _alunosRepositorio.AdicionarAluno(aluno);
            }
            else
            {
                aluno = alunos;
            }
            MatriculasModel matricula = new MatriculasModel
            {
                AlunosId = aluno.Id,
                
            };

            _matriculaRepositorio.AdicionarMatricula(matricula);
            return RedirectToAction("Index");
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
