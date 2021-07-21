using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListinTelefonico.Data;
using ListinTelefonico.Models;

namespace ListinTelefonico.Controllers
{
    public class ContactosController : Controller
    {
        private readonly ListinTelefonicoContext _context;


        public ContactosController(ListinTelefonicoContext context)
        {
            _context = context;
        }

        // GET: Contactos
        public async Task<IActionResult> Index()
        {


            return View(await _context.Contacto.ToListAsync());
        }

        // GET: Contactos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactos = await _context.Contacto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactos == null)
            {
                return NotFound();
            }

            return View(contactos);
        }

        // GET: Contactos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,nombre,telefono")] Contactos contactos)
        {



            if (ModelState.IsValid)
            {
                var lcontactos = await _context.Contacto
                .FirstOrDefaultAsync(m => m.telefono == contactos.telefono);

                if (lcontactos == null)
                {

                    _context.Add(contactos);
                    await _context.SaveChangesAsync();
                    ViewData["result"] = "";
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    ViewData["result"] = "El teléfono ya existe";



                }
            }
            return View(contactos);
        }

        // GET: Contactos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactos = await _context.Contacto.FindAsync(id);
            if (contactos == null)
            {
                return NotFound();
            }
            return View(contactos);
        }

        // POST: Contactos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,nombre,telefono")] Contactos contactos)
        {

            if (id != contactos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var lcontactos = await _context.Contacto
                .FirstOrDefaultAsync(m => m.telefono == contactos.telefono);

                if (lcontactos == null)
                {

                    _context.Update(contactos);
                    await _context.SaveChangesAsync();
                    ViewData["result"] = "";
                    return RedirectToAction(nameof(Index));

                }
                else
                {

                    ViewData["result"] = "El teléfono ya existe";



                }
                                


                if (!ContactosExists(contactos.ID))
                {
                    return NotFound();
                }


                return RedirectToAction(nameof(Index));
            }
            return View(contactos);
        }

        // GET: Contactos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactos = await _context.Contacto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactos == null)
            {
                return NotFound();
            }

            return View(contactos);
        }

        // POST: Contactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactos = await _context.Contacto.FindAsync(id);
            _context.Contacto.Remove(contactos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactosExists(int id)
        {
            return _context.Contacto.Any(e => e.ID == id);
        }
    }
}
