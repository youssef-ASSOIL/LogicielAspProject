using LogicielAspProject.BuisnessLayer;
using LogicielAspProject.BusinessLayer;
using LogicielAspProject.Models;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;

namespace LogicielAspProject.Controllers
{
    [Authorize(Roles = "Responsable")]
    public class CompteController : Controller
    {
        private IAccountManager accountManager = new AccountManager();
        private IFournisseurManager fournisseurManager = new FournisseurManager();


        // GET: Compte
        public ActionResult Index()
        {
            var comptes = accountManager.GetAllComptes();
            return View(comptes);
        }

        // GET: Compte/Details/5
        public ActionResult Details(int id)
        {
            var compte = accountManager.GetCompte(id);
            return View(compte);
        }

        // GET: Compte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compte/Create
        [HttpPost]
        public ActionResult Create(Compte compte)
        {
            try
            {
                accountManager.AddCompte(compte);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compte/Edit/5
        public ActionResult Edit(int id)
        {
            var compte = accountManager.GetCompte(id);
            return View(compte);
        }

        // POST: Compte/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Compte compte)
        {
            try
            {
                accountManager.UpdateCompte(compte);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compte/Delete/5
        public ActionResult Delete(int id)
        {
            var compte = accountManager.GetCompte(id);
            return View(compte);
        }

        // POST: Compte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                accountManager.DeleteCompte(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: Compte/SignUp
        [HttpPost]
        [AllowAnonymous]

        public ActionResult SignUp(CompteFournisseurViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    model.Fournisseur.compte = model.Compte;

                    fournisseurManager.AddFournisseur(model.Fournisseur,model.Compte);

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }

            catch
            {
                return View();
            }

        }

        // GET: Compte/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        // POST: Compte/Login
        [HttpPost]
        public ActionResult Login(FormCollection collection, Compte compte)
        {
            try
            {
                if (accountManager.ValidateCredentials(compte.Username, compte.Password))
                {
                    FormsAuthentication.SetAuthCookie(compte.Username, false);
                    if (accountManager.IsUserInRole("Responsable"))
                        return RedirectToAction("About");
                    else
                        return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.erreur = "Authentification failed!";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}