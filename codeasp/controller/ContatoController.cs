using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAplication.Controllers
{
    public class ContatoControllerdeprecated : Controller
    {


        //Trazendo Contexto do models
        private readonly Contexto _contexto;

        //Iniciando classe contexto "Cria/inicia db ou table"
        public ContatoControllerdeprecated(Contexto contexto)
        {
            _contexto = contexto;
        }



        //Trazendo informações em list
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Contato.ToListAsync());
        }


        /*
         * AÇÃO DE CRIAR CONTATO
         * 
         */
        [HttpGet]
        public IActionResult CriarContato()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarContato(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(contato);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(contato);
        }


        /*
         * AÇÃO DE EDITAR CONTATO
         * 
         */

        [HttpGet]
        public IActionResult AtualizarContato(int? id)
        {
            if (id != null)
            {
                Contato contato = _contexto.Contato.Find(id);
                return View(contato);
            }
            else return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> AtualizarContato(int? id, Contato contato)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    _contexto.Update(contato);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                else return View(contato);
            }
            else return View(contato);
        }




        /*
         * AÇÃO DE EXCLUIR CONTATO
         * 
         */

        [HttpGet]
        public IActionResult ExcluirContato(int? id)
        {
            if (id != null)
            {
                Contato contato = _contexto.Contato.Find(id);
                return View(contato);
            }
            else return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> ExcluirContato(int? id, Contato contato)
        {
            if (id != null)
            {
                _contexto.Remove(contato);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();
        }


    }
}
