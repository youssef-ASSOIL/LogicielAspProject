# ASP.NET-Projet
## Système de gestion des ressources matérielles
### Description du projet client
On veut réaliser une application web pour gérer les ressources matérielles des
différents départements de la faculté. Les départements, le responsable des
ressources et le service de maintenance sont connectés en réseau et toutes les
communications seront faites à travers le logiciel de gestion des ressources. Les accès
aux services du logiciel doivent être sécurisés pour tous les utilisateurs.
Le responsable des ressources affecte un code unique (numéro d’inventaire avec
code à barres à chaque ressource lors de sa livraison). La date de livraison, la durée
de garantie et le fournisseur de chaque ressource seront archivés. S’il s’agit d’un
nouveau fournisseur on doit alors garder le nom de la société, le lieu l’adresse email
et le gérant. Les ressources peuvent être des ordinateurs ou des imprimantes. Un
ordinateur est caractérisé par la marque, la CPU, la RAM, le disque dur et l’écran, une
imprimante par sa vitesse d’impression, sa résolution et sa marque. Le responsable
doit pouvoir lister les ressources livrées et affecter une ou plusieurs ressources à un
département donné. Chaque ressource sera affectée à une personne précise de ce
département ou bien à l’ensemble du département. Une personne du département
est soit un enseignant ou un administratif, pour le premier on doit mentionner le
laboratoire auquel il appartient. Le responsable peut aussi lister toutes les ressources
disponibles (celles qui sont affectées ou non), modifier ou supprimer une ressource
ou bien modifier une affectation ou la supprimer.

Les personnes des départements peuvent signaler au service de maintenance toute
panne qui survient dans leurs ressources. Ils doivent mentionner une explication de la
panne, sa date d’apparition, sa fréquence (rare, fréquente ou permanente) et sonordre logiciel (défaut du système ou d’un logiciel utilitaire) ou matériel. Les pannes
des imprimantes sont uniquement d’ordre matériel. Le service de maintenance peut
alors intervenir auprès du département, son constat sera envoyé automatiquement
au responsable qui décidera alors de réparer ou changer la ressource et doit aussi
envoyer par email le constat au fournisseur de cette ressource lorsqu’il s’agit d’un
défaut matériel et que la durée de garantie n’est pas encore terminée.

Nous voulons aussi gérer les appels d’offre pour l’acquisition des ressources.
Lorsqu’un département a un budget pour l’achat de ressources, le chef du
département doit demander aux enseignants du département d’envoyer leurs
besoins en termes de matériels. Après généralement une réunion du département, le
chef envoie ces besoins au responsable pour qu’il fasse un appel d’offre. Cependant,
le responsable rassemble généralement les besoins de tous les départements avant
de constituer un appel d’offre complet.
Le chef du département peut consulter à tout moment, le suivi de sa demande. Après
les soumissions des fournisseurs, le responsable reçoit l’offre du fournisseur le moins
disant et attend la livraison. Le responsable doit pouvoir éliminer les mauvais
fournisseurs, ceux qui n’ont pas respecté scrupuleusement leurs engagements
auparavant, et leur envoyer le motif de leur élimination.
Le chef du département doit aussi envoyer au responsable, la liste prévue des
affectations des ressources en fonction des personnes du département.
TAF
L’étude sera menée par un groupe d’étudiants (4 étudiants) et devrait donner lieu à
plusieurs phases un rap du cycle de vie de logiciel et un rapport bien organisé.
