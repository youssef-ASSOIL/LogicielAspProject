using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using LogicielAspProject.BuisnessLayer;
using LogicielAspProject.Models;


namespace LogicielAspProject.Controllers
{
    [Authorize]
    public class FournisseurController : Controller
    {

        IFournisseurManager manager = new FournisseurManager();

        // GET: Fournisseur
        public ActionResult Index()
        {
            return View();
        }

        // GET: Fournisseur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fournisseur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,Fournisseur fournisseur)
        {
            try
            {
                // TODO: Add insert logic here
                manager.AddFournisseur(fournisseur, Session["account"] as Compte);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            Fournisseur fournisseur = manager.GetFournisseurById(id);
            return View(fournisseur);
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,Fournisseur fournisseur)
        {
            try
            {
                // TODO: Add update logic here
                manager.UpdateFournisseur(id, fournisseur);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            Fournisseur fournisseur = manager.GetFournisseurById(id);
            return View(fournisseur);
        }

        // POST: Fournisseur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                manager.DeleteFournisseur(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
