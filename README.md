# Projet 2CP : HistoESI
Titre du projet : Réalisation d’un outil de gestion de l’historique des anciens étudiants de l’ESI

# Présentation générale du problème :

Le service de scolarité de l’ESI est chargé de gérer le cursus des étudiants durant leur parcours universitaire (depuis
l’inscription jusqu’à l’obtention du diplôme d’ingéniorat). Le service de scolarité reçoit des demandes fréquentes de la
part des anciens étudiants de l’école et de la tutelle pour l’obtention de données sur l’historique individuel ou par
promotion. Ces données sont souvent difficiles à obtenir et demandent beaucoup de temps de la part du personnel du
service de scolarité qui ont d’autres tâches en parallèle. C’est une tâche récurrente et fastidieuse d’où le besoin
d’automatiser l’accès, la visualisation et l’impression de l’historique des étudiants sous forme de relevés de notes, de
classement et de statistiques.
Actuellement, une population des étudiants, de 1989 au 2011 (environ 10000 inscrits), leur historique (cursus) est géré
avec un outil très basique (BDASE) ce qui engendre certaines difficultés. Parmi ces difficultés, nous citons :
- La clé primaire identifiant chaque étudiant de façon unique n’est pas prise en considération
- Risque d’avoir des doubles
- Perte de temps dans la recherche d’un étudiant
- Absence de l’historique concernant le cursus des étudiants
- Vérification manuelle des documents imprimés (comme les relevés des notes)
- Difficulté d’obtenir des statistiques générales
- etc.
Ce projet consiste donc à la réalisation d’un outil qui permettra de gérer cette population des étudiants d’une manière
complètement automatisée. Il permettra de migrer vers des fichiers normalisés sous Access et de requêter ces fichiers
pour l’obtention de l’historique par étudiant, par module, par promotion, etc.

# Objectifs auxquels répond notre solution HistoESI :

Notre solution **HistoESI** répond à tous les besoin exprimés par le service de scolarité qui sont les suivants :
- Effectuer le mapping des fichiers des étudiants vers un schéma d’une base de données bien défini implémentée
dans le SGBD Microsoft Access
- Recherche d’un étudiant par : matricule, nom, etc.
- Afficher l’historique d’un étudiant par année, par module, etc.
- Impression des états : relevé de notes, certificat de scolarité, PV de délibération
- Classement de fin de cursus des étudiants par promotion.
- Statistiques selon plusieurs critères :
  * Statistiques générales : nombre d’inscrits au cours des années selon le sexe, distribution des étudiants inscrits en fonction de leurs séries du BAC, taux de réussite et d'échec d'un niveau au cours des années
  * Statistiques d'une promotion : distribution des moyennes générales des étudiants, les taux d’échec et de réussite par sexe.
  * Statistiques d'une matière : les taux d’échec et de réussite et la moyennes des moyennes des étudiants dans une matière au cours des années.
