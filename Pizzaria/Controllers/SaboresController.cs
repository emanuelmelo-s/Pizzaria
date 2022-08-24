using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Data;
using Pizzaria.Models;
using Pizzaria.Models.ViewModel.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Controllers
{
    public class SaboresController : Controller
    {

        private PizzariaDbContext _context;



        public SaboresController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Tamanhos);

        public IActionResult Criar()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostSaborDTO tamanhoDto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Tamanho tamanho = new Tamanho
                (
                    tamanhoDto.Nome
                );

            _context.Add(tamanho);
            _context.SaveChanges();

            



            return RedirectToAction(nameof(Index));
        }


        public IActionResult Atualizar(int id)
        {
            var result = _context.Tamanhos
                .Include(x => x.Pizzas)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            var response = new Post()
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
