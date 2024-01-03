1. **Identification et Authentification :**
   - Utilisation d'une double authentification (nom d'utilisateur/mot de passe et éventuellement un code à usage unique) pour renforcer la sécurité.
   - Gestion des sessions pour garantir une connexion sécurisée et un accès approprié.

2. **Gestion des Ressources Matérielles :**
   - Possibilité d'ajouter des détails spécifiques aux ressources, tels que la version du logiciel installé sur un ordinateur.
   - Intégration d'un module de suivi des mouvements de stocks pour suivre les déplacements des ressources entre les départements.

3. **Affectation des Ressources :**
   - Attribution d'une date d'affectation à chaque ressource, permettant de suivre son historique.
   - Gestion des retours de ressources lorsqu'un enseignant ou un administratif n'a plus besoin de la ressource affectée.

4. **Maintenance :**
   - Création d'un tableau de bord pour le service de maintenance, affichant les pannes signalées, leur état actuel et les interventions effectuées.
   - Intégration d'une base de connaissances pour résoudre les problèmes fréquents sans intervention du service de maintenance.

5. **Gestion des Appels d'Offre :**
   - Suivi automatisé des budgets alloués à chaque département pour l'achat de ressources.
   - Archivage des appels d'offres précédents avec les détails des fournisseurs sélectionnés et des contrats conclus.

6. **Suivi et Rapports :**
   - Fonctionnalité de création de rapports personnalisés en fonction des besoins spécifiques de chaque département.
   - Notification proactive en cas de délais ou de problèmes potentiels liés aux demandes d'achat ou aux pannes.

7. **Collaboration et Communication :**
   - Intégration d'un système de messagerie interne pour faciliter la communication entre les départements, le service de maintenance et le responsable des ressources.
   - Historique des communications pour référence future.

8. **Sécurité et Confidentialité :**
   - Gestion fine des autorisations pour chaque type d'utilisateur afin de garantir l'accès uniquement aux informations nécessaires.
   - Journal d'audit enregistrant les activités sensibles pour la conformité et l'analyse de la sécurité.

------------------------------------------------------------------------------------------------

### Acteurs Principaux :

1. **Responsable des Ressources :**
   - Affecte les codes uniques aux ressources.
   - Gère l'affectation des ressources aux départements.
   - Supervise les appels d'offres et la sélection des fournisseurs.
   - Reçoit les rapports de maintenance et prend des décisions en conséquence.

2. **Chef de Département :**
   - Soumet les besoins en ressources pour son département.
   - Consulte le suivi de sa demande.
   - Participe à la sélection des fournisseurs lors des appels d'offres.

3. **Service de Maintenance :**
   - Reçoit les rapports de pannes des départements.
   - Intervient pour résoudre les problèmes signalés.
   - Communique avec le responsable des ressources sur les interventions nécessaires.

4. **Fournisseur :**
   - Soumet des offres en réponse aux appels d'offres.
   - Livre les ressources après la sélection de l'offre.

5. **Enseignant/Administratif :**
   - Reçoit les ressources affectées par le responsable des ressources.
   - Signale les pannes et communique avec le service de maintenance.
-------------------------------------------------------------------------------------------

# Modèle de Données

# 1. Utilisateur:
- ID
- Nom
- Prénom
- Adresse Email
- Mot de passe
- Rôle

# 2. Ressource:
- Code unique
- Date de livraison
- Durée de garantie
- Fournisseur
  - Méthodes : Ajouter, Modifier, Supprimer

  ## 2.1. Ordinateur (sous-classe de Ressource):
  - Marque
  - CPU
  - RAM
  - Disque Dur
  - Écran

  ## 2.2. Imprimante (sous-classe de Ressource):
  - Vitesse d'impression
  - Résolution

# 3. Fournisseur:
- Nom de la société
- Lieu
- Adresse Email
- Gérant
  - Méthodes : Ajouter, Modifier, Supprimer

# 4. Département:
- Nom du département

# 5. Personne:
- Nom
- Prénom
- Type (Enseignant/Administratif)

# 6. Affectation:
- Ressource
- Personne
- Département

# 7. Panne:
- Explication
- Date d'apparition
- Fréquence
- Ordre (logiciel/matériel)

# 8. Appel d'Offre:
- Chef de Département
- Liste des besoins
- Fournisseur sélectionné
- État

# 9. Notification:
- Destinataire
- Contenu
- Date

# 10. Cycle de Vie du Logiciel:
- Phase
- Description
- Date de début
- Date de fin
- Responsable

# 11. Journal d'Audit:
- Utilisateur
- Action
- Date
- Heure


---------------------------------------------------------------------------------------------------------
# Diagramme de Processus Métier

![Diagramme de Processus Métier]

## Explication des Activités :

1. **Demande de Ressources :**
   - Le chef de département soumet les besoins en ressources pour son département.

2. **Collecte des Besoins :**
   - Le responsable des ressources collecte les besoins de tous les départements.

3. **Appel d'Offre :**
   - Le responsable des ressources lance un appel d'offres en utilisant les besoins collectés.

4. **Soumissions des Fournisseurs :**
   - Les fournisseurs soumettent leurs offres en réponse à l'appel d'offres.

5. **Sélection du Fournisseur :**
   - Le responsable des ressources évalue les soumissions et sélectionne le fournisseur le moins disant.

6. **Livraison des Ressources :**
   - Le fournisseur livre les ressources conformément à l'offre sélectionnée.

7. **Affectation des Ressources :**
   - Le responsable des ressources affecte les ressources aux départements et aux utilisateurs spécifiques.

8. **Signalement de Panne :**
   - Les utilisateurs signalent les pannes au service de maintenance.

9. **Intervention de Maintenance :**
   - Le service de maintenance intervient pour résoudre les problèmes signalés.

10. **Évaluation de Fournisseur :**
    - Le responsable des ressources évalue la performance du fournisseur après la livraison.

11. **Communication :**
    - Les communications sont gérées entre les différents acteurs (responsable des ressources, service de maintenance, fournisseur, utilisateurs).

12. **Génération de Rapports :**
    - Le système génère des rapports périodiques sur l'état des ressources, les pannes, les évaluations des fournisseurs, etc.
