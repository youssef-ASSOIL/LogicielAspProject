using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicielAspProject.BuisnessLayer
{
    public class PanneManager
    {

        public PanneManager() : IPanneManager
    {
		  private List<Panne> pannes ;
          private SqlManagerPanne pannemanager;
          public PanneManager(){
               pannes = new List<Panne>();
          }
          public bool AddPanne(Panne panne)
         {
            try
            {
                 pannes.Add(panne);
                 pannemanager.AddPanne(panne);
                 return true; 
                 
            }
            catch (System.Exception)
            {
                return false;
            }
           return false;
        }

        public bool deletePanne(int id)
        {
            Panne panne = pannes.FirstOrDefault(p => p.PanneId == id);
            if (panne != null)
            {
                pannes.Remove(panne);
                pannemanager.DeletePanne(id);
                return true;
            }
            return false;
        }

        public Panne getPanne(int id)
        {
            return pannemanager.GetPanne(id);
        }
        public bool updatePanne(Panne panne)
        {
            List<Panne> existingPanne = pannes.FirstOrDefault(p => p.PanneId == panne.PanneId);
            if (existingPanne != null)
            {
                return pannemanager.UpdatePanne(panne);
                return true;
            }
            return false;
        }

        public List<Panne> listPannesByFrequence(Frequence frequence)
        {
            return pannemanager.ListPannesByFrequence(frequence)
        }

        public bool resolvePanne(int id)
        {
            Panne panne = pannes.FirstOrDefault(p => p.PanneId == id);
            if (panne != null)
            {
                // Assuming resolving a panne simply means to set a property, such as IsResolved
                panne.IsResolved = true;
                pannemanager.ResolvePanne(id);
                return true;
            }
            return false;
        }

         public List<Panne> ListAllPannes()
        {
            return pannemanager.ListAllPannes();
        }

        public List<Panne> ListPannesByType(TypePanne type)
        {
            return pannemanager.ListPannesByType(type);
        }
    }
}
}