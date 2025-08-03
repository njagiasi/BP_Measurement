using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BPMeasurementApp.Entities;
using BPMeasurementApp.Models;

namespace BPMeasurementApp.Controllers
{
    public class BPMeasurementController : Controller
    {

        public BPMeasurementController(BPMeasurementDbContext BPMDbContext)
        {
            _bpmDbContext = BPMDbContext;
        }

        public IActionResult List()
        {
            var allBPMData = _bpmDbContext.BPMeasurements.Include(p => p.Position).OrderBy(p => p.Position.Name).ToList();
            return View(allBPMData);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            BPMeasurementViewModel bpmeasurementViewModel = new BPMeasurementViewModel()
            {
                Positions = _bpmDbContext.Positions.OrderBy(p => p.Name).ToList(),
                ActiveBPData = new BPMeasurement()
            };

            return View(bpmeasurementViewModel);
        }

        [HttpPost()]
        public IActionResult Create(BPMeasurementViewModel bpmeasurementViewModel)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _bpmDbContext.BPMeasurements.Add(bpmeasurementViewModel.ActiveBPData);
                _bpmDbContext.SaveChanges();
                return RedirectToAction("List", "BPMeasurement");
            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view again:
                bpmeasurementViewModel.Positions = _bpmDbContext.Positions.OrderBy(p => p.Name).ToList();
                return View(bpmeasurementViewModel);
            }
        }

        [HttpGet()]
        public IActionResult Edit(int id)
        {
            BPMeasurementViewModel bpmeasurementViewModel = new BPMeasurementViewModel()
            {
                Positions = _bpmDbContext.Positions.OrderBy(p => p.Name).ToList(),
                ActiveBPData = _bpmDbContext.BPMeasurements.Find(id)
            };

            return View(bpmeasurementViewModel);
        }

        [HttpPost()]
        public IActionResult Edit(BPMeasurementViewModel bpmeasurementViewModel)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to update the existing movie in the DB:
                _bpmDbContext.BPMeasurements.Update(bpmeasurementViewModel.ActiveBPData);
                _bpmDbContext.SaveChanges();
                return RedirectToAction("List", "BPMeasurement");
            }
            else
            {
                bpmeasurementViewModel.Positions = _bpmDbContext.Positions.OrderBy(g => g.Name).ToList();
                return View(bpmeasurementViewModel);
            }
        }
        [HttpGet()]
        public IActionResult Delete(int id)
        {
            // Find/retrieve/select the movie to edit and then pass it to the view:
            var bpm = _bpmDbContext.BPMeasurements.Find(id);
            return View(bpm);
        }

        [HttpPost()]
        public IActionResult Delete(BPMeasurement bpm)
        {
            // Simply remove the movie and then redirect back to the all movies view:
            _bpmDbContext.BPMeasurements.Remove(bpm);
            _bpmDbContext.SaveChanges();
            return RedirectToAction("List", "BPMeasurement");
        }

        public IActionResult Information()
        {
            return View();
        }

        private BPMeasurementDbContext _bpmDbContext;
    }
}
