using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeWorkOutApi.NetCore.Models;
using homeWorkOutApi.Net6._0.Data;

namespace homeWorkOutApi.Net6._0.Ctrl
{
    public class ExerciseModelsController : Controller
    {
        private readonly homeWorkOutApiNet6_0Context _context;

        public ExerciseModelsController(homeWorkOutApiNet6_0Context context)
        {
            _context = context;
        }

        // GET: ExerciseModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseModel.ToListAsync());
        }

        // GET: ExerciseModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseModel = await _context.ExerciseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseModel == null)
            {
                return NotFound();
            }

            return View(exerciseModel);
        }

        // GET: ExerciseModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Tag,NumberOfTimes,IsChoosen,Seconds,ImageSource")] ExerciseModel exerciseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseModel);
        }

        // GET: ExerciseModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseModel = await _context.ExerciseModel.FindAsync(id);
            if (exerciseModel == null)
            {
                return NotFound();
            }
            return View(exerciseModel);
        }

        // POST: ExerciseModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Tag,NumberOfTimes,IsChoosen,Seconds,ImageSource")] ExerciseModel exerciseModel)
        {
            if (id != exerciseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseModelExists(exerciseModel.Id))
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
            return View(exerciseModel);
        }

        // GET: ExerciseModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseModel = await _context.ExerciseModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseModel == null)
            {
                return NotFound();
            }

            return View(exerciseModel);
        }

        // POST: ExerciseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseModel = await _context.ExerciseModel.FindAsync(id);
            _context.ExerciseModel.Remove(exerciseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseModelExists(int id)
        {
            return _context.ExerciseModel.Any(e => e.Id == id);
        }
    }
}
