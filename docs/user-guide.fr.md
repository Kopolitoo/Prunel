# Guide d'utilisation de Prunel

*English version: [user-guide.md](user-guide.md).*

Prunel permet d'utiliser un ordinateur Windows uniquement avec les yeux : on déplace un cercle
au regard, on fixe un endroit, puis on choisit quoi y faire (clic, double clic, glisser-déposer,
défilement, écriture…). Ce guide explique comment s'en servir. Pour l'installer, voir le
[README](../README.fr.md).

## Avant de commencer

- Installer le pilote officiel de l'eyetracker (Tobii) depuis le site du fabricant, et faire
  sa calibration.
- **Mettre en pause** le logiciel de commande au regard fourni avec l'eyetracker (TD Control)
  pendant l'utilisation de Prunel, pour que les deux logiciels ne déplacent pas la souris en
  même temps.
- Prunel a besoin de trois fichiers de l'eyetracker (voir
  [Fichiers de l'eyetracker](#fichiers-de-leyetracker)). Sur la plupart des ordinateurs, il les
  trouve tout seul.

## Se déplacer et fixer

- **Mode mouvement** (au démarrage) : un cercle blanc suit le regard. Il se déplace en douceur,
  sans sauts.
- **Regard fixe** : quand le regard reste immobile un instant, le cercle se fige, le curseur de
  la souris va sur le point fixé, et une **icône d'options** apparaît à côté du cercle.
  - Regarder l'icône d'options : le **choix d'action** s'ouvre.
  - Regarder ailleurs : le cercle suit de nouveau le regard.
  - Avec « Clic direct » activé (onglet « Fixation » des paramètres), garder le regard dans le
    cercle fait un clic gauche.
- **Suivi souris** (menu) : le curseur suit le cercle en permanence, et pas seulement quand le
  regard est fixé.

## Choix d'action

Un écran noir montre la zone fixée, agrandie deux fois, avec une croix sur le point exact.
Il apparaît et disparaît en fondu (un cinquième de seconde), pour que l'écran ne flashe pas.
Autour, des icônes : clic gauche, double clic, clic droit, loupe, glisser-déposer (bouton
gauche, bouton droit, android), défilement. On regarde une icône jusqu'à ce que son anneau soit
plein pour l'utiliser. Au bord gauche : **Ctrl**, **Maj**, **Alt** (un regard les active, le bord
devient vert ; ils sont appuyés pendant l'action suivante). En haut : **Copier**, **Couper**,
**Coller**. À droite : **Retour**. Après une action, on revient au mode mouvement.

Les boutons **Retour** à droite de l'écran (choix d'action, loupe, glisser-déposer,
défilement, paramètres, listes, et « Fermer » du clavier) sont faciles à viser : regarder le
bord de l'écran à leur hauteur, ou un peu au-delà, marche aussi.

Le double clic fait une courte pause entre ses deux clics (pour fermer deux onglets du
navigateur à la suite, par exemple). Pour la changer : Paramètres, onglet « Délais », « Pause du
double clic » (en millisecondes, 200 par défaut ; 0 = aucune pause).

Les icônes peuvent être déplacées ou retirées : Paramètres, onglet « Icônes », « Configurer les
icônes ».

## Loupe

Pour les petites cibles (une case à cocher, un petit lien). La zone est agrandie quatre fois ;
on fixe le point exact sur l'image, et le choix d'action s'ouvre sur ce point. « Loupe avant
l'action » (onglet « Loupe, glisser ») ouvre la loupe à chaque fois, avant le choix d'action.
« Délai de la loupe » (même onglet) règle le temps de fixation sur l'image, séparément du délai
de fixation du mode mouvement.

## Glisser-déposer

On choisit un glisser-déposer dans le choix d'action, puis on regarde la destination : une ligne
pointillée suit le regard. On fixe la destination, on l'affine dans la loupe, et l'élément est
déplacé. « Android » ajoute une pause avant le déplacement (pour les applications tactiles). Le
bouton retour au bord droit annule.

## Défilement

On choisit « Défilement » dans le choix d'action. Le cercle reste en place. On regarde au-dessus,
en dessous, à gauche ou à droite pour faire défiler dans ce sens : plus le regard est loin, plus
c'est rapide. Regarder dans le cercle arrête. « Retour » (bord droit) termine le défilement ; regarder hors de l'écran à droite pendant une
seconde aussi.

## Menu

Regarder **sous l'écran** une demi-seconde : la barre de menu s'ouvre en bas : une rangée de
boutons bien espacés, sans fond derrière eux. Elle s'ouvre depuis le mode mouvement, la pause et
le mode jeu. Boutons :

- **Paramètres** : voir plus bas.
- **Jeu** : mode jeu (voir plus bas).
- **Clavier** : le clavier du regard.
- **Pause** / **Reprendre** : plus rien ne suit le regard, jusqu'à ce qu'on rouvre le menu et
  qu'on choisisse « Reprendre ».

**Pause automatique** : quand l'eyetracker ne voit plus les yeux pendant 10 secondes (yeux
fermés, tête tournée, absence), Prunel se met en pause tout seul, pour que rien ne soit cliqué au
retour du regard. Un bouton rond « Reprendre » apparaît alors au centre de l'écran : le regarder
ramène au mode mouvement (le « Reprendre » du menu et Échap marchent aussi). Elle ne démarre que
depuis le mode mouvement et le regard fixe, jamais pendant le choix d'action, la loupe, le
défilement, le jeu ou les paramètres. Regarder sous l'écran ou à côté ne compte pas. Pour changer
le délai ou la désactiver : Paramètres, catégorie « Regard », onglet « Pause ».
- **Suivi souris** : activé / désactivé (bord vert quand il est activé).
- **Quitter Prunel** : demande d'abord « Oui » ou « Non ».

Regarder hors de la barre pendant une seconde la ferme.

## Clavier du regard

Menu, « Clavier ». Le clavier occupe la moitié basse de l'écran. On regarde une touche : elle
s'allume, clignote en vert et écrit. Au-dessus du clavier, le cercle fonctionne comme d'habitude
(on peut cliquer ailleurs). Cinq pages : lettres, accents, chiffres et ponctuation, symboles et
navigation, F1 à F12. Une touche de page regardée par erreur (« 123.! », « [(/ », « F1..F12 »…)
s'annule en gardant le regard au même endroit : après deux fois le délai des touches, le clavier
revient à la page d'avant.

On peut aussi placer « Clavier » sur la couronne du choix d'action (configuration des icônes).
On fixe le champ où l'on veut écrire, puis on choisit « Clavier » : Prunel clique d'abord à cet
endroit, le champ prend le focus et le curseur de texte se place là où l'on regardait.

- **Prédiction de mots** : les trois cases du haut proposent des mots. En regarder une l'écrit
  avec une espace. Un mot inconnu apparaît avec un « + » orangé : le regarder l'ajoute au
  dictionnaire personnel. Les nombres ne sont jamais ajoutés (un mot mêlant lettres et chiffres,
  comme « mp3 », peut l'être). Les mots courts passent devant, sauf si un mot plus long est beaucoup
  plus courant ou souvent utilisé. Prunel apprend aussi quel mot suit souvent un autre.
- **Barre du clavier** (regarder sous l'écran quand le clavier est ouvert) : monter ou descendre
  le clavier, changer sa taille, rendre son fond transparent (« Transparence » : 0, 25, 50 ou
  75 %, les lettres restent nettes), le mettre en pause, afficher la « Zone de saisie » (un aperçu de
  ce qui est écrit), choisir la « Disposition du clavier » (AZERTY, QWERTY…).
- **Mes mots** (Paramètres, onglet « Général ») : les mots ajoutés ; en regarder un le retire.
- On ferme le clavier par le bouton au-dessus de lui, par la barre du clavier, ou avec Échap.

## Mode jeu

Menu, « Jeu ». Rien n'est dessiné ; le curseur suit directement le regard (prévu pour des jeux
comme Mindball Play). Les clics se font avec un contacteur externe ou la reconnaissance vocale.
On ouvre le menu et on choisit « Quitter le jeu » pour revenir. L'onglet « Jeu » des paramètres
contient les options du jeu.

## Paramètres

Menu, « Paramètres ». Une page noire en plein écran, avec quatre catégories à gauche :
**Regard**, **Actions**, **Interface**, **Système**. Chaque réglage a « − » et « + » (garder le
regard dessus répète) ou un interrupteur oui / non. Les changements s'appliquent tout de suite et
sont enregistrés.

- **Défaut** (en haut à droite) : remet les valeurs d'origine de l'onglet affiché.
- **Retour** (bord droit) ou Échap : retour au mode mouvement.
- L'aidant peut aussi utiliser la souris et le clavier ici : cliquer sur une valeur pour la
  taper.
- **Langue** (onglet « Général ») : anglais ou français. Le dictionnaire de prédiction suit
  cette langue.
- **Profils** (onglet « Profils ») : enregistrer les réglages actuels sous un nom, et les
  recharger plus tard au regard (par exemple un profil « Matin » et un profil « Soir »).
- Onglet **Sons** : deux options oui / non, toutes deux désactivées au départ. **Son des
  touches** : un petit « tic » à chaque touche du clavier du regard. **Son des boutons** : un petit
  son pour tous les autres boutons (menu, choix d'action, icône d'options, paramètres). Le son
  suit le volume de Windows.
- Onglet **Outils** : **Calibration** (lance la calibration de l'eyetracker) et **Diagnostic**
  (montre le regard et le curseur en direct, et la stabilité du regard en haut, au milieu et en
  bas de l'écran ; rien n'est enregistré).
- Onglet **À propos** : la version installée, et deux boutons qui ouvrent le **site web** de
  Prunel et ce **guide d'utilisation** dans le navigateur (Prunel revient alors au mode
  mouvement).

## Pour l'aidant

- **Échap** sur le clavier physique ramène Prunel au mode mouvement, d'où que l'on soit. Échap
  dit à un logiciel de reconnaissance vocale (comme Dragon) aussi. Pendant le défilement ou
  quand le clavier au regard est ouvert, Prunel garde Échap pour lui : les autres logiciels ne
  le reçoivent pas.
- Lancer Prunel une deuxième fois ne fait rien : il tourne déjà.
- « Démarrer avec Windows » (onglet « Général ») lance Prunel automatiquement.

## Fichiers sur l'ordinateur

| Quoi | Où |
| --- | --- |
| Réglages | `%APPDATA%\Prunel\settings.json` (s'ouvre avec le Bloc-notes) |
| Dictionnaire personnel | `%APPDATA%\Prunel\personal-dictionary.json` |
| Profils | `Documents\Prunel\Profiles` |
| Journal | `%LOCALAPPDATA%\Prunel\prunel.log` |

Si l'on vient de GazeBar (l'ancien nom de Prunel, jusqu'à la version 0.2.0) : au premier
lancement, Prunel renomme les dossiers `GazeBar` ci-dessus en `Prunel`, donc les réglages, le
dictionnaire personnel et les profils sont gardés (l'ancien journal y reste sous le nom
`gazebar.log`). L'installateur met Prunel dans `C:\Program Files\Prunel`, déplace un dossier
`Eyetracker` depuis `C:\Program Files\GazeBar` et supprime l'ancien programme et son raccourci
du menu Démarrer.

Prunel n'enregistre jamais l'endroit où l'on regarde (la licence de l'eyetracker l'interdit) et
n'écrit jamais dans le journal ce que l'on tape. Le journal est court par défaut ; « Journal
détaillé » (onglet « Général ») note davantage, pour chercher un problème.

## Fichiers de l'eyetracker

Le regard est lu par trois fichiers de Tobii (`Tobii.Interaction.Net.dll`,
`Tobii.Interaction.Model.dll`, `Tobii.EyeX.Client.dll`). Ils appartiennent à Tobii AB, donc
Prunel ne les contient pas. Prunel les cherche dans le dossier `Eyetracker` à côté de
`Prunel.exe`, puis dans les dossiers des logiciels Tobii, puis dans le cache NuGet de Visual
Studio.

Si la fenêtre Diagnostic indique qu'ils manquent, il faut les récupérer soi-même, en acceptant la
licence de Tobii :

1. Sur nuget.org, ouvrir le paquet `Tobii.Interaction`, version 0.7.3, et cliquer sur « Download
   package ».
2. Renommer le fichier `.nupkg` téléchargé en `.zip` et l'ouvrir.
3. Copier les deux DLL de `lib\net45` et celle de `build\x86` dans le dossier `Eyetracker` à côté
   de `Prunel.exe` (le créer si besoin).

## Installation complète (accès à l'interface)

Prunel s'installe avec son installateur (`Prunel-x.y.z-setup.exe`). Grâce à lui, le cercle du
regard reste au-dessus du menu Démarrer, de la recherche et des notifications, et les clics et
les touches atteignent les fenêtres lancées « en administrateur ». Windows ne donne cet « accès à
l'interface » qu'à un programme signé et installé dans `C:\Program Files` : l'installateur
s'occupe des deux. C'est pourquoi Prunel n'existe qu'avec un installateur : une commande au
regard qui n'atteint ni le menu Démarrer, ni les notifications, ni les pop-ups du système de
Windows aurait peu d'intérêt. (Jusqu'à la version 0.3.1, un zip simple sans ces deux possibilités était
aussi proposé.)

Pour installer ou mettre à jour :

1. Sur la page [Releases](https://github.com/Kopolitoo/Prunel/releases), télécharger
   `Prunel-x.y.z-setup.exe` (sous « Assets ») et double-cliquer dessus. Garder un autre moyen
   de cliquer (voix, souris, TD Control) pour cette étape : Prunel se ferme pendant
   l'installation.
2. L'installateur n'est pas signé par un éditeur connu : Windows peut afficher « Windows a
   protégé votre ordinateur » ; cliquer sur « Informations complémentaires », puis « Exécuter
   quand même ». Windows demande ensuite « Voulez-vous autoriser cette application à apporter des
   modifications à votre appareil ? » : répondre « Oui ».
3. L'installateur parle la langue de Windows. « Créer une icône sur le Bureau » est coché
   (décocher si vous n'en voulez pas). Cliquer sur « Installer », puis « Terminer » avec
   « Exécuter Prunel » coché : Prunel démarre depuis `C:\Program Files\Prunel`.

Pour épingler Prunel à la barre des tâches : Windows ne laisse pas un programme s'épingler
lui-même, mais quelques regards suffisent. Ouvrir le menu Démarrer, trouver Prunel (taper ou dire
« Prunel » dans la recherche), faire un clic droit dessus (choix d'action), puis « Épingler à la
barre des tâches ».

Ce que fait l'installateur : il copie Prunel dans `C:\Program Files\Prunel`, crée un
certificat sur cet ordinateur, le fait approuver par l'ordinateur, signe `Prunel.exe` avec, puis
supprime la clé privée du certificat (plus rien ne pourra jamais être signé avec). Un nouveau
certificat est créé à chaque mise à jour. Il ajoute aussi Prunel au menu Démarrer, au Bureau si la case est
cochée, et à « Paramètres > Applications » de Windows. Vos réglages sont gardés. Si « Démarrer avec Windows »
est activé, Prunel met lui-même à jour son lancement au démarrage. Il met aussi à jour une copie
installée par l'ancien script `Install.cmd`.

Pour vérifier : le journal (`%LOCALAPPDATA%\Prunel\prunel.log`) dit « UI access: yes » au
démarrage.

Pour la retirer : « Paramètres > Applications > Applications installées » de Windows, Prunel,
« Désinstaller ». Il supprime le dossier du programme, le raccourci et le certificat. Vos réglages
sont gardés.

Si les fichiers de l'eyetracker ont dû être copiés à la main (voir
[Fichiers de l'eyetracker](#fichiers-de-leyetracker)), mettre le dossier `Eyetracker` dans
`C:\Program Files\Prunel` (Windows demande les droits d'administrateur). Les mises à jour le
gardent.

## Limites connues

- Un seul écran.
- Lancé depuis Visual Studio (développeurs), Prunel n'a pas l'accès à l'interface : une
  fenêtre lancée « en tant qu'administrateur » ignore ses clics et ses touches, et le menu
  Démarrer de Windows peut cacher le cercle.
  L'[installateur](#installation-complète-accès-à-linterface) n'a aucune de ces deux limites.
- Testé uniquement avec le Tobii Dynavox PCEye 5.
- Le mode jeu avec déplacement relatif de la souris n'a pas encore été testé.
- Le dictionnaire personnel est commun à toutes les langues.
- Avec le PCEye 5, la reconnaissance du visage de Windows Hello utilise la caméra de
  l'eyetracker : pendant qu'elle reconnaît le visage, le cercle reste figé. Validez plutôt avec le
  code PIN (Paramètres Windows › Comptes › Options de connexion), ou utilisez une autre caméra
  compatible Windows Hello.
- Le cercle peut sautiller, surtout en bas de l'écran, quand les yeux sont plissés (fatigue) ou
  qu'une lumière forte éblouit la caméra de l'eyetracker (le soleil de côté, par exemple). C'est
  une limite de l'eyetracker : son propre logiciel (TD Control) fait pareil. Ce qui aide : fermer
  un rideau ou un store ; refaire la calibration dans ces conditions (Paramètres, onglet
  « Outils ») ; enregistrer un [profil de réglages](#paramètres) plus calme (par exemple
  « Fatigue »), à charger à ces moments-là : un **Lissage** plus petit (onglet « Regard », par
  exemple 0.05) et un **Rayon de fixation** plus grand (onglet « Fixation », par exemple 2.6). Le
  cercle est plus calme, mais suit le regard un peu plus tard. Pour comparer, la fenêtre
  **Diagnostic** (onglet « Outils ») montre la stabilité du regard en haut, au milieu et en bas de
  l'écran.
