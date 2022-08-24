using Microsoft.AspNetCore.Mvc;
using Pizzaria.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Controllers
{
    public class TamanhosController : Controller
    {
        private TamanhosController _context;



        public TamanhosController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Tamanho);

        public IActionResult Criar()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostSaborDTO saborDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Sabor sabor = new Sabor
                (
                    saborDto.Nome,
                    saborDto.FotoURL


                );

            _context.Add(sabor);
            _context.SaveChanges();





            return RedirectToAction(nameof(Index));
        }


        public IActionResult Atualizar(int id)
        {
            var result = _context.Sabores
                .Include(x => x.PizzasSabores).ThenInclude(x => x.Sabor)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            var response = new PostSaborDTO()
            {
                Nome = result.Nome,
                FotoURL = result.FotoURL

            };


            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostSaborDTO saborDto)
        {
            var result = _context.Sabores.FirstOrDefault(x => x.Id == id);



            result.AlterarDados
                (
                    saborDto.Nome,
                    saborDto.FotoURL

                );

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Detalhes), result);
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Sabores

                .Include(ps => ps.PizzasSabores).ThenInclude(s => s.PizzaId)
                .FirstOrDefault(f => f.Id == id);

            return View(result);
        }



        public IActionResult Deletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
