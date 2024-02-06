using LogicielAspProject.BuisnessLayer;
using LogicielAspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogicielAspProject.Controllers
{
    public class EnseignantController : Controller
    {
        IEnseignantManager manager = new EnseignantManager();

        // GET: Enseignant
        public ActionResult Index()
        {
            return View();
        }

        // GET: Enseignant/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Enseignant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enseignant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,Enseignant enseignant)
        {
            try
            {
                Compte compte = new Compte
                {
                    Username = "test1",
                    Password = "test1",
                    Role = "Enseignant",
                    idCompte = 30
                };
                // TODO: Add insert logic here
              //  manager.AddEnseignant(enseignant, Session["compte"] as Compte);
                manager.AddEnseignant(enseignant, compte);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enseignant/Edit/5
        public ActionResult Edit(int id)
        {
            Enseignant enseignant= manager.GetEnseignantById(id);
            return View(enseignant);
        }

        // POST: Enseignant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,Enseignant enseignant)
        {
            try
            {
                // TODO: Add update logic here
                manager.UpdateEnseignant(id, enseignant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enseignant/Delete/5
        public ActionResult Delete(int id)
        {
            Enseignant enseignant = manager.GetEnseignantById(id);
            return View(enseignant);
        }

        // POST: Enseignant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                manager.DeleteEnseignant(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
