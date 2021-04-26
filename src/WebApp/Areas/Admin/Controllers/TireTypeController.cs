using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]/[action]")]
    public class TireTypeController : Controller
    {
        private ITireTypeService TireTypeService { get; }

        public TireTypeController(ITireTypeService tireTypeService)
        {
            TireTypeService = tireTypeService;
        }
        // GET: TireTypeController
        public ActionResult Index()
        {
            TireTypeFilter filter = new TireTypeFilter();
            var items = TireTypeService.Get(filter);
            return View(items);
        }

        // GET: TireTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TireTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TireTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TireTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TireTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TireTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TireTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
