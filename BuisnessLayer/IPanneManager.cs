using System;

namespace LogicielAspProject.BuisnessLayer
{
    internal interface IPanneManager{
        bool addPanne(Panne panne);
        bool deletePanne(int id);
        Panne getPanne(int id);
        bool updatePanne(Panne panne);
        List<Panne> listAllPannes();
        List<Panne> listPannesByType(TypePanne type);
        List<Panne> listPannesByFrequence(Frequence frequence);
        bool resolvePanne(int id);
    }
}