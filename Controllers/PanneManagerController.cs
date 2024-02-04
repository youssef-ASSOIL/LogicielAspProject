using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogicielAspProject.Controllers
{
    public class PanneManagerController : Controller
    {
        PanneManager panneManager;
        // GET: Create
        public ActionResult Create()
        {
            return View(new Panne());
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Panne panne)
        {
            if (ModelState.IsValid)
            {
                // Add save logic here
                return RedirectToAction("Index");
            }

            return View(panne);
        }
        // GET: PanneManager
        public ActionResult Index()
        {
            List<Panne> pannes = panneManager.ListAllPannes();

            return View(pannes);
        }

        // GET: PanneManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

        // POST: PanneManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PanneManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PanneManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PanneManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PanneManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
