using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMvcMysql.Data;
using WebMvcMysql.Models;

namespace WebMvcMysql.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly Contexto _context;

        public CaminhaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Caminhao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Caminhao.ToListAsync());
        }

        // GET: Caminhao/Details/ID
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao.FirstOrDefaultAsync(m => m.CaminhaoId == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // GET: Caminhao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caminhao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaminhaoId,CaminhaoModelo," +
            "CaminhaoAnoFabricacao,CaminhaoAnoModelo")] Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caminhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        // GET: Caminhao/Edit/ID
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao.FindAsync(id);
            if (caminhao == null)
            {
                return NotFound();
            }
            return View(caminhao);
        }

        // POST: Caminhao/Edit/ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaminhaoId,CaminhaoModelo," +
            "CaminhaoAnoFabricacao,CaminhaoAnoModelo")] Caminhao caminhao)
        {
            if (id != caminhao.CaminhaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.CaminhaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        // GET: Caminhao/Delete/ID
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhao
                .FirstOrDefaultAsync(m => m.CaminhaoId == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // POST: Caminhao/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caminhao = await _context.Caminhao.FindAsync(id);
            _context.Caminhao.Remove(caminhao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoExists(int id)
        {
            return _context.Caminhao.Any(e => e.CaminhaoId == id);
        }
    }
}
